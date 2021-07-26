namespace ViennaAdvantage.Model{
/** Generated Model - DO NOT CHANGE */
using System;using System.Text;using VAdvantage.DataBase;using VAdvantage.Common;using VAdvantage.Classes;using VAdvantage.Process;using VAdvantage.Model;using VAdvantage.Utility;using System.Data;/** Generated Model for VIS_CustomerInformation2
 *  @author Raghu (Updated) 
 *  @version Vienna Framework 1.1.1 - $Id$ */
public class X_VIS_CustomerInformation2 : PO{public X_VIS_CustomerInformation2 (Context ctx, int VIS_CustomerInformation2_ID, Trx trxName) : base (ctx, VIS_CustomerInformation2_ID, trxName){/** if (VIS_CustomerInformation2_ID == 0){SetVIS_CustomerInformation2_ID (0);} */
}public X_VIS_CustomerInformation2 (Ctx ctx, int VIS_CustomerInformation2_ID, Trx trxName) : base (ctx, VIS_CustomerInformation2_ID, trxName){/** if (VIS_CustomerInformation2_ID == 0){SetVIS_CustomerInformation2_ID (0);} */
}/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_VIS_CustomerInformation2 (Context ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName){}/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_VIS_CustomerInformation2 (Ctx ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName){}/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_VIS_CustomerInformation2 (Ctx ctx, IDataReader dr, Trx trxName) : base(ctx, dr, trxName){}/** Static Constructor 
 Set Table ID By Table Name
 added by ->Harwinder */
static X_VIS_CustomerInformation2(){ Table_ID = Get_Table_ID(Table_Name); model = new KeyNamePair(Table_ID,Table_Name);}/** Serial Version No */
static long serialVersionUID = 27908739105625L;/** Last Updated Timestamp 7/18/2021 4:09:49 PM */
public static long updatedMS = 1626613788836L;/** AD_Table_ID=1000779 */
public static int Table_ID; // =1000779;
/** TableName=VIS_CustomerInformation2 */
public static String Table_Name="VIS_CustomerInformation2";
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
public override String ToString(){StringBuilder sb = new StringBuilder ("X_VIS_CustomerInformation2[").Append(Get_ID()).Append("]");return sb.ToString();}/** Set Export.
@param Export_ID Export */
public void SetExport_ID (String Export_ID){if (Export_ID != null && Export_ID.Length > 50){log.Warning("Length > 50 - truncated");Export_ID = Export_ID.Substring(0,50);}Set_Value ("Export_ID", Export_ID);}/** Get Export.
@return Export */
public String GetExport_ID() {return (String)Get_Value("Export_ID");}/** Set BirthDate.
@param VIS_BirthDate BirthDate */
public void SetVIS_BirthDate (DateTime? VIS_BirthDate){Set_Value ("VIS_BirthDate", (DateTime?)VIS_BirthDate);}/** Get BirthDate.
@return BirthDate */
public DateTime? GetVIS_BirthDate() {return (DateTime?)Get_Value("VIS_BirthDate");}/** Set VIS_CustomerInformation2_ID.
@param VIS_CustomerInformation2_ID VIS_CustomerInformation2_ID */
public void SetVIS_CustomerInformation2_ID (int VIS_CustomerInformation2_ID){if (VIS_CustomerInformation2_ID < 1) throw new ArgumentException ("VIS_CustomerInformation2_ID is mandatory.");Set_ValueNoCheck ("VIS_CustomerInformation2_ID", VIS_CustomerInformation2_ID);}/** Get VIS_CustomerInformation2_ID.
@return VIS_CustomerInformation2_ID */
public int GetVIS_CustomerInformation2_ID() {Object ii = Get_Value("VIS_CustomerInformation2_ID");if (ii == null) return 0;return Convert.ToInt32(ii);}/** Set First Name.
@param VIS_FirstName First Name */
public void SetVIS_FirstName (String VIS_FirstName){if (VIS_FirstName != null && VIS_FirstName.Length > 20){log.Warning("Length > 20 - truncated");VIS_FirstName = VIS_FirstName.Substring(0,20);}Set_Value ("VIS_FirstName", VIS_FirstName);}/** Get First Name.
@return First Name */
public String GetVIS_FirstName() {return (String)Get_Value("VIS_FirstName");}
/** VIS_Gender AD_Reference_ID=1000291 */
public static int VIS_GENDER_AD_Reference_ID=1000291;/** Female = F */
public static String VIS_GENDER_Female = "F";/** Male = M */
public static String VIS_GENDER_Male = "M";/** Is test a valid value.
@param test testvalue
@returns true if valid **/
public bool IsVIS_GenderValid (String test){return test == null || test.Equals("F") || test.Equals("M");}/** Set Gender.
@param VIS_Gender Gender */
public void SetVIS_Gender (String VIS_Gender){if (!IsVIS_GenderValid(VIS_Gender))
throw new ArgumentException ("VIS_Gender Invalid value - " + VIS_Gender + " - Reference_ID=1000291 - F - M");if (VIS_Gender != null && VIS_Gender.Length > 1){log.Warning("Length > 1 - truncated");VIS_Gender = VIS_Gender.Substring(0,1);}Set_Value ("VIS_Gender", VIS_Gender);}/** Get Gender.
@return Gender */
public String GetVIS_Gender() {return (String)Get_Value("VIS_Gender");}/** Set Last Name.
@param VIS_LastName Last Name */
public void SetVIS_LastName (String VIS_LastName){if (VIS_LastName != null && VIS_LastName.Length > 20){log.Warning("Length > 20 - truncated");VIS_LastName = VIS_LastName.Substring(0,20);}Set_Value ("VIS_LastName", VIS_LastName);}/** Get Last Name.
@return Last Name */
public String GetVIS_LastName() {return (String)Get_Value("VIS_LastName");}
/** VIS_Title AD_Reference_ID=1000292 */
public static int VIS_TITLE_AD_Reference_ID=1000292;/** Mr = Mr */
public static String VIS_TITLE_Mr = "Mr";/** Miss = Ms */
public static String VIS_TITLE_Miss = "Ms";/** Is test a valid value.
@param test testvalue
@returns true if valid **/
public bool IsVIS_TitleValid (String test){return test == null || test.Equals("Mr") || test.Equals("Ms");}/** Set VIS_Title.
@param VIS_Title VIS_Title */
public void SetVIS_Title (String VIS_Title){if (!IsVIS_TitleValid(VIS_Title))
throw new ArgumentException ("VIS_Title Invalid value - " + VIS_Title + " - Reference_ID=1000292 - Mr - Ms");if (VIS_Title != null && VIS_Title.Length > 2){log.Warning("Length > 2 - truncated");VIS_Title = VIS_Title.Substring(0,2);}Set_Value ("VIS_Title", VIS_Title);}/** Get VIS_Title.
@return VIS_Title */
public String GetVIS_Title() {return (String)Get_Value("VIS_Title");}}
}