using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public int AddHistory(string keyword)
        {
            try
            {
                SearchHistory searchHistory = context.SearchHistories.Find(keyword);
                if (searchHistory == null)
                {
                    searchHistory = new SearchHistory();
                    searchHistory.Keyword = keyword;
                    searchHistory.IsExist = true;
                    searchHistory.Counter = 0;
                    context.SearchHistories.Add(searchHistory);
                }
                else
                {
                    searchHistory.IsExist = true;
                    searchHistory.Counter++;

                    //context.SearchHistories.
                }

            }
            catch
            { }

        }
    }
}