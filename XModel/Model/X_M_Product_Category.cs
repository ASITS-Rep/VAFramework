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
    /** Generated Model for VAM_ProductCategory
     *  @author Jagmohan Bhatt (generated) 
     *  @version Vienna Framework 1.1.1 - $Id$ */
    public class X_VAM_ProductCategory : PO
    {
        public X_VAM_ProductCategory(Context ctx, int VAM_ProductCategory_ID, Trx trxName)
            : base(ctx, VAM_ProductCategory_ID, trxName)
        {
            /** if (VAM_ProductCategory_ID == 0)
            {
            SetIsDefault (false);
            SetIsPurchasedToOrder (false);	// N
            SetIsSelfService (true);	// Y
            SetMMPolicy (null);	// F
            SetVAM_ProductCategory_ID (0);
            SetName (null);
            SetPlannedMargin (0.0);
            SetValue (null);
            }
             */
        }
        public X_VAM_ProductCategory(Ctx ctx, int VAM_ProductCategory_ID, Trx trxName)
            : base(ctx, VAM_ProductCategory_ID, trxName)
        {
            /** if (VAM_ProductCategory_ID == 0)
            {
            SetIsDefault (false);
            SetIsPurchasedToOrder (false);	// N
            SetIsSelfService (true);	// Y
            SetMMPolicy (null);	// F
            SetVAM_ProductCategory_ID (0);
            SetName (null);
            SetPlannedMargin (0.0);
            SetValue (null);
            }
             */
        }
        /** Load Constructor 
        @param ctx context
        @param rs result set 
        @param trxName transaction
        */
        public X_VAM_ProductCategory(Context ctx, DataRow rs, Trx trxName)
            : base(ctx, rs, trxName)
        {
        }
        /** Load Constructor 
        @param ctx context
        @param rs result set 
        @param trxName transaction
        */
        public X_VAM_ProductCategory(Ctx ctx, DataRow rs, Trx trxName)
            : base(ctx, rs, trxName)
        {
        }
        /** Load Constructor 
        @param ctx context
        @param rs result set 
        @param trxName transaction
        */
        public X_VAM_ProductCategory(Ctx ctx, IDataReader dr, Trx trxName)
            : base(ctx, dr, trxName)
        {
        }
        /** Static Constructor 
         Set Table ID By Table Name
         added by ->Harwinder */
        static X_VAM_ProductCategory()
        {
            Table_ID = Get_Table_ID(Table_Name);
            model = new KeyNamePair(Table_ID, Table_Name);
        }
        /** Serial Version No */
        static long serialVersionUID = 27721931421699L;
        /** Last Updated Timestamp 8/17/2015 3:38:25 PM */
        public static long updatedMS = 1439806104910L;
        /** VAF_TableView_ID=209 */
        public static int Table_ID;
        // =209;

        /** TableName=VAM_ProductCategory */
        public static String Table_Name = "VAM_ProductCategory";

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
            StringBuilder sb = new StringBuilder("X_VAM_ProductCategory[").Append(Get_ID()).Append("]");
            return sb.ToString();
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
        /** Set Print Color.
        @param VAF_Print_Rpt_Colour_ID Color used for printing and display */
        public void SetVAF_Print_Rpt_Colour_ID(int VAF_Print_Rpt_Colour_ID)
        {
            if (VAF_Print_Rpt_Colour_ID <= 0) Set_Value("VAF_Print_Rpt_Colour_ID", null);
            else
                Set_Value("VAF_Print_Rpt_Colour_ID", VAF_Print_Rpt_Colour_ID);
        }
        /** Get Print Color.
        @return Color used for printing and display */
        public int GetVAF_Print_Rpt_Colour_ID()
        {
            Object ii = Get_Value("VAF_Print_Rpt_Colour_ID");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }
        /** Set Asset Group.
        @param VAA_AssetGroup_ID Group of Assets */
        public void SetVAA_AssetGroup_ID(int VAA_AssetGroup_ID)
        {
            if (VAA_AssetGroup_ID <= 0) Set_Value("VAA_AssetGroup_ID", null);
            else
                Set_Value("VAA_AssetGroup_ID", VAA_AssetGroup_ID);
        }
        /** Get Asset Group.
        @return Group of Assets */
        public int GetVAA_AssetGroup_ID()
        {
            Object ii = Get_Value("VAA_AssetGroup_ID");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }
        /** Set Tax Category.
        @param VAB_TaxCategory_ID Tax Category */
        public void SetVAB_TaxCategory_ID(int VAB_TaxCategory_ID)
        {
            if (VAB_TaxCategory_ID <= 0) Set_Value("VAB_TaxCategory_ID", null);
            else
                Set_Value("VAB_TaxCategory_ID", VAB_TaxCategory_ID);
        }
        /** Get Tax Category.
        @return Tax Category */
        public int GetVAB_TaxCategory_ID()
        {
            Object ii = Get_Value("VAB_TaxCategory_ID");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }
        /** Set Consumable.
        @param DTD001_IsConsumable Consumable */
        public void SetDTD001_IsConsumable(Boolean DTD001_IsConsumable)
        {
            Set_Value("DTD001_IsConsumable", DTD001_IsConsumable);
        }
        /** Get Consumable.
        @return Consumable */
        public Boolean IsDTD001_IsConsumable()
        {
            Object oo = Get_Value("DTD001_IsConsumable");
            if (oo != null)
            {
                if (oo.GetType() == typeof(bool)) return Convert.ToBoolean(oo);
                return "Y".Equals(oo);
            }
            return false;
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
        /** Set Process.
        @param FRPT_Process Process */
        public void SetFRPT_Process(String FRPT_Process)
        {
            if (FRPT_Process != null && FRPT_Process.Length > 30)
            {
                log.Warning("Length > 30 - truncated");
                FRPT_Process = FRPT_Process.Substring(0, 30);
            }
            Set_Value("FRPT_Process", FRPT_Process);
        }
        /** Get Process.
        @return Process */
        public String GetFRPT_Process()
        {
            return (String)Get_Value("FRPT_Process");
        }
        /** Set Default.
        @param IsDefault Default value */
        public void SetIsDefault(Boolean IsDefault)
        {
            Set_Value("IsDefault", IsDefault);
        }
        /** Get Default.
        @return Default value */
        public Boolean IsDefault()
        {
            Object oo = Get_Value("IsDefault");
            if (oo != null)
            {
                if (oo.GetType() == typeof(bool)) return Convert.ToBoolean(oo);
                return "Y".Equals(oo);
            }
            return false;
        }
        /** Set Purchased To Order.
        @param IsPurchasedToOrder Products that are usually not kept in stock, but are purchased whenever there is a demand */
        public void SetIsPurchasedToOrder(Boolean IsPurchasedToOrder)
        {
            Set_Value("IsPurchasedToOrder", IsPurchasedToOrder);
        }
        /** Get Purchased To Order.
        @return Products that are usually not kept in stock, but are purchased whenever there is a demand */
        public Boolean IsPurchasedToOrder()
        {
            Object oo = Get_Value("IsPurchasedToOrder");
            if (oo != null)
            {
                if (oo.GetType() == typeof(bool)) return Convert.ToBoolean(oo);
                return "Y".Equals(oo);
            }
            return false;
        }
        /** Set Self-Service.
        @param IsSelfService This is a Self-Service entry or this entry can be changed via Self-Service */
        public void SetIsSelfService(Boolean IsSelfService)
        {
            Set_Value("IsSelfService", IsSelfService);
        }
        /** Get Self-Service.
        @return This is a Self-Service entry or this entry can be changed via Self-Service */
        public Boolean IsSelfService()
        {
            Object oo = Get_Value("IsSelfService");
            if (oo != null)
            {
                if (oo.GetType() == typeof(bool)) return Convert.ToBoolean(oo);
                return "Y".Equals(oo);
            }
            return false;
        }

        /** MMPolicy VAF_Control_Ref_ID=335 */
        public static int MMPOLICY_VAF_Control_Ref_ID = 335;
        /** FiFo = F */
        public static String MMPOLICY_FiFo = "F";
        /** LiFo = L */
        public static String MMPOLICY_LiFo = "L";
        /** Is test a valid value.
        @param test testvalue
        @returns true if valid **/
        public bool IsMMPolicyValid(String test)
        {
            return test.Equals("F") || test.Equals("L");
        }
        /** Set Material Policy.
        @param MMPolicy Material Movement Policy */
        public void SetMMPolicy(String MMPolicy)
        {
            if (MMPolicy == null) throw new ArgumentException("MMPolicy is mandatory");
            if (!IsMMPolicyValid(MMPolicy))
                throw new ArgumentException("MMPolicy Invalid value - " + MMPolicy + " - Reference_ID=335 - F - L");
            if (MMPolicy.Length > 1)
            {
                log.Warning("Length > 1 - truncated");
                MMPolicy = MMPolicy.Substring(0, 1);
            }
            Set_Value("MMPolicy", MMPolicy);
        }
        /** Get Material Policy.
        @return Material Movement Policy */
        public String GetMMPolicy()
        {
            return (String)Get_Value("MMPolicy");
        }
        /** Set Attribute Set.
        @param VAM_PFeature_Set_ID Product Attribute Set */
        public void SetVAM_PFeature_Set_ID(int VAM_PFeature_Set_ID)
        {
            if (VAM_PFeature_Set_ID <= 0) Set_Value("VAM_PFeature_Set_ID", null);
            else
                Set_Value("VAM_PFeature_Set_ID", VAM_PFeature_Set_ID);
        }
        /** Get Attribute Set.
        @return Product Attribute Set */
        public int GetVAM_PFeature_Set_ID()
        {
            Object ii = Get_Value("VAM_PFeature_Set_ID");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
        }

        /** Set Cost Element. @param VAM_ProductCostElement_ID Product Cost Element */
        public void SetVAM_ProductCostElement_ID(int VAM_ProductCostElement_ID)
        {
            if (VAM_ProductCostElement_ID <= 0) Set_Value("VAM_ProductCostElement_ID", null);
            else
                Set_Value("VAM_ProductCostElement_ID", VAM_ProductCostElement_ID);
        }/** Get Cost Element. @return Product Cost Element */
        public int GetVAM_ProductCostElement_ID() { Object ii = Get_Value("VAM_ProductCostElement_ID"); if (ii == null) return 0; return Convert.ToInt32(ii); }

        /** Set Product Category.
        @param VAM_ProductCategory_ID Category of a Product */
        public void SetVAM_ProductCategory_ID(int VAM_ProductCategory_ID)
        {
            if (VAM_ProductCategory_ID < 1) throw new ArgumentException("VAM_ProductCategory_ID is mandatory.");
            Set_ValueNoCheck("VAM_ProductCategory_ID", VAM_ProductCategory_ID);
        }
        /** Get Product Category.
        @return Category of a Product */
        public int GetVAM_ProductCategory_ID()
        {
            Object ii = Get_Value("VAM_ProductCategory_ID");
            if (ii == null) return 0;
            return Convert.ToInt32(ii);
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
        /** Set Planned Margin %.
        @param PlannedMargin Project's planned margin as a percentage */
        public void SetPlannedMargin(Decimal? PlannedMargin)
        {
            if (PlannedMargin == null) throw new ArgumentException("PlannedMargin is mandatory.");
            Set_Value("PlannedMargin", (Decimal?)PlannedMargin);
        }
        /** Get Planned Margin %.
        @return Project's planned margin as a percentage */
        public Decimal GetPlannedMargin()
        {
            Object bd = Get_Value("PlannedMargin");
            if (bd == null) return Env.ZERO;
            return Convert.ToDecimal(bd);
        }

        /** ProductType VAF_Control_Ref_ID=270 */
        public static int PRODUCTTYPE_VAF_Control_Ref_ID = 270;
        /** Expense type = E */
        public static String PRODUCTTYPE_ExpenseType = "E";
        /** Item = I */
        public static String PRODUCTTYPE_Item = "I";
        /** Online = O */
        public static String PRODUCTTYPE_Online = "O";
        /** Resource = R */
        public static String PRODUCTTYPE_Resource = "R";
        /** Service = S */
        public static String PRODUCTTYPE_Service = "S";
        /** Is test a valid value.
        @param test testvalue
        @returns true if valid **/
        public bool IsProductTypeValid(String test)
        {
            return test == null || test.Equals("E") || test.Equals("I") || test.Equals("O") || test.Equals("R") || test.Equals("S");
        }
        /** Set Product Type.
        @param ProductType Type of product */
        public void SetProductType(String ProductType)
        {
            if (!IsProductTypeValid(ProductType))
                throw new ArgumentException("ProductType Invalid value - " + ProductType + " - Reference_ID=270 - E - I - O - R - S");
            if (ProductType != null && ProductType.Length > 1)
            {
                log.Warning("Length > 1 - truncated");
                ProductType = ProductType.Substring(0, 1);
            }
            Set_Value("ProductType", ProductType);
        }
        /** Get Product Type.
        @return Type of product */
        public String GetProductType()
        {
            return (String)Get_Value("ProductType");
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

        /** Set Refernce Prod Category ID.
        @param VA007_RefProdCat_ID Refernce Prod Category ID */
        public void SetVA007_RefProdCat_ID(String VA007_RefProdCat_ID)
        {
            if (VA007_RefProdCat_ID != null && VA007_RefProdCat_ID.Length > 50)
            {
                log.Warning("Length > 50 - truncated");
                VA007_RefProdCat_ID = VA007_RefProdCat_ID.Substring(0, 50);
            }
            Set_Value("VA007_RefProdCat_ID", VA007_RefProdCat_ID);
        }
        /** Get Refernce Prod Category ID.
        @return Refernce Prod Category ID */
        public String GetVA007_RefProdCat_ID()
        {
            return (String)Get_Value("VA007_RefProdCat_ID");
        }

        #region FRPT Posting Columns
        /** FRPT_CostingLevel VAF_Control_Ref_ID=355 */
        public static int FRPT_COSTINGLEVEL_VAF_Control_Ref_ID = 355;/** Batch/Lot = B */
        public static String FRPT_COSTINGLEVEL_BatchLot = "B";/** Client = C */
        public static String FRPT_COSTINGLEVEL_Client = "C";/** Organization = O */
        public static String FRPT_COSTINGLEVEL_Organization = "O";

        /** Is test a valid value.
        @param test testvalue
        @returns true if valid **/
        public bool IsFRPT_CostingLevelValid(String test)
        {
            return test == null || test.Equals("B") || test.Equals("C") || test.Equals("O");
        }

        /** Set Costing Level.
        @param FRPT_CostingLevel Costing Level */
        public void SetFRPT_CostingLevel(String FRPT_CostingLevel)
        {
            if (!IsFRPT_CostingLevelValid(FRPT_CostingLevel))
                throw new ArgumentException("FRPT_CostingLevel Invalid value - " + FRPT_CostingLevel + " - Reference_ID=355 - B - C - O");
            if (FRPT_CostingLevel != null && FRPT_CostingLevel.Length > 1)
            {
                log.Warning("Length > 1 - truncated");
                FRPT_CostingLevel = FRPT_CostingLevel.Substring(0, 1);
            }
            Set_Value("FRPT_CostingLevel", FRPT_CostingLevel);
        }

        /** Get Costing Level.
        @return Costing Level */
        public String GetFRPT_CostingLevel()
        {
            return (String)Get_Value("FRPT_CostingLevel");
        }

        /** FRPT_CostingMethod VAF_Control_Ref_ID=122 */
        public static int FRPT_COSTINGMETHOD_VAF_Control_Ref_ID = 122;/** Average PO = A */
        public static String FRPT_COSTINGMETHOD_AveragePO = "A";/** Fifo = F */
        public static String FRPT_COSTINGMETHOD_Fifo = "F";/** Average Invoice = I */
        public static String FRPT_COSTINGMETHOD_AverageInvoice = "I";/** Lifo = L */
        public static String FRPT_COSTINGMETHOD_Lifo = "L";/** Standard Costing = S */
        public static String FRPT_COSTINGMETHOD_StandardCosting = "S";/** User Defined = U */
        public static String FRPT_COSTINGMETHOD_UserDefined = "U";/** Last Invoice = i */
        public static String FRPT_COSTINGMETHOD_LastInvoice = "i";/** Last PO Price = p */
        public static String FRPT_COSTINGMETHOD_LastPOPrice = "p";/** _ = x */
        public static String FRPT_COSTINGMETHOD_ = "x";

        /** Is test a valid value.
        @param test testvalue
        @returns true if valid **/
        public bool IsFRPT_CostingMethodValid(String test)
        {
            return test == null || test.Equals("A") || test.Equals("F") || test.Equals("I") ||
                test.Equals("L") || test.Equals("S") || test.Equals("U") || test.Equals("i")
                || test.Equals("p") || test.Equals("x");
        }

        /** Set Costing Method.
        @param FRPT_CostingMethod Costing Method */
        public void SetFRPT_CostingMethod(String FRPT_CostingMethod)
        {
            if (!IsFRPT_CostingMethodValid(FRPT_CostingMethod))
                throw new ArgumentException("FRPT_CostingMethod Invalid value - " + FRPT_CostingMethod + " - Reference_ID=122 - A - F - I - L - S - U - i - p - x");
            if (FRPT_CostingMethod != null && FRPT_CostingMethod.Length > 1)
            {
                log.Warning("Length > 1 - truncated");
                FRPT_CostingMethod = FRPT_CostingMethod.Substring(0, 1);
            }
            Set_Value("FRPT_CostingMethod", FRPT_CostingMethod);
        }

        /** Get Costing Method.
        @return Costing Method */
        public String GetFRPT_CostingMethod()
        {
            return (String)Get_Value("FRPT_CostingMethod");
        }

        #endregion


        /** CostingLevel VAF_Control_Ref_ID=355 */
        public static int COSTINGLEVEL_VAF_Control_Ref_ID = 355;/** Org + Batch = A */
        public static String COSTINGLEVEL_OrgPlusBatch = "A";/** Batch/Lot = B */
        public static String COSTINGLEVEL_BatchLot = "B";/** Client = C */
        public static String COSTINGLEVEL_Client = "C";/** Warehouse + Batch = D */
        public static String COSTINGLEVEL_WarehousePlusBatch = "D";/** Organization = O */
        public static String COSTINGLEVEL_Organization = "O";/** Warehouse = W */
        public static String COSTINGLEVEL_Warehouse = "W";
        /** Is test a valid value.
    @param test testvalue
    @returns true if valid **/
        public bool IsCostingLevelValid(String test)
        {
            return test == null || test.Equals("A") || test.Equals("B") || test.Equals("C") || test.Equals("D") || test.Equals("O") || test.Equals("W");
        }
        /** Set Costing Level.
    @param CostingLevel The lowest level to accumulate Costing Information */
        public void SetCostingLevel(String CostingLevel)
        {
            if (!IsCostingLevelValid(CostingLevel))
                throw new ArgumentException("CostingLevel Invalid value - " + CostingLevel + " - Reference_ID=355 - A - B - C - D - O - W"); if (CostingLevel != null && CostingLevel.Length > 1) { log.Warning("Length > 1 - truncated"); CostingLevel = CostingLevel.Substring(0, 1); } Set_Value("CostingLevel", CostingLevel);
        }
        /** Get Costing Level.
    @return The lowest level to accumulate Costing Information */
        public String GetCostingLevel()
        {
            return (String)Get_Value("CostingLevel");
        }

        /** CostingMethod VAF_Control_Ref_ID=122 */
        public static int COSTINGMETHOD_VAF_Control_Ref_ID = 122;/** Average PO = A */
        public static String COSTINGMETHOD_AveragePO = "A";/** Cost Combination = C */
        public static String COSTINGMETHOD_CostCombination = "C";/** Fifo = F */
        public static String COSTINGMETHOD_Fifo = "F";/** Average Invoice = I */
        public static String COSTINGMETHOD_AverageInvoice = "I";/** Lifo = L */
        public static String COSTINGMETHOD_Lifo = "L";/** Standard Costing = S */
        public static String COSTINGMETHOD_StandardCosting = "S";/** User Defined = U */
        public static String COSTINGMETHOD_UserDefined = "U";/** Last Invoice = i */
        public static String COSTINGMETHOD_LastInvoice = "i";/** Last PO Price = p */
        public static String COSTINGMETHOD_LastPOPrice = "p";/** _ = x */
        public static String COSTINGMETHOD_ = "x";/** Is test a valid value.
@param test testvalue
@returns true if valid **/
        public bool IsCostingMethodValid(String test) { return test == null || test.Equals("A") || test.Equals("C") || test.Equals("F") || test.Equals("I") || test.Equals("L") || test.Equals("S") || test.Equals("U") || test.Equals("i") || test.Equals("p") || test.Equals("x"); }/** Set Costing Method.
@param CostingMethod Indicates how Costs will be calculated */
        public void SetCostingMethod(String CostingMethod)
        {
            if (!IsCostingMethodValid(CostingMethod))
                throw new ArgumentException("CostingMethod Invalid value - " + CostingMethod + " - Reference_ID=122 - A - C - F - I - L - S - U - i - p - x"); if (CostingMethod != null && CostingMethod.Length > 1) { log.Warning("Length > 1 - truncated"); CostingMethod = CostingMethod.Substring(0, 1); } Set_Value("CostingMethod", CostingMethod);
        }/** Get Costing Method.
@return Indicates how Costs will be calculated */
        public String GetCostingMethod() { return (String)Get_Value("CostingMethod"); }
    }

}
