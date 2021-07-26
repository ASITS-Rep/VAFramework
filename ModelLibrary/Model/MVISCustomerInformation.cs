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
    class MVISCustomerInformation : X_VIS_CustomerInformation
    {
        public MVISCustomerInformation(Ctx ctx, int X_VIS_CustomerInformation, Trx trxName)
         : base(ctx, X_VIS_CustomerInformation, trxName)
        {
        }
        public MVISCustomerInformation(Ctx ctx, DataRow rs, Trx trxName)
            : base(ctx, rs, trxName)
        {
        }
    }
}
