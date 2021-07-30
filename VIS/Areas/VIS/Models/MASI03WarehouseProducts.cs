using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAdvantage.DataBase;
using VAdvantage.Model;
using VAdvantage.Utility;
using ViennaAdvantage.Model;

namespace VAdvantage.Model
{
    class MASI03WarehouseProducts : X_ASI03_WarehouseProducts
    {
        public MASI03WarehouseProducts(Ctx ctx, int X_ASI03_WarehouseProducts, Trx trxName)
        : base(ctx, X_ASI03_WarehouseProducts, trxName)
        {
        }
        public MASI03WarehouseProducts(Ctx ctx, DataRow rs, Trx trxName)
            : base(ctx, rs, trxName)
        {
        }
    }
}
