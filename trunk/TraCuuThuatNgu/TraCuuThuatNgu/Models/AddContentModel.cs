using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Security;

namespace TraCuuThuatNgu.Models
{
    public class AddContentModel:CommonModel
    {
        //add new rawdata
        public int Add(RawData rawdata)
        {
            try
            {
                context.RawDatas.Add(rawdata);
                return context.SaveChanges();
            }
            catch
            {
                return 0;
            }
        }

        //get all history by userid and paged
        public IPagedList<RawData> GetAllAddContent(int page, int pageSize)
        {
            Guid userId = (Guid)Membership.GetUser().ProviderUserKey;
            return context.RawDatas.Where(x => x.UserId == userId).OrderByDescending(x => x.DateAdd ).ToPagedList(page, pageSize);
        }


        //delete history by historyId       
        public int DeleteAddContent(int rawDataId)
        {
            context.RawDatas.Remove(context.RawDatas.Find(rawDataId));
            return context.SaveChanges();
        }

    }
}