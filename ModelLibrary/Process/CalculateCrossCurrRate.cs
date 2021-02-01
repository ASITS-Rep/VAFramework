﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VAdvantage.Model;
using VAdvantage.DataBase;
using System.Data;
using VAdvantage.Logging;
using VAdvantage.Utility;
using VAdvantage.ProcessEngine;
namespace VAdvantage.Process
{
    public class CalculateCrossCurrRate : SvrProcess
    {
        StringBuilder retmsg = new StringBuilder();
        StringBuilder query = new StringBuilder();
        int FromCurr1 = 0;
        DateTime ValidFrom1 = new DateTime();
        DateTime ValidFrom2 = new DateTime();
        DateTime ValidTo1 = new DateTime();
        DateTime ValidTo2 = new DateTime();
        Decimal newMulRate = 0;
        Decimal newDivideRate = 0;
        Decimal MulRate1, MulRate2 = 0;
        DateTime newValidFrom = new DateTime();
        DateTime newValidTo = new DateTime();
        MVABExchangeRate conobj;
        MCurrCrossRate Currobj;
        DataSet dsobj;

        /// <summary>
        /// Process to get Cross Currency Rate
        /// </summary>
        /// <returns>message</returns>
        protected override string DoIt()
        {
            // Getting records from cross rate setting
            query.Append("SELECT * FROM C_CurrCrossRate WHERE IsActive='Y'");
            dsobj = DB.ExecuteDataset(query.ToString());
            query.Clear();

            if (dsobj != null && dsobj.Tables.Count > 0 && dsobj.Tables[0].Rows.Count > 0)
            {
                //for (int i = 0; i < dsobj.Tables[0].Rows.Count; i++)
                foreach (DataRow dr in dsobj.Tables[0].Rows)
                {
                    Currobj = new MCurrCrossRate(GetCtx(), dr, Get_Trx());
                    // Getting records from currency rate based on conditions
                    query.Append("SELECT VAF_Org_ID,VAB_Currency_ID,ValidFrom,ValidTo,MultiplyRate FROM VAB_ExchangeRate WHERE " + GlobalVariable.TO_DATE(DateTime.Now.Date, true) +
                        " BETWEEN ValidFrom AND ValidTo AND IsActive='Y' AND VAF_Org_ID=" + Currobj.GetVAF_Org_ID() + " AND VAB_CurrencyType_ID=" + Currobj.GetVAB_CurrencyType_ID() +
                        " AND VAB_Currency_To_ID=" + Currobj.GetVAB_Currency_ID() + " AND VAB_Currency_ID IN ('" + Currobj.GetVAB_Currency_From_ID() + "','" + Currobj.GetVAB_Currency_To_ID() + "')");
                    dsobj = DB.ExecuteDataset(query.ToString());
                    query.Clear();
                    if (dsobj != null && dsobj.Tables.Count > 0 && dsobj.Tables[0].Rows.Count == 2)
                    {
                        for (int j = 0; j < dsobj.Tables[0].Rows.Count; j++)
                        {
                            //Org_ID = Util.GetValueOfInt(ds.Tables[0].Rows[j]["VAF_Org_ID"]);
                            FromCurr1 = Util.GetValueOfInt(dsobj.Tables[0].Rows[j]["VAB_Currency_ID"]);
                            // Getting multiply rate from both records
                            if (Currobj.GetVAB_Currency_From_ID() == FromCurr1)
                            {
                                ValidFrom1 = Convert.ToDateTime(dsobj.Tables[0].Rows[j]["ValidFrom"]);
                                ValidTo1 = Convert.ToDateTime(dsobj.Tables[0].Rows[j]["ValidTo"]);
                                MulRate1 = Util.GetValueOfDecimal(dsobj.Tables[0].Rows[j]["MultiplyRate"]);
                            }
                            else if (Currobj.GetVAB_Currency_To_ID() == FromCurr1)
                            {
                                ValidFrom2 = Convert.ToDateTime(dsobj.Tables[0].Rows[j]["ValidFrom"]);
                                ValidTo2 = Convert.ToDateTime(dsobj.Tables[0].Rows[j]["ValidTo"]);
                                MulRate2 = Util.GetValueOfDecimal(dsobj.Tables[0].Rows[j]["MultiplyRate"]);
                            }
                            else
                            {
                                retmsg.Append("Error: " + Msg.GetMsg(GetCtx(), "VIS_CurrNotMatch"));
                            }
                        }
                        // Calculating new multiply rate & divide rate
                        if (MulRate2 > 0)
                        {
                            newMulRate = MulRate1 / MulRate2;
                            newDivideRate = 1 / newMulRate;
                        }
                        else
                        {
                            retmsg.Append("Error: " + Msg.GetMsg(GetCtx(), "ProductUOMConversionRateError"));
                        }

                        // Geting Valid from and valid to dates
                        if (ValidFrom1 <= ValidFrom2 && ValidTo1 <= ValidTo2)
                        {
                            newValidFrom = ValidFrom2;
                            newValidTo = ValidTo1;
                        }
                        else if (ValidFrom1 >= ValidFrom2 && ValidTo1 >= ValidTo2)
                        {
                            newValidFrom = ValidFrom1;
                            newValidTo = ValidTo2;
                        }
                        else if (ValidFrom1 <= ValidFrom2 && ValidTo1 >= ValidTo2)
                        {
                            newValidFrom = ValidFrom2;
                            newValidTo = ValidTo2;
                        }
                        else if (ValidFrom1 >= ValidFrom2 && ValidTo1 <= ValidTo2)
                        {
                            newValidFrom = ValidFrom1;
                            newValidTo = ValidTo1;
                        }
                        else
                        {
                            retmsg.Append(Msg.GetMsg(GetCtx(), "VIS_InvalidDate"));
                        }
                        query.Clear();
                        //int ID = DB.GetNextID(0, "VAB_ExchangeRate", null);
                        //query.Append("INSERT INTO VAB_ExchangeRate (VAF_Client_ID,VAF_Org_ID,VAB_ExchangeRate_ID,VAB_Currency_ID,VAB_Currency_To_ID,VAB_CurrencyType_ID,ValidFrom,ValidTo,MultiplyRate,DivideRate,CreatedBy,UpdatedBy) "
                        //    + "Values (" + Client_ID + ", " + Org_ID + ","+ ID +", " + FromCurr + ", " + ToCurr + ", " + CurrType + ", TO_DATE('" + newValidFrom.ToShortDateString() + "','MM-DD-YYYY'), TO_DATE('" + newValidTo.ToShortDateString() + "','MM-DD-YYYY') , " + newMulRate + ", " + newDivideRate + ", " + Client_ID + ", "+ Client_ID + ") ");
                        //int _updated = DB.ExecuteQuery(query.ToString(), null);
                        //if (_updated > 0)
                        //{
                        //    Msg.GetMsg("Record Inserted","");
                        //}
                        // Inserting new conversion in the currency rate
                        conobj = new MVABExchangeRate(GetCtx(), 0, Get_Trx());
                        conobj.SetVAF_Client_ID(Currobj.GetVAF_Client_ID());
                        conobj.SetVAF_Org_ID(Currobj.GetVAF_Org_ID());
                        conobj.SetVAB_Currency_ID(Currobj.GetVAB_Currency_From_ID());
                        conobj.SetVAB_Currency_To_ID(Currobj.GetVAB_Currency_To_ID());
                        conobj.SetVAB_CurrencyType_ID(Currobj.GetVAB_CurrencyType_ID());
                        conobj.SetValidFrom(newValidFrom);
                        conobj.SetValidTo(newValidTo);
                        conobj.SetMultiplyRate(newMulRate);
                        conobj.SetDivideRate(newDivideRate);
                        if (!conobj.Save())
                        {
                            ValueNamePair pp = VLogger.RetrieveError();
                            if (pp != null)
                            {
                                retmsg.Append(Msg.GetMsg(GetCtx(), "VIS_CrossRateNotCal") + ":- " + pp.GetName() + Currobj.GetName() + ", ");
                            }
                            else
                            {
                                retmsg.Append(Msg.GetMsg(GetCtx(), "VIS_CrossRateNotCal"));
                            }
                        }
                        else
                        {
                            retmsg.Append(Msg.GetMsg(GetCtx(), "VIS_CrossRateCal") + ":- " + Currobj.GetName() + ", ");
                        }
                    }
                    else
                    {
                        retmsg.Append(Msg.GetMsg(GetCtx(), "VIS_CrossRateNotCal") + ":- " + Currobj.GetName() + ", ");
                    }
                }
            }
            else
            {
                retmsg.Append(Msg.GetMsg(GetCtx(), "NoRecords"));
            }
            return retmsg.ToString();
        }

        protected override void Prepare()
        {
        }

    }
}

