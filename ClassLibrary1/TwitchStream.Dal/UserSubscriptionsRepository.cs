using System.Collections.Generic;
using System.Data;
using System.Linq;
using TwitchStream.Entities;
using Dapper;
using Assessment.Entities;

/*AddSubscription
DeleteSubscription
UpdateSubscription */

namespace TwitchStream.Dal
{
    public class UserSubscriptionsRepository : Repository
    {
        public int Insert(int streamerId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                UserSubscriptions sub = new UserSubscriptions
                {
                    StreamerId = streamerId,
                    UserLoginId = 2
                };
                dbConnection.Open();
                return dbConnection.Query<InsertID>("team4.AddSubscription", sub, commandType: CommandType.StoredProcedure)?.FirstOrDefault()?.ID ?? 0;
            }
        }

        public void Delete(int subscriptionId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("team4.DeleteSubscription", new { SubscriptionId = subscriptionId }, commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(UserSubscriptions sub)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("team4.UpdateSubscription", sub, commandType: CommandType.StoredProcedure);
            }
        }

       
    }
}
