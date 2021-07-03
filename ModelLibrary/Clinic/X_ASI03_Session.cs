namespace ViennaAdvantage.Model{
/** Generated Model - DO NOT CHANGE */
using System;using System.Text;using VAdvantage.DataBase;using VAdvantage.Common;using VAdvantage.Classes;using VAdvantage.Process;using VAdvantage.Model;using VAdvantage.Utility;using System.Data;/** Generated Model for ASI03_Session
 *  @author Raghu (Updated) 
 *  @version Vienna Framework 1.1.1 - $Id$ */
public class X_ASI03_Session : PO{public X_ASI03_Session (Context ctx, int ASI03_Session_ID, Trx trxName) : base (ctx, ASI03_Session_ID, trxName){/** if (ASI03_Session_ID == 0){SetASI03_Session_ID (0);} */
}public X_ASI03_Session (Ctx ctx, int ASI03_Session_ID, Trx trxName) : base (ctx, ASI03_Session_ID, trxName){/** if (ASI03_Session_ID == 0){SetASI03_Session_ID (0);} */
}/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_ASI03_Session (Context ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName){}/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_ASI03_Session (Ctx ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName){}/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_ASI03_Session (Ctx ctx, IDataReader dr, Trx trxName) : base(ctx, dr, trxName){}/** Static Constructor 
 Set Table ID By Table Name
 added by ->Harwinder */
static X_ASI03_Session(){ Table_ID = Get_Table_ID(Table_Name); model = new KeyNamePair(Table_ID,Table_Name);}/** Serial Version No */
static long serialVersionUID = 27907260249893L;/** Last Updated Timestamp 2021-07-01 1:22:13 PM */
public static long updatedMS = 1625134933104L;/** AD_Table_ID=1000777 */
public static int Table_ID; // =1000777;
/** TableName=ASI03_Session */
public static String Table_Name="ASI03_Session";
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
public override String ToString(){StringBuilder sb = new StringBuilder ("X_ASI03_Session[").Append(Get_ID()).Append("]");return sb.ToString();}/** Set ASI03_Department_ID.
@param ASI03_Department_ID ASI03_Department_ID */
public void SetASI03_Department_ID (int ASI03_Department_ID){if (ASI03_Department_ID <= 0) Set_Value ("ASI03_Department_ID", null);else
Set_Value ("ASI03_Department_ID", ASI03_Department_ID);}/** Get ASI03_Department_ID.
@return ASI03_Department_ID */
public int GetASI03_Department_ID() {Object ii = Get_Value("ASI03_Department_ID");if (ii == null) return 0;return Convert.ToInt32(ii);}/** Set Session End Date.
@param ASI03_EndDate Session End Date */
public void SetASI03_EndDate (DateTime? ASI03_EndDate){Set_Value ("ASI03_EndDate", (DateTime?)ASI03_EndDate);}/** Get Session End Date.
@return Session End Date */
public DateTime? GetASI03_EndDate() {return (DateTime?)Get_Value("ASI03_EndDate");}/** Set ASI03_Patient_ID.
@param ASI03_Patient_ID ASI03_Patient_ID */
public void SetASI03_Patient_ID (int ASI03_Patient_ID){if (ASI03_Patient_ID <= 0) Set_Value ("ASI03_Patient_ID", null);else
Set_Value ("ASI03_Patient_ID", ASI03_Patient_ID);}/** Get ASI03_Patient_ID.
@return ASI03_Patient_ID */
public int GetASI03_Patient_ID() {Object ii = Get_Value("ASI03_Patient_ID");if (ii == null) return 0;return Convert.ToInt32(ii);}/** Set ASI03_Session_ID.
@param ASI03_Session_ID ASI03_Session_ID */
public void SetASI03_Session_ID (int ASI03_Session_ID){if (ASI03_Session_ID < 1) throw new ArgumentException ("ASI03_Session_ID is mandatory.");Set_ValueNoCheck ("ASI03_Session_ID", ASI03_Session_ID);}/** Get ASI03_Session_ID.
@return ASI03_Session_ID */
public int GetASI03_Session_ID() {Object ii = Get_Value("ASI03_Session_ID");if (ii == null) return 0;return Convert.ToInt32(ii);}/** Set Session Start Date.
@param ASI03_Startdate Session Start Date */
public void SetASI03_Startdate (DateTime? ASI03_Startdate){Set_Value ("ASI03_Startdate", (DateTime?)ASI03_Startdate);}/** Get Session Start Date.
@return Session Start Date */
public DateTime? GetASI03_Startdate() {return (DateTime?)Get_Value("ASI03_Startdate");}
/** ASI03_Type AD_Reference_ID=1000287 */
public static int ASI03_TYPE_AD_Reference_ID=1000287;/** Beauty = BET */
public static String ASI03_TYPE_Beauty = "BET";/** Dental = DET */
public static String ASI03_TYPE_Dental = "DET";/** Is test a valid value.
@param test testvalue
@returns true if valid **/
public bool IsASI03_TypeValid (String test){return test == null || test.Equals("BET") || test.Equals("DET");}/** Set Type.
@param ASI03_Type Type */
public void SetASI03_Type (String ASI03_Type){if (!IsASI03_TypeValid(ASI03_Type))
throw new ArgumentException ("ASI03_Type Invalid value - " + ASI03_Type + " - Reference_ID=1000287 - BET - DET");if (ASI03_Type != null && ASI03_Type.Length > 3){log.Warning("Length > 3 - truncated");ASI03_Type = ASI03_Type.Substring(0,3);}Set_Value ("ASI03_Type", ASI03_Type);}/** Get Type.
@return Type */
public String GetASI03_Type() {return (String)Get_Value("ASI03_Type");}/** Set Export.
@param Export_ID Export */
public void SetExport_ID (String Export_ID){if (Export_ID != null && Export_ID.Length > 50){log.Warning("Length > 50 - truncated");Export_ID = Export_ID.Substring(0,50);}Set_Value ("Export_ID", Export_ID);}/** Get Export.
@return Export */
public String GetExport_ID() {return (String)Get_Value("Export_ID");}}
}