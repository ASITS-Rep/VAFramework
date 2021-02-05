namespace VAdvantage.Model
{

/** Generated Model - DO NOT CHANGE */
using System;
using System.Text;
using VAdvantage.DataBase;
using VAdvantage.Common;
using VAdvantage.Classes;
using VAdvantage.Process;
using VAdvantage.Model;
using VAdvantage.Utility;
using System.Data;
/** Generated Model for VAM_BOMSubsitutue
 *  @author Jagmohan Bhatt (generated) 
 *  @version Vienna Framework 1.1.1 - $Id$ */
public class X_VAM_BOMSubsitutue : PO
{
public X_VAM_BOMSubsitutue (Context ctx, int VAM_BOMSubsitutue_ID, Trx trxName) : base (ctx, VAM_BOMSubsitutue_ID, trxName)
{
/** if (VAM_BOMSubsitutue_ID == 0)
{
SetVAM_BOMSubsitutue_ID (0);
SetVAM_Product_ID (0);
SetName (null);
}
 */
}
public X_VAM_BOMSubsitutue (Ctx ctx, int VAM_BOMSubsitutue_ID, Trx trxName) : base (ctx, VAM_BOMSubsitutue_ID, trxName)
{
/** if (VAM_BOMSubsitutue_ID == 0)
{
SetVAM_BOMSubsitutue_ID (0);
SetVAM_Product_ID (0);
SetName (null);
}
 */
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_VAM_BOMSubsitutue (Context ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName)
{
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_VAM_BOMSubsitutue (Ctx ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName)
{
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_VAM_BOMSubsitutue (Ctx ctx, IDataReader dr, Trx trxName) : base(ctx, dr, trxName)
{
}
/** Static Constructor 
 Set Table ID By Table Name
 added by ->Harwinder */
static X_VAM_BOMSubsitutue()
{
 Table_ID = Get_Table_ID(Table_Name);
 model = new KeyNamePair(Table_ID,Table_Name);
}
/** Serial Version No */
//static long serialVersionUID 27562514378488L;
/** Last Updated Timestamp 7/29/2010 1:07:41 PM */
public static long updatedMS = 1280389061699L;
/** VAF_TableView_ID=795 */
public static int Table_ID;
 // =795;

/** TableName=VAM_BOMSubsitutue */
public static String Table_Name="VAM_BOMSubsitutue";

protected static KeyNamePair model;
protected Decimal accessLevel = new Decimal(3);
/** AccessLevel
@return 3 - Client - Org 
*/
protected override int Get_AccessLevel()
{
return Convert.ToInt32(accessLevel.ToString());
}
/** Load Meta Data
@param ctx context
@return PO Info
*/
protected override POInfo InitPO (Ctx ctx)
{
POInfo poi = POInfo.GetPOInfo (ctx, Table_ID);
return poi;
}
/** Load Meta Data
@param ctx context
@return PO Info
*/
protected override POInfo InitPO(Context ctx)
{
POInfo poi = POInfo.GetPOInfo (ctx, Table_ID);
return poi;
}
/** Info
@return info
*/
public override String ToString()
{
StringBuilder sb = new StringBuilder ("X_VAM_BOMSubsitutue[").Append(Get_ID()).Append("]");
return sb.ToString();
}
/** Set Description.
@param Description Optional short description of the record */
public void SetDescription (String Description)
{
if (Description != null && Description.Length > 255)
{
log.Warning("Length > 255 - truncated");
Description = Description.Substring(0,255);
}
Set_Value ("Description", Description);
}
/** Get Description.
@return Optional short description of the record */
public String GetDescription() 
{
return (String)Get_Value("Description");
}
/** Set Alternative Group.
@param VAM_BOMSubsitutue_ID Product BOM Alternative Group */
public void SetVAM_BOMSubsitutue_ID (int VAM_BOMSubsitutue_ID)
{
if (VAM_BOMSubsitutue_ID < 1) throw new ArgumentException ("VAM_BOMSubsitutue_ID is mandatory.");
Set_ValueNoCheck ("VAM_BOMSubsitutue_ID", VAM_BOMSubsitutue_ID);
}
/** Get Alternative Group.
@return Product BOM Alternative Group */
public int GetVAM_BOMSubsitutue_ID() 
{
Object ii = Get_Value("VAM_BOMSubsitutue_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Product.
@param VAM_Product_ID Product, Service, Item */
public void SetVAM_Product_ID (int VAM_Product_ID)
{
if (VAM_Product_ID < 1) throw new ArgumentException ("VAM_Product_ID is mandatory.");
Set_ValueNoCheck ("VAM_Product_ID", VAM_Product_ID);
}
/** Get Product.
@return Product, Service, Item */
public int GetVAM_Product_ID() 
{
Object ii = Get_Value("VAM_Product_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Name.
@param Name Alphanumeric identifier of the entity */
public void SetName (String Name)
{
if (Name == null) throw new ArgumentException ("Name is mandatory.");
if (Name.Length > 60)
{
log.Warning("Length > 60 - truncated");
Name = Name.Substring(0,60);
}
Set_Value ("Name", Name);
}
/** Get Name.
@return Alphanumeric identifier of the entity */
public String GetName() 
{
return (String)Get_Value("Name");
}
/** Get Record ID/ColumnName
@return ID/ColumnName pair */
public KeyNamePair GetKeyNamePair() 
{
return new KeyNamePair(Get_ID(), GetName());
}
}

}
