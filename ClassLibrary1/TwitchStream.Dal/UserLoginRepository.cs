using System.Collections.Generic;
using System.Data;
using System.Linq;
using Assessment.Entities;
using Dapper;

/*AddUserLogin
UpdateUserLogin
GetUserWithCredentials
GetUser*/

namespace TwitchStream.Dal
{
    public class UserLoginRepository : Repository
    {
        public int Insert(UserLogin answer)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<InsertID>("team4.AddUserLogin", answer, commandType: CommandType.StoredProcedure).First().ID;
            }
        }

        public void Update(UserLogin answer)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("team4.UpdateUserLogin", answer, commandType: CommandType.StoredProcedure);
            }
        }

        public Answer Get(int answerID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Answer>("team4.GetUserWithCredentials", new { AnswerID = answerID }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public IEnumerable<Answer> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Answer>("team4.GetUser", commandType: CommandType.StoredProcedure);
            }
        }
    }
}
