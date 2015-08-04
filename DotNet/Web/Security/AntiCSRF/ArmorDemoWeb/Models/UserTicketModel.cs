using System;

namespace ArmorDemoWeb.Models
{
    public class UserTicketModel
    {
        public string UserName { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public string UserData { get; set; }
    }
}