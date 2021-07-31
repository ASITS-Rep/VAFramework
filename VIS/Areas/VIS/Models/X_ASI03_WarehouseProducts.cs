namespace ViennaAdvantage.Model{
/** Generated Model - DO NOT CHANGE */
using System;using System.Text;using VAdvantage.DataBase;using VAdvantage.Common;using VAdvantage.Classes;using VAdvantage.Process;using VAdvantage.Model;using VAdvantage.Utility;using System.Data;/** Generated Model for ASI03_WarehouseProducts
 *  @author Raghu (Updated) 
 *  @version Vienna Framework 1.1.1 - $Id$ */
public class X_ASI03_WarehouseProducts : PO{public X_ASI03_WarehouseProducts (Context ctx, int ASI03_WarehouseProducts_ID, Trx trxName) : base (ctx, ASI03_WarehouseProducts_ID, trxName){/** if (ASI03_WarehouseProducts_ID == 0){SetASI03_WarehouseProducts_ID (0);} */
}public X_ASI03_WarehouseProducts (Ctx ctx, int ASI03_WarehouseProducts_ID, Trx trxName) : base (ctx, ASI03_WarehouseProducts_ID, trxName){/** if (ASI03_WarehouseProducts_ID == 0){SetASI03_WarehouseProducts_ID (0);} */
}/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_ASI03_WarehouseProducts (Context ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName){}/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_ASI03_WarehouseProducts (Ctx ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName){}/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_ASI03_WarehouseProducts (Ctx ctx, IDataReader dr, Trx trxName) : base(ctx, dr, trxName){}/** Static Constructor 
 Set Table ID By Table Name
 added by ->Harwinder */
static X_ASI03_WarehouseProducts(){ Table_ID = Get_Table_ID(Table_Name); model = new KeyNamePair(Table_ID,Table_Name);}/** Serial Version No */
static long serialVersionUID = 27909774137545L;/** Last Updated Timestamp 2021-07-30 3:40:20 PM */
public static long updatedMS = 1627648820756L;/** AD_Table_ID=1000783 */
public static int Table_ID; // =1000783;
/** TableName=ASI03_WarehouseProducts */
public static String Table_Name="ASI03_WarehouseProducts";
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
public override String ToString(){StringBuilder sb = new StringBuilder ("X_ASI03_WarehouseProducts[").Append(Get_ID()).Append("]");return sb.ToString();}/** Set Product Amount.
@param ASI03_ProductAmount Product Amount */
public void SetASI03_ProductAmount (int ASI03_ProductAmount){Set_Value ("ASI03_ProductAmount", ASI03_ProductAmount);}/** Get Product Amount.
@return Product Amount */
public int GetASI03_ProductAmount() {Object ii = Get_Value("ASI03_ProductAmount");if (ii == null) return 0;return Convert.ToInt32(ii);}/** Set ِASI03_Product_ID.
@param ASI03_Product_ID ِASI03_Product_ID */
public void SetASI03_Product_ID (int ASI03_Product_ID){if (ASI03_Product_ID <= 0) Set_Value ("ASI03_Product_ID", null);else
Set_Value ("ASI03_Product_ID", ASI03_Product_ID);}/** Get ِASI03_Product_ID.
@return ِASI03_Product_ID */
public int GetASI03_Product_ID() {Object ii = Get_Value("ASI03_Product_ID");if (ii == null) return 0;return Convert.ToInt32(ii);}/** Set ASI03_WarehouseProducts_ID.
@param ASI03_WarehouseProducts_ID ASI03_WarehouseProducts_ID */
public void SetASI03_WarehouseProducts_ID (int ASI03_WarehouseProducts_ID){if (ASI03_WarehouseProducts_ID < 1) throw new ArgumentException ("ASI03_WarehouseProducts_ID is mandatory.");Set_ValueNoCheck ("ASI03_WarehouseProducts_ID", ASI03_WarehouseProducts_ID);}/** Get ASI03_WarehouseProducts_ID.
@return ASI03_WarehouseProducts_ID */
public int GetASI03_WarehouseProducts_ID() {Object ii = Get_Value("ASI03_WarehouseProducts_ID");if (ii == null) return 0;return Convert.ToInt32(ii);}/** Set ASI03_Warehouse_ID.
@param ASI03_Warehouse_ID ASI03_Warehouse_ID */
public void SetASI03_Warehouse_ID (int ASI03_Warehouse_ID){if (ASI03_Warehouse_ID <= 0) Set_Value ("ASI03_Warehouse_ID", null);else
Set_Value ("ASI03_Warehouse_ID", ASI03_Warehouse_ID);}/** Get ASI03_Warehouse_ID.
@return ASI03_Warehouse_ID */
public int GetASI03_Warehouse_ID() {Object ii = Get_Value("ASI03_Warehouse_ID");if (ii == null) return 0;return Convert.ToInt32(ii);}/** Set UOM.
@param C_UOM_ID Unit of Measure */
public void SetC_UOM_ID (int C_UOM_ID){if (C_UOM_ID <= 0) Set_Value ("C_UOM_ID", null);else
Set_Value ("C_UOM_ID", C_UOM_ID);}/** Get UOM.
@return Unit of Measure */
public int GetC_UOM_ID() {Object ii = Get_Value("C_UOM_ID");if (ii == null) return 0;return Convert.ToInt32(ii);}/** Set Export.
@param Export_ID Export */
public void SetExport_ID (String Export_ID){if (Export_ID != null && Export_ID.Length > 50){log.Warning("Length > 50 - truncated");Export_ID = Export_ID.Substring(0,50);}Set_Value ("Export_ID", Export_ID);}/** Get Export.
@return Export */
public String GetExport_ID() {return (String)Get_Value("Export_ID");}}
}