﻿/********************************************************
 * Module Name    : 
 * Purpose        : Inventory Movement Confirmation Line
 * Class Used     : X_VAM_InvTrf_LineConfirm
 * Chronological Development
 * Veena         27-Oct-2009
 ******************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using VAdvantage.Classes;
using VAdvantage.Common;
using VAdvantage.Process;
using VAdvantage.DataBase;
using VAdvantage.Utility;
using System.Data;
using System.Data.SqlClient;
using VAdvantage.Logging;

namespace VAdvantage.Model
{
    /// <summary>
    /// Inventory Movement Confirmation Line
    /// </summary>
    public class MMovementLineConfirm : X_VAM_InvTrf_LineConfirm
    {
        /**	Movement Line			*/
        private MMovementLine _line = null;

        /// <summary>
        /// Standard Constructor
        /// </summary>
        /// <param name="ctx">context</param>
        /// <param name="VAM_InvTrf_LineConfirm_ID">id</param>
        /// <param name="trxName">transaction</param>
        public MMovementLineConfirm(Ctx ctx, int VAM_InvTrf_LineConfirm_ID, Trx trxName)
            : base(ctx, VAM_InvTrf_LineConfirm_ID, trxName)
	    {
            if (VAM_InvTrf_LineConfirm_ID == 0)
		    {
                //	SetVAM_InvTrf_Confirm_ID (0);	Parent
                //	SetVAM_InvTrf_Line_ID (0);
                SetConfirmedQty(Env.ZERO);
                SetDifferenceQty(Env.ZERO);
                SetScrappedQty(Env.ZERO);
                SetTargetQty(Env.ZERO);
                SetProcessed(false);
            }	
	    }

	    /// <summary>
        /// Load Constructor
        /// </summary>
        /// <param name="ctx">context</param>
        /// <param name="dr">data row</param>
        /// <param name="trxName">transation</param>
        public MMovementLineConfirm(Ctx ctx, DataRow dr, Trx trxName)
            : base(ctx, dr, trxName)
        {
        }

	    /// <summary>
	    /// Parent constructor
	    /// </summary>
	    /// <param name="parent">parent</param>
	    public MMovementLineConfirm (MMovementConfirm parent)
            : this(parent.GetCtx(), 0, parent.Get_TrxName())
	    {
            SetClientOrg(parent);
            SetVAM_InvTrf_Confirm_ID(parent.GetVAM_InvTrf_Confirm_ID());
	    }

        /// <summary>
        /// Set Movement Line
        /// </summary>
        /// <param name="line">line</param>
        public void SetMovementLine(MMovementLine line)
        {
            SetVAM_InvTrf_Line_ID(line.GetVAM_InvTrf_Line_ID());
            SetTargetQty(line.GetMovementQty());
            //Amit 25-nov-2014
            // SetConfirmedQty(GetTargetQty());	//	suggestion
            SetConfirmedQty(0);
            //amit
            _line = line;
        }

        /// <summary>
        /// Get Movement Line
        /// </summary>
        /// <returns>line</returns>
        public MMovementLine GetLine()
        {
            if (_line == null)
                _line = new MMovementLine(GetCtx(), GetVAM_InvTrf_Line_ID(), Get_TrxName());
            return _line;
        }

        /// <summary>
        /// Process Confirmation Line.
        ///	- Update Movement Line
        /// </summary>
        /// <returns>success</returns>
        public Boolean ProcessLine()
        {
            MMovementLine line = GetLine();

            line.SetTargetQty(GetTargetQty());
            line.SetMovementQty(GetConfirmedQty());
            line.SetConfirmedQty(GetConfirmedQty());
            line.SetScrappedQty(GetScrappedQty());

            return line.Save(Get_TrxName());
        }

        //Handle Reverse case
        public Boolean ProcessLineReverse()
        {
            MMovementLine line = GetLine();

            line.SetTargetQty(line.GetQtyEntered());
            line.SetMovementQty(line.GetQtyEntered());
            line.SetConfirmedQty(0);
            line.SetScrappedQty(0);

            return line.Save(Get_TrxName());
        }

        /// <summary>
        /// Is Fully Confirmed
        /// </summary>
        /// <returns>true if TarGet = Confirmed qty</returns>
        public Boolean IsFullyConfirmed()
        {
            return GetTargetQty().CompareTo(GetConfirmedQty()) == 0;
        }

        /// <summary>
        /// Before Delete - do not delete
        /// </summary>
        /// <returns>false</returns>
        protected override Boolean BeforeDelete()
        {
            return false;
        }

        /// <summary>
        /// Before Save
        /// </summary>
        /// <param name="newRecord">new</param>
        /// <returns>true</returns>
        protected override Boolean BeforeSave(Boolean newRecord)
        {
            //	Calculate Difference = Target - Confirmed - Scrapped
            //Decimal difference = GetTargetQty();
            //difference = Decimal.Subtract(difference, GetConfirmedQty());
            //difference = Decimal.Subtract(difference, GetScrappedQty());
            //SetDifferenceQty(difference);
            //
            return true;
        }
    }
}
