using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Lesson7
{
    public class BaseContext
    {
        private string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";

        protected IEnumerable<dynamic> PerformQuery(string query)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query(query);
            }
        }
    }
}
