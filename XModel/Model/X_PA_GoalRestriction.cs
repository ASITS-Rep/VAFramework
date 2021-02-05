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
/** Generated Model for VAPA_TargetRestriction
 *  @author Jagmohan Bhatt (generated) 
 *  @version Vienna Framework 1.1.1 - $Id$ */
public class X_VAPA_TargetRestriction : PO
{
public X_VAPA_TargetRestriction (Context ctx, int VAPA_TargetRestriction_ID, Trx trxName) : base (ctx, VAPA_TargetRestriction_ID, trxName)
{
/** if (VAPA_TargetRestriction_ID == 0)
{
SetGoalRestrictionType (null);
SetName (null);
SetVAPA_TargetRestriction_ID (0);
SetVAPA_Target_ID (0);
}
 */
}
public X_VAPA_TargetRestriction (Ctx ctx, int VAPA_TargetRestriction_ID, Trx trxName) : base (ctx, VAPA_TargetRestriction_ID, trxName)
{
/** if (VAPA_TargetRestriction_ID == 0)
{
SetGoalRestrictionType (null);
SetName (null);
SetVAPA_TargetRestriction_ID (0);
SetVAPA_Target_ID (0);
}
 */
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_VAPA_TargetRestriction (Context ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName)
{
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_VAPA_TargetRestriction (Ctx ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName)
{
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_VAPA_TargetRestriction (Ctx ctx, IDataReader dr, Trx trxName) : base(ctx, dr, trxName)
{
}
/** Static Constructor 
 Set Table ID By Table Name
 added by ->Harwinder */
static X_VAPA_TargetRestriction()
{
 Table_ID = Get_Table_ID(Table_Name);
 model = new KeyNamePair(Table_ID,Table_Name);
}
/** Serial Version No */
//static long serialVersionUID 27562514381857L;
/** Last Updated Timestamp 7/29/2010 1:07:45 PM */
public static long updatedMS = 1280389065068L;
/** VAF_TableView_ID=832 */
public static int Table_ID;
 // =832;

/** TableName=VAPA_TargetRestriction */
public static String Table_Name="VAPA_TargetRestriction";

protected static KeyNamePair model;
protected Decimal accessLevel = new Decimal(6);
/** AccessLevel
@return 6 - System - Client 
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
StringBuilder sb = new StringBuilder ("X_VAPA_TargetRestriction[").Append(Get_ID()).Append("]");
return sb.ToString();
}
/** Set Business Partner Group.
@param VAB_BPart_Category_ID Business Partner Group */
public void SetVAB_BPart_Category_ID (int VAB_BPart_Category_ID)
{
if (VAB_BPart_Category_ID <= 0) Set_Value ("VAB_BPart_Category_ID", null);
else
Set_Value ("VAB_BPart_Category_ID", VAB_BPart_Category_ID);
}
/** Get Business Partner Group.
@return Business Partner Group */
public int GetVAB_BPart_Category_ID() 
{
Object ii = Get_Value("VAB_BPart_Category_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Business Partner.
@param VAB_BusinessPartner_ID Identifies a Business Partner */
public void SetVAB_BusinessPartner_ID (int VAB_BusinessPartner_ID)
{
if (VAB_BusinessPartner_ID <= 0) Set_Value ("VAB_BusinessPartner_ID", null);
else
Set_Value ("VAB_BusinessPartner_ID", VAB_BusinessPartner_ID);
}
/** Get Business Partner.
@return Identifies a Business Partner */
public int GetVAB_BusinessPartner_ID() 
{
Object ii = Get_Value("VAB_BusinessPartner_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}

/** GoalRestrictionType VAF_Control_Ref_ID=368 */
public static int GOALRESTRICTIONTYPE_VAF_Control_Ref_ID=368;
/** Business Partner = B */
public static String GOALRESTRICTIONTYPE_BusinessPartner = "B";
/** Product Category = C */
public static String GOALRESTRICTIONTYPE_ProductCategory = "C";
/** Bus.Partner Group = G */
public static String GOALRESTRICTIONTYPE_BusPartnerGroup = "G";
/** Organization = O */
public static String GOALRESTRICTIONTYPE_Organization = "O";
/** Product = P */
public static String GOALRESTRICTIONTYPE_Product = "P";
/** Is test a valid value.
@param test testvalue
@returns true if valid **/
public bool IsGoalRestrictionTypeValid (String test)
{
return test.Equals("B") || test.Equals("C") || test.Equals("G") || test.Equals("O") || test.Equals("P");
}
/** Set Restriction Type.
@param GoalRestrictionType Goal Restriction Type */
public void SetGoalRestrictionType (String GoalRestrictionType)
{
if (GoalRestrictionType == null) throw new ArgumentException ("GoalRestrictionType is mandatory");
if (!IsGoalRestrictionTypeValid(GoalRestrictionType))
throw new ArgumentException ("GoalRestrictionType Invalid value - " + GoalRestrictionType + " - Reference_ID=368 - B - C - G - O - P");
if (GoalRestrictionType.Length > 1)
{
log.Warning("Length > 1 - truncated");
GoalRestrictionType = GoalRestrictionType.Substring(0,1);
}
Set_Value ("GoalRestrictionType", GoalRestrictionType);
}
/** Get Restriction Type.
@return Goal Restriction Type */
public String GetGoalRestrictionType() 
{
return (String)Get_Value("GoalRestrictionType");
}
/** Set Product Category.
@param VAM_ProductCategory_ID Category of a Product */
public void SetVAM_ProductCategory_ID (int VAM_ProductCategory_ID)
{
if (VAM_ProductCategory_ID <= 0) Set_Value ("VAM_ProductCategory_ID", null);
else
Set_Value ("VAM_ProductCategory_ID", VAM_ProductCategory_ID);
}
/** Get Product Category.
@return Category of a Product */
public int GetVAM_ProductCategory_ID() 
{
Object ii = Get_Value("VAM_ProductCategory_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Product.
@param VAM_Product_ID Product, Service, Item */
public void SetVAM_Product_ID (int VAM_Product_ID)
{
if (VAM_Product_ID <= 0) Set_Value ("VAM_Product_ID", null);
else
Set_Value ("VAM_Product_ID", VAM_Product_ID);
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

/** Org_ID VAF_Control_Ref_ID=322 */
public static int ORG_ID_VAF_Control_Ref_ID=322;
/** Set Organization.
@param Org_ID Organizational entity within client */
public void SetOrg_ID (int Org_ID)
{
if (Org_ID <= 0) Set_Value ("Org_ID", null);
else
Set_Value ("Org_ID", Org_ID);
}
/** Get Organization.
@return Organizational entity within client */
public int GetOrg_ID() 
{
Object ii = Get_Value("Org_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Goal Restriction.
@param VAPA_TargetRestriction_ID Performance Goal Restriction */
public void SetVAPA_TargetRestriction_ID (int VAPA_TargetRestriction_ID)
{
if (VAPA_TargetRestriction_ID < 1) throw new ArgumentException ("VAPA_TargetRestriction_ID is mandatory.");
Set_ValueNoCheck ("VAPA_TargetRestriction_ID", VAPA_TargetRestriction_ID);
}
/** Get Goal Restriction.
@return Performance Goal Restriction */
public int GetVAPA_TargetRestriction_ID() 
{
Object ii = Get_Value("VAPA_TargetRestriction_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Goal.
@param VAPA_Target_ID Performance Goal */
public void SetVAPA_Target_ID (int VAPA_Target_ID)
{
if (VAPA_Target_ID < 1) throw new ArgumentException ("VAPA_Target_ID is mandatory.");
Set_ValueNoCheck ("VAPA_Target_ID", VAPA_Target_ID);
}
/** Get Goal.
@return Performance Goal */
public int GetVAPA_Target_ID() 
{
Object ii = Get_Value("VAPA_Target_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
}

}
