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
    class MASI03Warehouse : X_ASI03_Warehouse
    {
        public MASI03Warehouse(Ctx ctx, int X_ASI03_Warehouse, Trx trxName)
        : base(ctx, X_ASI03_Warehouse, trxName)
        {
        }
        public MASI03Warehouse(Ctx ctx, DataRow rs, Trx trxName)
            : base(ctx, rs, trxName)
        {
        }
    }
}
