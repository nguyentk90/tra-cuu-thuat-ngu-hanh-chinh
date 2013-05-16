using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace TraCuuThuatNgu.Models
{
    public class UsersModel:CommonModel
    {

        // Get all user
        public IPagedList<aspnet_Users> GetAllUserPaged(int page, int size)
        {
            return context.aspnet_Users.OrderBy(x => x.UserName).ToPagedList(page, size);
        }


        // Get user by username
        public aspnet_Users GetUserByUsername(string username)
        {
            return context.aspnet_Users.Where(x => x.UserName == username).FirstOrDefault();        
        }

    }
}