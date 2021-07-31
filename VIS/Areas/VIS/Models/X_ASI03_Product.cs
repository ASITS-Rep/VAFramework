namespace ViennaAdvantage.Model{
/** Generated Model - DO NOT CHANGE */
using System;using System.Text;using VAdvantage.DataBase;using VAdvantage.Common;using VAdvantage.Classes;using VAdvantage.Process;using VAdvantage.Model;using VAdvantage.Utility;using System.Data;/** Generated Model for ASI03_Product
 *  @author Raghu (Updated) 
 *  @version Vienna Framework 1.1.1 - $Id$ */
public class X_ASI03_Product : PO{public X_ASI03_Product (Context ctx, int ASI03_Product_ID, Trx trxName) : base (ctx, ASI03_Product_ID, trxName){/** if (ASI03_Product_ID == 0){SetASI03_Product_ID (0);} */
}public X_ASI03_Product (Ctx ctx, int ASI03_Product_ID, Trx trxName) : base (ctx, ASI03_Product_ID, trxName){/** if (ASI03_Product_ID == 0){SetASI03_Product_ID (0);} */
}/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_ASI03_Product (Context ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName){}/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_ASI03_Product (Ctx ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName){}/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_ASI03_Product (Ctx ctx, IDataReader dr, Trx trxName) : base(ctx, dr, trxName){}/** Static Constructor 
 Set Table ID By Table Name
 added by ->Harwinder */
static X_ASI03_Product(){ Table_ID = Get_Table_ID(Table_Name); model = new KeyNamePair(Table_ID,Table_Name);}/** Serial Version No */
static long serialVersionUID = 27909774095724L;/** Last Updated Timestamp 2021-07-30 3:39:38 PM */
public static long updatedMS = 1627648778935L;/** AD_Table_ID=1000785 */
public static int Table_ID; // =1000785;
/** TableName=ASI03_Product */
public static String Table_Name="ASI03_Product";
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
public override String ToString(){StringBuilder sb = new StringBuilder ("X_ASI03_Product[").Append(Get_ID()).Append("]");return sb.ToString();}/** Set Product Code.
@param ASI03_ProductCode Product Code */
public void SetASI03_ProductCode (String ASI03_ProductCode){if (ASI03_ProductCode != null && ASI03_ProductCode.Length > 5){log.Warning("Length > 5 - truncated");ASI03_ProductCode = ASI03_ProductCode.Substring(0,5);}Set_Value ("ASI03_ProductCode", ASI03_ProductCode);}/** Get Product Code.
@return Product Code */
public String GetASI03_ProductCode() {return (String)Get_Value("ASI03_ProductCode");}/** Set Product Image.
@param ASI03_ProductImage Product Image */
public void SetASI03_ProductImage (int ASI03_ProductImage){Set_Value ("ASI03_ProductImage", ASI03_ProductImage);}/** Get Product Image.
@return Product Image */
public int GetASI03_ProductImage() {Object ii = Get_Value("ASI03_ProductImage");if (ii == null) return 0;return Convert.ToInt32(ii);}/** Set ِASI03_Product_ID.
@param ASI03_Product_ID ِASI03_Product_ID */
public void SetASI03_Product_ID (int ASI03_Product_ID){if (ASI03_Product_ID < 1) throw new ArgumentException ("ASI03_Product_ID is mandatory.");Set_ValueNoCheck ("ASI03_Product_ID", ASI03_Product_ID);}/** Get ِASI03_Product_ID.
@return ِASI03_Product_ID */
public int GetASI03_Product_ID() {Object ii = Get_Value("ASI03_Product_ID");if (ii == null) return 0;return Convert.ToInt32(ii);}/** Set Export.
@param Export_ID Export */
public void SetExport_ID (String Export_ID){if (Export_ID != null && Export_ID.Length > 50){log.Warning("Length > 50 - truncated");Export_ID = Export_ID.Substring(0,50);}Set_Value ("Export_ID", Export_ID);}/** Get Export.
@return Export */
public String GetExport_ID() {return (String)Get_Value("Export_ID");}/** Set Product Name.
@param Name Product Name */
public void SetName (String Name){if (Name != null && Name.Length > 50){log.Warning("Length > 50 - truncated");Name = Name.Substring(0,50);}Set_Value ("Name", Name);}/** Get Product Name.
@return Product Name */
public String GetName() {return (String)Get_Value("Name");}}
}