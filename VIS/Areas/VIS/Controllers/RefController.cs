using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VAdvantage.DataBase;
using VAdvantage.Model;
using VAdvantage.Utility;

namespace VIS.Models
{
    public class Ref
    {


        public List<ASI03_SessionsData> LoadSessionsData(Ctx ctx, int AD_Client_ID)
        {
            List<ASI03_SessionsData> sessData = new List<ASI03_SessionsData>();
            string sql = "Select ad_ref_list rl WJERE rl.value = VIS_Title";
            var dr = DB.ExecuteReader(sql);
            if (dr != null)
            {
                while (dr.Read())
                {
                    ASI03_SessionsData sData = new ASI03_SessionsData();
                    sData.SessID = Util.GetValueOfInt(dr["ASI03_Sessions_ID"]);
                    sData.Patient = Util.GetValueOfString(dr["asi03_name"]);
                    sData.Department = Util.GetValueOfString(dr["asi03_departmentname"]);
                    sData.Type = Util.GetValueOfString(dr["name"]);
                    sData.TypeValue = Util.GetValueOfString(dr["value"]);
                    sData.SDate = Util.GetValueOfDateTime(dr["StartTime"]);
                    sData.EDate = Util.GetValueOfDateTime(dr["EndTime"]);
                    sData.DepID = Util.GetValueOfInt(dr["ASI03_Departments_ID"]);
                    sData.PatID = Util.GetValueOfInt(dr["ASI03_Patients_ID"]);
                    sessData.Add(sData);
                }
                dr.Close();
                dr = null;
            }
            return sessData;
        }

        public class ASI03_SessionsData
        {
            public int SessID { get; set; }
            public string Patient { get; set; }
            public string Department { get; set; }
            public string Type { get; set; }
            public DateTime? SDate { get; set; }
            public DateTime? EDate { get; set; }
            public int DepID { get; set; }
            public int PatID { get; set; }
            public string TypeValue { get; set; }
        }

        //    internal object Save(Ctx ctx, int v1, int v2, int v3, string startDate, string endDate)
        //    {
        //        throw new NotImplementedException();
        //    }

        //}

    }
}