using System.Collections.Generic;
using System.Data;
using System.Linq;
using Assessment.Entities;
using Dapper;

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
                return dbConnection.Query<InsertID>("Assess.AddSubscription", sub, commandType: CommandType.StoredProcedure).First().ID;
            }
        }

        public void Delete(UserSubscriptions sub)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("Assess.DeleteSubscription", sub, commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(UserSubscriptions sub)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("Assess.UpdateSubscription", sub, commandType: CommandType.StoredProcedure);
            }
        }

       
    }
}
