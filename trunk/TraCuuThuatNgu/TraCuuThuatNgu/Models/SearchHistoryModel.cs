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

        //get top % history lastest
        public IQueryable<SearchHistory> GetTopLastest(int top)
        {
            return context.SearchHistories.OrderByDescending(x => x.DateModify).Take(top);   
        }

                
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
                    searchHistory.Counter = 1;
                    searchHistory.DateModify = DateTime.Now;
                    //add new
                    context.SearchHistories.Add(searchHistory);
                }
                else
                {
                    searchHistory.IsExist = isExist;
                    searchHistory.Counter++;
                    searchHistory.DateModify = DateTime.Now;
                    //increment count
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