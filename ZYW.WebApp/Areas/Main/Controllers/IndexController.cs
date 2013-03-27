using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Resources;

namespace ZYW.WebApp.Areas.Main.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Main/Index/

        public ActionResult Index()
        {
            #region ViewBag

            ViewBag.Title = ViewBagMessage.MainIndex;

            #endregion

            return RedirectToAction("Index", "SysXCode");
        }

    }
}
