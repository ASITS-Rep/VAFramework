using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAdvantage.DataBase;
using VAdvantage.Utility;
using ViennaAdvantage.Model;

namespace VAdvantage.Model
{
    class MASI03Session : X_ASI03_Session
    {
        public MASI03Session(Ctx ctx, int X_ASI03_Session, Trx trxName)
         : base(ctx, X_ASI03_Session, trxName)
        {
        }
        public MASI03Session(Ctx ctx, DataRow rs, Trx trxName)
            : base(ctx, rs, trxName)
        {
        }
    }
}
