using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TelephoneDirectory.Entities;

namespace TelephoneDirectory.SqlRespository
{
    public class UserDbOperations
    {
        public const string ConnectionString = "Data Source=BALA;Initial Catalog=TelephoneDirectory;Integrated Security=True";

        public int Create(User user)
        {
            const string query = @" INSERT INTO USers (Name,Address) VALUES (@name,@address);
                                    SELECT SCOPE_IDENTITY();

";

            using (var conn = new SqlConnection(ConnectionString))
            {
                return conn.Query<int>(query, new
                {
                    name = user.Name,
                    address = user.Address
                }).FirstOrDefault();


            }
        }

        public void Update(User user)
        {
            const string query = "UPDATE Users SET Name = @name, Address = @address where Id = @id";

            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Execute(query, new
                {
                    name = user.Name,
                    address = user.Address,
                    id = user.Id

                });
            }

        }

        public void Delete(int uid)
        {
            const string query = "Delete from Users where Id = @Id";

            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Execute(query, new
                {
                    Id = uid
                });

            }
        }

        public List<User> GetAll()
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                return conn.Query<User>("SELECT * FROM Users").ToList();
            }
        }

        public User GetById(int uid)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                return conn.Query<User>("SELECT * FROM Users WHERE Id=@Id", new
                {
                    Id = uid
                }).FirstOrDefault();
            }
        }
    }
}