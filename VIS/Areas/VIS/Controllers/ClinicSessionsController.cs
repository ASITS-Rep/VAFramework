using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VAdvantage.Utility;
using VIS.Helpers;
using VIS.Filters;
using VIS.Models;

namespace VIS.Controllers
{
    public class ClinicSessionsController : Controller
    {
        ClinicHelper objClinicHelp = null;
        // GET: VIS/ClinicSessions
        public ActionResult Index()
        {
            return View();
        }

        //Get Notice List
        [AjaxAuthorizeAttribute]
        [AjaxSessionFilterAttribute]
        public JsonResult GetJSONClinicSessions(int pagesize, int page, Boolean isTabDataRef)
        {
            List<HomeClinic> lst = null;
            int count = 0;
            string error = "";
            if (Session["ctx"] != null)
            {
                objClinicHelp = new ClinicHelper();
                lst = new List<HomeClinic>();
                Ctx ct = Session["ctx"] as Ctx;
                if (isTabDataRef)
                {
                    count = objClinicHelp.getClinicSessionsCount(ct);
                }
                lst = objClinicHelp.getClinicSessions(ct, pagesize, page);

            }
            else
            {
                error = "Session Expired";
            }
            return Json(new { count = count, data = JsonConvert.SerializeObject(lst), error = error }, JsonRequestBehavior.AllowGet);
        }

        [AjaxAuthorizeAttribute]
        [AjaxSessionFilterAttribute]
        [HttpPost]
        public JsonResult EnterPatient(int ASI03_Session_ID)
        {
            objClinicHelp = new ClinicHelper();
            Ctx ct = Session["ctx"] as Ctx;
            var res = objClinicHelp.EnterPatient(ct, ASI03_Session_ID);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}