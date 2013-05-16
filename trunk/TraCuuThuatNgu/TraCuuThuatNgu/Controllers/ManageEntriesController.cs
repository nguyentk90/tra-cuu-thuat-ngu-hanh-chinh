﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TraCuuThuatNgu.Models;
using TraCuuThuatNgu.ViewModels;

namespace TraCuuThuatNgu.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManageEntriesController : Controller
    {
        //
        // GET: /ManageEntries/

        public ActionResult Index(int? page, string startWith, string keyword)
        {
            EntriesModel entriesModel = new EntriesModel();
            EntriesViewModel viewModel = new EntriesViewModel();

            int size = 5;

            var pageNumber = page ?? 1;

            var startW = String.IsNullOrEmpty(startWith) ? "none" : startWith;

            if (!String.IsNullOrWhiteSpace(keyword))
            {
                viewModel.AllEntries = entriesModel.GetEntriesContainsPaged(pageNumber, size, keyword);
            }
            else
            {
                if (startW.Equals("none"))
                {
                    viewModel.AllEntries = entriesModel.GetEntriesPaged(pageNumber, size);
                }
                else
                {
                    viewModel.AllEntries = entriesModel.GetEntriesByStartWithPaged(pageNumber, size, startW);
                }
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
            try
            {
                EntriesModel entriesModel = new EntriesModel();
                entriesModel.AddNewTermOrSynset(term);
                ViewBag.Success = "Thêm thuật ngữ thành công!";
            }
            catch {
                ViewBag.Fail = "Thêm thuật ngữ không thành công!";
            }
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
            ViewBag.ListSynonyms = entriesModel.GetSynonyms(synsetId, headWord);
            return View(editSynset);
        }


        // POST: edit synset
        [HttpPost]
        public ActionResult Edit(AddTermViewModel editedSynset, int synsetId)
        {
            EntriesModel entriesModel = new EntriesModel();
            int result = entriesModel.EditSynsetBySynsetId(editedSynset,synsetId);
            ViewBag.Result = result;
            return RedirectToAction("Edit", new {synsetId = synsetId, headWord = editedSynset.HeadWord, r="success" });
            //return View();
        }
    }
}
