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
    public class MASI03Patient : X_ASI03_Patient
    {
        public MASI03Patient(Ctx ctx, int X_ASI03_Patient, Trx trxName)
         : base(ctx, X_ASI03_Patient, trxName)
        {
        }
        public MASI03Patient(Ctx ctx, DataRow rs, Trx trxName)
            : base(ctx, rs, trxName)
        {
        }
    }
}
