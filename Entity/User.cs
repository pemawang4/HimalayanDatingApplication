using System;
namespace HimalayanMeetDatingApp.Entity
{
    public class User
    {
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public int zipCode { get; set; }
        public bool preference { get; set; }
    }
}
