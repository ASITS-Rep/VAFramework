using System.Data;
using VAdvantage.DataBase;
using VAdvantage.Utility;

namespace VAdvantage.Model
{
    public class X_VIS_CustomerInformation2
    {
        private Ctx ctx;
        private int x_VIS_CustomerInformation2;
        private int x_VIS_CustomerInformation;
        private Trx trxName;
        private DataRow rs;

        public X_VIS_CustomerInformation2(Ctx ctx, int x_VIS_CustomerInformation2, Trx trxName)
        {
            this.ctx = ctx;
            this.x_VIS_CustomerInformation2 = x_VIS_CustomerInformation2;
            this.trxName = trxName;
        }

        public X_VIS_CustomerInformation2(Ctx ctx, DataRow rs, Trx trxName)
        {
            this.ctx = ctx;
            this.rs = rs;
            this.trxName = trxName;
        }
    }
}