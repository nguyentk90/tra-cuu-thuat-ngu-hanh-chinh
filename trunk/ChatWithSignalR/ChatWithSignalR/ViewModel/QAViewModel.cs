using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChatWithSignalR.Models;

namespace ChatWithSignalR.ViewModel
{
    public class QAViewModel
    {
        public IEnumerable<Question> GetQuestionPaged { get; set; }
    }
}