using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TraCuuThuatNgu.Models;
using TraCuuThuatNgu.ViewModels;
using System.Collections;

namespace TraCuuThuatNgu.Controllers
{
    public class ResultController : Controller
    {
        //
        // GET: /Result/

        public ActionResult Index(string keyword)
        {

            if (keyword == null || keyword.Trim().Equals(""))
                return RedirectToAction("Index", "Home");

            ResultModel resultModel = new ResultModel();

            ResultViewModel resultViewModel = new ResultViewModel();
            Entry entry = resultModel.GetEntryByKeyword(keyword);


            bool isExistData = true;
            if (entry != null)
            {
                //set view model
                resultViewModel.Entry = entry;

                if (entry.Synsets.Where(x => x.Category == "n").Count() > 0)
                    ViewBag.Noun = entry.Synsets.Where(x => x.Category == "n");
                if (entry.Synsets.Where(x => x.Category == "v").Count() > 0)
                    ViewBag.Verb = entry.Synsets.Where(x => x.Category == "v");

                //add history
                isExistData = true;
            }
            else
            {
                isExistData = false;
            }

            //add history
            SearchHistoryModel searchHistoryModel = new SearchHistoryModel();
            searchHistoryModel.AddSearchHistory(keyword, isExistData);
            //add user history
            if (Request.IsAuthenticated)
            {
                UserHistoryModel userHistoryModel = new UserHistoryModel();
                userHistoryModel.AddUserHistory(keyword);
            }

            return View(resultViewModel);
        }
    }
}
