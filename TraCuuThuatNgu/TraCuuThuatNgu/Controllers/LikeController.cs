using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TraCuuThuatNgu.Models;

namespace TraCuuThuatNgu.Controllers
{
    public class LikeController : Controller
    {
        //model, work with database
        LikeModel likeModel = new LikeModel();

        //
        // GET: /Like/

        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /Like/Add
        [HttpPost]
        public ActionResult Add(string headWord)
        {
            int result = likeModel.Add(headWord);

            if (result == LikeModel.SUCCESS)
            {
                return Json(new { message = "SUCCESS" }); 
            }
            else if (result == LikeModel.EXISTED)
            {
                return Json(new { message = "EXISTED" }); 
            }
            else {
                return Json(new { message = "FAIL" }); 
            }
        }

    }
}
