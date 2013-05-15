using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace TraCuuThuatNgu.Models
{
    public class CommentModel:CommonModel
    {
        // View all comment paging
        public IPagedList<Comment> GetCommentPaged(int page, int size)
        {
            return context.Comments.OrderByDescending(x => x.DateAdd).ToPagedList(page, size);
        }


        // Delete comment by commnetId
        public int Delete(int commentId)
        {
            Comment cm = context.Comments.Find(commentId);
            context.Comments.Remove(cm);
            return context.SaveChanges();
        }
    }
}