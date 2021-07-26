namespace VAdvantage.Model{
/** Generated Model - DO NOT CHANGE */
using System;using System.Text;using VAdvantage.DataBase;using VAdvantage.Common;using VAdvantage.Classes;using VAdvantage.Process;using VAdvantage.Model;using VAdvantage.Utility;using System.Data;/** Generated Model for VIS_CustomerInformation
 *  @author Raghu (Updated) 
 *  @version Vienna Framework 1.1.1 - $Id$ */
public class X_VIS_CustomerInformation : PO{public X_VIS_CustomerInformation (Context ctx, int VIS_CustomerInformation_ID, Trx trxName) : base (ctx, VIS_CustomerInformation_ID, trxName){/** if (VIS_CustomerInformation_ID == 0){} */
}public X_VIS_CustomerInformation (Ctx ctx, int VIS_CustomerInformation_ID, Trx trxName) : base (ctx, VIS_CustomerInformation_ID, trxName){/** if (VIS_CustomerInformation_ID == 0){} */
}/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_VIS_CustomerInformation (Context ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName){}/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_VIS_CustomerInformation (Ctx ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName){}/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_VIS_CustomerInformation (Ctx ctx, IDataReader dr, Trx trxName) : base(ctx, dr, trxName){}/** Static Constructor 
 Set Table ID By Table Name
 added by ->Harwinder */
static X_VIS_CustomerInformation(){ Table_ID = Get_Table_ID(Table_Name); model = new KeyNamePair(Table_ID,Table_Name);}/** Serial Version No */
static long serialVersionUID = 27908221722606L;/** Last Updated Timestamp 7/12/2021 4:26:45 PM */
public static long updatedMS = 1626096405817L;/** AD_Table_ID=1000777 */
public static int Table_ID; // =1000777;
/** TableName=VIS_CustomerInformation */
public static String Table_Name="VIS_CustomerInformation";
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
public override String ToString(){StringBuilder sb = new StringBuilder ("X_VIS_CustomerInformation[").Append(Get_ID()).Append("]");return sb.ToString();}/** Set Export.
@param Export_ID Export */
public void SetExport_ID (String Export_ID){if (Export_ID != null && Export_ID.Length > 50){log.Warning("Length > 50 - truncated");Export_ID = Export_ID.Substring(0,50);}Set_Value ("Export_ID", Export_ID);}/** Get Export.
@return Export */
public String GetExport_ID() {return (String)Get_Value("Export_ID");}/** Set Birth Date.
@param VIS_BirthDate Birth Date */
public void SetVIS_BirthDate (DateTime? VIS_BirthDate){Set_Value ("VIS_BirthDate", (DateTime?)VIS_BirthDate);}/** Get Birth Date.
@return Birth Date */
public DateTime? GetVIS_BirthDate() {return (DateTime?)Get_Value("VIS_BirthDate");}/** Set First Name.
@param VIS_FirstName First Name */
public void SetVIS_FirstName (String VIS_FirstName){if (VIS_FirstName != null && VIS_FirstName.Length > 20){log.Warning("Length > 20 - truncated");VIS_FirstName = VIS_FirstName.Substring(0,20);}Set_Value ("VIS_FirstName", VIS_FirstName);}/** Get First Name.
@return First Name */
public String GetVIS_FirstName() {return (String)Get_Value("VIS_FirstName");}
/** VIS_Gender AD_Reference_ID=1000291 */
public static int VIS_GENDER_AD_Reference_ID=1000291;/** M = 10000008 */
public static String VIS_GENDER_M = "10000008";/** F = 10000009 */
public static String VIS_GENDER_F = "10000009";/** Is test a valid value.
@param test testvalue
@returns true if valid **/
public bool IsVIS_GenderValid (String test){return test == null || test.Equals("10000008") || test.Equals("10000009");}/** Set Gender.
@param VIS_Gender Gender */
public void SetVIS_Gender (String VIS_Gender){if (!IsVIS_GenderValid(VIS_Gender))
throw new ArgumentException ("VIS_Gender Invalid value - " + VIS_Gender + " - Reference_ID=1000291 - 10000008 - 10000009");if (VIS_Gender != null && VIS_Gender.Length > 2){log.Warning("Length > 2 - truncated");VIS_Gender = VIS_Gender.Substring(0,2);}Set_Value ("VIS_Gender", VIS_Gender);}/** Get Gender.
@return Gender */
public String GetVIS_Gender() {return (String)Get_Value("VIS_Gender");}/** Set Last Name.
@param VIS_LastName Last Name */
public void SetVIS_LastName (String VIS_LastName){if (VIS_LastName != null && VIS_LastName.Length > 20){log.Warning("Length > 20 - truncated");VIS_LastName = VIS_LastName.Substring(0,20);}Set_Value ("VIS_LastName", VIS_LastName);}/** Get Last Name.
@return Last Name */
public String GetVIS_LastName() {return (String)Get_Value("VIS_LastName");}
/** VIS_Title AD_Reference_ID=1000292 */
public static int VIS_TITLE_AD_Reference_ID=1000292;/** Mr = 10000010 */
public static String VIS_TITLE_Mr = "10000010";/** Ms = 10000011 */
public static String VIS_TITLE_Ms = "10000011";/** Is test a valid value.
@param test testvalue
@returns true if valid **/
public bool IsVIS_TitleValid (String test){return test == null || test.Equals("10000010") || test.Equals("10000011");}/** Set VIS_Title.
@param VIS_Title VIS_Title */
public void SetVIS_Title (String VIS_Title){if (!IsVIS_TitleValid(VIS_Title))
throw new ArgumentException ("VIS_Title Invalid value - " + VIS_Title + " - Reference_ID=1000292 - 10000010 - 10000011");if (VIS_Title != null && VIS_Title.Length > 1){log.Warning("Length > 1 - truncated");VIS_Title = VIS_Title.Substring(0,1);}Set_Value ("VIS_Title", VIS_Title);}/** Get VIS_Title.
@return VIS_Title */
public String GetVIS_Title() {return (String)Get_Value("VIS_Title");}}
}