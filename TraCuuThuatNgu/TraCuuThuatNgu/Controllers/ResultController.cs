using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TraCuuThuatNgu.Controllers
{
    public class ResultController : Controller
    {
        //
        // GET: /Result/

        public ActionResult Index(string keyword)
        {
            ViewBag.Keyword = keyword;
            return View();
        }

    }
}
