using System;
using System.Collections.Generic;
using System.Linq;
using VAdvantage.DataBase;
using VAdvantage.Model;
using VAdvantage.Utility;
using System.Data;
using VIS.Models;
using System.Text;
using VIS.DataContracts;
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;
using System.Web.Hosting;
using VAdvantage.Classes;
using DB = VIS.DBase.DB;
using ViennaAdvantage.Model;

namespace VIS.Helpers
{
    public class ClinicHelper
    {
        DataSet dsData = new DataSet();
        string strQuery = "";

        public HomeModels getHomeAlrtCount(Ctx ctx) 
        {
            HomeModels objHome = new HomeModels();
            #region Clinic Sessions Count
            //To get Notice Count
            strQuery = MRole.Get(ctx, ctx.GetAD_Role_ID()).AddAccessSQL("SELECT count(ASI03_Session_ID) FROM ASI03_Session "
                , "ASI03_Session", MRole.SQL_FULLYQUALIFIED, MRole.SQL_RO);
            strQuery += " AND AD_User_ID IN (" + ctx.GetAD_User_ID() + ")"
              + " AND IsActive='Y'";
            dsData = new DataSet();
            dsData = DB.ExecuteDataset(strQuery);
            int nSessions = 0;
            if (dsData != null)
            {
                nSessions = Util.GetValueOfInt(dsData.Tables[0].Rows[0][0].ToString());
            }
            #endregion

            objHome.ClinicSessionsCnt = nSessions;

            return objHome;
        }

        # region Start Sessions
        //Count of notice
        public int getClinicSessionsCount(Ctx ctx)
        {
            int scount = 0;
            try
            {
                //To get Notice Count
                strQuery = MRole.Get(ctx, ctx.GetAD_Role_ID()).AddAccessSQL("SELECT count(ASI03_Session_ID) FROM ASI03_Session "
                    , "ASI03_Session", MRole.SQL_FULLYQUALIFIED, MRole.SQL_RO);
                strQuery += " AND AD_User_ID IN (" + ctx.GetAD_User_ID() + ")"
                  + " AND IsActive='Y'";

                dsData = new DataSet();
                dsData = DB.ExecuteDataset(strQuery);
                scount = Util.GetValueOfInt(dsData.Tables[0].Rows[0][0].ToString());
            }
            catch (Exception)
            {

            }
            return scount;
        }

        public List<HomeClinic> getClinicSessions(Ctx ctx, int PageSize, int page)
        {
            List<HomeClinic> listSessions = new List<HomeClinic>();
            strQuery = @"Select s.ASI03_Session_ID, to_char(s.asi03_startdate, 'YYYY-MM-DD HH24:MI am') as StartTime," +
                        "to_char(s.asi03_enddate, 'YYYY-MM-DD HH24:MI am') as EndTime," +
                        "d.ASI03_Department_ID, d.name as DepartmentName, p.ASI03_Patient_ID, p.name as PatientName, rl.name, rl.value" +
                        "from ASI03_Session s" +
                        "INNER JOIN ASI03_Department d ON d.ASI03_Department_ID = s.ASI03_Department_ID" +
                        "INNER JOIN ASI03_Patient p ON p.ASI03_Patient_ID = s.ASI03_Patient_ID" +
                        "INNER JOIN ad_ref_list rl ON rl.value = s.ASI03_Type;";
            dsData = DB.ExecuteDatasetPaging(strQuery, page, PageSize);
            dsData = VAdvantage.DataBase.DB.SetUtcDateTime(dsData);
            if (dsData != null)
            {
                for (int i = 0; i < dsData.Tables[0].Rows.Count; i++)
                {
                    var Sess = new HomeClinic();
                    Sess.ASI03_Session_ID = Util.GetValueOfInt(dsData.Tables[0].Rows[i]["ASI03_Session_ID"].ToString());
                    Sess.ASI03_Department_ID = Util.GetValueOfInt(dsData.Tables[0].Rows[i]["ASI03_Department_ID"].ToString());
                    Sess.DepartmentName = Util.GetValueOfString(dsData.Tables[0].Rows[i]["DepartmentName"].ToString());
                    Sess.ASI03_Patient_ID = Util.GetValueOfInt(dsData.Tables[0].Rows[i]["ASI03_Patient"].ToString());
                    Sess.PatientName = Util.GetValueOfString(dsData.Tables[0].Rows[i]["PatientName"].ToString());
                    Sess.ASI03_Startdate = (DateTime)Util.GetValueOfDateTime(dsData.Tables[0].Rows[i]["StartTime"].ToString());
                    Sess.ASI03_EndDate = (DateTime)Util.GetValueOfDateTime(dsData.Tables[0].Rows[i]["EndTime"].ToString());
                    listSessions.Add(Sess);
                }
            }

                return listSessions;
        }
        #endregion

        public bool EnterPatient(Ctx ctx, int ASI03_Session_ID)
        {
            
            MASI03Session objSess = new MASI03Session(ctx, ASI03_Session_ID, null);
            objSess.SetASI03_isPatEnter(true);
            if (objSess.Save())
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}