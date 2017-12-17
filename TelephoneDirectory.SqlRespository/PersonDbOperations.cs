using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneDirectory.Entities;
using Dapper;
namespace TelephoneDirectory.SqlRespository
{
    public class PersonDbOperations
    {
        public const string ConnectionString = "Data Source=BALA;Initial Catalog=TelephoneDirectory;Integrated Security=True";
        public void Create(Person person)
        {

            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = "Data Source=BALA;Initial Catalog=TelephoneDirectory;Integrated Security=True";
                con.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = @"Insert into Directory(FirstName,LastName,PhoneNumber,Address) values (@FirstName,@LastName,@PhoneNumber,@Address";
                    cmd.Parameters.AddWithValue("@FirstName", person.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", person.LastName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", person.PhoneNumbers);
                    cmd.Parameters.AddWithValue("@Address", person.Address);

                    cmd.CommandText = string.Format(cmd.CommandText, person.FirstName);
                    cmd.CommandText = string.Format(cmd.CommandText, person.LastName);
                    cmd.CommandText = string.Format(cmd.CommandText, person.PhoneNumbers);
                    cmd.CommandText = string.Format(cmd.CommandText, person.Address);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public List<Person> GetAll()
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                return con.Query<Person>("SELECT * FROM Users").ToList();
            }
        }

        public Person GetById(int id)
        {
            var something = new { id = 1, name = "rakesh" };

            using (var con = new SqlConnection(ConnectionString))
            {
                return con.Query<Person>("SELECT * FROM Users where Id=@id", new
                {
                    id = id
                }).FirstOrDefault();
            }
        }
               

        public Person GetByName()
        {
            return null;
        }

        public List<Person> Search(string searchKey)
        {
            const string query = @"SELECT u.Id as UserId,u.Name AS FirstName,u.Address,p.PhoneNumber  FROM USers u INNER JOIN PhoneNumbers p ON p.USerId=u.Id WHERE u.Name LIKE %@searchKey%";

            using (var con = new SqlConnection(ConnectionString))
            {
                return con.Query<Person>(query,
                    new
                    {
                        key = searchKey                        
                    }).ToList();
            }
        }

        public void Update(Person person, int id)
        {
            const string query = "UPDATE USers SET NAme=@name WHERE Id=@Id";

            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Execute(query, new { name = person.FirstName, Id = id });
            }
        }

        public void Delete(int id)
        {
            const string query = "DELETE FROM Users WHERE Id=@Id";

            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Execute(query, new { Id = id });
            }
        }
    }
}
