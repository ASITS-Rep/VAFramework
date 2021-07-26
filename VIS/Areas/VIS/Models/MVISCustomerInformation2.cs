using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAdvantage.DataBase;
using VAdvantage.Utility;
using ViennaAdvantage.Model;

namespace VIS.Models
{
    public class MVISCustomerInformation2 : X_VIS_CustomerInformation2
    {
        /// <summary>
        /// Standard Constructor
        /// </summary>
        /// <param name="ctx">context</param>
        /// <param name="VIS_CustomerInformation2_ID">id</param>
        /// <param name="trxName">transaction</param>
        public MVISCustomerInformation2(Ctx ctx, int VIS_CustomerInformation2_ID, Trx trxName)
            : base(ctx, VIS_CustomerInformation2_ID, trxName)
        {

        }

        /// <summary>
        ///	Load Constructor
        /// </summary>
        /// <param name="ctx">context</param>
        /// <param name="dr">DataRow</param>
        /// <param name="trxName">transaction</param>
        public MVISCustomerInformation2(Ctx ctx, DataRow dr, Trx trxName)
            : base(ctx, dr, trxName)
        {

        }

        /// <summary>
        ///	After Save.Insert - create tree
        /// </summary>
        /// <param name="newRecord">insert</param>
        /// <param name="success">save success</param>
        /// <returns>true if saved</returns>
        protected override bool AfterSave(bool newRecord, bool success)
        {
            if (!success)
            {
                return success;
            }
            //	Value/Name change

            return true;
        }

    }
}
