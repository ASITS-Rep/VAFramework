using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VIS.Controllers
{
    public class CustomerFormController : Controller
    {
        // GET: ASI03/Sessions
        public ActionResult Index(int windowno)
        {
            ViewBag.WindowNumber = windowno;
            return Json(ViewBag.WindowNumber);
        }
    }
}