using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace TraCuuThuatNgu.Models
{
    public class SearchHistoryModel
    {
        TraCuuThuatNguEntities context = null;

        public SearchHistoryModel()
        {
            context = new TraCuuThuatNguEntities();
        }

        //It has not done yet!
        //add searching history 
        public int AddSearchHistory(string keyword, bool isExist)
        {
            try
            {
                SearchHistory searchHistory = context.SearchHistories.Find(keyword);
                if (searchHistory == null)
                {
                    searchHistory = new SearchHistory();
                    searchHistory.Keyword = keyword;
                    searchHistory.IsExist = isExist;
                    searchHistory.Counter = 0;
                    //add new
                    context.SearchHistories.Add(searchHistory);
                }
                else
                {
                    searchHistory.IsExist = isExist;
                    searchHistory.Counter++;
                    //increment
                    context.Entry(searchHistory).State = EntityState.Modified;
                }

                //change context
                return context.SaveChanges();
            }
            catch
            {
                return 0;
            }

        }
    }
}