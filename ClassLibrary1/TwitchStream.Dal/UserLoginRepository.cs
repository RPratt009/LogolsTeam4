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
        public int Insert(UserLogin user)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<InsertID>("team4.AddUserLogin", user, commandType: CommandType.StoredProcedure).First().ID;
            }
        }

        public void Update(UserLogin user)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("team4.UpdateUserLogin", user, commandType: CommandType.StoredProcedure);
            }
        }

        public UserLogin Get(int streamerId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<UserLogin>("team4.GetUser", new { StreamerId = streamerId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public UserLogin Get(string userName, string password)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<UserLogin>("team4.GetUserWithCredentials", new { Username = userName, Pass = password }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
