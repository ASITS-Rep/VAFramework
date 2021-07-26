using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VAdvantage.DataBase;
using VAdvantage.Utility;
using VAdvantage.Model;
//using ViennaAdvantageSvc.Model;
//using ViennaAdvantageSvc.Model;

namespace VIS.Models
{
    public class Customer
    {

        public List<VIS_CustomerData> LoadCustomerData(Ctx ctx)
        {
            List<VIS_CustomerData> cusData = new List<VIS_CustomerData>();
            string sql = "SELECT VIS_CustomerInformation2_ID, VIS_Title, VIS_FirstName, VIS_LastName, VIS_Gender, VIS_BirthDate FROM VIS_CustomerInformation2 ";
            var dr = DB.ExecuteReader(sql);
            if (dr != null)
            {
                while (dr.Read())
                {
                    VIS_CustomerData eData = new VIS_CustomerData();
                    eData.Id = Util.GetValueOfInt(dr["VIS_CustomerInformation2_ID"]);
                    eData.Title = Util.GetValueOfString(dr["VIS_Title"]);
                    eData.FirstName = Util.GetValueOfString(dr["VIS_FirstName"]);
                    eData.LastName = Util.GetValueOfString(dr["VIS_LastName"]);
                    eData.Gender = Util.GetValueOfString(dr["VIS_Gender"]);
                    eData.BDate = Util.GetValueOfDateTime(dr["VIS_BirthDate"]);

                    cusData.Add(eData);
                }
                dr.Close();
                dr = null;
            }
            return cusData;
        }

        public List<VIS_CustomerData> SearchCustomerData(Ctx ctx, String search)
        {

            List<VIS_CustomerData> cusData = new List<VIS_CustomerData>();
            string sql = "SELECT VIS_CustomerInformation2_ID, VIS_Title, VIS_FirstName, VIS_LastName, VIS_Gender, VIS_BirthDate FROM VIS_CustomerInformation2 where VIS_FirstName LIKE '%" + search + "%'";
            var dr = DB.ExecuteReader(sql);
            if (dr != null)
            {
                VIS_CustomerData eData = new VIS_CustomerData();
                while (dr.Read())
                {
                    eData.Id = Util.GetValueOfInt(dr["VIS_CustomerInformation2_ID"]);
                    eData.Title = Util.GetValueOfString(dr["VIS_Title"]);
                    eData.FirstName = Util.GetValueOfString(dr["VIS_FirstName"]);
                    eData.LastName = Util.GetValueOfString(dr["VIS_LastName"]);
                    eData.Gender = Util.GetValueOfString(dr["VIS_Gender"]);
                    eData.BDate = Util.GetValueOfDateTime(dr["VIS_BirthDate"]);

                    cusData.Add(eData);
                }
                dr.Close();
                dr = null;
            }
            return cusData;
        }



        public List<VIS_CustomerData> GettitleData(Ctx ctx)
        {
            List<VIS_CustomerData> grades = new List<VIS_CustomerData>();
            string sql = "SELECT value,name FROM ad_ref_list WHERE ad_reference_id=(SELECT ad_reference_id FROM ad_reference WHERE name='VIS_Title')";
            var dr = DB.ExecuteReader(sql);
            if (dr != null)
            {
                while (dr.Read())
                {
                    VIS_CustomerData grade = new VIS_CustomerData();
                    grade.ID = Util.GetValueOfString(dr["value"]);
                    grade.Value = Util.GetValueOfString(dr["name"]);
                    grades.Add(grade);
                }
                dr.Close();
                dr = null;
            }

            return grades;
        }

        public bool Save(Ctx ctx, string title, string fname, string lname, string gender, string date)
        {
            MVISCustomerInformation2 obj = new MVISCustomerInformation2(ctx, 0, null);
            obj.SetVIS_FirstName(fname);
            obj.SetVIS_LastName(lname);
            obj.SetVIS_Gender(gender);
            obj.SetVIS_Title(title);
            if (date != "")
            {
                obj.SetVIS_BirthDate(Convert.ToDateTime(date));
            }
            if (!obj.Save())
            {
                return false;
            }
            return true;
        }


        public List<VIS_CustomerData> GetgenderData(Ctx ctx)
        {
            List<VIS_CustomerData> grades = new List<VIS_CustomerData>();
            string sql = "SELECT value,name FROM ad_ref_list WHERE ad_reference_id=(SELECT ad_reference_id FROM ad_reference WHERE name='VIS_Gender')";
            var dr = DB.ExecuteReader(sql);
            if (dr != null)
            {
                while (dr.Read())
                {
                    VIS_CustomerData grade = new VIS_CustomerData();
                    grade.ID = Util.GetValueOfString(dr["value"]);
                    grade.Value = Util.GetValueOfString(dr["name"]);
                    grades.Add(grade);
                }
                dr.Close();
                dr = null;
            }

            return grades;
        }
    }


public class VIS_CustomerData
    {
        public string bdy { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Gender { get; set; }
        public DateTime? BDate { get; set; }
        public string ID { get; set; }
        public string Value { get; set; }
    }

}