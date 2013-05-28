using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace TraCuuThuatNgu
{
    public class ChatHub : Hub
    {
        //public void Send(string username, string content, string type, int qid)
        //{
        //    if (type.Equals("Q"))
        //    {               
        //        // Call the broadcastMessage method to update clients.
        //        Clients.All.newQuestion(username, content, type, 0);

        //    }
        //    else
        //    {
        //        Clients.All.newAnswer(username, content, type, qid);
        //    }
        //}
        public void Send(string message)
        {
            Clients.All.broadcastMessage(message);
        }

    }
}