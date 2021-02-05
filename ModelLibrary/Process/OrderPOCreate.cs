﻿/********************************************************
 * Project Name   : VAdvantage
 * Class Name     : OrderPOCreate
 * Purpose        : Generate PO from Sales Order
 * Class Used     : ProcessEngine.SvrProcess
 * Chronological    Development
 * Raghunandan     03-Nov-2009
  ******************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VAdvantage.Classes;
using VAdvantage.Common;
using VAdvantage.Process;
using VAdvantage.Model;
using VAdvantage.DataBase;
using VAdvantage.SqlExec;
using VAdvantage.Utility;
//using System.Windows.Forms;

using System.Data;
using System.Data.SqlClient;
using VAdvantage.Logging;

using VAdvantage.ProcessEngine;
namespace VAdvantage.Process
{
    public class OrderPOCreate : ProcessEngine.SvrProcess
    {
        #region Private Variables
        //Order Date From	
        private DateTime? _DateOrdered_From = null;
        //Order Date To		
        private DateTime? _DateOrdered_To = null;
        //Customer			
        private int _VAB_BusinessPartner_ID;
        //Vendor			
        private int _Vendor_ID;
        //Sales Order		
        private string _VAB_Order_ID;
        //Drop Ship			
        private String _IsDropShip;
        // Consolidated PO
        private bool _IsConsolidatedPO = false;
        // list of PO Creation
        List<ConsolidatePO> listConsolidatePO = new List<ConsolidatePO>();
        // list of Consolidate PO Line
        //List<ConsolidatePOLine> listConsolidatePOLine = new List<ConsolidatePOLine>();
        // Display error Message
        StringBuilder messageErrorOrSetting = new StringBuilder();
        #endregion

        /// <summary>
        /// Prepare - e.g., get Parameters.
        /// </summary>
        protected override void Prepare()
        {
            ProcessInfoParameter[] para = GetParameter();
            for (int i = 0; i < para.Length; i++)
            {
                String name = para[i].GetParameterName();
                if (para[i].GetParameter() == null)
                {
                    ;
                }
                else if (name.Equals("DateOrdered"))
                {
                    _DateOrdered_From = (DateTime?)para[i].GetParameter();
                    _DateOrdered_To = (DateTime?)para[i].GetParameter_To();
                }
                else if (name.Equals("VAB_BusinessPartner_ID"))
                {
                    _VAB_BusinessPartner_ID = Utility.Util.GetValueOfInt(para[i].GetParameter());//.intValue();
                }
                else if (name.Equals("Vendor_ID"))
                {
                    _Vendor_ID = Utility.Util.GetValueOfInt(para[i].GetParameter());//.intValue();
                }
                else if (name.Equals("VAB_Order_ID"))
                {
                    _VAB_Order_ID = Util.GetValueOfString(para[i].GetParameter());
                    //acctSchemaRecord = Array.ConvertAll(_VAB_Order_ID.Split(','), int.Parse);
                    //_VAB_Order_ID = Utility.Util.GetValueOfInt(para[i].GetParameter());//.intValue();
                }
                else if (name.Equals("IsDropShip"))
                {
                    _IsDropShip = (String)para[i].GetParameter();
                }
                else if (name.Equals("IsConsolidatePO"))
                {
                    _IsConsolidatedPO = "Y".Equals(para[i].GetParameter());
                }
                else
                {
                    log.Log(Level.SEVERE, "Unknown Parameter: " + name);
                }
            }
        }

        /// <summary>
        /// Perrform Process.
        /// </summary>
        /// <returns>Message </returns>
        protected override String DoIt()
        {
            log.Info("DateOrdered=" + _DateOrdered_From + " - " + _DateOrdered_To
                + " - VAB_BusinessPartner_ID=" + _VAB_BusinessPartner_ID + " - Vendor_ID=" + _Vendor_ID
                + " - IsDropShip=" + _IsDropShip + " - VAB_Order_ID=" + _VAB_Order_ID);
            if (string.IsNullOrEmpty(_VAB_Order_ID) && _IsDropShip == null
                && _DateOrdered_From == null && _DateOrdered_To == null
                && _VAB_BusinessPartner_ID == 0 && _Vendor_ID == 0)
            {
                throw new Exception("You need to restrict selection");
            }
            //
            String sql = "SELECT * FROM VAB_Order o "
                + "WHERE o.IsSOTrx='Y' AND o.IsReturnTrx='N' AND o.IsSalesQuotation = 'N'"
                //	No Duplicates
                //	" AND o.Ref_Order_ID IS NULL"
                + " AND NOT EXISTS (SELECT * FROM VAB_OrderLine ol WHERE o.VAB_Order_ID=ol.VAB_Order_ID AND ol.Ref_OrderLine_ID IS NOT NULL)"
                ;
            if (!string.IsNullOrEmpty(_VAB_Order_ID))
            {
                sql += " AND o.VAB_Order_ID IN ( " + _VAB_Order_ID + " ) ";
            }
            else
            {
                if (GetVAF_Org_ID() > 0)
                {
                    sql += " AND o.VAF_Org_ID=" + GetVAF_Org_ID();
                }

                if (_VAB_BusinessPartner_ID != 0)
                {
                    sql += " AND o.VAB_BusinessPartner_ID=" + _VAB_BusinessPartner_ID;
                }
                // Commented by Vivek on 20/09/2017 assigned by Pradeep
                // not to check if dropship is true
                //if (_IsDropShip != null)
                //{
                //    sql += " AND o.IsDropShip='" + _IsDropShip+"'";
                //}
                if (_Vendor_ID != 0)
                {
                    sql += " AND EXISTS (SELECT * FROM VAB_OrderLine ol"
                        + " INNER JOIN VAM_Product_PO po ON (ol.VAM_Product_ID=po.VAM_Product_ID) "
                            + "WHERE o.VAB_Order_ID=ol.VAB_Order_ID AND po.VAB_BusinessPartner_ID=" + _Vendor_ID + ")";
                }
                if (_DateOrdered_From != null && _DateOrdered_To != null)
                {
                    sql += "AND TRUNC(o.DateOrdered,'DD') BETWEEN " + GlobalVariable.TO_DATE(_DateOrdered_From, true) + " AND " + GlobalVariable.TO_DATE(_DateOrdered_To, true);
                }
                else if (_DateOrdered_From != null && _DateOrdered_To == null)
                {
                    sql += "AND TRUNC(o.DateOrdered,'DD') >= " + GlobalVariable.TO_DATE(_DateOrdered_From, true);
                }
                else if (_DateOrdered_From == null && _DateOrdered_To != null)
                {
                    sql += "AND TRUNC(o.DateOrdered,'DD') <= " + GlobalVariable.TO_DATE(_DateOrdered_To, true);
                }
            }
            DataTable dt = null;
            IDataReader idr = null;
            int counter = 0;
            try
            {
                idr = DataBase.DB.ExecuteReader(sql, null, Get_TrxName());
                dt = new DataTable();
                dt.Load(idr);
                idr.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    counter += CreatePOFromSO(new MOrder(GetCtx(), dr, Get_TrxName()));
                }
                // display price with document no
                if (listConsolidatePO.Count > 0)
                {
                    for (int i = 0; i < listConsolidatePO.Count; i++)
                    {
                        MOrder purchaseOrder = new MOrder(GetCtx(), listConsolidatePO[i].VAB_Order_ID, Get_Trx());
                        AddLog(0, null, purchaseOrder.GetGrandTotal(), purchaseOrder.GetDocumentNo());
                    }
                }
            }
            catch (Exception e)
            {
                if (idr != null)
                {
                    idr.Close();
                }
                log.Log(Level.SEVERE, sql, e);
            }
            finally
            {
                if (idr != null)
                {
                    idr.Close();
                }
                dt = null;
            }

            if (counter == 0)
            {
                log.Fine(sql);
            }
            return "@Created@ " + counter + " , " + messageErrorOrSetting;
        }

        /// <summary>
        /// Create PO From SO
        /// </summary>
        /// <param name="so">sales order</param>
        /// <returns>number of POs created</returns>
        private int CreatePOFromSO(MOrder so)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder sqlErrorMessage = new StringBuilder();
            sqlErrorMessage.Clear();
            string _Dropship = "";
            log.Info(so.ToString());
            MOrderLine[] soLines = so.GetLines(true, null);
            if (soLines == null || soLines.Length == 0)
            {
                log.Warning("No Lines - " + so);
                return 0;
            }
            //
            int counter = 0;
            //	Order Lines with a Product which has a current vendor 
            sql.Append(@"SELECT DISTINCT po.VAB_BusinessPartner_ID, po.VAM_Product_ID ,ol.Isdropship, po.PriceList , po.PricePO , po.VAB_Currency_ID
                FROM  VAM_Product_PO po
                INNER JOIN VAM_Product prd ON po.VAM_Product_ID=prd.VAM_Product_ID
                INNER JOIN VAB_OrderLine ol ON (po.VAM_Product_ID=ol.VAM_Product_ID ");       // changes done by bharat on 26 June 2018 If purchased Checkbox is false on Finished Good Product, System should not generate Purchase Order.

            sqlErrorMessage.Append(@"SELECT DISTINCT po.VAB_BusinessPartner_ID, bp.name AS BPName,  ol.VAM_Product_ID , p.Name,  ol.Isdropship,  po.VAB_Currency_ID,  bp.PO_PaymentTerm_ID,  bp.PO_PriceList_ID 
                FROM  VAB_OrderLine ol INNER JOIN VAM_Product p ON (p.VAM_Product_ID =ol.VAM_Product_ID)
                LEFT JOIN VAM_Product_PO po ON (po.VAM_Product_ID=ol.VAM_Product_ID  AND po.isactive = 'Y' AND po.IsCurrentVendor = 'Y' )
                LEFT JOIN VAB_BusinessPartner bp ON (bp.VAB_BusinessPartner_id = po.VAB_BusinessPartner_id ");

            // Added by Vivek on  20/09/2017 Assigned By Pradeep for drop shipment
            // if drop ship parameter is true then get all records true drop ship lines
            if (_IsDropShip == "Y")
            {
                sql.Append(@"AND Ol.Isdropship='Y' ");
                sqlErrorMessage.Append(@"AND Ol.Isdropship='Y' ");
            }
            // if drop ship parameter is false then get all records false drop ship lines
            else if (_IsDropShip == "N")
            {
                sql.Append(@"AND Ol.Isdropship='N' ");
                sqlErrorMessage.Append(@"AND Ol.Isdropship='N' ");
            }

            // changes don eby Bharat on 26 June 2018 to handle If purchased Checkbox is false on Finished Good Product, System should not generate Purchase Order.
            sql.Append(@") WHERE ol.VAB_Order_ID=" + so.GetVAB_Order_ID() + @" AND po.IsCurrentVendor='Y' AND prd.IsPurchased='Y'");
            sqlErrorMessage.Append(@") WHERE ol.VAB_Order_ID=" + so.GetVAB_Order_ID());

            if (_Vendor_ID > 0)
            {
                sql.Append(@" AND po.VAB_BusinessPartner_ID = " + _Vendor_ID);
                sqlErrorMessage.Append(@" AND po.VAB_BusinessPartner_ID = " + _Vendor_ID);
            }
            sql.Append(@" ORDER BY po.VAB_BusinessPartner_id,ol.Isdropship ");
            sqlErrorMessage.Append(@" ORDER BY po.VAB_BusinessPartner_id,ol.Isdropship ");

            // get error or setting message
            GetErrorOrSetting(sqlErrorMessage.ToString(), Get_TrxName());

            IDataReader idr = null;
            DataTable dt = null;
            MOrder po = null;
            ConsolidatePO consolidatePO = null;
            //ConsolidatePOLine consolidatePOLine = null;
            try
            {
                idr = DataBase.DB.ExecuteReader(sql.ToString(), null, Get_TrxName());
                dt = new DataTable();
                dt.Load(idr);
                idr.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    //while (idr.Read())                {
                    //	New Order                    
                    int VAB_BusinessPartner_ID = Utility.Util.GetValueOfInt(dr[0]);//.getInt(1);
                    // Code Commented by Vivek Kumar on 20/09/2017 Assigned By Pradeep for drop shipment
                    //if (po == null || po.GetBill_BPartner_ID() != VAB_BusinessPartner_ID)
                    //{
                    //    po = CreatePOForVendor(Utility.Util.GetValueOfInt(dr[0]), so);
                    //    AddLog(0, null, null, po.GetDocumentNo());
                    //    counter++;
                    //

                    // check ANY PO created with same Business Partnet and Drop Shipment
                    if (_IsConsolidatedPO && listConsolidatePO.Count > 0)
                    {
                        ConsolidatePO poRecord;
                        if (listConsolidatePO.Exists(x => (x.VAB_BusinessPartner_ID == VAB_BusinessPartner_ID) && (x.IsDropShip == Utility.Util.GetValueOfString(dr[2]))))
                        {
                            poRecord = listConsolidatePO.Find(x => (x.VAB_BusinessPartner_ID == VAB_BusinessPartner_ID) && (x.IsDropShip == Utility.Util.GetValueOfString(dr[2])));
                            if (poRecord != null)
                            {
                                po = new MOrder(GetCtx(), poRecord.VAB_Order_ID, Get_Trx());
                                _Dropship = po.IsDropShip() ? "Y" : "N";
                            }
                        }
                    }

                    // Drop Shipment fucntionality added by Vivek on 20/09/2017 Assigned By Pradeep 
                    if (po == null || po.GetBill_BPartner_ID() != VAB_BusinessPartner_ID || _Dropship != Utility.Util.GetValueOfString(dr[2]))
                    {
                        po = CreatePOForVendor(Utility.Util.GetValueOfInt(dr[0]), so, Utility.Util.GetValueOfString(dr[2]));
                        if (po == null)
                            return counter;
                        // AddLog(0, null, null, po.GetDocumentNo());
                        counter++;

                        // maintain list
                        if (po != null && po.GetVAB_Order_ID() > 0)
                        {
                            consolidatePO = new ConsolidatePO();
                            consolidatePO.VAB_Order_ID = po.GetVAB_Order_ID();
                            consolidatePO.VAB_BusinessPartner_ID = VAB_BusinessPartner_ID;
                            consolidatePO.IsDropShip = Utility.Util.GetValueOfString(dr[2]);
                            listConsolidatePO.Add(consolidatePO);
                        }
                    }

                    _Dropship = Utility.Util.GetValueOfString(dr[2]);
                    //	Line
                    int VAM_Product_ID = Utility.Util.GetValueOfInt(dr[1]);//.getInt(2);
                    for (int i = 0; i < soLines.Length; i++)
                    {
                        // When Drop ship parameter is yes but SO line does not contains any drop shipment product
                        if (_IsDropShip == "Y" && Util.GetValueOfBool(soLines[i].IsDropShip()) == false)
                        {
                            continue;
                        }
                        // When Drop ship parameter is NO but SO line contains drop shipment product then it also does not generate any 
                        else if (_IsDropShip == "N" && Util.GetValueOfBool(soLines[i].IsDropShip()) == true)
                        {
                            continue;
                        }
                        //When Drop ship parameter is yes and SO line also contains drop shipment product
                        else
                        {
                            String _Drop = "N";
                            if (Util.GetValueOfBool(soLines[i].IsDropShip()))
                            {
                                _Drop = "Y";
                            }
                            if (soLines[i].GetVAM_Product_ID() == VAM_Product_ID && _Drop == _Dropship)
                            {
                                MOrderLine poLine = new MOrderLine(po);
                                poLine.SetRef_OrderLine_ID(soLines[i].GetVAB_OrderLine_ID());
                                poLine.SetVAM_Product_ID(soLines[i].GetVAM_Product_ID());
                                poLine.SetVAM_PFeature_SetInstance_ID(soLines[i].GetVAM_PFeature_SetInstance_ID());
                                poLine.SetVAB_UOM_ID(soLines[i].GetVAB_UOM_ID());
                                poLine.SetQtyEntered(soLines[i].GetQtyEntered());
                                poLine.SetQtyOrdered(soLines[i].GetQtyOrdered());
                                poLine.SetDescription(soLines[i].GetDescription());
                                poLine.SetDatePromised(soLines[i].GetDatePromised());
                                poLine.SetIsDropShip(soLines[i].IsDropShip());
                                poLine.SetPrice();
                                
                                // Set value in Property From Process to check on Before Save.
                                poLine.SetFromProcess(true);
                                if (!poLine.Save())
                                {
                                    ValueNamePair pp = VLogger.RetrieveError();
                                    log.Info("CreatePOfromSO : Not Saved. Error Value : " + pp.GetValue() + " , Error Name : " + pp.GetName());
                                }
                                //else
                                //{
                                //    if (poLine != null && poLine.GetVAB_OrderLine_ID() > 0)
                                //    {
                                //        consolidatePOLine = new ConsolidatePOLine();
                                //        consolidatePOLine.VAB_Order_ID = poLine.GetVAB_Order_ID();
                                //        consolidatePOLine.VAB_OrderLine_ID = poLine.GetVAB_OrderLine_ID();
                                //        consolidatePOLine.VAM_Product_ID = poLine.GetVAM_Product_ID();
                                //        consolidatePOLine.VAM_PFeature_SetInstance_ID = poLine.GetVAM_PFeature_SetInstance_ID();
                                //        consolidatePOLine.VAB_UOM_ID = poLine.GetVAB_UOM_ID();
                                //        consolidatePOLine.IsDropShip = soLines[i].IsDropShip() ? "Y" : "N";
                                //        listConsolidatePOLine.Add(consolidatePOLine);
                                //    }
                                //}
                            }
                        }
                    }

                }
                //idr.Close();
            }
            catch (Exception e)
            {
                if (idr != null)
                {
                    idr.Close();
                }
                log.Log(Level.SEVERE, sql.ToString(), e);
            }


            //	Set Reference to PO
            if (po != null)
            {
                so.SetRef_Order_ID(po.GetVAB_Order_ID());
                so.Save();
            }
            return counter;
        }

        /// <summary>
        /// Create PO for Vendor
        /// </summary>
        /// <param name="VAB_BusinessPartner_ID">vendor</param>
        /// <param name="so">sales order</param>
        /// <returns>MOrder</returns>
        public MOrder CreatePOForVendor(int VAB_BusinessPartner_ID, MOrder so, string _shipDrop)
        {
            MOrder po = new MOrder(GetCtx(), 0, Get_TrxName());
            po.SetClientOrg(so.GetVAF_Client_ID(), so.GetVAF_Org_ID());
            po.SetRef_Order_ID(so.GetVAB_Order_ID());
            po.SetIsSOTrx(false);
            // method edited to set unreleased document type for PO
            po.SetVAB_DocTypesTarget_ID(false);
            //
            po.SetDescription(so.GetDescription());
            po.SetPOReference(so.GetDocumentNo());
            po.SetPriorityRule(so.GetPriorityRule());
            po.SetSalesRep_ID(so.GetSalesRep_ID());
            // Code Commented by Vivek Kumar on 20/09/2017 Assigned By Pradeep for drop shipment
            //po.SetVAM_Warehouse_ID(so.GetVAM_Warehouse_ID());
            //	Set Vendor
            MVABBusinessPartner vendor = new MVABBusinessPartner(GetCtx(), VAB_BusinessPartner_ID, Get_TrxName());
            if (Env.IsModuleInstalled("VA009_"))
            {
                // Set PO Payment Method from Vendor
                if (Util.GetValueOfInt(vendor.GetVA009_PO_PaymentMethod_ID()) > 0)
                {
                    po.SetVA009_PaymentMethod_ID(Util.GetValueOfInt(vendor.GetVA009_PO_PaymentMethod_ID()));
                }
                else
                {
                    if (string.IsNullOrEmpty(messageErrorOrSetting.ToString()))
                    {
                        messageErrorOrSetting.Append(Msg.GetMsg(GetCtx(), "VIS_PaymentMethodNotDefined") + " : " + vendor.GetName());
                    }
                    else
                    {
                        messageErrorOrSetting.Append(" , " + Msg.GetMsg(GetCtx(), "VIS_PaymentMethodNotDefined") + " : " + vendor.GetName());
                    }
                    po = null;
                    return po;
                }
            }

            //JID_1252: If Vendor do not have Po Pricelist bind. System should give message.
            if (vendor.GetPO_PriceList_ID() > 0)
            {
                po.SetVAM_PriceList_ID(vendor.GetPO_PriceList_ID());
            }
            else
            {
                if (string.IsNullOrEmpty(messageErrorOrSetting.ToString()))
                {
                    messageErrorOrSetting.Append(Msg.GetMsg(GetCtx(), "VIS_VendorPrcListNotDefine") + " : " + vendor.GetName());
                }
                else
                {
                    messageErrorOrSetting.Append(" , " + Msg.GetMsg(GetCtx(), "VIS_VendorPrcListNotDefine") + " : " + vendor.GetName());
                }
                po = null;
                return po;
            }

            // JID_1262: If Payment Term is not bind BP, BP Group and No Default Payment Term. System do not create PO neither give message. 
            if (vendor.GetPO_PaymentTerm_ID() > 0)
            {
                po.SetVAB_PaymentTerm_ID(vendor.GetPO_PaymentTerm_ID());
            }
            else
            {
                if (string.IsNullOrEmpty(messageErrorOrSetting.ToString()))
                {
                    messageErrorOrSetting.Append(Msg.GetMsg(GetCtx(), "VIS_VendorPaytemNotDefine") + " : " + vendor.GetName());
                }
                else
                {
                    messageErrorOrSetting.Append(" , " + Msg.GetMsg(GetCtx(), "VIS_VendorPaytemNotDefine") + " : " + vendor.GetName());
                }
                po = null;
                return po;
            }

            po.SetBPartner(vendor);

            // Code Commented by Vivek Kumar on 20/09/2017 Assigned By Pradeep  for drop shipment
            //	Drop Ship
            //po.SetIsDropShip(so.IsDropShip());
            //if (so.IsDropShip())
            //{
            //    po.SetShip_BPartner_ID(so.GetVAB_BusinessPartner_ID());
            //    po.SetShip_Location_ID(so.GetVAB_BPart_Location_ID());
            //    po.SetShip_User_ID(so.GetVAF_UserContact_ID());
            //}

            if (_shipDrop == "Y")
            {
                po.SetIsDropShip(true);
                po.SetShipToPartner_ID(so.GetVAB_BusinessPartner_ID());
                po.SetShipToLocation_ID(so.GetVAB_BPart_Location_ID());
                int _Warehouse_ID = Util.GetValueOfInt(DB.ExecuteScalar("Select VAM_Warehouse_ID From VAM_Warehouse Where VAF_Org_ID=" + so.GetVAF_Org_ID() + " AND Isdropship='Y' AND IsActive='Y'"));
                if (_Warehouse_ID >= 0)
                {
                    po.SetVAM_Warehouse_ID(_Warehouse_ID);
                }
            }

            // Added by Bharat on 29 Jan 2018 to set Inco Term from Order

            if (po.Get_ColumnIndex("VAB_IncoTerm_ID") > 0)
            {
                po.SetVAB_IncoTerm_ID(so.GetVAB_IncoTerm_ID());
            }
            //	References
            po.SetVAB_BillingCode_ID(so.GetVAB_BillingCode_ID());
            po.SetVAB_Promotion_ID(so.GetVAB_Promotion_ID());
            po.SetVAB_Project_ID(so.GetVAB_Project_ID());
            po.SetUser1_ID(so.GetUser1_ID());
            po.SetUser2_ID(so.GetUser2_ID());
            //
            po.Save();
            return po;
        }

        // getting Error or Setting available for Process
        public void GetErrorOrSetting(String sql, Trx trxName)
        {
            try
            {
                DataSet dsRecod = DB.ExecuteDataset(sql, null, trxName);
                if (dsRecod != null && dsRecod.Tables.Count > 0 && dsRecod.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsRecod.Tables[0].Rows.Count; i++)
                    {
                        // check Current vendor available or not
                        if (Util.GetValueOfInt(dsRecod.Tables[0].Rows[i]["VAB_BusinessPartner_ID"]) == 0)
                        {
                            if (string.IsNullOrEmpty(messageErrorOrSetting.ToString()))
                            {
                                messageErrorOrSetting.Append(Msg.GetMsg(GetCtx(), "VIS_VendorNotFound") + ":" + Util.GetValueOfString(dsRecod.Tables[0].Rows[i]["Name"]));
                            }
                            else
                            {
                                messageErrorOrSetting.Append(" , " + Msg.GetMsg(GetCtx(), "VIS_VendorNotFound") + ":" + Util.GetValueOfString(dsRecod.Tables[0].Rows[i]["Name"]));
                            }
                            continue;
                        }
                        // check Payment term 
                        //if (Util.GetValueOfInt(dsRecod.Tables[0].Rows[i]["PO_PaymentTerm_ID"]) == 0)
                        //{
                        //    if (string.IsNullOrEmpty(messageErrorOrSetting.ToString()))
                        //    {
                        //        messageErrorOrSetting.Append(Msg.GetMsg(GetCtx(), "VIS_VendorPaytemNotDefine") + ":" + Util.GetValueOfString(dsRecod.Tables[0].Rows[i]["BPName"]));
                        //    }
                        //    else
                        //    {
                        //        messageErrorOrSetting.Append(" , " + Msg.GetMsg(GetCtx(), "VIS_VendorPaytemNotDefine") + ":" + Util.GetValueOfString(dsRecod.Tables[0].Rows[i]["BPName"]));
                        //    }
                        //    continue;
                        //}

                        // check price list                        
                        //if (Util.GetValueOfInt(dsRecod.Tables[0].Rows[i]["PO_PriceList_ID"]) == 0)
                        //{
                        //    if (string.IsNullOrEmpty(messageErrorOrSetting.ToString()))
                        //    {
                        //        messageErrorOrSetting.Append(Msg.GetMsg(GetCtx(), "VIS_VendorPrcListNotDefine") + " : " + Util.GetValueOfString(dsRecod.Tables[0].Rows[i]["BPName"]));
                        //    }
                        //    else
                        //    {
                        //        messageErrorOrSetting.Append(" , " + Msg.GetMsg(GetCtx(), "VIS_VendorPrcListNotDefine") + " : " + Util.GetValueOfString(dsRecod.Tables[0].Rows[i]["BPName"]));
                        //    }
                        //    continue;
                        //}
                    }
                }
            }
            catch (Exception e)
            {
                log.Log(Level.SEVERE, sql, e);
            }
        }

    }

    public class ConsolidatePO
    {
        public int VAB_Order_ID { get; set; }
        public int VAB_BusinessPartner_ID { get; set; }
        public string IsDropShip { get; set; }
    }

    //public class ConsolidatePOLine
    //{
    //    public int VAB_Order_ID { get; set; }
    //    public int VAB_OrderLine_ID { get; set; }
    //    public int VAM_Product_ID { get; set; }
    //    public int VAM_PFeature_SetInstance_ID { get; set; }
    //    public int VAB_UOM_ID { get; set; }
    //    public string IsDropShip { get; set; }
    //}
}
