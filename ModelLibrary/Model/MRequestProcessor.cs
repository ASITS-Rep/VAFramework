﻿/******************************************************
 * Project Name   : VAdvantage
 * Class Name     : MRequestProcessor
 * Purpose        : Request Processor Model
 * Class Used     : X_VAR_Req_Handler,ViennaProcessor
 * Chronological    Development
 * Raghunandan      21-Jan-2010
  *****************************************************/
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
using System.Threading;
using System.Data;
using VAdvantage.Logging;
using System.Data.SqlClient;

namespace VAdvantage.Model
{
    public class MRequestProcessor : X_VAR_Req_Handler, ViennaProcessor
    {
        //Static Logger	
        private static VLogger _log = VLogger.GetVLogger(typeof(MRequestProcessor).FullName);
        //The Lines						
        private MRequestProcessorRoute[] _routes = null;

        /// <summary>
        /// Get Active Request Processors
        /// </summary>
        /// <param name="ctx">context</param>
        /// <returns>array of Request </returns>
        public static MRequestProcessor[] GetActive(Ctx ctx)
        {
            List<MRequestProcessor> list = new List<MRequestProcessor>();
            String sql = "SELECT * FROM VAR_Req_Handler WHERE IsActive='Y'";
            IDataReader idr = null;

            //Changed By Karan.....
            string scheduleIP = null;
            try
            {
                //idr = DataBase.DB.ExecuteReader(sql, null, null);
                //while (idr.Read())
                //{
                //    list.Add(new MRequestProcessor(ctx, idr, null));
                //}
                //idr.Close();

                string machineIP = System.Net.Dns.GetHostEntry(Environment.MachineName).AddressList[0].ToString();


                idr = DataBase.DB.ExecuteReader(sql, null, null);
                while (idr.Read())
                {
                    scheduleIP = Util.GetValueOfString(DB.ExecuteScalar(@"SELECT RunOnlyOnIP FROM VAF_Plan WHERE 
                                                       VAF_Plan_ID = (SELECT VAF_Plan_ID FROM VAR_Req_Handler WHERE VAR_Req_Handler_ID =" + idr["VAR_Req_Handler_ID"] + " )"));

                    //list.Add(new MAcctProcessor(ctx, idr, null));

                    if (string.IsNullOrEmpty(scheduleIP) || machineIP.Contains(scheduleIP))
                    {
                        list.Add(new MRequestProcessor(new Ctx(), idr, null));
                    }

                }
                idr.Close();

            }
            catch (Exception e)
            {
                if (idr != null)
                {
                    idr.Close();
                    idr = null;
                }
                _log.Log(Level.SEVERE, sql, e);
            }

            MRequestProcessor[] retValue = new MRequestProcessor[list.Count];
            retValue = list.ToArray();
            return retValue;
        }

        /// <summary>
        /// 	Standard Constructor
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="VAR_Req_Handler_ID"></param>
        /// <param name="trxName"></param>
        public MRequestProcessor(Ctx ctx, int VAR_Req_Handler_ID, Trx trxName)
            : base(ctx, VAR_Req_Handler_ID, trxName)
        {
            if (VAR_Req_Handler_ID == 0)
            {
                //	setName (null);
                SetFrequencyType(FREQUENCYTYPE_Day);
                SetFrequency(0);
                SetKeepLogDays(7);
                SetOverdueAlertDays(0);
                SetOverdueAssignDays(0);
                SetRemindDays(0);
                //	setSupervisor_ID (0);
            }
        }

        /// <summary>
        /// Load Constructor
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="idr"></param>
        /// <param name="trxName"></param>
        public MRequestProcessor(Ctx ctx, IDataReader idr, Trx trxName)
            : base(ctx, idr, trxName)
        {

        }

        /// <summary>
        /// Parent Constructor
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="Supervisor_ID"></param>
        public MRequestProcessor(MClient parent, int Supervisor_ID)
            : this(parent.GetCtx(), 0, parent.Get_TrxName())
        {
            SetClientOrg(parent);
            SetName(parent.GetName() + " - "
                + Msg.Translate(GetCtx(), "VAR_Req_Handler_ID"));
            SetSupervisor_ID(Supervisor_ID);
        }

        /// <summary>
        /// Get Routes
        /// </summary>
        /// <param name="reload">reload data</param>
        /// <returns>array of routes</returns>
        public MRequestProcessorRoute[] GetRoutes(bool reload)
        {
            if (_routes != null && !reload)
            {
                return _routes;
            }

            String sql = "SELECT * FROM VAR_Req_Handler_Route WHERE VAR_Req_Handler_ID=" + GetVAR_Req_Handler_ID() + " ORDER BY SeqNo";
            List<MRequestProcessorRoute> list = new List<MRequestProcessorRoute>();
            IDataReader idr = null;
            try
            {
                idr = DataBase.DB.ExecuteReader(sql, null, Get_TrxName());
                while (idr.Read())
                {
                    list.Add(new MRequestProcessorRoute(GetCtx(), idr, Get_TrxName()));
                }
                idr.Close();
            }
            catch (Exception e)
            {
                if (idr != null)
                {
                    idr.Close();
                    idr = null;
                }
                log.Log(Level.SEVERE, sql, e);
            }
            
            //
            _routes = new MRequestProcessorRoute[list.Count];
            _routes = list.ToArray();
            return _routes;
        }

        /// <summary>
        /// Get Logs
        /// </summary>
        /// <returns>Array of Logs</returns>
        public ViennaProcessorLog[] GetLogs()
        {
            List<MRequestProcessorLog> list = new List<MRequestProcessorLog>();
            String sql = "SELECT * "
                + "FROM VAR_Req_HandlerLog "
                + "WHERE VAR_Req_Handler_ID=" + GetVAR_Req_Handler_ID()
                + "ORDER BY Created DESC";
            IDataReader idr = null;
            try
            {
                idr = DataBase.DB.ExecuteReader(sql, null, Get_TrxName());
                while (idr.Read())
                {
                    list.Add(new MRequestProcessorLog(GetCtx(), idr, Get_TrxName()));
                }
                idr.Close();
            }
            catch (Exception e)
            {
                if (idr != null)
                {
                    idr.Close();
                    idr = null;
                }
                log.Log(Level.SEVERE, sql, e);
            }

            MRequestProcessorLog[] retValue = new MRequestProcessorLog[list.Count];
            retValue = list.ToArray();
            return retValue;
        }

        /// <summary>
        /// Delete old Request Log
        /// </summary>
        /// <returns>number of records</returns>
        public int DeleteLog()
        {
            if (GetKeepLogDays() < 1)
            {
                return 0;
            }
            String sql = "DELETE FROM VAR_Req_HandlerLog "
                + "WHERE VAR_Req_Handler_ID=" + GetVAR_Req_Handler_ID()
                //jz + " AND (Created+" + getKeepLogDays() + ") < SysDate";
                + " AND addDays(Created," + GetKeepLogDays() + ") < SysDate";

            int no = DataBase.DB.ExecuteQuery(sql, null, Get_TrxName());
            return 0;
        }

        /// <summary>
        /// Get the date Next run
        /// </summary>
        /// <param name="requery">requery database</param>
        /// <returns>date next run</returns>
        public DateTime? GetDateNextRun(bool requery)
        {
            if (requery)
            {
                Load(Get_TrxName());
            }
            return GetDateNextRun();
        }

        /// <summary>
        /// Get Unique ID
        /// </summary>
        /// <returns>Unique ID</returns>
        public String GetServerID()
        {
            return "RequestProcessor" + Get_ID();
        }
    }
}
