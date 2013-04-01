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

        public ActionResult Index()
        {

            //String a = "heelll";
            //List<SuggestWordsModel> list = new List<SuggestWordsModel>();
            //list.Add(new SuggestWordsModel("Nguyen", 21));
            //list.Add(new SuggestWordsModel("Edward", 22));
            //list.Add(new SuggestWordsModel("Tran", 22));
            //list.Add(new SuggestWordsModel("Nguyen", 21));
            //list.Add(new SuggestWordsModel("Nguyen", 21));



            //return Json(list, "Stores", JsonRequestBehavior.AllowGet);
            return View();

        }

    }
}
