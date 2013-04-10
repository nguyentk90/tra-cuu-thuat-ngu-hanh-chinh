using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TraCuuThuatNgu.Models;

namespace TraCuuThuatNgu.Controllers
{
    public class ManageEntriesController : Controller
    {
        //
        // GET: /ManageEntries/

        public ActionResult Index()
        {
            return View();
        }


        //
        // GET: /ManageEntries/Add        
        public ActionResult Add()
        {


            return View();
        }


        //
        // POST: /ManageEntries/Add
        [HttpPost]
        public ActionResult Add(Entry entry)
        {


            return View();
        }

    }
}
