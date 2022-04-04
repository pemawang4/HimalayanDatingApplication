using System;
using System.Collections.Generic;
using HimalayanMeetDatingApp.Entity;

namespace HimalayanMeetDatingApp.DAL.Repo.Interface
{
    public interface IUserRepository
    {
        List<User> userList();

        User saveUser(User user);

        User userLogin(User user);

        User getUserById(int id);

        void savePreference(Preference preference);

        List<MatchList> getMatches(int id);
    }
}
