using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using TraCuuThuatNgu.ViewModels;
using System.Data.SqlClient;

namespace TraCuuThuatNgu.Models
{
    public class EntriesModel : CommonModel
    {
        //get all terms paged x size
        public IPagedList<WordIndex> GetEntriesPaged(int page, int size)
        {
            return context.WordIndexes.OrderBy(x => x.HeadWord).ToPagedList(page, size);
        }

        //get terms by startWith paged x size
        public IPagedList<WordIndex> GetEntriesByStartWithPaged(int page, int size, string startWith)
        {
            return context.WordIndexes.Where(x => x.HeadWord.StartsWith(startWith)).OrderBy(x => x.HeadWord).ToPagedList(page, size);
        }


        //add new term or new synset
        public void AddNewTermOrSynset(AddTermViewModel term)
        {

            //check isExist term
            WordIndex checkTerm = context.WordIndexes.Find(term.HeadWord);

            if (checkTerm == null)
            {
                //entry
                WordIndex newTerm = new WordIndex();
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
                context.WordIndexes.Add(newTerm);

                int result = context.SaveChanges();
            }
            else
            {


            }

        }

        // delete synset by synsetId
        public int DeleteSynsetBySynsetId(int synsetId, string headWord)
        {
            Synset synset = context.Synsets.Find(synsetId);

            WordIndex term = context.WordIndexes.Find(headWord);

            term.Synsets.Remove(synset);
            context.Synsets.Remove(synset);

            return context.SaveChanges();
        }


        // edit synset by synsetId
        public int EditSynsetBySynsetId(AddTermViewModel editedSynset,int synsetId)
        {
            Synset synset = context.Synsets.Find(synsetId);

            synset.Category = editedSynset.Catagory;
            synset.Def = editedSynset.Def;
            synset.Exa = editedSynset.Exa;
            

            

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


        // get another synset of term
        public IEnumerable<Synset> GetAnotherSynsetOfTerm(string headWord, int synsetId)
        {
            var list = context.WordIndexes.Find(headWord).Synsets.Where(x => x.SynsetId != synsetId).ToList();
            return list;
        }


        //suggest freetext
        public IEnumerable<WordIndex> SuggestTerm(string keyword)
        {
            return context.Database.SqlQuery<WordIndex>(
                "SELECT * FROM fts_termSearch(@param)", new SqlParameter("param", keyword));
        }

    }
}