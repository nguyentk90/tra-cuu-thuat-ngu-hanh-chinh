using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using TraCuuThuatNgu.ViewModels;

namespace TraCuuThuatNgu.Models
{
    public class EntriesModel : CommonModel
    {
        //get all terms paged x size
        public IPagedList<Entry> GetEntriesPaged(int page, int size)
        {
            return context.Entries.OrderBy(x => x.HeadWord).ToPagedList(page, size);
        }

        //get terms by startWith paged x size
        public IPagedList<Entry> GetEntriesByStartWithPaged(int page, int size, string startWith)
        {
            return context.Entries.Where(x => x.HeadWord.StartsWith(startWith)).OrderBy(x => x.HeadWord).ToPagedList(page, size);
        }


        //add new term or new synset
        public void AddNewTermOrSynset(AddTermViewModel term)
        {

            //check isExist term
            Entry checkTerm = context.Entries.Find(term.HeadWord);

            if (checkTerm == null)
            {
                //entry
                Entry newTerm = new Entry();
                newTerm.HeadWord = term.HeadWord;
                string[] word = term.HeadWord.Split(' ');

                if (word.Count() > 1)
                {
                    newTerm.WordType = "c";
                }
                else
                {
                    newTerm.WordType = "s";
                }

                //synset
                Synset synset = new Synset();
                synset.Category = term.Catagory;
                synset.Def = term.Def;
                synset.Exa = term.Exa;

                newTerm.Synsets.Add(synset);
                context.Entries.Add(newTerm);

                int result = context.SaveChanges();
            }
            else
            {


            }





        }

        //delete synset by synsetId
        public int DeleteSynsetBySynsetId(int synsetId, string headWord)
        {
            Synset synset = context.Synsets.Find(synsetId);

            Entry term = context.Entries.Find(headWord);

            term.Synsets.Remove(synset);
            context.Synsets.Remove(synset);

            return context.SaveChanges();
        }


        //view edit synset
        public AddTermViewModel ViewEditSynset(int synsetId, string headWord)
        {
            AddTermViewModel editSynset = new AddTermViewModel();

            Synset synset = context.Synsets.Find(synsetId);

            editSynset.Catagory = synset.Category;
            editSynset.Def = synset.Def;
            editSynset.Exa = synset.Exa;
            editSynset.HeadWord = headWord;

            return editSynset;        
        }


        //suggest freetext
        public List<string> SuggestTerm(string keyword)
        {
            List<string> listSuggest = new List<string>();

            return context.Database.SqlQuery<string>("dbo.fts_termSearch", "bao").ToList();

            //return listSuggest;
        }

    }
}