using System;
using System.Collections.Generic;
using HimalayanMeetDatingApp.DAL.Repo.Interface;
using HimalayanMeetDatingApp.DAL.Service.Interface;
using HimalayanMeetDatingApp.Entity;

namespace HimalayanMeetDatingApp.DAL.Service.ServiceClasses
{
    public class User : IUser
    {
        private readonly IUserRepository _userRepository;
        public User(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Entity.User saveUser(Entity.User user)
        {
            return _userRepository.saveUser(user);
        }

        public List<Entity.User> userList()
        {
            return _userRepository.userList();
        }

        public Entity.User userLogin(Entity.User user)
        {
            return _userRepository.userLogin(user);
        }

        public Entity.User getUserById(int id)
        {
            return _userRepository.getUserById(id);
        }

        public void savePreference(Preference preference)
        {
            _userRepository.savePreference(preference);
        }

        public List<MatchList> getMatches(int id)
        {
            return _userRepository.getMatches(id);
        }
    }
}
