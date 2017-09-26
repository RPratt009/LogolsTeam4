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
                return dbConnection.Query<InsertID>("Assess.AddUserLogin", answer, commandType: CommandType.StoredProcedure).First().ID;
            }
        }

        public void Update(UserLogin answer)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("Assess.UpdateUserLogin", answer, commandType: CommandType.StoredProcedure);
            }
        }

        public Answer Get(int answerID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Answer>("Assess.GetUserWithCredentials", new { AnswerID = answerID }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public IEnumerable<Answer> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Answer>("Assess.GetUser", commandType: CommandType.StoredProcedure);
            }
        }
    }
}
