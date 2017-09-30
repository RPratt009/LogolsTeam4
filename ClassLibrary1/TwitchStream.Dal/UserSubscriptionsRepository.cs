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
        public int Insert(UserSubscriptions sub)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<InsertID>("team4.AddSubscription", sub, commandType: CommandType.StoredProcedure).First().ID;
            }
        }

        public void Delete(UserSubscriptions sub)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("team4.DeleteSubscription", sub, commandType: CommandType.StoredProcedure);
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
