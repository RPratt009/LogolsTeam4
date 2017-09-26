using System.Collections.Generic;
using System.Data;
using System.Linq;
using Assessment.Entities;
using Dapper;

/*AddStreamer
UpdateStreamerOnline
UpdateStreamer
GetStreamer
GetStreamerWithChannel */


namespace TwitchStream.Dal
{
    public class StreamerListRepository : Repository
    {
        public int Insert(AddStreamer AddStreamer)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<InsertID>("Assess.AddStreamer", answer, commandType: CommandType.StoredProcedure).First().ID;
            }
        }

        public void Update(Answer answer)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("Assess.UpdateStreamerOnline", answer, commandType: CommandType.StoredProcedure);
            }
        }
        public void Update(Answer answer)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("Assess.UpdateStreamer", answer, commandType: CommandType.StoredProcedure);
            }
        }

        public Answer Get(int answerID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Answer>("Assess.GetStreamer", new { AnswerID = answerID }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Answer Get(int answerID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Answer>("Assess.GetStreamerWithChannel", new { AnswerID = answerID }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

    }
}
