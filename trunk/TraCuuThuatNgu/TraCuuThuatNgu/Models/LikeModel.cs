using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace TraCuuThuatNgu.Models
{
    public class LikeModel
    {
        //DbContext
        TraCuuThuatNguEntities context = null;

        public static int SUCCESS = 1;
        public static int FAIL = 0;
        public static int EXISTED = 2;

        public LikeModel()
        {
            context = new TraCuuThuatNguEntities(); ;
        }

        //add a like
        public int Add(string headWord)
        {
            try
            {
                Guid userId = (Guid)Membership.GetUser().ProviderUserKey;
                //check have liked
                if (context.Favorites.Find(headWord, userId) != null)
                {
                    return LikeModel.EXISTED;
                }
                else
                {
                    Favorite favorite= new Favorite();
                    favorite.HeadWord = headWord;
                    favorite.UserId = userId;
                    favorite.DateAdd = DateTime.Now;
                    
                    context.Favorites.Add(favorite);
                    context.SaveChanges();

                    return LikeModel.SUCCESS;
                }
            }
            catch
            {
                return LikeModel.FAIL;
            }
           
        }

    }
}