using System;
namespace HimalayanMeetDatingApp.Entity
{
    public class Preference
    {
        public int preferenceID { get; set; }
        public string gender { get; set; }
        public string enthnicity { get; set; }
        public string religion { get; set; }
        public string region { get; set; }
        public int userId { get; set; }
        public string education { get; set; }
        public string description { get; set; }
    }
}
