using System.Data;
using System.Linq;
using TwitchStream.Entities;
using Dapper;
using Assessment.Entities;
using System.Collections.Generic;

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

        public void UpdateOnline(StreamerList updateStreamer)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("team4.UpdateStreamerOnline", updateStreamer, commandType: CommandType.StoredProcedure);
            }
        }
        public void Update(StreamerList updateStreamer)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("team4.UpdateStreamer", updateStreamer, commandType: CommandType.StoredProcedure);
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

        public IEnumerable<StreamerList> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<StreamerList>("team4.GetAllStreamers", commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<StreamerList> GetSubscriptions(int userId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<StreamerList>("team4.GetStreamersUserSubscribedTo", new { UserId = userId }, commandType: CommandType.StoredProcedure);
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
