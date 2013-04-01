using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TraCuuThuatNgu.Models
{
    public class SuggestWordsModel
    {
        public SuggestWordsModel() { }
        public SuggestWordsModel(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            ListWords = new List<OneWord>();
            ListWords.Add(new OneWord("hello",3));
            ListWords.Add(new OneWord("hi", 5));
            ListWords.Add(new OneWord("Chao", 3));
            ListWords.Add(new OneWord("Mobile", 3));

        }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<OneWord> ListWords { get; set; }
    }
    public class OneWord
    {
        public OneWord(string name, int counter)
        {
            this.Name = name;
            this.Counter = counter;
        
        }
        public string Name { get; set; }
        public int Counter { get; set; }
    }
}