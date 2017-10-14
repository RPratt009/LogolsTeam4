using System.Collections.Generic;
using System.Data;
using System.Linq;
using TwitchStream.Entities;
using Dapper;
using Assessment.Entities;

/*AddUserLogin
UpdateUserLogin
GetUserWithCredentials
GetUser*/

namespace TwitchStream.Dal
{
    public class UserLoginRepository : Repository
    {
        public int Insert(UserLogin userLogin)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                userLogin.ID = null;
                return dbConnection.Query<InsertID>("team4.AddUserLogin", userLogin, commandType: CommandType.StoredProcedure).First().ID;
            }
        }

        public void Update(UserLogin userLogin)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("team4.UpdateUserLogin", userLogin, commandType: CommandType.StoredProcedure);
            }
        }

        public UserLogin Get(string username, string password)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<UserLogin>("team4.GetUserWithCredentials", new { Username = username, Pass = password }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public UserLogin Get(int userId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<UserLogin>("team4.GetUser", new { UserLoginId = userId }, commandType: CommandType.StoredProcedure).First();
            }
        }
    }
}
