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

            if (context.UserHistories.Find(keyword, userId) == null)
            {
                UserHistory userHistory = new UserHistory();
                userHistory.Keyword = keyword;
                userHistory.UserId = userId;
                userHistory.DateModify = DateTime.Now;
                context.UserHistories.Add(userHistory);
                return context.SaveChanges();
            }
            else
            {
                return 0;
            }

        }

    }
}