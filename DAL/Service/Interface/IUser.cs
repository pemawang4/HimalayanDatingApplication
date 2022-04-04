using System;
using System.Collections.Generic;
using HimalayanMeetDatingApp.Entity;

namespace HimalayanMeetDatingApp.DAL.Service.Interface
{
    public interface IUser
    {
        List<User> userList();
        User saveUser(User user);
        User userLogin(User user);
        User getUserById(int id);
        void savePreference(Preference preference);
        List<MatchList> getMatches(int id);
    }
}
