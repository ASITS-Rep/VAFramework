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
    /** Generated Model for VAF_WFlow_Node
     *  @author Jagmohan Bhatt (generated) 
     *  @version Vienna Framework 1.1.1 - $Id$ */
    public class X_VAF_WFlow_Node : PO
    {
        public X_VAF_WFlow_Node(Context ctx, int VAF_WFlow_Node_ID, Trx trxName)
            : base(ctx, VAF_WFlow_Node_ID, trxName)
        {
            /** if (VAF_WFlow_Node_ID == 0)
            {
            SetVAF_WFlow_Node_ID (0);
            SetVAF_Workflow_ID (0);
            SetAction (null);	// N
            SetDuration (0);
            SetDurationLimit (0);
            SetEntityType (null);	// U
            SetIsCentrallyMaintained (true);	// Y
            SetJoinElement (null);	// X
            SetName (null);
            SetSplitElement (null);	// X
            SetValue (null);
            SetWaitingTime (0);
            SetXPosition (0);
            SetYPosition (0);
            }
             */
        }
        public X_VAF_WFlow_Node(Ctx ctx, int VAF_WFlow_Node_ID, Trx trxName)
            : base(ctx, VAF_WFlow_Node_ID, trxName)
        {
            /** if (VAF_WFlow_Node_ID == 0)
            {
            SetVAF_WFlow_Node_ID (0);
            SetVAF_Workflow_ID (0);
            SetAction (null);	// N
            SetDuration (0);
            SetDurationLimit (0);
            SetEntityType (null);	// U
            SetIsCentrallyMaintained (true);	// Y
            SetJoinElement (null);	// X
            SetName (null);
            SetSplitElement (null);	// X
            SetValue (null);
            SetWaitingTime (0);
            SetXPosition (0);
            SetYPosition (0);
            }
             */
        }
        /** Load Constructor 
        @param ctx context
        @param rs result set 
        @param trxName transaction
        */
        public X_VAF_WFlow_Node(Context ctx, DataRow rs, Trx trxName)
            : base(ctx, rs, trxName)
        {
        }
        /** Load Constructor 
        @param ctx context
        @param rs result set 
        @param trxName transaction
        */
        public X_VAF_WFlow_Node(Ctx ctx, DataRow rs, Trx trxName)
            : base(ctx, rs, trxName)
        {
        }
        /** Load Constructor 
        @param ctx context
        @param rs result set 
        @param trxName transaction
        */
        public X_VAF_WFlow_Node(Ctx ctx, IDataReader dr, Trx trxName)
            : base(ctx, dr, trxName)
        {
        }
        /** Static Constructor 
         Set Table ID By Table Name
         added by ->Harwinder */
        static X_VAF_WFlow_Node()
        {
            Table_ID = Get_Table_ID(Table_Name);
            model = new KeyNamePair(Table_ID, Table_Name);
        }
        /** Serial Version No */
        //static long serialVersionUID 27671913487529L;
        /** Last Updated Timestamp 15-01-2014 17:46:10 */
        public static long updatedMS = 1389788170740L;
        /** VAF_TableView_ID=129 */
        public static int Table_ID;
        // =129;

        /** TableName=VAF_WFlow_Node */
        public static String Table_Name = "VAF_WFlow_Node";

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
        protected override POInfo InitPO(Context ctx)
        {
            POInfo poi = POInfo.GetPOInfo(ctx, Table_ID);
            return poi;
        }
        /** Load Meta Data
        @param ctx context
        @return PO Info
        */
        protected override POInfo InitPO(Ctx ctx)
        {
            POInfo poi = POInfo.GetPOInfo(ctx, Table_ID);
            return poi;
        }
        /** Info
        @return info
        */
        public override String ToString()
        {
            StringBuilder sb = new StringBuilder("X_VAF_WFlow_Node[").Append(Get_ID()).Append("]");
            return sb.ToString();
        }
        /** Set Column.
        @param VAF_Column_ID Column in the table */
        public void SetVAF_Column_ID(int VAF_Column_ID)
        {
            if (VAF_Column_ID <= 0) Set_Value("VAF_Column_ID", null);
            else
                Set_Value("VAF_Column_ID", VAF_Column_ID);
        }
        /** Get Column.
        @return Column in the table */
        public int GetVAF_Column_ID()
        {
            Object ii = Get_Value("VAF_Column_ID");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }

        /** VAF_Column_ID_1 VAF_Control_Ref_ID=414 */
        public static int VAF_COLUMN_ID_1_VAF_Control_Ref_ID = 414;
        /** Set Column.
        @param VAF_Column_ID_1 Used to store second reference of VAF_Column_ID column  */
        public void SetVAF_Column_ID_1(int VAF_Column_ID_1)
        {
            Set_Value("VAF_Column_ID_1", VAF_Column_ID_1);
        }
        /** Get Column.
        @return Used to store second reference of VAF_Column_ID column  */
        public int GetVAF_Column_ID_1()
        {
            Object ii = Get_Value("VAF_Column_ID_1");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }

        /** VAF_Column_ID_2 VAF_Control_Ref_ID=414 */
        public static int VAF_COLUMN_ID_2_VAF_Control_Ref_ID = 414;
        /** Set Column.
        @param VAF_Column_ID_2 Used to store third reference of VAF_Column_ID column  */
        public void SetVAF_Column_ID_2(int VAF_Column_ID_2)
        {
            Set_Value("VAF_Column_ID_2", VAF_Column_ID_2);
        }
        /** Get Column.
        @return Used to store third reference of VAF_Column_ID column  */
        public int GetVAF_Column_ID_2()
        {
            Object ii = Get_Value("VAF_Column_ID_2");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }

        /** VAF_Column_ID_3 VAF_Control_Ref_ID=414 */
        public static int VAF_COLUMN_ID_3_VAF_Control_Ref_ID = 414;
        /** Set Invoked By.
        @param VAF_Column_ID_3 Invoked By */
        public void SetVAF_Column_ID_3(int VAF_Column_ID_3)
        {
            Set_Value("VAF_Column_ID_3", VAF_Column_ID_3);
        }
        /** Get Invoked By.
        @return Invoked By */
        public int GetVAF_Column_ID_3()
        {
            Object ii = Get_Value("VAF_Column_ID_3");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }
        /** Set Special Form.
        @param VAF_Page_ID Special Form */
        public void SetVAF_Page_ID(int VAF_Page_ID)
        {
            if (VAF_Page_ID <= 0) Set_Value("VAF_Page_ID", null);
            else
                Set_Value("VAF_Page_ID", VAF_Page_ID);
        }
        /** Get Special Form.
        @return Special Form */
        public int GetVAF_Page_ID()
        {
            Object ii = Get_Value("VAF_Page_ID");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }
        /** Set Image.
        @param VAF_Image_ID Image or Icon */
        public void SetVAF_Image_ID(int VAF_Image_ID)
        {
            if (VAF_Image_ID <= 0) Set_Value("VAF_Image_ID", null);
            else
                Set_Value("VAF_Image_ID", VAF_Image_ID);
        }
        /** Get Image.
        @return Image or Icon */
        public int GetVAF_Image_ID()
        {
            Object ii = Get_Value("VAF_Image_ID");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }
        /** Set Process.
        @param VAF_Job_ID Process or Report */
        public void SetVAF_Job_ID(int VAF_Job_ID)
        {
            if (VAF_Job_ID <= 0) Set_Value("VAF_Job_ID", null);
            else
                Set_Value("VAF_Job_ID", VAF_Job_ID);
        }
        /** Get Process.
        @return Process or Report */
        public int GetVAF_Job_ID()
        {
            Object ii = Get_Value("VAF_Job_ID");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }
        /** Set OS Task.
        @param VAF_Task_ID Operation System Task */
        public void SetVAF_Task_ID(int VAF_Task_ID)
        {
            if (VAF_Task_ID <= 0) Set_Value("VAF_Task_ID", null);
            else
                Set_Value("VAF_Task_ID", VAF_Task_ID);
        }
        /** Get OS Task.
        @return Operation System Task */
        public int GetVAF_Task_ID()
        {
            Object ii = Get_Value("VAF_Task_ID");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }
        /** Set Workflow Block.
        @param VAF_WFlow_Block_ID Workflow Transaction Execution Block */
        public void SetVAF_WFlow_Block_ID(int VAF_WFlow_Block_ID)
        {
            if (VAF_WFlow_Block_ID <= 0) Set_Value("VAF_WFlow_Block_ID", null);
            else
                Set_Value("VAF_WFlow_Block_ID", VAF_WFlow_Block_ID);
        }
        /** Get Workflow Block.
        @return Workflow Transaction Execution Block */
        public int GetVAF_WFlow_Block_ID()
        {
            Object ii = Get_Value("VAF_WFlow_Block_ID");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }
        /** Set Node.
        @param VAF_WFlow_Node_ID Workflow Node (activity), step or process */
        public void SetVAF_WFlow_Node_ID(int VAF_WFlow_Node_ID)
        {
            if (VAF_WFlow_Node_ID < 1) throw new ArgumentException("VAF_WFlow_Node_ID is mandatory.");
            Set_ValueNoCheck("VAF_WFlow_Node_ID", VAF_WFlow_Node_ID);
        }
        /** Get Node.
        @return Workflow Node (activity), step or process */
        public int GetVAF_WFlow_Node_ID()
        {
            Object ii = Get_Value("VAF_WFlow_Node_ID");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }
        /** Set Workflow Responsible.
        @param VAF_WFlow_Incharge_ID Responsible for Workflow Execution */
        public void SetVAF_WFlow_Incharge_ID(int VAF_WFlow_Incharge_ID)
        {
            if (VAF_WFlow_Incharge_ID <= 0) Set_Value("VAF_WFlow_Incharge_ID", null);
            else
                Set_Value("VAF_WFlow_Incharge_ID", VAF_WFlow_Incharge_ID);
        }
        /** Get Workflow Responsible.
        @return Responsible for Workflow Execution */
        public int GetVAF_WFlow_Incharge_ID()
        {
            Object ii = Get_Value("VAF_WFlow_Incharge_ID");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }
        /** Set Window.
        @param VAF_Screen_ID Data entry or display window */
        public void SetVAF_Screen_ID(int VAF_Screen_ID)
        {
            if (VAF_Screen_ID <= 0) Set_Value("VAF_Screen_ID", null);
            else
                Set_Value("VAF_Screen_ID", VAF_Screen_ID);
        }
        /** Get Window.
        @return Data entry or display window */
        public int GetVAF_Screen_ID()
        {
            Object ii = Get_Value("VAF_Screen_ID");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }
        /** Set Workflow.
        @param VAF_Workflow_ID Workflow or combination of tasks */
        public void SetVAF_Workflow_ID(int VAF_Workflow_ID)
        {
            if (VAF_Workflow_ID < 1) throw new ArgumentException("VAF_Workflow_ID is mandatory.");
            Set_ValueNoCheck("VAF_Workflow_ID", VAF_Workflow_ID);
        }
        /** Get Workflow.
        @return Workflow or combination of tasks */
        public int GetVAF_Workflow_ID()
        {
            Object ii = Get_Value("VAF_Workflow_ID");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }

        /** Action VAF_Control_Ref_ID=302 */
        public static int ACTION_VAF_Control_Ref_ID = 302;
        /** FaxEMail = A */
        public static String ACTION_FaxEMail = "A";
        /** User Workbench = B */
        public static String ACTION_UserWorkbench = "B";
        /** User Choice = C */
        public static String ACTION_UserChoice = "C";
        /** Document Action = D */
        public static String ACTION_DocumentAction = "D";
        /** Sub Workflow = F */
        public static String ACTION_SubWorkflow = "F";
        /** Forward Document = G */
        public static String ACTION_ForwardDocument = "G";
        /** Move Document = H */
        public static String ACTION_MoveDocument = "H";
        /** Access Document = I */
        public static String ACTION_AccessDocument = "I";
        /** EMail+FaxEMail = L */
        public static String ACTION_EMailPlusFaxEMail = "L";
        /** EMail = M */
        public static String ACTION_EMail = "M";
        /** Apps Process = P */
        public static String ACTION_AppsProcess = "P";
        /** Apps Report = R */
        public static String ACTION_AppsReport = "R";
        /** SMS = S */
        public static String ACTION_SMS = "S";
        /** Apps Task = T */
        public static String ACTION_AppsTask = "T";
        /** Set Variable = V */
        public static String ACTION_SetVariable = "V";
        /** User Window = W */
        public static String ACTION_UserWindow = "W";
        /** User Form = X */
        public static String ACTION_UserForm = "X";
        /** Wait (Sleep) = Z */
        public static String ACTION_WaitSleep = "Z";
        /** Is test a valid value.
        @param test testvalue
        @returns true if valid **/
        public bool IsActionValid(String test)
        {
            return test.Equals("A") || test.Equals("B") || test.Equals("C") || test.Equals("D") || test.Equals("F") || test.Equals("G") || test.Equals("H") || test.Equals("I") || test.Equals("L") || test.Equals("M") || test.Equals("P") || test.Equals("R") || test.Equals("S") || test.Equals("T") || test.Equals("V") || test.Equals("W") || test.Equals("X") || test.Equals("Z");
        }
        /** Set Action.
        @param Action Indicates the Action to be performed */
        public void SetAction(String Action)
        {
            if (Action == null) throw new ArgumentException("Action is mandatory");
            if (!IsActionValid(Action))
                throw new ArgumentException("Action Invalid value - " + Action + " - Reference_ID=302 - A - B - C - D - F - G - H - I - L - M - P - R - S - T - V - W - X - Z");
            if (Action.Length > 1)
            {
                log.Warning("Length > 1 - truncated");
                Action = Action.Substring(0, 1);
            }
            Set_Value("Action", Action);
        }
        /** Get Action.
        @return Indicates the Action to be performed */
        public String GetAction()
        {
            return (String)Get_Value("Action");
        }
        /** Set Approval Leval.
        @param ApprovalLeval Approval Leval */
        public void SetApprovalLeval(int ApprovalLeval)
        {
            Set_Value("ApprovalLeval", ApprovalLeval);
        }
        /** Get Approval Leval.
        @return Approval Leval */
        public int GetApprovalLeval()
        {
            Object ii = Get_Value("ApprovalLeval");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }
        /** Set Attribute Name.
        @param AttributeName Name of the Attribute */
        public void SetAttributeName(String AttributeName)
        {
            if (AttributeName != null && AttributeName.Length > 60)
            {
                log.Warning("Length > 60 - truncated");
                AttributeName = AttributeName.Substring(0, 60);
            }
            Set_Value("AttributeName", AttributeName);
        }
        /** Get Attribute Name.
        @return Name of the Attribute */
        public String GetAttributeName()
        {
            return (String)Get_Value("AttributeName");
        }
        /** Set Attribute Value.
        @param AttributeValue Value of the Attribute */
        public void SetAttributeValue(String AttributeValue)
        {
            if (AttributeValue != null && AttributeValue.Length > 60)
            {
                log.Warning("Length > 60 - truncated");
                AttributeValue = AttributeValue.Substring(0, 60);
            }
            Set_Value("AttributeValue", AttributeValue);
        }
        /** Get Attribute Value.
        @return Value of the Attribute */
        public String GetAttributeValue()
        {
            return (String)Get_Value("AttributeValue");
        }
        /** Set VAB_GenFeatureSetInstance_ID.
        @param VAB_GenFeatureSetInstance_ID VAB_GenFeatureSetInstance_ID */
        public void SetVAB_GenFeatureSetInstance_ID(Object VAB_GenFeatureSetInstance_ID)
        {
            Set_Value("VAB_GenFeatureSetInstance_ID", VAB_GenFeatureSetInstance_ID);
        }
        /** Get VAB_GenFeatureSetInstance_ID.
        @return VAB_GenFeatureSetInstance_ID */
        public Object GetVAB_GenFeatureSetInstance_ID()
        {
            return Get_Value("VAB_GenFeatureSetInstance_ID");
        }
        /** Set VAB_GenFeatureSet_ID.
        @param VAB_GenFeatureSet_ID VAB_GenFeatureSet_ID */
        public void SetVAB_GenFeatureSet_ID(int VAB_GenFeatureSet_ID)
        {
            if (VAB_GenFeatureSet_ID <= 0) Set_Value("VAB_GenFeatureSet_ID", null);
            else
                Set_Value("VAB_GenFeatureSet_ID", VAB_GenFeatureSet_ID);
        }
        /** Get VAB_GenFeatureSet_ID.
        @return VAB_GenFeatureSet_ID */
        public int GetVAB_GenFeatureSet_ID()
        {
            Object ii = Get_Value("VAB_GenFeatureSet_ID");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }
        /** Set Cost.
        @param Cost Cost information */
        public void SetCost(Decimal? Cost)
        {
            Set_Value("Cost", (Decimal?)Cost);
        }
        /** Get Cost.
        @return Cost information */
        public Decimal GetCost()
        {
            Object bd = Get_Value("Cost");
            if (bd == null) return Env.ZERO;
            return Convert.ToDecimal(bd);
        }
        /** Set Description.
        @param Description Optional short description of the record */
        public void SetDescription(String Description)
        {
            if (Description != null && Description.Length > 255)
            {
                log.Warning("Length > 255 - truncated");
                Description = Description.Substring(0, 255);
            }
            Set_Value("Description", Description);
        }
        /** Get Description.
        @return Optional short description of the record */
        public String GetDescription()
        {
            return (String)Get_Value("Description");
        }

        /** DocAction VAF_Control_Ref_ID=135 */
        public static int DOCACTION_VAF_Control_Ref_ID = 135;
        /** <None> = -- */
        public static String DOCACTION_None = "--";
        /** Approve = AP */
        public static String DOCACTION_Approve = "AP";
        /** Close = CL */
        public static String DOCACTION_Close = "CL";
        /** Complete = CO */
        public static String DOCACTION_Complete = "CO";
        /** Invalidate = IN */
        public static String DOCACTION_Invalidate = "IN";
        /** Post = PO */
        public static String DOCACTION_Post = "PO";
        /** Prepare = PR */
        public static String DOCACTION_Prepare = "PR";
        /** Reverse - Accrual = RA */
        public static String DOCACTION_Reverse_Accrual = "RA";
        /** Reverse - Correct = RC */
        public static String DOCACTION_Reverse_Correct = "RC";
        /** Re-activate = RE */
        public static String DOCACTION_Re_Activate = "RE";
        /** Reject = RJ */
        public static String DOCACTION_Reject = "RJ";
        /** Void = VO */
        public static String DOCACTION_Void = "VO";
        /** Wait Complete = WC */
        public static String DOCACTION_WaitComplete = "WC";
        /** Unlock = XL */
        public static String DOCACTION_Unlock = "XL";
        /** Is test a valid value.
        @param test testvalue
        @returns true if valid **/
        public bool IsDocActionValid(String test)
        {
            return test == null || test.Equals("--") || test.Equals("AP") || test.Equals("CL") || test.Equals("CO") || test.Equals("IN") || test.Equals("PO") || test.Equals("PR") || test.Equals("RA") || test.Equals("RC") || test.Equals("RE") || test.Equals("RJ") || test.Equals("VO") || test.Equals("WC") || test.Equals("XL");
        }
        /** Set Document Action.
        @param DocAction The targeted status of the document */
        public void SetDocAction(String DocAction)
        {
            if (!IsDocActionValid(DocAction))
                throw new ArgumentException("DocAction Invalid value - " + DocAction + " - Reference_ID=135 - -- - AP - CL - CO - IN - PO - PR - RA - RC - RE - RJ - VO - WC - XL");
            if (DocAction != null && DocAction.Length > 2)
            {
                log.Warning("Length > 2 - truncated");
                DocAction = DocAction.Substring(0, 2);
            }
            Set_Value("DocAction", DocAction);
        }
        /** Get Document Action.
        @return The targeted status of the document */
        public String GetDocAction()
        {
            return (String)Get_Value("DocAction");
        }
        /** Set Duration.
        @param Duration Normal Duration in Duration Unit */
        public void SetDuration(int Duration)
        {
            Set_Value("Duration", Duration);
        }
        /** Get Duration.
        @return Normal Duration in Duration Unit */
        public int GetDuration()
        {
            Object ii = Get_Value("Duration");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }
        /** Set Duration Limit.
        @param DurationLimit Maximum Duration in Duration Unit */
        public void SetDurationLimit(int DurationLimit)
        {
            Set_Value("DurationLimit", DurationLimit);
        }
        /** Get Duration Limit.
        @return Maximum Duration in Duration Unit */
        public int GetDurationLimit()
        {
            Object ii = Get_Value("DurationLimit");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }
        /** Set Dynamic Priority Change.
        @param DynPriorityChange Change of priority when Activity is suspended waiting for user */
        public void SetDynPriorityChange(Decimal? DynPriorityChange)
        {
            Set_Value("DynPriorityChange", (Decimal?)DynPriorityChange);
        }
        /** Get Dynamic Priority Change.
        @return Change of priority when Activity is suspended waiting for user */
        public Decimal GetDynPriorityChange()
        {
            Object bd = Get_Value("DynPriorityChange");
            if (bd == null) return Env.ZERO;
            return Convert.ToDecimal(bd);
        }

        /** DynPriorityUnit VAF_Control_Ref_ID=221 */
        public static int DYNPRIORITYUNIT_VAF_Control_Ref_ID = 221;
        /** Day = D */
        public static String DYNPRIORITYUNIT_Day = "D";
        /** Hour = H */
        public static String DYNPRIORITYUNIT_Hour = "H";
        /** Minute = M */
        public static String DYNPRIORITYUNIT_Minute = "M";
        /** Is test a valid value.
        @param test testvalue
        @returns true if valid **/
        public bool IsDynPriorityUnitValid(String test)
        {
            return test == null || test.Equals("D") || test.Equals("H") || test.Equals("M");
        }
        /** Set Dynamic Priority Unit.
        @param DynPriorityUnit Change of priority when Activity is suspended waiting for user */
        public void SetDynPriorityUnit(String DynPriorityUnit)
        {
            if (!IsDynPriorityUnitValid(DynPriorityUnit))
                throw new ArgumentException("DynPriorityUnit Invalid value - " + DynPriorityUnit + " - Reference_ID=221 - D - H - M");
            if (DynPriorityUnit != null && DynPriorityUnit.Length > 1)
            {
                log.Warning("Length > 1 - truncated");
                DynPriorityUnit = DynPriorityUnit.Substring(0, 1);
            }
            Set_Value("DynPriorityUnit", DynPriorityUnit);
        }
        /** Get Dynamic Priority Unit.
        @return Change of priority when Activity is suspended waiting for user */
        public String GetDynPriorityUnit()
        {
            return (String)Get_Value("DynPriorityUnit");
        }
        /** Set EMail Address.
        @param EMail Electronic Mail Address */
        public void SetEMail(String EMail)
        {
            if (EMail != null && EMail.Length > 60)
            {
                log.Warning("Length > 60 - truncated");
                EMail = EMail.Substring(0, 60);
            }
            Set_Value("EMail", EMail);
        }
        /** Get EMail Address.
        @return Electronic Mail Address */
        public String GetEMail()
        {
            return (String)Get_Value("EMail");
        }

        /** EMailRecipient VAF_Control_Ref_ID=363 */
        public static int EMAILRECIPIENT_VAF_Control_Ref_ID = 363;
        /** Document Business Partner = B */
        public static String EMAILRECIPIENT_DocumentBusinessPartner = "B";
        /** Document Owner = D */
        public static String EMAILRECIPIENT_DocumentOwner = "D";
        /** WF Responsible = R */
        public static String EMAILRECIPIENT_WFResponsible = "R";
        /** Document Owner's Supervisor = S */
        public static String EMAILRECIPIENT_DocumentOwnerSSupervisor = "S";
        /** Document  User = U */
        public static String EMAILRECIPIENT_DocumentUser = "U";
        /** Is test a valid value.
        @param test testvalue
        @returns true if valid **/
        public bool IsEMailRecipientValid(String test)
        {
            return test == null || test.Equals("B") || test.Equals("D") || test.Equals("R") || test.Equals("S") || test.Equals("U");
        }
        /** Set EMail Recipient.
        @param EMailRecipient Recipient of the EMail */
        public void SetEMailRecipient(String EMailRecipient)
        {
            if (!IsEMailRecipientValid(EMailRecipient))
                throw new ArgumentException("EMailRecipient Invalid value - " + EMailRecipient + " - Reference_ID=363 - B - D - R - S - U");
            if (EMailRecipient != null && EMailRecipient.Length > 1)
            {
                log.Warning("Length > 1 - truncated");
                EMailRecipient = EMailRecipient.Substring(0, 1);
            }
            Set_Value("EMailRecipient", EMailRecipient);
        }
        /** Get EMail Recipient.
        @return Recipient of the EMail */
        public String GetEMailRecipient()
        {
            return (String)Get_Value("EMailRecipient");
        }

        /** EntityType VAF_Control_Ref_ID=389 */
        public static int ENTITYTYPE_VAF_Control_Ref_ID = 389;
        /** Set Entity Type.
        @param EntityType Dictionary Entity Type;
         Determines ownership and synchronization */
        public void SetEntityType(String EntityType)
        {
            if (EntityType.Length > 4)
            {
                log.Warning("Length > 4 - truncated");
                EntityType = EntityType.Substring(0, 4);
            }
            Set_Value("EntityType", EntityType);
        }
        /** Get Entity Type.
        @return Dictionary Entity Type;
         Determines ownership and synchronization */
        public String GetEntityType()
        {
            return (String)Get_Value("EntityType");
        }
        /** Set Export.
        @param Export_ID Export */
        public void SetExport_ID(String Export_ID)
        {
            if (Export_ID != null && Export_ID.Length > 50)
            {
                log.Warning("Length > 50 - truncated");
                Export_ID = Export_ID.Substring(0, 50);
            }
            Set_ValueNoCheck("Export_ID", Export_ID);
        }
        /** Get Export.
        @return Export */
        public String GetExport_ID()
        {
            return (String)Get_Value("Export_ID");
        }

        /** FinishMode VAF_Control_Ref_ID=303 */
        public static int FINISHMODE_VAF_Control_Ref_ID = 303;
        /** Automatic = A */
        public static String FINISHMODE_Automatic = "A";
        /** Manual = M */
        public static String FINISHMODE_Manual = "M";
        /** Is test a valid value.
        @param test testvalue
        @returns true if valid **/
        public bool IsFinishModeValid(String test)
        {
            return test == null || test.Equals("A") || test.Equals("M");
        }
        /** Set Finish Mode.
        @param FinishMode Workflow Activity Finish Mode */
        public void SetFinishMode(String FinishMode)
        {
            if (!IsFinishModeValid(FinishMode))
                throw new ArgumentException("FinishMode Invalid value - " + FinishMode + " - Reference_ID=303 - A - M");
            if (FinishMode != null && FinishMode.Length > 1)
            {
                log.Warning("Length > 1 - truncated");
                FinishMode = FinishMode.Substring(0, 1);
            }
            Set_Value("FinishMode", FinishMode);
        }
        /** Get Finish Mode.
        @return Workflow Activity Finish Mode */
        public String GetFinishMode()
        {
            return (String)Get_Value("FinishMode");
        }
        /** Set Comment.
        @param Help Comment, Help or Hint */
        public void SetHelp(String Help)
        {
            if (Help != null && Help.Length > 2000)
            {
                log.Warning("Length > 2000 - truncated");
                Help = Help.Substring(0, 2000);
            }
            Set_Value("Help", Help);
        }
        /** Get Comment.
        @return Comment, Help or Hint */
        public String GetHelp()
        {
            return (String)Get_Value("Help");
        }
        /** Set Centrally maintained.
        @param IsCentrallyMaintained Information maintained in System Element table */
        public void SetIsCentrallyMaintained(Boolean IsCentrallyMaintained)
        {
            Set_Value("IsCentrallyMaintained", IsCentrallyMaintained);
        }
        /** Get Centrally maintained.
        @return Information maintained in System Element table */
        public Boolean IsCentrallyMaintained()
        {
            Object oo = Get_Value("IsCentrallyMaintained");
            if (oo != null)
            {
                if (oo.GetType() == typeof(bool)) return Convert.ToBoolean(oo);
                return "Y".Equals(oo);
            }
            return false;
        }
        /** Set Multi Approval.
        @param IsMultiApproval Multi Approval */
        public void SetIsMultiApproval(Boolean IsMultiApproval)
        {
            Set_Value("IsMultiApproval", IsMultiApproval);
        }
        /** Get Multi Approval.
        @return Multi Approval */
        public Boolean IsMultiApproval()
        {
            Object oo = Get_Value("IsMultiApproval");
            if (oo != null)
            {
                if (oo.GetType() == typeof(bool)) return Convert.ToBoolean(oo);
                return "Y".Equals(oo);
            }
            return false;
        }

        /** JoinElement VAF_Control_Ref_ID=301 */
        public static int JOINELEMENT_VAF_Control_Ref_ID = 301;
        /** AND = A */
        public static String JOINELEMENT_AND = "A";
        /** XOR = X */
        public static String JOINELEMENT_XOR = "X";
        /** Is test a valid value.
        @param test testvalue
        @returns true if valid **/
        public bool IsJoinElementValid(String test)
        {
            return test.Equals("A") || test.Equals("X");
        }
        /** Set Join Element.
        @param JoinElement Semantics for multiple incoming Transitions */
        public void SetJoinElement(String JoinElement)
        {
            if (JoinElement == null) throw new ArgumentException("JoinElement is mandatory");
            if (!IsJoinElementValid(JoinElement))
                throw new ArgumentException("JoinElement Invalid value - " + JoinElement + " - Reference_ID=301 - A - X");
            if (JoinElement.Length > 1)
            {
                log.Warning("Length > 1 - truncated");
                JoinElement = JoinElement.Substring(0, 1);
            }
            Set_Value("JoinElement", JoinElement);
        }
        /** Get Join Element.
        @return Semantics for multiple incoming Transitions */
        public String GetJoinElement()
        {
            return (String)Get_Value("JoinElement");
        }
        /** Set Name.
        @param Name Alphanumeric identifier of the entity */
        public void SetName(String Name)
        {
            if (Name == null) throw new ArgumentException("Name is mandatory.");
            if (Name.Length > 60)
            {
                log.Warning("Length > 60 - truncated");
                Name = Name.Substring(0, 60);
            }
            Set_Value("Name", Name);
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
        /** Set Priority.
        @param Priority Indicates if this request is of a high, medium or low priority. */
        public void SetPriority(int Priority)
        {
            Set_Value("Priority", Priority);
        }
        /** Get Priority.
        @return Indicates if this request is of a high, medium or low priority. */
        public int GetPriority()
        {
            Object ii = Get_Value("Priority");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }
        /** Set Mail Template.
        @param VAR_MailTemplate_ID Text templates for mailings */
        public void SetVAR_MailTemplate_ID(int VAR_MailTemplate_ID)
        {
            if (VAR_MailTemplate_ID <= 0) Set_Value("VAR_MailTemplate_ID", null);
            else
                Set_Value("VAR_MailTemplate_ID", VAR_MailTemplate_ID);
        }
        /** Get Mail Template.
        @return Text templates for mailings */
        public int GetVAR_MailTemplate_ID()
        {
            Object ii = Get_Value("VAR_MailTemplate_ID");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }

        /** SplitElement VAF_Control_Ref_ID=301 */
        public static int SPLITELEMENT_VAF_Control_Ref_ID = 301;
        /** AND = A */
        public static String SPLITELEMENT_AND = "A";
        /** XOR = X */
        public static String SPLITELEMENT_XOR = "X";
        /** Is test a valid value.
        @param test testvalue
        @returns true if valid **/
        public bool IsSplitElementValid(String test)
        {
            return test.Equals("A") || test.Equals("X");
        }
        /** Set Split Element.
        @param SplitElement Semantics for multiple outgoing Transitions */
        public void SetSplitElement(String SplitElement)
        {
            if (SplitElement == null) throw new ArgumentException("SplitElement is mandatory");
            if (!IsSplitElementValid(SplitElement))
                throw new ArgumentException("SplitElement Invalid value - " + SplitElement + " - Reference_ID=301 - A - X");
            if (SplitElement.Length > 1)
            {
                log.Warning("Length > 1 - truncated");
                SplitElement = SplitElement.Substring(0, 1);
            }
            Set_Value("SplitElement", SplitElement);
        }
        /** Get Split Element.
        @return Semantics for multiple outgoing Transitions */
        public String GetSplitElement()
        {
            return (String)Get_Value("SplitElement");
        }

        /** StartMode VAF_Control_Ref_ID=303 */
        public static int STARTMODE_VAF_Control_Ref_ID = 303;
        /** Automatic = A */
        public static String STARTMODE_Automatic = "A";
        /** Manual = M */
        public static String STARTMODE_Manual = "M";
        /** Is test a valid value.
        @param test testvalue
        @returns true if valid **/
        public bool IsStartModeValid(String test)
        {
            return test == null || test.Equals("A") || test.Equals("M");
        }
        /** Set Start Mode.
        @param StartMode Workflow Activity Start Mode  */
        public void SetStartMode(String StartMode)
        {
            if (!IsStartModeValid(StartMode))
                throw new ArgumentException("StartMode Invalid value - " + StartMode + " - Reference_ID=303 - A - M");
            if (StartMode != null && StartMode.Length > 1)
            {
                log.Warning("Length > 1 - truncated");
                StartMode = StartMode.Substring(0, 1);
            }
            Set_Value("StartMode", StartMode);
        }
        /** Get Start Mode.
        @return Workflow Activity Start Mode  */
        public String GetStartMode()
        {
            return (String)Get_Value("StartMode");
        }

        /** SubflowExecution VAF_Control_Ref_ID=307 */
        public static int SUBFLOWEXECUTION_VAF_Control_Ref_ID = 307;
        /** Asynchronously = A */
        public static String SUBFLOWEXECUTION_Asynchronously = "A";
        /** Synchronously = S */
        public static String SUBFLOWEXECUTION_Synchronously = "S";
        /** Is test a valid value.
        @param test testvalue
        @returns true if valid **/
        public bool IsSubflowExecutionValid(String test)
        {
            return test == null || test.Equals("A") || test.Equals("S");
        }
        /** Set Subflow Execution.
        @param SubflowExecution Mode how the sub-workflow is executed */
        public void SetSubflowExecution(String SubflowExecution)
        {
            if (!IsSubflowExecutionValid(SubflowExecution))
                throw new ArgumentException("SubflowExecution Invalid value - " + SubflowExecution + " - Reference_ID=307 - A - S");
            if (SubflowExecution != null && SubflowExecution.Length > 1)
            {
                log.Warning("Length > 1 - truncated");
                SubflowExecution = SubflowExecution.Substring(0, 1);
            }
            Set_Value("SubflowExecution", SubflowExecution);
        }
        /** Get Subflow Execution.
        @return Mode how the sub-workflow is executed */
        public String GetSubflowExecution()
        {
            return (String)Get_Value("SubflowExecution");
        }

        /** VADMS_Access VAF_Control_Ref_ID=1000152 */
        public static int VADMS_ACCESS_VAF_Control_Ref_ID = 1000152;
        /** None = 10 */
        public static String VADMS_ACCESS_None = "10";
        /** Full = 100 */
        public static String VADMS_ACCESS_Full = "100";
        /** Read = 20 */
        public static String VADMS_ACCESS_Read = "20";
        /** Read/Write = 30 */
        public static String VADMS_ACCESS_ReadWrite = "30";
        /** Read/Write/Delete = 40 */
        public static String VADMS_ACCESS_ReadWriteDelete = "40";
        /** Is test a valid value.
        @param test testvalue
        @returns true if valid **/
        public bool IsVADMS_AccessValid(String test)
        {
            return test == null || test.Equals("10") || test.Equals("100") || test.Equals("20") || test.Equals("30") || test.Equals("40");
        }
        /** Set Access.
        @param VADMS_Access Access */
        public void SetVADMS_Access(String VADMS_Access)
        {
            if (!IsVADMS_AccessValid(VADMS_Access))
                throw new ArgumentException("VADMS_Access Invalid value - " + VADMS_Access + " - Reference_ID=1000152 - 10 - 100 - 20 - 30 - 40");
            if (VADMS_Access != null && VADMS_Access.Length > 3)
            {
                log.Warning("Length > 3 - truncated");
                VADMS_Access = VADMS_Access.Substring(0, 3);
            }
            Set_Value("VADMS_Access", VADMS_Access);
        }
        /** Get Access.
        @return Access */
        public String GetVADMS_Access()
        {
            return (String)Get_Value("VADMS_Access");
        }
        /** Set Folder.
        @param VADMS_Folder_ID Folder */
        public void SetVADMS_Folder_ID(int VADMS_Folder_ID)
        {
            if (VADMS_Folder_ID <= 0) Set_Value("VADMS_Folder_ID", null);
            else
                Set_Value("VADMS_Folder_ID", VADMS_Folder_ID);
        }
        /** Get Folder.
        @return Folder */
        public int GetVADMS_Folder_ID()
        {
            Object ii = Get_Value("VADMS_Folder_ID");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }

        /** VADMS_Folder_ID_1 VAF_Control_Ref_ID=1000148 */
        public static int VADMS_FOLDER_ID_1_VAF_Control_Ref_ID = 1000148;
        /** Set From Folder.
        @param VADMS_Folder_ID_1 From Folder */
        public void SetVADMS_Folder_ID_1(int VADMS_Folder_ID_1)
        {
            Set_Value("VADMS_Folder_ID_1", VADMS_Folder_ID_1);
        }
        /** Get From Folder.
        @return From Folder */
        public int GetVADMS_Folder_ID_1()
        {
            Object ii = Get_Value("VADMS_Folder_ID_1");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }
        /** Set Search Key.
        @param Value Search key for the record in the format required - must be unique */
        public void SetValue(String Value)
        {
            if (Value == null) throw new ArgumentException("Value is mandatory.");
            if (Value.Length > 40)
            {
                log.Warning("Length > 40 - truncated");
                Value = Value.Substring(0, 40);
            }
            Set_Value("Value", Value);
        }
        /** Get Search Key.
        @return Search key for the record in the format required - must be unique */
        public String GetValue()
        {
            return (String)Get_Value("Value");
        }
        /** Set Wait Time.
        @param WaitTime Time in minutes to wait (sleep) */
        public void SetWaitTime(int WaitTime)
        {
            Set_Value("WaitTime", WaitTime);
        }
        /** Get Wait Time.
        @return Time in minutes to wait (sleep) */
        public int GetWaitTime()
        {
            Object ii = Get_Value("WaitTime");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }
        /** Set Waiting Time.
        @param WaitingTime Workflow Simulation Waiting time */
        public void SetWaitingTime(int WaitingTime)
        {
            Set_Value("WaitingTime", WaitingTime);
        }
        /** Get Waiting Time.
        @return Workflow Simulation Waiting time */
        public int GetWaitingTime()
        {
            Object ii = Get_Value("WaitingTime");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }

        /** Workflow_ID VAF_Control_Ref_ID=174 */
        public static int WORKFLOW_ID_VAF_Control_Ref_ID = 174;
        /** Set Workflow.
        @param Workflow_ID Workflow or tasks */
        public void SetWorkflow_ID(int Workflow_ID)
        {
            if (Workflow_ID <= 0) Set_Value("Workflow_ID", null);
            else
                Set_Value("Workflow_ID", Workflow_ID);
        }
        /** Get Workflow.
        @return Workflow or tasks */
        public int GetWorkflow_ID()
        {
            Object ii = Get_Value("Workflow_ID");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }
        /** Set Working Time.
        @param WorkingTime Workflow Simulation Execution Time */
        public void SetWorkingTime(int WorkingTime)
        {
            Set_Value("WorkingTime", WorkingTime);
        }
        /** Get Working Time.
        @return Workflow Simulation Execution Time */
        public int GetWorkingTime()
        {
            Object ii = Get_Value("WorkingTime");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }
        /** Set X Position.
        @param XPosition Absolute X (horizontal) position in 1/72 of an inch */
        public void SetXPosition(int XPosition)
        {
            Set_Value("XPosition", XPosition);
        }
        /** Get X Position.
        @return Absolute X (horizontal) position in 1/72 of an inch */
        public int GetXPosition()
        {
            Object ii = Get_Value("XPosition");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }
        /** Set Y Position.
        @param YPosition Absolute Y (vertical) position in 1/72 of an inch */
        public void SetYPosition(int YPosition)
        {
            Set_Value("YPosition", YPosition);
        }
        /** Get Y Position.
        @return Absolute Y (vertical) position in 1/72 of an inch */
        public int GetYPosition()
        {
            Object ii = Get_Value("YPosition");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }

        ///<summary>
        /// SetQueue with email content
        ///</summary>
        ///<param name="QueueWithEmailContent">Whether save this email node with its content/template</param>
        public void SetQueueWithEmailContent(Boolean QueueWithEmailContent)
        {
            Set_Value("QueueWithEmailContent", QueueWithEmailContent);
        }

        ///<summary>
        /// GetQueue with email content
        ///</summary>
        ///<returns> Whether save this email node with its content/template</returns>
        public Boolean IsQueueWithEmailContent()
        {
            Object oo = Get_Value("QueueWithEmailContent"); if (oo != null)
            {
                if (oo.GetType() == typeof(bool)) return Convert.ToBoolean(oo);
                return "Y".Equals(oo);
            }
            return false;
        }


        ///<summary>
        /// SetIs Background
        ///</summary>
        ///<param name="IsBackground">If true then this node runs at background</param>
        public void SetIsBackground(Boolean IsBackground)
        {
            Set_Value("IsBackground", IsBackground);
        }

        ///<summary>
        /// GetIs Background
        ///</summary>
        ///<returns> If true then this node runs at background</returns>
        public Boolean IsBackground()
        {
            Object oo = Get_Value("IsBackground"); if (oo != null)
            {
                if (oo.GetType() == typeof(bool)) return Convert.ToBoolean(oo);
                return "Y".Equals(oo);
            }
            return false;
        }


        ///<summary>
        /// SetAttach Report
        ///</summary>
        ///<param name="IsAttachReport">Attach Report</param>
        public void SetIsAttachReport(Boolean IsAttachReport)
        {
            Set_Value("IsAttachReport", IsAttachReport);
        }

        ///<summary>
        /// GetAttach Report
        ///</summary>
        ///<returns> Attach Report</returns>
        public Boolean IsAttachReport()
        {
            Object oo = Get_Value("IsAttachReport"); if (oo != null)
            {
                if (oo.GetType() == typeof(bool)) return Convert.ToBoolean(oo);
                return "Y".Equals(oo);
            }
            return false;
        }

        /// <summary>
        /// Set VAF_TextTemplate_ID
        /// </summary>
        /// <param name="VAF_TextTemplate_ID">VAF_TextTemplate_ID</param>
        public void SetVAF_TextTemplate_ID(int VAF_TextTemplate_ID)
        {
            Set_Value("VAF_TextTemplate_ID", VAF_TextTemplate_ID);
        }

        /// <summary>
        /// Get VAF_TextTemplate_ID
        /// </summary>
        /// <returns>VAF_TextTemplate_ID</returns>
        public int GetVAF_TextTemplate_ID()
        {
            Object ii = Get_Value("VAF_TextTemplate_ID");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }

        /** Set Notify Previous Transition Message.
        @param IsNotifyPrevTsnMsg Notify Previous Transition Message */
        public void SetIsNotifyPrevTsnMsg(Boolean IsNotifyPrevTsnMsg)
        {
            Set_Value("IsNotifyPrevTsnMsg", IsNotifyPrevTsnMsg);
        }
        /** Get Notify Previous Transition Message.
        @return Notify Previous Transition Message */
        public Boolean IsNotifyPrevTsnMsg()
        {
            Object oo = Get_Value("IsNotifyPrevTsnMsg");
            if (oo != null)
            {
                if (oo.GetType() == typeof(bool))
                    return Convert.ToBoolean(oo);
                return "Y".Equals(oo);
            }
            return false;
        }

        /** NotifyNode_ID VAF_Control_Ref_ID=1000348 */
        public static int NOTIFYNODE_ID_VAF_Control_Ref_ID = 1000348;/** Set Notify Nodes.
        @param NotifyNode_ID Notify Nodes */
        public void SetNotifyNode_ID(String NotifyNode_ID)
        {
            if (NotifyNode_ID != null && NotifyNode_ID.Length > 500)
            {
                log.Warning("Length > 500 - truncated");
                NotifyNode_ID = NotifyNode_ID.Substring(0, 500);
            }
            Set_Value("NotifyNode_ID", NotifyNode_ID);
        }
        /** Get Notify Nodes.
        @return Notify Nodes */
        public String GetNotifyNode_ID()
        {
            return (String)Get_Value("NotifyNode_ID");
        }

        /** ZoomWindow_ID VAF_Control_Ref_ID=284 */
        public static int ZOOMWINDOW_ID_VAF_Control_Ref_ID = 284;/** Set Zoom Window.
        @param ZoomWindow_ID Zoom Window */
        public void SetZoomWindow_ID(int ZoomWindow_ID)
        {
            if (ZoomWindow_ID <= 0) Set_Value("ZoomWindow_ID", null);
            else
                Set_Value("ZoomWindow_ID", ZoomWindow_ID);
        }/** Get Zoom Window.
        @return Zoom Window */
        public int GetZoomWindow_ID()
        {
            Object ii = Get_Value("ZoomWindow_ID");
            if (ii == null)
                return 0;
            return Convert.ToInt32(ii);
        }
    }

}
