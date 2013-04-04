using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TraCuuThuatNgu.ViewModels;

namespace TraCuuThuatNgu.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            
            return View(new CommonViewModel());
        }

        //
        // GET: /Test/
        [HttpPost]
        public ActionResult Index(CommonViewModel cm)
        {
            return View(cm);
        }

    }
}
