using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAdvantage.DataBase;
using VAdvantage.Logging;
using VAdvantage.Model;
using VAdvantage.Utility;
using ViennaAdvantage.Model;

namespace VAdvantage.Model
{
    class MASI03ProductTransaction : X_ASI03_ProductTransaction
    {
        string _processMsg = "";
        string _fromprod = "";
        string _toprod = "";
        int fromwharehouse;
        int towarehouse;
        int productId;
        int amount;
        public MASI03ProductTransaction(Ctx ctx, int X_ASI03_ProductTransaction, Trx trxName)
        : base(ctx, X_ASI03_ProductTransaction, trxName)
        {
        }
        public MASI03ProductTransaction(Ctx ctx, DataRow rs, Trx trxName)
            : base(ctx, rs, trxName)
        {
        }

        protected override bool BeforeSave(bool newRecord)
        {
            fromwharehouse = GetASI03_FromStorage();
            towarehouse = GetASI03_ToStorage();
            productId = GetASI03_Product_ID();
            amount = GetASI03_ProductAmount();
            _fromprod = "select ASI03_WarehouseProducts_ID from ASI03_WarehouseProducts where IsActive='Y' "
                        + "and ASI03_Warehouse_ID =" + fromwharehouse + " and ASI03_Product_ID =" + productId;
            _toprod = "select ASI03_WarehouseProducts_ID from ASI03_WarehouseProducts where IsActive='Y' "
                        + "and ASI03_Warehouse_ID =" + towarehouse + " and ASI03_Product_ID =" + productId;

            int fromProdId = Util.GetValueOfInt(DB.ExecuteScalar(_fromprod.ToString()));
            int toProdId = Util.GetValueOfInt(DB.ExecuteScalar(_toprod.ToString()));
            MASI03WarehouseProducts fromProd = new MASI03WarehouseProducts(GetCtx(), fromProdId, Get_TrxName());
            MASI03WarehouseProducts toProd = new MASI03WarehouseProducts(GetCtx(), toProdId, Get_TrxName());
            int fromProdAmount = fromProd.GetASI03_ProductAmount();
            int toProdAmount = toProd.GetASI03_ProductAmount();
            fromProd.SetASI03_ProductAmount(fromProdAmount - amount);
            toProd.SetASI03_ProductAmount(toProdAmount + amount);
            if (!fromProd.Save())
            {
                ValueNamePair vnp = VLogger.RetrieveError();
                _processMsg = Msg.GetMsg(GetCtx(), "") + " :: " + vnp.Name;
            }
            if (!toProd.Save())
            {
                ValueNamePair vnp = VLogger.RetrieveError();
                _processMsg = Msg.GetMsg(GetCtx(), "") + " :: " + vnp.Name;
            }
            return true;
        }
    }
}
