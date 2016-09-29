using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace HelloSignalR.Hubs
{
    public class BabyNamesHub : Hub
    {
        public void AddBabyName(string name)
        {
            Clients.All.babyNamed(name);
        }
    }
}