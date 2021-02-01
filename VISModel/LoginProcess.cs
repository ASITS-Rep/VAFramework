﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VAdvantage.Common;
using VAdvantage.Classes;
using VAdvantage.Model;
using VAdvantage.DataBase;
using System.Data;
using VAdvantage.Utility;

using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace VAdvantage.Login
{
    public class LoginProcess
    {
        public LoginProcess(Ctx ctx)
        {
            if (ctx == null)
                throw new ArgumentException("Context missing");
            m_ctx = ctx;
        }	//	Login



        // private Context m_ctx = null;
        private Ctx m_ctx = null;

        /** List of Roles		*/
        private List<KeyNamePair> m_roles = new List<KeyNamePair>();
        /** List of Users for Roles		*/
        private List<int> m_users = new List<int>();
        /** The Current User	*/
        private KeyNamePair m_user = null;
        /** The Current Role	*/
        private KeyNamePair m_role = null;
        /** The Current Org		*/
        private KeyNamePair m_org = null;
        /** Web Store Login		*/
        //private X_W_Store m_store = null;
        private X_W_Store m_store = null;





        /// <summary>
        /// Get Roles for the user with email in client with the web store.
        /// If the user does not have roles and the web store has a default role, it will return that.
        /// </summary>
        /// <param name="eMail">email add</param>
        /// <param name="password">password</param>
        /// <param name="W_Store_ID">web store</param>
        /// <returns></returns>
        private KeyNamePair[] GetRolesByEmail(String eMail, String password, int W_Store_ID)
        {
            long start = CommonFunctions.CurrentTimeMillis();
            if (eMail == null || eMail.Length == 0
                || password == null || password.Length == 0
                || W_Store_ID == 0)
            {
                return null;
            }
            //	Cannot use encrypted password
            if (SecureEngine.IsEncrypted(password))
            {
                return null;
            }

            KeyNamePair[] retValue = null;
            List<KeyNamePair> list = new List<KeyNamePair>();
            //
            String sql = "SELECT u.VAF_UserContact_ID, r.VAF_Role_ID, u.Name "
                + "FROM VAF_UserContact u"
                + " INNER JOIN W_Store ws ON (u.VAF_Client_ID=ws.VAF_Client_ID) "
                + " INNER JOIN VAF_Role r ON (ws.VAF_Role_ID=r.VAF_Role_ID) "
                + "WHERE u.EMail='" + eMail + "'"
                + " AND (u.Password='" + password + "' OR u.Password='" + password + "')"
                + " AND ws.W_Store_ID='" + W_Store_ID + "'"
                + " AND (r.IsActive='Y' OR r.IsActive IS NULL)"
                + " AND u.isActive='Y' AND ws.IsActive='Y'"
                + " AND u.VAF_Client_ID=ws.VAF_Client_ID "
                + "ORDER BY r.Name";
            m_roles.Clear();
            m_users.Clear();
            IDataReader dr = null;
            try
            {

                //	execute a query
                dr = DataBase.DB.ExecuteReader(sql);

                if (!dr.Read())
                {
                    dr.Close();
                    return null;
                }

                int VAF_UserContact_ID = Utility.Util.GetValueOfInt(dr[0].ToString());
                m_ctx.SetVAF_UserContact_ID(VAF_UserContact_ID);
                m_user = new KeyNamePair(VAF_UserContact_ID, eMail);
                m_users.Add(VAF_UserContact_ID);	//	for role
                //
                int VAF_Role_ID = Utility.Util.GetValueOfInt(dr[1].ToString());
                m_ctx.SetVAF_Role_ID(VAF_Role_ID);
                String Name = dr[2].ToString();
                m_ctx.SetContext("##VAF_UserContact_Name", Name);
                if (VAF_Role_ID == 0)	//	User is a Sys Admin
                    m_ctx.SetContext("#SysAdmin", "Y");
                KeyNamePair p = new KeyNamePair(VAF_Role_ID, Name);
                m_roles.Add(p);
                list.Add(p);

                dr.Close();
                //
                retValue = new KeyNamePair[list.Count];
                retValue = list.ToArray();
            }
            catch
            {
                if (dr != null)
                {
                    dr.Close();
                }
                retValue = null;
                m_ctx.SetContext("##VAF_UserContact_Name", eMail);
            }

            return retValue;
        }

        /// <summary>
        /// Get User
        /// </summary>
        /// <returns>user id</returns>
        public int GetVAF_UserContact_ID()
        {
            if (m_user != null)
                return m_user.GetKey();
            return -1;
        }	//	getVAF_UserContact_ID


        public int GetVAF_Role_ID()
        {
            if (m_role != null)
                return m_role.GetKey();
            return -1;
        }	//	getVAF_Role_ID



        /// <summary>
        /// Load Preferences into Context for selected client.
        /// <para>
        /// Sets Org info in context and loads relevant field from
        /// - VAF_Client/Info,
        /// - VAB_AccountBook,
        /// - VAB_AccountBook_Elements
        /// - VAF_ValuePreference
        /// </para>
        /// Assumes that the context is set for #VAF_Client_ID, ##VAF_UserContact_ID, #VAF_Role_ID
        /// </summary>
        /// <param name="org">org information</param>
        /// <param name="warehouse">optional warehouse information</param>
        /// <param name="timestamp">optional date</param>
        /// <param name="printerName">optional printer info</param>
        /// <returns>VAF_Msg_Lable of error (NoValidAcctInfo) or ""</returns>
        public String LoadPreferences(KeyNamePair org,
            KeyNamePair warehouse, DateTime timestamp, String printerName)
        {
            m_org = org;

            if (m_ctx == null || org == null)
                throw new ArgumentException("Required parameter missing");
            if (m_ctx.GetContext("#VAF_Client_ID").Length == 0)
                throw new Exception("Missing Context #VAF_Client_ID");
            if (m_ctx.GetContext("##VAF_UserContact_ID").Length == 0)
                throw new Exception("Missing Context ##VAF_UserContact_ID");
            if (m_ctx.GetContext("#VAF_Role_ID").Length == 0)
                throw new Exception("Missing Context #VAF_Role_ID");


            //  Org Info - assumes that it is valid
            m_ctx.SetVAF_Org_ID(org.GetKey());
            m_ctx.SetContext("#VAF_Org_Name", org.GetName());
            Ini.SetProperty(Ini.P_ORG, org.GetName());

            //  Warehouse Info
            if (warehouse != null)
            {
                m_ctx.SetContext("#M_Warehouse_ID", warehouse.GetKey());
                Ini.SetProperty(Ini.P_WAREHOUSE, warehouse.GetName());
            }

            //	Date (default today)
            long today = CommonFunctions.CurrentTimeMillis();
            if (timestamp != null)
                today = CommonFunctions.CurrentTimeMillis(timestamp);
            m_ctx.SetContext("#Date", today.ToString());

            //	Load User/Role Info
            MVAFUserContact user = MVAFUserContact.Get(m_ctx, GetVAF_UserContact_ID());
            MVAFUserPrefInfo preference = user.GetPreference();
            MVAFRole role = MVAFRole.GetDefault(m_ctx, true);

            //	Optional Printer
            if (printerName == null)
                printerName = "";
            if (printerName.Length == 0 && preference.GetPrinterName() != null)
                printerName = preference.GetPrinterName();
            m_ctx.SetPrinterName(printerName);
            if (preference.GetPrinterName() == null && printerName.Length > 0)
                preference.SetPrinterName(printerName);

            //	Other
            m_ctx.SetAutoCommit(preference.IsAutoCommit());
            m_ctx.SetAutoNew(Ini.IsPropertyBool(Ini.P_A_NEW));
            if (role.IsShowAcct())
                m_ctx.SetContext("#ShowAcct", preference.IsShowAcct());
            else
                m_ctx.SetContext("#ShowAcct", "N");
            m_ctx.SetContext("#ShowTrl", preference.IsShowTrl());
            m_ctx.SetContext("#ShowAdvanced", preference.IsShowAdvanced());

            String retValue = "";
            int VAF_Client_ID = m_ctx.GetVAF_Client_ID();
            //	int VAF_Org_ID =  org.getKey();
            //	int VAF_UserContact_ID =  Env.getVAF_UserContact_ID (m_ctx);
            int VAF_Role_ID = m_ctx.GetVAF_Role_ID();

            //	Other Settings
            m_ctx.SetContext("#YYYY", "Y");

            //	AccountSchema Info (first)
            String sql = "SELECT a.VAB_AccountBook_ID, a.VAB_Currency_ID, a.HasAlias, c.ISO_Code, c.StdPrecision, t.AutoArchive "    // Get AutoArchive from Tenant header
                + "FROM VAB_AccountBook a"
                + " INNER JOIN VAF_ClientDetail ci ON (a.VAB_AccountBook_ID=ci.VAB_AccountBook1_ID)"
                + " INNER JOIN VAF_Client t ON (ci.VAF_Client_ID=t.VAF_Client_ID)"
                + " INNER JOIN VAB_Currency c ON (a.VAB_Currency_ID=c.VAB_Currency_ID) "
                + "WHERE ci.VAF_Client_ID='" + VAF_Client_ID + "'";
            IDataReader dr = null;
            try
            {
                int VAB_AccountBook_ID = 0;
                dr = DataBase.DB.ExecuteReader(sql);

                if (!dr.Read())
                {
                    //  No Warning for System
                    if (VAF_Role_ID != 0)
                        retValue = "NoValidAcctInfo";
                }
                else
                {
                    //	Accounting Info
                    VAB_AccountBook_ID = Utility.Util.GetValueOfInt(dr[0].ToString());
                    m_ctx.SetContext("$VAB_AccountBook_ID", VAB_AccountBook_ID);
                    m_ctx.SetContext("$VAB_Currency_ID", Utility.Util.GetValueOfInt(dr[1].ToString()));
                    m_ctx.SetContext("$HasAlias", dr[2].ToString());
                    m_ctx.SetContext("$CurrencyISO", dr[3].ToString());
                    m_ctx.SetStdPrecision(Utility.Util.GetValueOfInt(dr[4].ToString()));
                    m_ctx.SetContext("$AutoArchive", dr[5].ToString());
                }
                dr.Close();

                //	Accounting Elements
                sql = "SELECT ElementType "
                    + "FROM VAB_AccountBook_Element "
                    + "WHERE VAB_AccountBook_ID='" + VAB_AccountBook_ID + "'"
                    + " AND IsActive='Y'";

                dr = DataBase.DB.ExecuteReader(sql);
                while (dr.Read())
                    m_ctx.SetContext("$Element_" + dr["ElementType"].ToString(), "Y");
                dr.Close();


                //	This reads all relevant window neutral defaults
                //	overwriting superseeded ones.  Window specific is read in Maintain
                sql = "SELECT Attribute, Value, VAF_Screen_ID "
                    + "FROM VAF_ValuePreference "
                    + "WHERE VAF_Client_ID IN (0, @#VAF_Client_ID@)"
                    + " AND VAF_Org_ID IN (0, @#VAF_Org_ID@)"
                    + " AND (VAF_UserContact_ID IS NULL OR VAF_UserContact_ID=0 OR VAF_UserContact_ID=@##VAF_UserContact_ID@)"
                    + " AND IsActive='Y' "
                    + "ORDER BY Attribute, VAF_Client_ID, VAF_UserContact_ID DESC, VAF_Org_ID";
                //	the last one overwrites - System - Client - User - Org - Window
                sql = Utility.Env.ParseContext(m_ctx, 0, sql, false);
                if (sql.Length == 0)
                { }
                else
                {
                    dr = DataBase.DB.ExecuteReader(sql);
                    while (dr.Read())
                    {
                        string VAF_Screen_ID = dr[2].ToString();
                        String at = "";
                        if (string.IsNullOrEmpty(VAF_Screen_ID))
                            at = "P|" + dr[0].ToString();
                        else
                            at = "P" + VAF_Screen_ID + "|" + dr[0].ToString();
                        String va = dr[1].ToString();
                        m_ctx.SetContext(at, va);
                    }
                    dr.Close();
                }

                //	Default Values
                sql = "SELECT t.TableName, c.ColumnName "
                    + "FROM VAF_Column c "
                    + " INNER JOIN VAF_TableView t ON (c.VAF_TableView_ID=t.VAF_TableView_ID) "
                    + "WHERE c.IsKey='Y' AND t.IsActive='Y'"
                    + " AND EXISTS (SELECT * FROM VAF_Column cc "
                    + " WHERE ColumnName = 'IsDefault' AND t.VAF_TableView_ID=cc.VAF_TableView_ID AND cc.IsActive='Y')";

                dr = DataBase.DB.ExecuteReader(sql);
                while (dr.Read())
                    LoadDefault(dr[0].ToString(), dr[1].ToString());
                dr.Close();
            }
            catch
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            Ini.SaveProperties(Ini.IsClient());
            //	Country
            m_ctx.SetContext("#VAB_Country_ID", MVABCountry.GetDefault(m_ctx).GetVAB_Country_ID());

            m_ctx.SetShowClientOrg(Ini.IsShowClientOrg() ? "Y" : "N");
            m_ctx.SetShowMiniGrid(Ini.GetProperty(Ini.P_Show_Mini_Grid));
            return retValue;
        }	//	loadPreferences


        private void LoadDefault(String TableName, String ColumnName)
        {
            if (TableName.StartsWith("VAF_Screen")
                || TableName.StartsWith("VAF_Print_Rpt_Layout")
                || TableName.StartsWith("VAF_Workflow"))
                return;
            String value = null;
            //
            String sql = "SELECT " + ColumnName + " FROM " + TableName	//	most specific first
                + " WHERE IsDefault='Y' AND IsActive='Y' ORDER BY VAF_Client_ID DESC, VAF_Org_ID DESC";
            sql = MVAFRole.GetDefault(m_ctx, false).AddAccessSQL(sql, TableName, MVAFRole.SQL_NOTQUALIFIED, MVAFRole.SQL_RO);
            IDataReader dr = null;
            try
            {

                dr = DataBase.DB.ExecuteReader(sql);
                if (dr.Read())
                {
                    value = dr[0].ToString();
                }
                dr.Close();
            }
            catch
            {
                if (dr != null)
                {
                    dr.Close();
                }
                return;
            }

            //	Set Context Value
            if (value != null && value.Length != 0)
            {
                if (TableName.Equals("VAB_DocTypes"))
                    m_ctx.SetContext("#VAB_DocTypesTarget_ID", value);
                else
                    m_ctx.SetContext("#" + ColumnName, value);
            }
        }	//	loadDefault


        /// <summary>
        /// Validate Login.
        /// Creates session and calls ModelValidationEngine
        /// </summary>
        /// <param name="org">log-in org</param>
        /// <returns>error message</returns>
        public String ValidateLogin(KeyNamePair org)
        {
            String info = m_user + ",R:" + m_role.ToString() + ",O=" + m_org.ToString();
            int VAF_Client_ID = m_ctx.GetVAF_Client_ID();
            int VAF_Org_ID = org.GetKey();
            int VAF_Role_ID = m_ctx.GetVAF_Role_ID();
            int VAF_UserContact_ID = m_ctx.GetVAF_UserContact_ID();
            //
            MVAFSession session = MVAFSession.Get(m_ctx, true);
            if (VAF_Client_ID != session.GetVAF_Client_ID())
                session.SetVAF_Client_ID(VAF_Client_ID);
            if (VAF_Org_ID != session.GetVAF_Org_ID())
                session.SetVAF_Org_ID(VAF_Org_ID);
            if (VAF_Role_ID != session.GetVAF_Role_ID())
                session.SetVAF_Role_ID(VAF_Role_ID);
            //
            String error = ModelValidationEngine.Get().LoginComplete(VAF_Client_ID, VAF_Org_ID, VAF_Role_ID, VAF_UserContact_ID);
            if (error != null && error.Length > 0)
            {
                session.SetDescription(error);
                session.Save();
                return error;
            }
            //	Log
            session.Save();
            return null;
        }	//	validateLogin


        public KeyNamePair[] GetRoles(String app_user, String app_pwd)
        {
            return GetRoles(app_user, app_pwd, false, false);
        }   //  login


        /// <summary>
        /// Actual DB login procedure.
        /// </summary>
        /// <param name="app_user">user</param>
        /// <param name="app_pwd">pwd</param>
        /// <param name="force">ignore pwd</param>
        /// <param name="ignore_pwd">If true, indicates that the user had previously authenticated successfully, and therefore
        /// there is no need to check password again.  This differs from the <b>force</b> parameter in that <b>force</b>
        /// will force a login with System Administrator privileges.
        /// </param>
        /// <returns>array or null if in error.</returns>
        private KeyNamePair[] GetRoles(String app_user, String app_pwd, bool force, bool ignore_pwd)
        {
            long start = CommonFunctions.CurrentTimeMillis();
            if (app_user == null)
            {
                return null;
            }

            //	Authenticate


            KeyNamePair[] retValue = null;
            List<KeyNamePair> list = new List<KeyNamePair>();
            //
            StringBuilder sql = new StringBuilder("SELECT u.VAF_UserContact_ID, r.VAF_Role_ID,r.Name,")
                .Append(" u.ConnectionProfile, u.Password ")	//	4,5
                .Append("FROM VAF_UserContact u")
                .Append(" INNER JOIN VAF_UserContact_Roles ur ON (u.VAF_UserContact_ID=ur.VAF_UserContact_ID AND ur.IsActive='Y')")
                .Append(" INNER JOIN VAF_Role r ON (ur.VAF_Role_ID=r.VAF_Role_ID AND r.IsActive='Y') ")
                .Append("WHERE COALESCE(u.LDAPUser,u.Name)=@username")		//	#1
                .Append(" AND u.IsActive='Y'")
                .Append(" AND EXISTS (SELECT * FROM VAF_Client c WHERE u.VAF_Client_ID=c.VAF_Client_ID AND c.IsActive='Y')")
                .Append(" AND EXISTS (SELECT * FROM VAF_Client c WHERE r.VAF_Client_ID=c.VAF_Client_ID AND c.IsActive='Y')");
            if (app_pwd != null)
                sql.Append(" AND (u.Password='" + app_pwd + "' OR u.Password='" + app_pwd + "')");	//  #2/3
            sql.Append(" ORDER BY r.Name");
            IDataReader dr = null;
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@username", app_user);
                //	execute a query
                dr = DataBase.DB.ExecuteReader(sql.ToString(), param);

                if (!dr.Read())		//	no record found
                {
                    if (force)
                    {
                        m_ctx.SetVAF_UserContact_ID(0);
                        m_ctx.SetContext("##VAF_UserContact_Name", "System (force)");
                        m_ctx.SetContext("##VAF_UserContact_Description", "System Forced Login");
                        m_ctx.SetContext("#User_Level", "S  ");  	//	Format 'SCO'
                        m_ctx.SetContext("#User_Client", "0");		//	Format c1, c2, ...
                        m_ctx.SetContext("#User_Org", "0"); 		//	Format o1, o2, ...
                        m_user = new KeyNamePair(0, app_user + " (force)");
                        dr.Close();
                        retValue = new KeyNamePair[] { new KeyNamePair(0, "System Administrator (force)") };
                        return retValue;
                    }
                    else
                    {
                        dr.Close();
                        return null;
                    }
                }

                int VAF_UserContact_ID = Utility.Util.GetValueOfInt(dr[0].ToString());
                m_ctx.SetVAF_UserContact_ID(VAF_UserContact_ID);
                m_user = new KeyNamePair(VAF_UserContact_ID, app_user);
                m_ctx.SetContext("##VAF_UserContact_Name", app_user);

                if (MVAFUserContact.IsSalesRep(VAF_UserContact_ID))
                    m_ctx.SetContext("#SalesRep_ID", VAF_UserContact_ID);
                //
                Ini.SetProperty(Ini.P_UID, app_user);

                if (Ini.IsPropertyBool(Ini.P_STORE_PWD))
                    Ini.SetProperty(Ini.P_PWD, app_pwd);


                m_roles.Clear();
                m_users.Clear();
                do	//	read all roles
                {
                    VAF_UserContact_ID = Utility.Util.GetValueOfInt(dr[0].ToString());
                    m_users.Add(VAF_UserContact_ID);	//	for role
                    //
                    int VAF_Role_ID = Utility.Util.GetValueOfInt(dr[1].ToString());
                    if (VAF_Role_ID == 0)	//	User is a Sys Admin
                        m_ctx.SetContext("#SysAdmin", "Y");
                    String Name = dr[2].ToString();
                    KeyNamePair p = new KeyNamePair(VAF_Role_ID, Name);
                    m_roles.Add(p);
                    list.Add(p);
                }
                while (dr.Read());

                dr.Close();
                //
                retValue = new KeyNamePair[list.Count];
                retValue = list.ToArray();
            }
            catch
            {
                if (dr != null)
                {
                    dr.Close();
                }
                retValue = null;
            }
            long ms = CommonFunctions.CurrentTimeMillis() - start;

            return retValue;
        }	//	getRoles


        /// <summary>
        /// Load Clients.
        /// <para>
        /// Sets Role info in context and loads its clients
        /// </para>
        /// </summary>
        /// <param name="role"> role information</param>
        /// <returns>list of valid client KeyNodePairs or null if in error</returns>
        public KeyNamePair[] GetClients(KeyNamePair role)
        {
            if (role == null)
                throw new Exception("Role missing");
            m_role = role;
            //	Web Store Login
           // if (m_store != null)
            //    return new KeyNamePair[] { new KeyNamePair(m_store.GetVAF_Client_ID(), m_store.GetName() + " Tenant") };

            //	Set User for Role
            int VAF_Role_ID = role.GetKey();
            for (int i = 0; i < m_roles.Count; i++)
            {
                if (VAF_Role_ID == m_roles[i].GetKey())
                {
                    int VAF_UserContact_ID = m_users[i];
                    m_ctx.SetVAF_UserContact_ID(VAF_UserContact_ID);
                    if (MVAFUserContact.IsSalesRep(VAF_UserContact_ID))
                        m_ctx.SetContext("#SalesRep_ID", VAF_UserContact_ID);
                    m_user = new KeyNamePair(VAF_UserContact_ID, m_user.GetName());
                    break;
                }
            }

            List<KeyNamePair> list = new List<KeyNamePair>();
            KeyNamePair[] retValue = null;
            String sql = "SELECT DISTINCT r.UserLevel, r.ConnectionProfile, "	//	1..2
                + " c.VAF_Client_ID,c.Name "								//	3..4 
                + "FROM VAF_Role r"
                + " INNER JOIN VAF_Client c ON (r.VAF_Client_ID=c.VAF_Client_ID) "
                + "WHERE r.VAF_Role_ID=@roleid"		//	#1
                + " AND r.IsActive='Y' AND c.IsActive='Y'";

            //	get Role details
            IDataReader dr = null;
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@roleid", role.GetKey());

                dr = DataBase.DB.ExecuteReader(sql, param);
                if (!dr.Read())
                {
                    dr.Close();
                    return null;
                }

                //  Role Info
                m_ctx.SetVAF_Role_ID(role.GetKey());
                m_ctx.SetContext("#VAF_Role_Name", role.GetName());
                Ini.SetProperty(Ini.P_ROLE, role.GetName());
                //	User Level
                m_ctx.SetContext("#User_Level", dr[0].ToString());  	//	Format 'SCO'

                //  load Clients
                do
                {
                    int VAF_Client_ID = Utility.Util.GetValueOfInt(dr[2].ToString());
                    String Name = dr[3].ToString();
                    KeyNamePair p = new KeyNamePair(VAF_Client_ID, Name);
                    list.Add(p);
                }
                while (dr.Read());
                dr.Close();
                //
                retValue = new KeyNamePair[list.Count];
                retValue = list.ToArray();
            }
            catch
            {
                if (dr != null)
                {
                    dr.Close();
                }
                retValue = null;
            }
            return retValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public KeyNamePair[] GetOrgs(KeyNamePair client)
        {
            if (client == null)
                throw new ArgumentException("Client missing");
            //	Web Store Login
            if (m_store != null)
                return new KeyNamePair[] { new KeyNamePair(m_store.GetVAF_Org_ID(), m_store.GetName() + " Org") };

            if (m_ctx.GetContext("#VAF_Role_ID").Length == 0)	//	could be number 0
                throw new Exception("Missing Context #VAF_Role_ID");

            int VAF_Role_ID = m_ctx.GetVAF_Role_ID();
            int VAF_UserContact_ID = m_ctx.GetVAF_UserContact_ID();
            //	s_log.fine("Client: " + client.toStringX() + ", VAF_Role_ID=" + VAF_Role_ID);

            //	get Client details for role
            List<KeyNamePair> list = new List<KeyNamePair>();
            KeyNamePair[] retValue = null;
            //
            String sql = "SELECT o.VAF_Org_ID,o.Name,o.IsSummary "	//	1..3
                + "FROM VAF_Role r, VAF_Client c"
                + " INNER JOIN VAF_Org o ON (c.VAF_Client_ID=o.VAF_Client_ID OR o.VAF_Org_ID=0) "
                + "WHERE r.VAF_Role_ID='" + VAF_Role_ID + "'" 	//	#1
                + " AND c.VAF_Client_ID='" + client.GetKey() + "'"	//	#2
                + " AND o.IsActive='Y' AND o.IsSummary='N'"
                + " AND (r.IsAccessAllOrgs='Y' "
                    + "OR (r.IsUseUserOrgAccess='N' AND o.VAF_Org_ID IN (SELECT VAF_Org_ID FROM VAF_Role_OrgRights ra "
                        + "WHERE ra.VAF_Role_ID=r.VAF_Role_ID AND ra.IsActive='Y')) "
                    + "OR (r.IsUseUserOrgAccess='Y' AND o.VAF_Org_ID IN (SELECT VAF_Org_ID FROM VAF_UserContact_OrgRights ua "
                        + "WHERE ua.VAF_UserContact_ID='" + VAF_UserContact_ID + "' AND ua.IsActive='Y'))"		//	#3
                    + ") "
                + "ORDER BY o.Name";
            //
            MVAFRole role = null;
            IDataReader dr = null;
            try
            {

                dr = DataBase.DB.ExecuteReader(sql);
                //  load Orgs
                while (dr.Read())
                {
                    int VAF_Org_ID = Utility.Util.GetValueOfInt(dr[0].ToString());
                    String Name = dr[1].ToString();
                    bool summary = "Y".Equals(dr[2].ToString());
                    if (summary)
                    {
                        if (role == null)
                            role = MVAFRole.Get(m_ctx, VAF_Role_ID, VAF_UserContact_ID, false);
                        GetOrgsAddSummary(list, VAF_Org_ID, Name, role);
                    }
                    else
                    {
                        KeyNamePair p = new KeyNamePair(VAF_Org_ID, Name);
                        if (!list.Contains(p))
                            list.Add(p);
                    }
                }
                dr.Close();

                //
                retValue = new KeyNamePair[list.Count];
                retValue = list.ToArray();
            }
            catch
            {
                if (dr != null)
                {
                    dr.Close();
                }
                retValue = null;
            }

            //	No Orgs
            if (retValue == null || retValue.Length == 0)
            {
                return null;
            }

            //  Client Info
            m_ctx.SetContext("#VAF_Client_ID", client.GetKey());
            m_ctx.SetContext("#VAF_Client_Name", client.GetName());
            Ini.SetProperty(Ini.P_CLIENT, client.GetName());
            return retValue;
        }   //  getOrgs


        /// <summary>
        /// Get Orgs - Add Summary Org
        /// </summary>
        /// <param name="list">list</param>
        /// <param name="Summary_Org_ID">summary org</param>
        /// <param name="Summary_Name">name</param>
        /// <param name="role"></param>
        private void GetOrgsAddSummary(List<KeyNamePair> list, int Summary_Org_ID, String Summary_Name, MVAFRole role)
        {
            if (role == null)
            {
                return;
            }
            //	Do we look for trees?
            if (role.GetVAF_TreeInfo_Org_ID() == 0)
            {
                return;
            }
            //	Summary Org - Get Dependents
            MVAFTreeInfo tree = MVAFTreeInfo.Get(m_ctx, role.GetVAF_TreeInfo_Org_ID(), null);
            String sql = "SELECT VAF_Client_ID, VAF_Org_ID, Name, IsSummary FROM VAF_Org "
                + "WHERE IsActive='Y' AND VAF_Org_ID IN (SELECT Node_ID FROM "
                + tree.GetNodeTableName()
                + " WHERE VAF_TreeInfo_ID='" + tree.GetVAF_TreeInfo_ID() + "' AND Parent_ID='" + Summary_Org_ID + "' AND IsActive='Y') "
                + "ORDER BY Name";

            IDataReader dr = DataBase.DB.ExecuteReader(sql);
            try
            {
                while (dr.Read())
                {
                    //	int VAF_Client_ID = rs.getInt(1);
                    int VAF_Org_ID = Utility.Util.GetValueOfInt(dr[1].ToString());
                    String Name = dr[2].ToString();
                    bool summary = "Y".Equals(dr[3].ToString());
                    //
                    if (summary)
                        GetOrgsAddSummary(list, VAF_Org_ID, Name, role);
                    else
                    {
                        KeyNamePair p = new KeyNamePair(VAF_Org_ID, Name);
                        if (!list.Contains(p))
                            list.Add(p);
                    }
                }
                dr.Close();
            }
            catch
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }
        }	//	getOrgAddSummary


        /// <summary>
        ///  Load Warehouses
        /// </summary>
        /// <param name="org"></param>
        /// <returns></returns>
        public KeyNamePair[] GetWarehouses(KeyNamePair org)
        {
            ;
            if (org == null)
                throw new Exception("Org missing");
            m_org = org;
            if (m_store != null)
                return new KeyNamePair[] { new KeyNamePair(m_store.GetM_Warehouse_ID(), m_store.GetName() + " Warehouse") };

            //	s_log.info("loadWarehouses - Org: " + org.toStringX());

            List<KeyNamePair> list = new List<KeyNamePair>();
            KeyNamePair[] retValue = null;
            String sql = "SELECT M_Warehouse_ID, Name FROM M_Warehouse "
                + "WHERE VAF_Org_ID=@p1 AND IsActive='Y' "
                + "ORDER BY Name";
            IDataReader dr = null;
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@p1", org.GetKey());
                dr = DataBase.DB.ExecuteReader(sql, param);
                if (!dr.Read())
                {
                    dr.Close();
                    return null;
                }

                //  load Warehouses
                do
                {
                    int AD_Warehouse_ID = Utility.Util.GetValueOfInt(dr[0].ToString());
                    String Name = dr[1].ToString();
                    KeyNamePair p = new KeyNamePair(AD_Warehouse_ID, Name);
                    list.Add(p);
                }
                while (dr.Read());

                dr.Close();
                //
                retValue = new KeyNamePair[list.Count];
                retValue = list.ToArray();
            }
            catch
            {
                if (dr != null)
                {
                    dr.Close();
                }
                retValue = null;
            }

            return retValue;
        }   //  getWarehouses




        /* HTML5 */

        /// <summary>
        /// Load Preferences into Context for selected client.
        /// <para>
        /// Sets Org info in context and loads relevant field from
        /// - VAF_Client/Info,
        /// - VAB_AccountBook,
        /// - VAB_AccountBook_Elements
        /// - VAF_ValuePreference
        /// </para>
        /// Assumes that the context is set for #VAF_Client_ID, ##VAF_UserContact_ID, #VAF_Role_ID
        /// </summary>
        /// <param name="org">org information</param>
        /// <param name="warehouse">optional warehouse information</param>
        /// <param name="timestamp">optional date</param>
        /// <param name="printerName">optional printer info</param>
        /// <returns>VAF_Msg_Lable of error (NoValidAcctInfo) or ""</returns>
        public String LoadPreferences(string date, String printerName)
        {
            if (m_ctx.GetContext("#VAF_Client_ID").Length == 0)
                throw new Exception("Missing Context #VAF_Client_ID");
            if (m_ctx.GetContext("##VAF_UserContact_ID").Length == 0)
                throw new Exception("Missing Context ##VAF_UserContact_ID");
            if (m_ctx.GetContext("#VAF_Role_ID").Length == 0)
                throw new Exception("Missing Context #VAF_Role_ID");

            string dateS = m_ctx.GetContext("#Date");

            DateTime dt = DateTime.Now;
            long today = CommonFunctions.CurrentTimeMillis();
            if (DateTime.TryParse(dateS, out dt))
            {
                today = CommonFunctions.CurrentTimeMillis(dt);
            }

            m_ctx.SetContext("#Date", today.ToString());

            //	Load User/Role Infos
            MVAFUserContact user = MVAFUserContact.Get(m_ctx, m_ctx.GetVAF_UserContact_ID());

            MVAFUserPrefInfo preference = user.GetPreference();
            MVAFRole role = MVAFRole.GetDefault(m_ctx);

            //	Optional Printer
            if (printerName == null)
                printerName = "";
            if (printerName.Length == 0 && preference.GetPrinterName() != null)
                printerName = preference.GetPrinterName();
            m_ctx.SetPrinterName(printerName);
            if (preference.GetPrinterName() == null && printerName.Length > 0)
                preference.SetPrinterName(printerName);

            //	Other
            m_ctx.SetAutoCommit(preference.IsAutoCommit());
            m_ctx.SetAutoNew(Ini.IsPropertyBool(Ini.P_A_NEW));
            if (role.IsShowAcct())
                m_ctx.SetContext("#ShowAcct", preference.IsShowAcct());
            else
                m_ctx.SetContext("#ShowAcct", "N");
            m_ctx.SetContext("#ShowTrl", preference.IsShowTrl());
            m_ctx.SetContext("#ShowAdvanced", preference.IsShowAdvanced());

            String retValue = "";
            int VAF_Client_ID = m_ctx.GetVAF_Client_ID();
            //	int VAF_Org_ID =  org.getKey();
            //	int VAF_UserContact_ID =  Env.getVAF_UserContact_ID (m_ctx);
            int VAF_Role_ID = m_ctx.GetVAF_Role_ID();

            //	Other Settings
            m_ctx.SetContext("#YYYY", "Y");


            //LoadSysConfig();

            string sql = "";
            IDataReader dr = null;
            bool checkNonItem = true;           // to identify that on Tenant there exista new column "IsAllowNonItem".
            //	AccountSchema Info (first)
            try
            {
                sql = "SELECT a.VAB_AccountBook_ID, a.VAB_Currency_ID, a.HasAlias, c.ISO_Code, c.StdPrecision, t.AutoArchive, t.IsAllowNonItem "  // 6. Get "Alloe Non Item on Ship/Receipt" from Tenant header
                    + "FROM VAB_AccountBook a"
                    + " INNER JOIN VAF_ClientDetail ci ON (a.VAB_AccountBook_ID=ci.VAB_AccountBook1_ID)"
                    + " INNER JOIN VAF_Client t ON (ci.VAF_Client_ID=t.VAF_Client_ID)"
                    + " INNER JOIN VAB_Currency c ON (a.VAB_Currency_ID=c.VAB_Currency_ID) "
                    + "WHERE ci.VAF_Client_ID='" + VAF_Client_ID + "'";

                dr = DataBase.DB.ExecuteReader(sql);
            }
            catch
            {
                checkNonItem = false;
                sql = "SELECT a.VAB_AccountBook_ID, a.VAB_Currency_ID, a.HasAlias, c.ISO_Code, c.StdPrecision, t.AutoArchive "       // 5. Get AutoArchive from Tenant header
                    + "FROM VAB_AccountBook a"
                    + " INNER JOIN VAF_ClientDetail ci ON (a.VAB_AccountBook_ID=ci.VAB_AccountBook1_ID)"
                    + " INNER JOIN VAF_Client t ON (ci.VAF_Client_ID=t.VAF_Client_ID)"
                    + " INNER JOIN VAB_Currency c ON (a.VAB_Currency_ID=c.VAB_Currency_ID) "
                    + "WHERE ci.VAF_Client_ID='" + VAF_Client_ID + "'";
            }

            try
            {
                int VAB_AccountBook_ID = 0;
                if (!checkNonItem)
                {
                    dr = DataBase.DB.ExecuteReader(sql);
                }

                if (!dr.Read())
                {
                    //  No Warning for System
                    if (VAF_Role_ID != 0)
                        retValue = "NoValidAcctInfo";
                }
                else
                {
                    //	Accounting Info
                    VAB_AccountBook_ID = Utility.Util.GetValueOfInt(dr[0].ToString());
                    m_ctx.SetContext("$VAB_AccountBook_ID", VAB_AccountBook_ID);
                    m_ctx.SetContext("$VAB_Currency_ID", Utility.Util.GetValueOfInt(dr[1].ToString()));
                    m_ctx.SetContext("$HasAlias", dr[2].ToString());
                    m_ctx.SetContext("$CurrencyISO", dr[3].ToString());
                    m_ctx.SetStdPrecision(Utility.Util.GetValueOfInt(dr[4].ToString()));
                    m_ctx.SetContext("$AutoArchive", dr[5].ToString());

                    // 
                    if (checkNonItem)       // Get "Alloe Non Item on Ship/Receipt" from Tenant header if exist.
                    {
                        m_ctx.SetContext("$AllowNonItem", dr[6].ToString());
                    }
                }
                dr.Close();

                //	Accounting Elements
                sql = "SELECT ElementType "
                    + "FROM VAB_AccountBook_Element "
                    + "WHERE VAB_AccountBook_ID='" + VAB_AccountBook_ID + "'"
                    + " AND IsActive='Y'";

                dr = DataBase.DB.ExecuteReader(sql);
                while (dr.Read())
                    m_ctx.SetContext("$Element_" + dr["ElementType"].ToString(), "Y");
                dr.Close();


                //	This reads all relevant window neutral defaults
                //	overwriting superseeded ones.  Window specific is read in Maintain
                sql = "SELECT Attribute, Value, VAF_Screen_ID "
                    + "FROM VAF_ValuePreference "
                    + "WHERE VAF_Client_ID IN (0, @#VAF_Client_ID@)"
                    + " AND VAF_Org_ID IN (0, @#VAF_Org_ID@)"
                    + " AND (VAF_UserContact_ID IS NULL OR VAF_UserContact_ID=0 OR VAF_UserContact_ID=@##VAF_UserContact_ID@)"
                    + " AND IsActive='Y' "
                    + "ORDER BY Attribute, VAF_Client_ID, VAF_UserContact_ID DESC, VAF_Org_ID";
                //	the last one overwrites - System - Client - User - Org - Window
                sql = Utility.Env.ParseContext(m_ctx, 0, sql, false);
                if (sql.Length == 0)
                { }
                else
                {
                    dr = DataBase.DB.ExecuteReader(sql);
                    while (dr.Read())
                    {
                        string VAF_Screen_ID = dr[2].ToString();
                        String at = "";
                        if (string.IsNullOrEmpty(VAF_Screen_ID))
                            at = "P|" + dr[0].ToString();
                        else
                            at = "P" + VAF_Screen_ID + "|" + dr[0].ToString();
                        String va = dr[1].ToString();
                        m_ctx.SetContext(at, va);
                    }
                    dr.Close();
                }

                //	Default Values
                sql = "SELECT t.TableName, c.ColumnName "
                    + "FROM VAF_Column c "
                    + " INNER JOIN VAF_TableView t ON (c.VAF_TableView_ID=t.VAF_TableView_ID) "
                    + "WHERE c.IsKey='Y' AND t.IsActive='Y'"
                    + " AND EXISTS (SELECT * FROM VAF_Column cc "
                    + " WHERE ColumnName = 'IsDefault' AND t.VAF_TableView_ID=cc.VAF_TableView_ID AND cc.IsActive='Y')";

                dr = DataBase.DB.ExecuteReader(sql);
                while (dr.Read())
                    LoadDefault(dr[0].ToString(), dr[1].ToString());
                dr.Close();


            }
            catch
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            //Ini.SaveProperties(Ini.IsClient());
            //	Country
            m_ctx.SetContext("#VAB_Country_ID", MVABCountry.GetDefault(m_ctx).GetVAB_Country_ID());

            m_ctx.SetShowClientOrg(Ini.IsShowClientOrg() ? "Y" : "N");
            m_ctx.SetShowMiniGrid(Ini.GetProperty(Ini.P_Show_Mini_Grid));
            return retValue;
        }	//	loadPreferences

        /// <summary>
        /// Load System Config
        /// </summary>
        public void LoadSysConfig()
        {
            //	Report Page Size Element
            m_ctx.SetContext("#REPORT_PAGE_SIZE", "500");
            string sql = "SELECT NAME, VALUE FROM VAF_SysConfig WHERE NAME = 'REPORT_PAGE_SIZE'";
            IDataReader dr = DataBase.DB.ExecuteReader(sql);
            while (dr.Read())
                if (!string.IsNullOrEmpty(dr[1].ToString()))
                {
                    Regex regex = new Regex(@"^[1-9]\d*$");
                    if (regex.IsMatch(dr[1].ToString()))
                        m_ctx.SetContext("#REPORT_PAGE_SIZE", (dr[1].ToString()));
                }
            dr.Close();

            //	Bulk Report Download
            m_ctx.SetContext("#BULK_REPORT_DOWNLOAD", "N");
            sql = "SELECT NAME, VALUE FROM VAF_SysConfig WHERE NAME = 'BULK_REPORT_DOWNLOAD'";
            dr = DataBase.DB.ExecuteReader(sql);
            while (dr.Read())
                if (!string.IsNullOrEmpty(dr[1].ToString()))
                {
                    Regex regex = new Regex(@"Y|N");
                    if (regex.IsMatch(dr[1].ToString()))
                        m_ctx.SetContext("#BULK_REPORT_DOWNLOAD", (dr[1].ToString()));
                }
            dr.Close();

            // Set Default Value of System Config in Context
            sql = "SELECT NAME, VALUE FROM VAF_SysConfig WHERE ISACTIVE = 'Y' AND NAME NOT IN ('REPORT_PAGE_SIZE' , 'BULK_REPORT_DOWNLOAD')";
            dr = DataBase.DB.ExecuteReader(sql);
            while (dr.Read())
                if (!string.IsNullOrEmpty(dr[1].ToString()))
                {
                    m_ctx.SetContext("#" + dr[0].ToString(), (dr[1].ToString()));
                }
            dr.Close();
        }

    }
}
