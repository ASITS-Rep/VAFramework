namespace ViennaAdvantage.Model{
/** Generated Model - DO NOT CHANGE */
using System;using System.Text;using VAdvantage.DataBase;using VAdvantage.Common;using VAdvantage.Classes;using VAdvantage.Process;using VAdvantage.Model;using VAdvantage.Utility;using System.Data;/** Generated Model for ASI03_Patient
 *  @author Raghu (Updated) 
 *  @version Vienna Framework 1.1.1 - $Id$ */
public class X_ASI03_Patient : PO{public X_ASI03_Patient (Context ctx, int ASI03_Patient_ID, Trx trxName) : base (ctx, ASI03_Patient_ID, trxName){/** if (ASI03_Patient_ID == 0){SetASI03_Patient_ID (0);} */
}public X_ASI03_Patient (Ctx ctx, int ASI03_Patient_ID, Trx trxName) : base (ctx, ASI03_Patient_ID, trxName){/** if (ASI03_Patient_ID == 0){SetASI03_Patient_ID (0);} */
}/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_ASI03_Patient (Context ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName){}/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_ASI03_Patient (Ctx ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName){}/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_ASI03_Patient (Ctx ctx, IDataReader dr, Trx trxName) : base(ctx, dr, trxName){}/** Static Constructor 
 Set Table ID By Table Name
 added by ->Harwinder */
static X_ASI03_Patient(){ Table_ID = Get_Table_ID(Table_Name); model = new KeyNamePair(Table_ID,Table_Name);}/** Serial Version No */
static long serialVersionUID = 27907260240745L;/** Last Updated Timestamp 2021-07-01 1:22:03 PM */
public static long updatedMS = 1625134923956L;/** AD_Table_ID=1000779 */
public static int Table_ID; // =1000779;
/** TableName=ASI03_Patient */
public static String Table_Name="ASI03_Patient";
protected static KeyNamePair model;protected Decimal accessLevel = new Decimal(3);/** AccessLevel
@return 3 - Client - Org 
*/
protected override int Get_AccessLevel(){return Convert.ToInt32(accessLevel.ToString());}/** Load Meta Data
@param ctx context
@return PO Info
*/
protected override POInfo InitPO (Context ctx){POInfo poi = POInfo.GetPOInfo (ctx, Table_ID);return poi;}/** Load Meta Data
@param ctx context
@return PO Info
*/
protected override POInfo InitPO (Ctx ctx){POInfo poi = POInfo.GetPOInfo (ctx, Table_ID);return poi;}/** Info
@return info
*/
public override String ToString(){StringBuilder sb = new StringBuilder ("X_ASI03_Patient[").Append(Get_ID()).Append("]");return sb.ToString();}/** Set ASI03_Patient_ID.
@param ASI03_Patient_ID ASI03_Patient_ID */
public void SetASI03_Patient_ID (int ASI03_Patient_ID){if (ASI03_Patient_ID < 1) throw new ArgumentException ("ASI03_Patient_ID is mandatory.");Set_ValueNoCheck ("ASI03_Patient_ID", ASI03_Patient_ID);}/** Get ASI03_Patient_ID.
@return ASI03_Patient_ID */
public int GetASI03_Patient_ID() {Object ii = Get_Value("ASI03_Patient_ID");if (ii == null) return 0;return Convert.ToInt32(ii);}/** Set Birthday.
@param Birthday Birthday or Anniversary day */
public void SetBirthday (DateTime? Birthday){Set_Value ("Birthday", (DateTime?)Birthday);}/** Get Birthday.
@return Birthday or Anniversary day */
public DateTime? GetBirthday() {return (DateTime?)Get_Value("Birthday");}/** Set Export.
@param Export_ID Export */
public void SetExport_ID (String Export_ID){if (Export_ID != null && Export_ID.Length > 50){log.Warning("Length > 50 - truncated");Export_ID = Export_ID.Substring(0,50);}Set_Value ("Export_ID", Export_ID);}/** Get Export.
@return Export */
public String GetExport_ID() {return (String)Get_Value("Export_ID");}
/** Gender AD_Reference_ID=1000020 */
public static int GENDER_AD_Reference_ID=1000020;/** Female = F */
public static String GENDER_Female = "F";/** Male = M */
public static String GENDER_Male = "M";/** Is test a valid value.
@param test testvalue
@returns true if valid **/
public bool IsGenderValid (String test){return test == null || test.Equals("F") || test.Equals("M");}/** Set Gender.
@param Gender Gender */
public void SetGender (String Gender){if (!IsGenderValid(Gender))
throw new ArgumentException ("Gender Invalid value - " + Gender + " - Reference_ID=1000020 - F - M");if (Gender != null && Gender.Length > 1){log.Warning("Length > 1 - truncated");Gender = Gender.Substring(0,1);}Set_Value ("Gender", Gender);}/** Get Gender.
@return Gender */
public String GetGender() {return (String)Get_Value("Gender");}/** Set Patient Name.
@param Name Patient Name */
public void SetName (String Name){if (Name != null && Name.Length > 500){log.Warning("Length > 500 - truncated");Name = Name.Substring(0,500);}Set_Value ("Name", Name);}/** Get Patient Name.
@return Patient Name */
public String GetName() {return (String)Get_Value("Name");}}
}