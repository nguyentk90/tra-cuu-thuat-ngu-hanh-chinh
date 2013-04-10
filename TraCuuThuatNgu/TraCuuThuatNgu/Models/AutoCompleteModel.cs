using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TraCuuThuatNgu.Models
{
    public class AutoCompleteModel : CommonModel
    {
        //get suggest words by prefix
        public List<string> GetByPrefix(string prefix)
        {
           
            List<string> listSuggest = new List<string>();

            var suggestWordsFromSearchHistories = context.SearchHistories.Where(x => x.Keyword.Contains(prefix))
                .OrderByDescending(x => x.Counter)
                .Select(x => x.Keyword).Take(8);

            IQueryable<string> suggestWordsFromEntries;
            int count = suggestWordsFromSearchHistories.Count();

            if (count >= 8)
            {
                return suggestWordsFromSearchHistories.ToList();
            }
            else if (count != 0)
            {
                suggestWordsFromEntries = context.Entries.Where(x => x.HeadWord.Contains(prefix))
              .Select(x => x.HeadWord).Take(8 - count);

                listSuggest.AddRange(suggestWordsFromSearchHistories);
                listSuggest.AddRange(suggestWordsFromEntries);

                return listSuggest.Distinct().ToList();
            }
            else
            {
                suggestWordsFromEntries = context.Entries.Where(x => x.HeadWord.Contains(prefix))
             .Select(x => x.HeadWord).Take(8);

                return suggestWordsFromEntries.ToList();
            }
        }
    }
}