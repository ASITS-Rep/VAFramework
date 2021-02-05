﻿/********************************************************
 * Project Name   : VAdvantage
 * Class Name     : MProductCosting
 * Purpose        : 
 * Class Used     : 
 * Chronological    Development
 * Raghunandan     15-Jun-2009
  ******************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VAdvantage.Classes;
using VAdvantage.Common;
using VAdvantage.Process;
//////using System.Windows.Forms;
using VAdvantage.Model;
using VAdvantage.DataBase;
using VAdvantage.SqlExec;
using VAdvantage.Utility;
using System.Data;
using VAdvantage.Logging;

namespace VAdvantage.Model
{
    public class MProductCosting : X_VAM_ProductCosting
    {

        /**	Static Logger	*/
        private static VLogger _log = VLogger.GetVLogger(typeof(MProductCosting).FullName);

        /**
         * 	Get Costing Of Product
         *	@param ctx context
         *	@param VAM_Product_ID product
         *	@param trxName trx
         *	@return array of costs
         */
        public static MProductCosting[] GetOfProduct(Ctx ctx, int VAM_Product_ID, Trx trxName)
        {
            String sql = "SELECT * FROM VAM_ProductCosting WHERE VAM_Product_ID=" + VAM_Product_ID;
            List<MProductCosting> list = new List<MProductCosting>();
            DataTable dt = null;
            IDataReader idr = null;
            try
            {
                idr = DataBase.DB.ExecuteReader(sql, null, trxName);
                dt = new DataTable();
                dt.Load(idr);
                idr.Close();
                foreach(DataRow dr in dt.Rows)
                {
                    list.Add(new MProductCosting(ctx, dr, trxName));
                }
            }
            catch (Exception e)
            {
                if (idr != null)
                {
                    idr.Close();
                }
                _log.Log(Level.SEVERE, sql, e);
            }
            finally
            {
                if (idr != null)
                {
                    idr.Close();
                }
                dt = null;
            }
            MProductCosting[] retValue = new MProductCosting[list.Count];
            retValue=list.ToArray();
            return retValue;
        }	

        /**
         * 	Get Costing
         *	@param ctx context
         *	@param VAM_Product_ID product
         *	@param VAB_AccountBook_ID as
         *	@param trxName trx
         *	@return array of costs
         */
        public static MProductCosting Get(Ctx ctx, int VAM_Product_ID,
            int VAB_AccountBook_ID, Trx trxName)
        {
            MProductCosting retValue = null;
            String sql = "SELECT * FROM VAM_ProductCosting WHERE VAM_Product_ID=" + VAM_Product_ID + " AND VAB_AccountBook_ID=" + VAB_AccountBook_ID;
            DataTable dt = null;
            IDataReader idr = null;
            try
            {
                
                idr = DataBase.DB.ExecuteReader(sql, null, trxName);
                dt = new DataTable();
                dt.Load(idr);
                idr.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    retValue = new MProductCosting(ctx, dr, trxName);
                }
            }
            catch (Exception e)
            {
                if (idr != null)
                {
                    idr.Close();
                }
                _log.Log(Level.SEVERE, sql, e);
            }
            finally
            {
                if (idr != null)
                {
                    idr.Close();
                }
                dt = null;
            }
            return retValue;
        }	




        /***
         * 	Standard Constructor (odl)
         *	@param ctx context
         *	@param ignored (multi key)
         *	@param trxName transaction
         */
        public MProductCosting(Ctx ctx, int ignored, Trx trxName)
            : base(ctx, ignored, trxName)
        {
            
            if (ignored != 0)
                throw new ArgumentException("Multi-Key");
            else
            {
                //	setVAM_Product_ID (0);
                //	setVAB_AccountBook_ID (0);
                //
                SetCostAverage(Env.ZERO);
                SetCostAverageCumAmt(Env.ZERO);
                SetCostAverageCumQty(Env.ZERO);
                SetCostStandard(Env.ZERO);
                SetCostStandardCumAmt(Env.ZERO);
                SetCostStandardCumQty(Env.ZERO);
                SetCostStandardPOAmt(Env.ZERO);
                SetCostStandardPOQty(Env.ZERO);
                SetCurrentCostPrice(Env.ZERO);
                SetFutureCostPrice(Env.ZERO);
                SetPriceLastInv(Env.ZERO);
                SetPriceLastPO(Env.ZERO);
                SetTotalInvAmt(Env.ZERO);
                SetTotalInvQty(Env.ZERO);
            }
        }	

        /**
         * 	Parent Constructor (old)
         *	@param product parent
         *	@param VAB_AccountBook_ID accounting schema
         */
        public MProductCosting(MProduct product, int VAB_AccountBook_ID)
            : base(product.GetCtx(), 0, product.Get_TrxName())
        {
            
            SetClientOrg(product);
            SetVAM_Product_ID(product.GetVAM_Product_ID());
            SetVAB_AccountBook_ID(VAB_AccountBook_ID);
        }


        /**
         * 	Load Constructor (old)
         *	@param ctx context
         *	@param rs result set
         *	@param trxName transaction
         */
        public MProductCosting(Ctx ctx, DataRow dr, Trx trxName)
            : base(ctx, dr, trxName)
        {
            
        }

    }
}
