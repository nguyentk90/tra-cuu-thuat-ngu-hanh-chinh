using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TraCuuThuatNgu.Models;
using TraCuuThuatNgu.ViewModels;

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
            ResultViewModel result = new ResultViewModel();
            result.ThuatNgu = thuatngu;

            return View(result);
        }
    }
}
