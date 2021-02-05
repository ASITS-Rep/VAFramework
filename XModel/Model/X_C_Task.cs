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
/** Generated Model for VAB_Std_Task
 *  @author Jagmohan Bhatt (generated) 
 *  @version Vienna Framework 1.1.1 - $Id$ */
public class X_VAB_Std_Task : PO
{
public X_VAB_Std_Task (Context ctx, int VAB_Std_Task_ID, Trx trxName) : base (ctx, VAB_Std_Task_ID, trxName)
{
/** if (VAB_Std_Task_ID == 0)
{
SetVAB_Std_Stage_ID (0);
SetVAB_Std_Task_ID (0);
SetName (null);
SetSeqNo (0);	// @SQL=SELECT NVL(MAX(SeqNo),0)+10 AS DefaultValue FROM VAB_Std_Task WHERE VAB_Std_Stage_ID=@VAB_Std_Stage_ID@
SetStandardQty (0.0);	// 1
}
 */
}
public X_VAB_Std_Task (Ctx ctx, int VAB_Std_Task_ID, Trx trxName) : base (ctx, VAB_Std_Task_ID, trxName)
{
/** if (VAB_Std_Task_ID == 0)
{
SetVAB_Std_Stage_ID (0);
SetVAB_Std_Task_ID (0);
SetName (null);
SetSeqNo (0);	// @SQL=SELECT NVL(MAX(SeqNo),0)+10 AS DefaultValue FROM VAB_Std_Task WHERE VAB_Std_Stage_ID=@VAB_Std_Stage_ID@
SetStandardQty (0.0);	// 1
}
 */
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_VAB_Std_Task (Context ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName)
{
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_VAB_Std_Task (Ctx ctx, DataRow rs, Trx trxName) : base(ctx, rs, trxName)
{
}
/** Load Constructor 
@param ctx context
@param rs result set 
@param trxName transaction
*/
public X_VAB_Std_Task (Ctx ctx, IDataReader dr, Trx trxName) : base(ctx, dr, trxName)
{
}
/** Static Constructor 
 Set Table ID By Table Name
 added by ->Harwinder */
static X_VAB_Std_Task()
{
 Table_ID = Get_Table_ID(Table_Name);
 model = new KeyNamePair(Table_ID,Table_Name);
}
/** Serial Version No */
//static long serialVersionUID 27562514375322L;
/** Last Updated Timestamp 7/29/2010 1:07:38 PM */
public static long updatedMS = 1280389058533L;
/** VAF_TableView_ID=583 */
public static int Table_ID;
 // =583;

/** TableName=VAB_Std_Task */
public static String Table_Name="VAB_Std_Task";

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
StringBuilder sb = new StringBuilder ("X_VAB_Std_Task[").Append(Get_ID()).Append("]");
return sb.ToString();
}
/** Set Standard Phase.
@param VAB_Std_Stage_ID Standard Phase of the Project Type */
public void SetVAB_Std_Stage_ID (int VAB_Std_Stage_ID)
{
if (VAB_Std_Stage_ID < 1) throw new ArgumentException ("VAB_Std_Stage_ID is mandatory.");
Set_ValueNoCheck ("VAB_Std_Stage_ID", VAB_Std_Stage_ID);
}
/** Get Standard Phase.
@return Standard Phase of the Project Type */
public int GetVAB_Std_Stage_ID() 
{
Object ii = Get_Value("VAB_Std_Stage_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Standard Task.
@param VAB_Std_Task_ID Standard Project Type Task */
public void SetVAB_Std_Task_ID (int VAB_Std_Task_ID)
{
if (VAB_Std_Task_ID < 1) throw new ArgumentException ("VAB_Std_Task_ID is mandatory.");
Set_ValueNoCheck ("VAB_Std_Task_ID", VAB_Std_Task_ID);
}
/** Get Standard Task.
@return Standard Project Type Task */
public int GetVAB_Std_Task_ID() 
{
Object ii = Get_Value("VAB_Std_Task_ID");
if (ii == null) return 0;
return Convert.ToInt32(ii);
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
/** Set Comment.
@param Help Comment, Help or Hint */
public void SetHelp (String Help)
{
if (Help != null && Help.Length > 2000)
{
log.Warning("Length > 2000 - truncated");
Help = Help.Substring(0,2000);
}
Set_Value ("Help", Help);
}
/** Get Comment.
@return Comment, Help or Hint */
public String GetHelp() 
{
return (String)Get_Value("Help");
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
/** Set Sequence.
@param SeqNo Method of ordering elements;
 lowest number comes first */
public void SetSeqNo (int SeqNo)
{
Set_Value ("SeqNo", SeqNo);
}
/** Get Sequence.
@return Method of ordering elements;
 lowest number comes first */
public int GetSeqNo() 
{
Object ii = Get_Value("SeqNo");
if (ii == null) return 0;
return Convert.ToInt32(ii);
}
/** Set Standard Quantity.
@param StandardQty Standard Quantity */
public void SetStandardQty (Decimal? StandardQty)
{
if (StandardQty == null) throw new ArgumentException ("StandardQty is mandatory.");
Set_Value ("StandardQty", (Decimal?)StandardQty);
}
/** Get Standard Quantity.
@return Standard Quantity */
public Decimal GetStandardQty() 
{
Object bd =Get_Value("StandardQty");
if (bd == null) return Env.ZERO;
return  Convert.ToDecimal(bd);
}

/** TaskType VAF_Control_Ref_ID=408 */
public static int TASKTYPE_VAF_Control_Ref_ID=408;
/** Personal Activity = A */
public static String TASKTYPE_PersonalActivity = "A";
/** Delegation = D */
public static String TASKTYPE_Delegation = "D";
/** Other = O */
public static String TASKTYPE_Other = "O";
/** Research = R */
public static String TASKTYPE_Research = "R";
/** Test/Verify = T */
public static String TASKTYPE_TestVerify = "T";
/** Is test a valid value.
@param test testvalue
@returns true if valid **/
public bool IsTaskTypeValid (String test)
{
return test == null || test.Equals("A") || test.Equals("D") || test.Equals("O") || test.Equals("R") || test.Equals("T");
}
/** Set Task Type.
@param TaskType Type of Project Task */
public void SetTaskType (String TaskType)
{
if (!IsTaskTypeValid(TaskType))
throw new ArgumentException ("TaskType Invalid value - " + TaskType + " - Reference_ID=408 - A - D - O - R - T");
if (TaskType != null && TaskType.Length > 1)
{
log.Warning("Length > 1 - truncated");
TaskType = TaskType.Substring(0,1);
}
Set_Value ("TaskType", TaskType);
}
/** Get Task Type.
@return Type of Project Task */
public String GetTaskType() 
{
return (String)Get_Value("TaskType");
}
}

}
