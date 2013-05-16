using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using TraCuuThuatNgu.ViewModels;
using System.Data.SqlClient;
using System.Data;

namespace TraCuuThuatNgu.Models
{
    public class EntriesModel : CommonModel
    {
        // Get all terms paged x size
        public IPagedList<WordIndex> GetEntriesPaged(int page, int size)
        {
            return context.WordIndexes.OrderBy(x => x.HeadWord).ToPagedList(page, size);
        }

        // Get terms by startWith paged x size
        public IPagedList<WordIndex> GetEntriesByStartWithPaged(int page, int size, string startWith)
        {
            return context.WordIndexes.Where(x => x.HeadWord.StartsWith(startWith)).OrderBy(x => x.HeadWord).ToPagedList(page, size);
        }

        // Get terms contains keyword paged x size
        public IPagedList<WordIndex> GetEntriesContainsPaged(int page, int size, string keyword)
        {
            return context.WordIndexes.Where(x => x.HeadWord.Contains(keyword)).OrderBy(x => x.HeadWord).ToPagedList(page, size);
        }



        // Add new term or new synset
        public void AddNewTermOrSynset(AddTermViewModel term)
        {

            // Check isExist term
            WordIndex checkTerm = context.WordIndexes.Find(term.HeadWord);

            if (checkTerm == null)
            {
                // Entry
                checkTerm = new WordIndex();
                checkTerm.HeadWord = term.HeadWord;
                string[] word = term.HeadWord.Split(' ');

                if (word.Count() > 1)
                {
                    checkTerm.WordType = "c";
                }
                else
                {
                    checkTerm.WordType = "s";
                }
            }
            else
            {
            }            

            // Synset
            Synset synset = new Synset();
            synset.Category = term.Catagory;
            synset.Def = term.Def;
            synset.Exa = term.Exa;

            // If synset has synonym(s)
            if (!String.IsNullOrWhiteSpace(term.Synonyms))
            {
                string[] synonyms = term.Synonyms.Split(',');

                foreach (string headWord in synonyms)
                {
                    // Check headWord exist in database
                    WordIndex wordIndex = context.WordIndexes.Find(headWord);
                    if (wordIndex != null)
                    {
                        //synset.WordIndexes.Add(wordIndex);
                    }
                    else
                    {
                        //entry
                        wordIndex = new WordIndex();
                        wordIndex.HeadWord = headWord;
                        string[] words = headWord.Split(' ');

                        if (words.Count() > 1)
                        {
                            wordIndex.WordType = "c";
                        }
                        else
                        {
                            wordIndex.WordType = "s";
                        }
                    }
                    synset.WordIndexes.Add(wordIndex);
                }
            }

            // 
            synset.WordIndexes.Add(checkTerm);
            context.Synsets.Add(synset);

            int result = context.SaveChanges();


        }

        // Delete synset by synsetId
        public int DeleteSynsetBySynsetId(int synsetId, string headWord)
        {
            Synset synset = context.Synsets.Find(synsetId);

            WordIndex term = context.WordIndexes.Find(headWord);

            term.Synsets.Remove(synset);
            context.Synsets.Remove(synset);

            return context.SaveChanges();
        }


        // Edit synset by synsetId
        public int EditSynsetBySynsetId(AddTermViewModel editedSynset, int synsetId)
        {
            Synset synset = context.Synsets.Find(synsetId);

            synset.Category = editedSynset.Catagory;
            synset.Def = editedSynset.Def;
            synset.Exa = editedSynset.Exa;

            //delete all synonym relation 
            synset.WordIndexes.Clear();
            context.SaveChanges();
            synset.WordIndexes.Add(context.WordIndexes.Find(editedSynset.HeadWord));

            // If synset has synonym(s)
            if (!String.IsNullOrWhiteSpace(editedSynset.Synonyms))
            {
                string[] synonyms = editedSynset.Synonyms.Split(',');

                foreach (string headWord in synonyms)
                {
                    // Check headWord exist in database
                    WordIndex wordIndex = context.WordIndexes.Find(headWord);
                    if (wordIndex != null)
                    {
                        //synset.WordIndexes.Add(wordIndex);
                    }
                    else
                    {
                        //entry
                        wordIndex = new WordIndex();
                        wordIndex.HeadWord = headWord;
                        string[] word = headWord.Split(' ');

                        if (word.Count() > 1)
                        {
                            wordIndex.WordType = "c";
                        }
                        else
                        {
                            wordIndex.WordType = "s";
                        }
                    }
                    synset.WordIndexes.Add(wordIndex);
                }
            }

            context.Entry(synset).State = EntityState.Modified;
            return context.SaveChanges();
        }


        // View edit synset
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

        //get synonyms
        public IEnumerable<string> GetSynonyms(int synsetId, string headWord)
        {
            return context.Synsets.Find(synsetId)
                .WordIndexes.Where(x => x.HeadWord != headWord)
                .Select(x => x.HeadWord).ToList();
        }


        // Get another synset of term
        public IEnumerable<Synset> GetAnotherSynsetOfTerm(string headWord, int synsetId)
        {
            var list = context.WordIndexes.Find(headWord).Synsets
                .Where(x => x.SynsetId != synsetId).ToList();
            return list;
        }


        // Suggest freetext
        public IEnumerable<WordIndex> SuggestTerm(string keyword)
        {
            return context.Database.SqlQuery<WordIndex>(
                "SELECT * FROM fts_termSearch(@param)", new SqlParameter("param", keyword));
        }

    }
}