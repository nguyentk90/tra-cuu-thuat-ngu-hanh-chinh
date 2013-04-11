using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TraCuuThuatNgu.Models;
using TraCuuThuatNgu.ViewModels;

namespace TraCuuThuatNgu.Controllers
{
    public class ManageSearchHistoryController : Controller
    {

        SearchHistoryModel searchHistoryModel = new SearchHistoryModel();

        //
        // GET: /ManageSearch/

        public ActionResult Index()
        {
            //view models for search history
            ManageSearchHistoryViewModel managesearchHistoryModel = new ManageSearchHistoryViewModel();
            
            //search history list
            managesearchHistoryModel.GetAllSearchHistory = searchHistoryModel.GetAllSearchHistory();
            
            //summary search history 
            managesearchHistoryModel.SummarySearchHistoryModel = new SummarySearchHistoryModel();

            return View(managesearchHistoryModel);
        }

    }
}
