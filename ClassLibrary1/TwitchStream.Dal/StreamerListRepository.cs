using System.Collections.Generic;
using System.Data;
using System.Linq;
using TwitchStream.Entities;
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
        public int Insert(StreamerList AddStreamer)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<InsertID>("team4.AddStreamer", answer, commandType: CommandType.StoredProcedure).First().ID;
            }
        }

        public void Update(StreamerList answer)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("team4.UpdateStreamerOnline", answer, commandType: CommandType.StoredProcedure);
            }
        }
        public void Update(StreamerList answer)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("team4.UpdateStreamer", answer, commandType: CommandType.StoredProcedure);
            }
        }

        public StreamerList Get(int answerID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Answer>("team4.GetStreamer", new { AnswerID = answerID }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public StreamerList Get(int answerID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Answer>("team4.GetStreamerWithChannel", new { AnswerID = answerID }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

    }
}
