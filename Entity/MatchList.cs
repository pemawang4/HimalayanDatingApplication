using System;
namespace HimalayanMeetDatingApp.Entity
{
    public class MatchList
    {
        public int matchListID { get; set; }
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public string enthnicity { get; set; }
        public string religion { get; set; }
        public string region { get; set; }
        public string education { get; set; }
        public string description { get; set; }
    }
}
