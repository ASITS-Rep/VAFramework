using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VAdvantage.Utility;
using VIS.Areas.VIS.Helpers;
using VIS.Filters;
using VIS.Helpers;
using VIS.Models;

namespace VIS.Areas.VIS.Controllers
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
            List<HomeClinicSessions> lst = null;
            int count = 0;
            string error = "";
            if (Session["ctx"] != null)
            {
                objClinicHelp = new ClinicHelper();
                lst = new List<HomeClinicSessions>();
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
    }
}