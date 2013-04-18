using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace TraCuuThuatNgu.Models
{
    public class UserHistoryModel : CommonModel
    {
        //add user history
        public int AddUserHistory(string keyword)
        {
            Guid userId = (Guid)Membership.GetUser().ProviderUserKey;

            UserHistory userHistory = new UserHistory();
            userHistory.Keyword = keyword;
            userHistory.UserId = userId;
            userHistory.DateModify = DateTime.Now;
            context.UserHistories.Add(userHistory);
            return context.SaveChanges();
        }

        //get all history by userid
        public IQueryable<UserHistory> GetAllUserHistory()
        {
            Guid userId = (Guid)Membership.GetUser().ProviderUserKey;

            return context.UserHistories.Where(x => x.UserId == userId).OrderByDescending(x => x.DateModify);
        }


        //delete history by historyId       
        public int DeleteUserHistory(int historyId)
        {
            context.UserHistories.Remove(context.UserHistories.Find(historyId));
            return context.SaveChanges();
        }

    }
}