using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAdvantage.DataBase;
using VAdvantage.Utility;

namespace ViennaAdvantage.Model
{
    public class MASI03Department : X_ASI03_Department
    {
        public MASI03Department(Ctx ctx, int X_ASI03_Department, Trx trxName)
         : base(ctx, X_ASI03_Department, trxName)
        {
        }
        public MASI03Department(Ctx ctx, DataRow rs, Trx trxName)
            : base(ctx, rs, trxName)
        {
        }
    }
}
