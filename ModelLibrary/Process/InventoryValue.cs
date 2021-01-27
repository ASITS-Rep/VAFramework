﻿/********************************************************
 * Module  Name   : 
 * Purpose        : Inventory Valuation. Process to fill VAT_StockData
 * Class Used     : ProcessEngine.SvrProcess
 * Chronological    Development
 * Veena        20-Oct-2009
  ******************************************************/

using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using VAdvantage.Classes;
using VAdvantage.Utility;
using VAdvantage.Model;
using VAdvantage.Logging;
using VAdvantage.DataBase;
using System.Data;
using System.Data.SqlClient;

using VAdvantage.ProcessEngine;
namespace VAdvantage.Process
{
    /// <summary>
    /// Inventory Valuation.
    /// Process to fill VAT_StockData
    /// </summary>
    public class InventoryValue : ProcessEngine.SvrProcess
    {
        /** Price List Used         */
        private int _M_PriceList_Version_ID;
        /** Valuation Date          */
        private DateTime? _DateValue;
        /** Warehouse               */
        private int _M_Warehouse_ID;
        /** Currency                */
        private int _VAB_Currency_ID;
        /** Optional Cost Element	*/
        private int _M_CostElement_ID;

        /// <summary>
        /// Prepare
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
                else if (name.Equals("M_PriceList_Version_ID"))
                    _M_PriceList_Version_ID = para[i].GetParameterAsInt();
                else if (name.Equals("DateValue"))
                    _DateValue = (DateTime?)para[i].GetParameter();
                else if (name.Equals("M_Warehouse_ID"))
                    _M_Warehouse_ID = para[i].GetParameterAsInt();
                else if (name.Equals("VAB_Currency_ID"))
                    _VAB_Currency_ID = para[i].GetParameterAsInt();
                else if (name.Equals("M_CostElement_ID"))
                    _M_CostElement_ID = para[i].GetParameterAsInt();
            }
            if (_DateValue == null)
                _DateValue = new DateTime(CommonFunctions.CurrentTimeMillis());
        }

        /// <summary>
        /// Perform Process.
        /// - Fill Table with QtyOnHand for Warehouse and Valuation Date
        /// - Perform Price Calculations
        /// </summary>
        /// <returns>message</returns>
        protected override String DoIt()
        {
            log.Info("M_Warehouse_ID=" + _M_Warehouse_ID
                + ",VAB_Currency_ID=" + _VAB_Currency_ID
                + ",DateValue=" + _DateValue
                + ",M_PriceList_Version_ID=" + _M_PriceList_Version_ID
                + ",M_CostElement_ID=" + _M_CostElement_ID);

            MWarehouse wh = MWarehouse.Get(GetCtx(), _M_Warehouse_ID);
            MClient c = MClient.Get(GetCtx(), wh.GetVAF_Client_ID());
            MAcctSchema mas = c.GetAcctSchema();

            //  Delete (just to be sure)
            StringBuilder sql = new StringBuilder("DELETE FROM VAT_StockData WHERE VAF_JInstance_ID=");
            sql.Append(GetVAF_JInstance_ID());
            int no = DataBase.DB.ExecuteQuery(sql.ToString(), null, Get_TrxName());
            MPInstance instance = new MPInstance(GetCtx(), GetVAF_JInstance_ID(), null);
            DateTime Createddate = instance.GetCreated();
            Createddate = Createddate.AddHours(-1);

            string qry = "select MAX(VAF_JINSTANCE_ID) from VAF_JINSTANCE WHERE VAF_Job_ID=" + instance.GetVAF_Job_ID() + " AND created<  TO_Date('" + Createddate.ToString("MM/dd/yyyy HH:mm:ss") + "', 'MM-DD-YYYY HH24:MI:SS')";
            int MaxInstance_ID = Util.GetValueOfInt(DB.ExecuteScalar(qry, null, null));

           int no1= DB.ExecuteQuery("DELETE FROM VAT_StockData WHERE VAF_JInstance_ID <=" + MaxInstance_ID);

            //	Insert Standard Costs
            sql = new StringBuilder("INSERT INTO VAT_StockData "
                + "(VAF_JInstance_ID, M_Warehouse_ID, M_Product_ID, M_AttributeSetInstance_ID,"
                + " VAF_Client_ID, VAF_Org_ID, CostStandard) "
                + "SELECT ").Append(GetVAF_JInstance_ID())
                .Append(", w.M_Warehouse_ID, c.M_Product_ID, c.M_AttributeSetInstance_ID,"
                + " w.VAF_Client_ID, w.VAF_Org_ID, c.CurrentCostPrice "
                + "FROM M_Warehouse w"
                + " INNER JOIN VAF_ClientDetail ci ON (w.VAF_Client_ID=ci.VAF_Client_ID)"
                + " INNER JOIN VAB_AccountBook acs ON (ci.VAB_AccountBook1_ID=acs.VAB_AccountBook_ID)"
                + " INNER JOIN M_Cost c ON (acs.VAB_AccountBook_ID=c.VAB_AccountBook_ID AND acs.M_CostType_ID=c.M_CostType_ID AND c.VAF_Org_ID IN (0, w.VAF_Org_ID))"
                + " INNER JOIN M_CostElement ce ON (c.M_CostElement_ID=ce.M_CostElement_ID AND ce.CostingMethod='S' AND ce.CostElementType='M') "
                + "WHERE w.M_Warehouse_ID=").Append(_M_Warehouse_ID);
            int noInsertStd = DataBase.DB.ExecuteQuery(sql.ToString(), null, Get_TrxName());
            log.Fine("Inserted Std=" + noInsertStd);
            if (noInsertStd == 0)
                return "No Standard Costs found";

            //	Insert addl Costs
            int noInsertCost = 0;
            if (_M_CostElement_ID != 0)
            {
                sql = new StringBuilder("INSERT INTO VAT_StockData "
                    + "(VAF_JInstance_ID, M_Warehouse_ID, M_Product_ID, M_AttributeSetInstance_ID,"
                    + " VAF_Client_ID, VAF_Org_ID, CostStandard, Cost, M_CostElement_ID) "
                    + "SELECT ").Append(GetVAF_JInstance_ID())
                    .Append(", w.M_Warehouse_ID, c.M_Product_ID, c.M_AttributeSetInstance_ID,"
                    + " w.VAF_Client_ID, w.VAF_Org_ID, 0, c.CurrentCostPrice, c.M_CostElement_ID "
                    + "FROM M_Warehouse w"
                    + " INNER JOIN VAF_ClientDetail ci ON (w.VAF_Client_ID=ci.VAF_Client_ID)"
                    + " INNER JOIN VAB_AccountBook acs ON (ci.VAB_AccountBook1_ID=acs.VAB_AccountBook_ID)"
                    + " INNER JOIN M_Cost c ON (acs.VAB_AccountBook_ID=c.VAB_AccountBook_ID AND acs.M_CostType_ID=c.M_CostType_ID AND c.VAF_Org_ID IN (0, w.VAF_Org_ID)) "
                    + "WHERE w.M_Warehouse_ID=").Append(_M_Warehouse_ID)
                    .Append(" AND c.M_CostElement_ID=").Append(_M_CostElement_ID)
                    .Append(" AND NOT EXISTS (SELECT * FROM VAT_StockData iv "
                        + "WHERE iv.VAF_JInstance_ID=").Append(GetVAF_JInstance_ID())
                        .Append(" AND iv.M_Warehouse_ID=w.M_Warehouse_ID"
                        + " AND iv.M_Product_ID=c.M_Product_ID"
                        + " AND iv.M_AttributeSetInstance_ID=c.M_AttributeSetInstance_ID)");
                noInsertCost = DataBase.DB.ExecuteQuery(sql.ToString(), null, Get_TrxName());
                log.Fine("Inserted Cost=" + noInsertCost);
                //	Update Std Cost Records
                sql = new StringBuilder("UPDATE VAT_StockData iv "
                    + "SET (Cost, M_CostElement_ID)="
                        + "(SELECT c.CurrentCostPrice, c.M_CostElement_ID "
                        + "FROM M_Warehouse w"
                        + " INNER JOIN VAF_ClientDetail ci ON (w.VAF_Client_ID=ci.VAF_Client_ID)"
                        + " INNER JOIN VAB_AccountBook acs ON (ci.VAB_AccountBook1_ID=acs.VAB_AccountBook_ID)"
                        + " INNER JOIN M_Cost c ON (acs.VAB_AccountBook_ID=c.VAB_AccountBook_ID"
                            + " AND acs.M_CostType_ID=c.M_CostType_ID AND c.VAF_Org_ID IN (0, w.VAF_Org_ID)) "
                        + "WHERE c.M_CostElement_ID=" + _M_CostElement_ID
                        + " AND w.M_Warehouse_ID=iv.M_Warehouse_ID"
                        + " AND c.M_Product_ID=iv.M_Product_ID"
                        + " AND c.M_AttributeSetInstance_ID=iv.M_AttributeSetInstance_ID AND rownum=1 AND w.m_warehouse_ID=" + _M_Warehouse_ID + ") "
                    + "WHERE EXISTS (SELECT * FROM VAT_StockData ivv "
                        + "WHERE ivv.VAF_JInstance_ID=" + GetVAF_JInstance_ID()
                        + " AND ivv.M_CostElement_ID IS NULL) AND iv.VAF_JInstance_ID ="+GetVAF_JInstance_ID());
                int noUpdatedCost = DataBase.DB.ExecuteQuery(sql.ToString(), null, Get_TrxName());
                log.Fine("Updated Cost=" + noUpdatedCost);
            }
            if ((noInsertStd + noInsertCost) == 0)
                return "No Costs found";

            //  Update Constants
            //  YYYY-MM-DD HH24:MI:SS.mmmm  JDBC Timestamp format
            // String myDate = _DateValue.ToString();
            sql = new StringBuilder("UPDATE VAT_StockData SET ")
                //.Append("DateValue=To_Date('").Append(myDate.Substring(0,10))
                //.Append("23:59:59','MM-DD-YYYY HH24:MI:SS'),")
             .Append("DateValue=").Append(GlobalVariable.TO_DATE(_DateValue, true)).Append(",")
            .Append("M_PriceList_Version_ID=").Append(_M_PriceList_Version_ID).Append(",")
            .Append("VAB_Currency_ID=").Append(_VAB_Currency_ID);
            if (_M_CostElement_ID != 0)
            {
                sql.Append(",").Append("M_CostElement_ID=").Append(_M_CostElement_ID);
            }
            no = DataBase.DB.ExecuteQuery(sql.ToString(), null, Get_TrxName());
            log.Fine("Constants=" + no);

            //  Get current QtyOnHand with ASI
            sql = new StringBuilder("UPDATE VAT_StockData iv SET QtyOnHand = "
                    + "(SELECT SUM(QtyOnHand) FROM M_Storage s"
                    + " INNER JOIN M_Locator l ON (l.M_Locator_ID=s.M_Locator_ID) "
                    + "WHERE iv.M_Product_ID=s.M_Product_ID"
                    + " AND iv.M_Warehouse_ID=l.M_Warehouse_ID"
                    + " AND iv.M_AttributeSetInstance_ID=s.M_AttributeSetInstance_ID) "
                + "WHERE VAF_JInstance_ID=").Append(GetVAF_JInstance_ID())
                .Append(" AND iv.M_AttributeSetInstance_ID<>0");
            no = DataBase.DB.ExecuteQuery(sql.ToString(), null, Get_TrxName());
            log.Fine("QtHand with ASI=" + no);
            //  Get current QtyOnHand without ASI
            sql = new StringBuilder("UPDATE VAT_StockData iv SET QtyOnHand = "
                    + "(SELECT SUM(QtyOnHand) FROM M_Storage s"
                    + " INNER JOIN M_Locator l ON (l.M_Locator_ID=s.M_Locator_ID) "
                    + "WHERE iv.M_Product_ID=s.M_Product_ID"
                    + " AND iv.M_Warehouse_ID=l.M_Warehouse_ID) "
                + "WHERE VAF_JInstance_ID=").Append(GetVAF_JInstance_ID())
                .Append(" AND iv.M_AttributeSetInstance_ID=0");
            no = DataBase.DB.ExecuteQuery(sql.ToString(), null, Get_TrxName());
            log.Fine("QtHand w/o ASI=" + no);

            //  Adjust for Valuation Date
            sql = new StringBuilder("UPDATE VAT_StockData iv "
                + "SET QtyOnHand="
                    + "(SELECT iv.QtyOnHand - NVL(SUM(t.MovementQty), 0) "
                    + "FROM M_Transaction t"
                    + " INNER JOIN M_Locator l ON (t.M_Locator_ID=l.M_Locator_ID) "
                    + "WHERE t.M_Product_ID=iv.M_Product_ID"
                    + " AND t.M_AttributeSetInstance_ID=iv.M_AttributeSetInstance_ID"
                    + " AND t.MovementDate > iv.DateValue"
                    + " AND l.M_Warehouse_ID=iv.M_Warehouse_ID) "
                + "WHERE iv.M_AttributeSetInstance_ID<>0");
            no = DataBase.DB.ExecuteQuery(sql.ToString(), null, Get_TrxName());
            log.Fine("Update with ASI=" + no);
            //
            sql = new StringBuilder("UPDATE VAT_StockData iv "
                + "SET QtyOnHand="
                    + "(SELECT iv.QtyOnHand - NVL(SUM(t.MovementQty), 0) "
                    + "FROM M_Transaction t"
                    + " INNER JOIN M_Locator l ON (t.M_Locator_ID=l.M_Locator_ID) "
                    + "WHERE t.M_Product_ID=iv.M_Product_ID"
                    + " AND t.MovementDate > iv.DateValue"
                    + " AND l.M_Warehouse_ID=iv.M_Warehouse_ID) "
                + "WHERE iv.M_AttributeSetInstance_ID=0");
            no = DataBase.DB.ExecuteQuery(sql.ToString(), null, Get_TrxName());
            log.Fine("Update w/o ASI=" + no);

            //  Delete Records w/o OnHand Qty
            sql = new StringBuilder("DELETE FROM VAT_StockData "
                + "WHERE (QtyOnHand=0 OR QtyOnHand IS NULL) AND VAF_JInstance_ID=").Append(GetVAF_JInstance_ID());
            int noQty = DataBase.DB.ExecuteQuery(sql.ToString(), null, Get_TrxName());
            log.Fine("NoQty Deleted=" + noQty);

            //  Update Prices
            no = DataBase.DB.ExecuteQuery("UPDATE VAT_StockData iv "
                + "SET PricePO = "
                    + "(SELECT MAX(currencyConvert (po.PriceList,po.VAB_Currency_ID,iv.VAB_Currency_ID,iv.DateValue,null, po.VAF_Client_ID,po.VAF_Org_ID))"
                    + " FROM M_Product_PO po WHERE po.M_Product_ID=iv.M_Product_ID"
                    + " AND po.IsCurrentVendor='Y'), "
                + "PriceList = "
                    + "(SELECT currencyConvert(pp.PriceList,pl.VAB_Currency_ID,iv.VAB_Currency_ID,iv.DateValue,null, pl.VAF_Client_ID,pl.VAF_Org_ID)"
                    + " FROM M_PriceList pl, M_PriceList_Version plv, M_ProductPrice pp"
                    + " WHERE pp.M_Product_ID=iv.M_Product_ID AND pp.M_PriceList_Version_ID=iv.M_PriceList_Version_ID"
                    + " AND pp.M_PriceList_Version_ID=plv.M_PriceList_Version_ID"
                    + " AND plv.M_PriceList_ID=pl.M_PriceList_ID), "
                + "PriceStd = "
                    + "(SELECT currencyConvert(pp.PriceStd,pl.VAB_Currency_ID,iv.VAB_Currency_ID,iv.DateValue,null, pl.VAF_Client_ID,pl.VAF_Org_ID)"
                    + " FROM M_PriceList pl, M_PriceList_Version plv, M_ProductPrice pp"
                    + " WHERE pp.M_Product_ID=iv.M_Product_ID AND pp.M_PriceList_Version_ID=iv.M_PriceList_Version_ID"
                    + " AND pp.M_PriceList_Version_ID=plv.M_PriceList_Version_ID"
                    + " AND plv.M_PriceList_ID=pl.M_PriceList_ID), "
                + "PriceLimit = "
                    + "(SELECT currencyConvert(pp.PriceLimit,pl.VAB_Currency_ID,iv.VAB_Currency_ID,iv.DateValue,null, pl.VAF_Client_ID,pl.VAF_Org_ID)"
                    + " FROM M_PriceList pl, M_PriceList_Version plv, M_ProductPrice pp"
                    + " WHERE pp.M_Product_ID=iv.M_Product_ID AND pp.M_PriceList_Version_ID=iv.M_PriceList_Version_ID"
                    + " AND pp.M_PriceList_Version_ID=plv.M_PriceList_Version_ID"
                    + " AND plv.M_PriceList_ID=pl.M_PriceList_ID)"
                    , null, Get_TrxName());
            String msg = "";
            if (no == 0)
                msg = "No Prices";

            //	Convert if different Currency
            if (mas.GetVAB_Currency_ID() != _VAB_Currency_ID)
            {
                sql = new StringBuilder("UPDATE VAT_StockData iv "
                    + "SET CostStandard= "
                        + "(SELECT currencyConvert(iv.CostStandard,acs.VAB_Currency_ID,iv.VAB_Currency_ID,iv.DateValue,null, iv.VAF_Client_ID,iv.VAF_Org_ID) "
                        + "FROM VAB_AccountBook acs WHERE acs.VAB_AccountBook_ID=" + mas.GetVAB_AccountBook_ID() + "),"
                    + "	Cost= "
                        + "(SELECT currencyConvert(iv.Cost,acs.VAB_Currency_ID,iv.VAB_Currency_ID,iv.DateValue,null, iv.VAF_Client_ID,iv.VAF_Org_ID) "
                        + "FROM VAB_AccountBook acs WHERE acs.VAB_AccountBook_ID=" + mas.GetVAB_AccountBook_ID() + ") "
                    + "WHERE VAF_JInstance_ID=" + GetVAF_JInstance_ID());
                no = DataBase.DB.ExecuteQuery(sql.ToString(), null, Get_TrxName());
                log.Fine("Convered=" + no);
            }

            //  Update Values
            no = DataBase.DB.ExecuteQuery("UPDATE VAT_StockData SET "
                + "PricePOAmt = QtyOnHand * PricePO, "
                + "PriceListAmt = QtyOnHand * PriceList, "
                + "PriceStdAmt = QtyOnHand * PriceStd, "
                + "PriceLimitAmt = QtyOnHand * PriceLimit, "
                + "CostStandardAmt = QtyOnHand * CostStandard, "
                + "CostAmt = QtyOnHand * Cost "
                + "WHERE VAF_JInstance_ID=" + GetVAF_JInstance_ID(), null, Get_TrxName());
            log.Fine("Calculation=" + no);
            //
            return msg;
        }
    }
}
