using System.Data.SqlClient;
using Dapper;
using TelephoneDirectory.Entities;

namespace TelephoneDirectory.SqlRespository
{
    public class UserDbOperations
    {
        public const string ConnectionString = "Data Source=BALA;Initial Catalog=TelephoneDirectory;Integrated Security=True";

        public void Create(User user)
        {
            const string query = " INSERT INTO USers (Name,Address) VALUES (@name,@address) ";

            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Execute(query, new
                {
                    name = user.Name,
                    address = user.Address
                });
            }
        }
    }
}