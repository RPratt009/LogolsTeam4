using System.Collections.Generic;
using System.Data;
using System.Linq;
using TwitchStream.Entities;
using Dapper;
using Assessment.Entities;

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
                return dbConnection.Query<InsertID>("team4.AddStreamer", AddStreamer, commandType: CommandType.StoredProcedure).First().ID;
            }
        }

        public void Update(StreamerList AddStreamer)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("team4.UpdateStreamerOnline", AddStreamer, commandType: CommandType.StoredProcedure);
            }
        }
        public void UpdateStreamer(StreamerList answer)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("team4.UpdateStreamer", answer, commandType: CommandType.StoredProcedure);
            }
        }

        public StreamerList Get(int streamerId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<StreamerList>("team4.GetStreamer", new { StreamerId = streamerId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public StreamerList Get(string channel)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<StreamerList>("team4.GetStreamerWithChannel", new { Channel = channel }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

    }
}
