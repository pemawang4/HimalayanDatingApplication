using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using HimalayanMeetDatingApp.DAL.Repo.Interface;
using HimalayanMeetDatingApp.Entity;
using Microsoft.Extensions.Configuration;

namespace HimalayanMeetDatingApp.DAL.Repo.Repository
{
    public class UserRepository : IUserRepository
    {
        public IConfiguration _configuration;
        SqlConnection sqlConn;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            sqlConn = new SqlConnection(_configuration.GetConnectionString("DBConn"));
        }

        public User saveUser(User user)
        {
            using (sqlConn)
            {
                sqlConn.Open();
                var sql = "INSERT INTO Users(FirstName, LastName, Email, Password, Gender, address1, address2, city, state, country, zipCode) VALUES('" + user.firstName + "', '" + user.lastName + "', '" + user.email + "', '" + user.password + "', '" + user.gender + "', '" + user.address1 + "', '" + user.address2 + "', '" + user.city + "', '" + user.state + "', '" + user.country + "', '" + user.zipCode + "')";
                sqlConn.Execute(sql);

                var userSql = "SELECT top 1 * FROM Users ORDER BY userId DESC";
                var newUser = sqlConn.Query<User>(userSql).FirstOrDefault();
                return newUser;
            }
        }

        public List<User> userList()
        {
            using (sqlConn)
            {
                sqlConn.Open();
                var sql = "SELECT * FROM Users";
                List<User> users = sqlConn.Query<User>(sql).ToList();
                return users;
            }
        }

        public User userLogin(User user)
        {
            using (sqlConn)
            {
                User newUser = new User();
                var sql = "SELECT * FROM Users WHERE email = '" + user.email + "' AND password = '" + user.password + "'";
                newUser = sqlConn.Query<User>(sql).FirstOrDefault();
                return newUser;
            }
        }

        public User getUserById(int id)
        {
            using (sqlConn)
            {
                User newUser = new User();
                var sql = "SELECT * FROM Users WHERE userId =" + id;
                newUser = sqlConn.Query<User>(sql).FirstOrDefault();
                return newUser;
            }
        }

        public void savePreference(Preference preference)
        {
            using (sqlConn)
            {
                var sql = "INSERT INTO Preference(gender, enthnicity, religion, region, userId, education) VALUES('" + preference.gender + "', '" + preference.enthnicity + "', '" + preference.religion + "', '" + preference.region + "', '" + preference.userId + "', '" + preference.education + "')";
                sqlConn.Execute(sql);
            }
        }

        public List<MatchList> getMatches(int id)
        {
            using (sqlConn)
            {
                var matchSql = "SELECT * FROM Users, Preference WHERE Preference.userId = " + id;
                MatchList matchList = sqlConn.Query<MatchList>(matchSql).FirstOrDefault();
                var sql = "SELECT * FROM Users, Preference WHERE Preference.gender = '" + matchList?.gender + "' AND Preference.religion = '" + matchList?.religion + "' AND Preference.region = '" + matchList?.region + "' AND Preference.enthnicity = '" + matchList?.enthnicity + "' AND Preference.education = '" + matchList?.education + "'";
                List<MatchList> matchLists = sqlConn.Query<MatchList>(sql).ToList();
                return matchLists;
            }
        }
    }
}
