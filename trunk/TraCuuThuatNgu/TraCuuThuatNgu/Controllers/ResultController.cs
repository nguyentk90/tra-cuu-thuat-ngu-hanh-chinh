using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TraCuuThuatNgu.Models;

namespace TraCuuThuatNgu.Controllers
{
    public class ResultController : Controller
    {
        //
        // GET: /Result/
        TraCuuThuatNguEntities entity = new TraCuuThuatNguEntities();

        public ActionResult Index(string keyword)
        {
            ThuatNgu thuatngu = entity.ThuatNgus.Find(keyword);
            ViewBag.Keyword = keyword;
            return View();
        }
    }
}
