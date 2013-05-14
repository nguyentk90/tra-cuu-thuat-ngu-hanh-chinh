using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TraCuuThuatNgu.Models;
using TraCuuThuatNgu.ViewModels;

namespace TraCuuThuatNgu.Controllers
{
    public class ManageEntriesController : Controller
    {
        //
        // GET: /ManageEntries/

        public ActionResult Index(int? page, string startWith)
        {
            EntriesModel entriesModel = new EntriesModel();
            EntriesViewModel viewModel = new EntriesViewModel();

            int size = 5;

            var pageNumber = page ?? 1;

            var startW = String.IsNullOrEmpty(startWith) ? "none" : startWith;


            if (startW.Equals("none"))
            {
                viewModel.AllEntries = entriesModel.GetEntriesPaged(pageNumber, size);
            }
            else
            {
                viewModel.AllEntries = entriesModel.GetEntriesByStartWithPaged(pageNumber, size, startW);
            }


            ViewBag.Size = size;

            return View(viewModel);
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
        public ActionResult Add(AddTermViewModel term)
        {
            EntriesModel entriesModel = new EntriesModel();
            entriesModel.AddNewTermOrSynset(term);
            return View();
        }

        //delete synset
        [Authorize]
        public ActionResult Delete(int synsetId,string headWord)
        {
            EntriesModel entriesModel = new EntriesModel();

            entriesModel.DeleteSynsetBySynsetId(synsetId, headWord);

            return View();
        }

        //edit synset
        [HttpGet]
        public ActionResult Edit(int synsetId, string headWord)
        {
            
            EntriesModel entriesModel = new EntriesModel();
            AddTermViewModel editSynset = entriesModel.ViewEditSynset(synsetId, headWord);
            ViewBag.ListAnotherSynset = entriesModel.GetAnotherSynsetOfTerm(headWord, synsetId);
            return View(editSynset);
        }

    }
}
