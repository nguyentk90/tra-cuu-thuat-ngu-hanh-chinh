using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChatWithSignalR.Models;
using ChatWithSignalR.ViewModel;

namespace ChatWithSignalR.Controllers
{
    public class QAController : Controller
    {
        //
        // GET: /QA/

        public ActionResult Index()
        {

            QAModel model = new QAModel();
            QAViewModel viewmodel = new QAViewModel();
            viewmodel.GetQuestionPaged = model.GetQuestionPaged(1, 10);

            return View(viewmodel);
        }

    }
}
