using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TraCuuThuatNgu.Models;

namespace TraCuuThuatNgu.Controllers
{
    public class AutoCompleteController : Controller
    {
        //
        // GET: /AutoComplete/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /AutoComplete/
        [HttpPost]
        public ActionResult Index(string prefix)
        {
            List<string> list = new List<string>();
            //list.Add(new OneWord("hello" + prefix, 3));
            //list.Add(new OneWord("hi" + prefix, 5));
            //list.Add(new OneWord("Chao", 3));
            //list.Add(new OneWord("Mobile", 3));
            list.Add("hello");
            list.Add("nguyên");
            list.Add("Chào");
            list.Add("Mobile");
            return Json(list, JsonRequestBehavior.DenyGet);
        }

    }
}
