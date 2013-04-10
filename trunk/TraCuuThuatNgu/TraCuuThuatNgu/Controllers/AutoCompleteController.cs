using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TraCuuThuatNgu.Models;
using System.Web.Script.Serialization;
using Newtonsoft.Json;


namespace TraCuuThuatNgu.Controllers
{
    public class AutoCompleteController : Controller
    {
        //
        // GET: /AutoComplete/
        [HttpGet]
        public ActionResult Index()
        {
            //get model
            AutoCompleteModel autoCompleteModel = new AutoCompleteModel();

            List<SearchHistory> list = new List<SearchHistory>();
            SearchHistory s = new SearchHistory();
            s.Keyword = "nguyen";
            s.IsExist = true;
            s.Counter = 1;
            s.DateModify = DateTime.Now;

            list.Add(s);

            return Json(autoCompleteModel.GetByPrefix("n"), JsonRequestBehavior.AllowGet);           
        }

        //
        // POST: /AutoComplete/
        [HttpPost]
        public ActionResult Index(string prefix)
        {
            //get model
            AutoCompleteModel autoCompleteModel = new AutoCompleteModel();    



            return Json(autoCompleteModel.GetByPrefix(prefix), JsonRequestBehavior.DenyGet);
        }

    }
}
