using System.Data;
using System.Data.SqlClient;

namespace TwitchStream.Dal
{
    public class Repository
    {
        private string connectionString;


        public Repository()
        {
            connectionString = @"Data Source=logolsdb.database.windows.net;Initial Catalog=LogolsLearning;Persist Security Info=True;User ID=Team4;Password=logolsteam#4";
        }



        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

    }
}
