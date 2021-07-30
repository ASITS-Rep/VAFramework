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
    class MASI03Storage : X_ASI03_Storage
    {
        public MASI03Storage(Ctx ctx, int X_ASI03_Storage, Trx trxName)
        : base(ctx, X_ASI03_Storage, trxName)
        {
        }
        public MASI03Storage(Ctx ctx, DataRow rs, Trx trxName)
            : base(ctx, rs, trxName)
        {
        }
    }
}
