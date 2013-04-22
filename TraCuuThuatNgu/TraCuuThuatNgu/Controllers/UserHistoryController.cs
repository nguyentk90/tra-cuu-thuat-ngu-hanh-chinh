using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TraCuuThuatNgu.Models;
using TraCuuThuatNgu.ViewModels;
using PagedList;

namespace TraCuuThuatNgu.Controllers
{
    public class UserHistoryController : Controller
    {
        //
        // GET: /UserHistory/
        [Authorize]
        public ActionResult Index(int? page)
        {
            UserHistoryModel userHistoryModel = new UserHistoryModel();
            UserHistoryViewModel viewModel = new UserHistoryViewModel();
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            viewModel.AllUserHistoryPaged = userHistoryModel.GetAllUserHistoryPaged(pageNumber, 10); 
            return View(viewModel);
        }


        //delete history
        [HttpPost]
        public ActionResult Delete(int historyId)
        {
            UserHistoryModel userHistoryModel = new UserHistoryModel();
            int result = userHistoryModel.DeleteUserHistory(historyId);
            if (result > 0)
            {
                return Json(new { message = "SUCCESS" });
            }
            else
            {
                return Json(new { message = "FAIL" });
            }
        }
    }
}
