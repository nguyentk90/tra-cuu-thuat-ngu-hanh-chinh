using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TraCuuThuatNgu.Models;
using System.Web.Security;

namespace TraCuuThuatNgu.Controllers
{
    public class CommentController : Controller
    {

        //DbContext
        TraCuuThuatNguEntities context = new TraCuuThuatNguEntities();

        //
        // GET: /Comment/

        public ActionResult Index()
        {
            return View();
        }


        //
        // POST: /Add Comment/
        [HttpPost]
        public ActionResult Add(string headWord, string content)
        {
            Guid userGuid = (Guid)Membership.GetUser().ProviderUserKey;

            Comment cmt = new Comment();

            cmt.HeadWord = headWord;
            cmt.CmContent = content;
            cmt.DateAdd = DateTime.Now;
            cmt.UserId = userGuid;            

            context.Comments.Add(cmt);
            context.SaveChanges();
            return Redirect("/Result?keyword=" + headWord);
        }

    }
}
