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
    class MASI03Product : X_ASI03_Product
    {
        public MASI03Product(Ctx ctx, int X_ASI03_Product, Trx trxName)
        : base(ctx, X_ASI03_Product, trxName)
        {
        }
        public MASI03Product(Ctx ctx, DataRow rs, Trx trxName)
            : base(ctx, rs, trxName)
        {
        }
    }
}
