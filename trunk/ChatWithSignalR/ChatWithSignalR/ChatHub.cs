﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ChatWithSignalR
{
    public class ChatHub : Hub
    {
        static int QuestionId = 0;

        public void Send(string name, string message, string type, string qid)
        {

            if (type.Equals("Q"))
            {
                QuestionId++;
                // Call the broadcastMessage method to update clients.
                Clients.All.broadcastMessage(name, message, type, QuestionId);
            }
            else
            {
                Clients.All.broadcastMessage(name, message, type, qid);
            }
        }
    }
}