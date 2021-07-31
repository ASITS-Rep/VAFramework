namespace ViennaAdvantage.Model{
/** Generated Model - DO NOT CHANGE */
using System;using System.Text;using VAdvantage.DataBase;using VAdvantage.Common;using VAdvantage.Classes;using VAdvantage.Process;using VAdvantage.Model;using VAdvantage.Utility;using System.Data;/** Generated Model for ASI03_Storage
 *  @author Raghu (Updated) 
 *  @version Vienna Framework 1.1.1 - $Id$ */
public class X_ASI03_Storage : PO{public X_ASI03_Storage (Context ctx, int ASI03_Storage_ID, Trx trxName) : base (ctx, ASI03_Storage_ID, trxName){/** if (ASI03_Storage_ID == 0){SetASI03_Storage_ID (0);} */
}public X_ASI03_Storage (Ctx ctx, int ASI03_Storage_ID, Trx trxName) : base (ctx, ASI03_Storage_ID, trxName){/** if (ASI03_Storage_ID == 0){SetASI03_Storage_ID (0);} */
}/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_ASI03_Storage (Context ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName){}/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_ASI03_Storage (Ctx ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName){}/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_ASI03_Storage (Ctx ctx, IDataReader dr, Trx trxName) : base(ctx, dr, trxName){}/** Static Constructor 
 Set Table ID By Table Name
 added by ->Harwinder */
static X_ASI03_Storage(){ Table_ID = Get_Table_ID(Table_Name); model = new KeyNamePair(Table_ID,Table_Name);}/** Serial Version No */
static long serialVersionUID = 27909774115817L;/** Last Updated Timestamp 2021-07-30 3:39:59 PM */
public static long updatedMS = 1627648799028L;/** AD_Table_ID=1000780 */
public static int Table_ID; // =1000780;
/** TableName=ASI03_Storage */
public static String Table_Name="ASI03_Storage";
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
public override String ToString(){StringBuilder sb = new StringBuilder ("X_ASI03_Storage[").Append(Get_ID()).Append("]");return sb.ToString();}/** Set Storage Code.
@param ASI03_StorageCode Storage Code */
public void SetASI03_StorageCode (String ASI03_StorageCode){if (ASI03_StorageCode != null && ASI03_StorageCode.Length > 5){log.Warning("Length > 5 - truncated");ASI03_StorageCode = ASI03_StorageCode.Substring(0,5);}Set_Value ("ASI03_StorageCode", ASI03_StorageCode);}/** Get Storage Code.
@return Storage Code */
public String GetASI03_StorageCode() {return (String)Get_Value("ASI03_StorageCode");}/** Set ASI03_Storage_ID.
@param ASI03_Storage_ID ASI03_Storage_ID */
public void SetASI03_Storage_ID (int ASI03_Storage_ID){if (ASI03_Storage_ID < 1) throw new ArgumentException ("ASI03_Storage_ID is mandatory.");Set_ValueNoCheck ("ASI03_Storage_ID", ASI03_Storage_ID);}/** Get ASI03_Storage_ID.
@return ASI03_Storage_ID */
public int GetASI03_Storage_ID() {Object ii = Get_Value("ASI03_Storage_ID");if (ii == null) return 0;return Convert.ToInt32(ii);}/** Set Export.
@param Export_ID Export */
public void SetExport_ID (String Export_ID){if (Export_ID != null && Export_ID.Length > 50){log.Warning("Length > 50 - truncated");Export_ID = Export_ID.Substring(0,50);}Set_Value ("Export_ID", Export_ID);}/** Get Export.
@return Export */
public String GetExport_ID() {return (String)Get_Value("Export_ID");}/** Set Storage Name.
@param Name Storage Name */
public void SetName (String Name){if (Name != null && Name.Length > 50){log.Warning("Length > 50 - truncated");Name = Name.Substring(0,50);}Set_Value ("Name", Name);}/** Get Storage Name.
@return Storage Name */
public String GetName() {return (String)Get_Value("Name");}}
}