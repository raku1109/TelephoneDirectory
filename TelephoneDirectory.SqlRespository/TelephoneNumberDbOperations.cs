using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TelephoneDirectory.Entities;
using Dapper;

namespace TelephoneDirectory.SqlRespository
{
    class TelephoneNumberDbOperations
    {
        public const string ConnectionString = "Data Source=BALA;Initial Catalog=TelephoneDirectory;Integrated Security=True";

        public void Create(TelephoneNumber telephoneNumber)
        {
            const string query = "INSERT into TelephoneNumbers (UId, PhoneNumber, NumberType) VALUES (@uid,@phoneNumber,@numberType) ";

            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(query, new
                {
                    uid = telephoneNumber.UId,
                    phoneNumber = telephoneNumber.PhoneNumber,
                    numberType = telephoneNumber.NumberType                
                });
            }

        }

        public void Update( TelephoneNumber telephoneNumber,int pid)
        {
            const string query = "UPDATE TelephoneNumbers SET PhoneNumber = @number where PId=@pid";

            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(query, new
                {
                    number = telephoneNumber.PhoneNumber,
                    pid = telephoneNumber.PId
                });
            }
          

        }

        public void Delete(int pid)
        {
            const string query = "DELETE FROM TelephoneNumbers WHERE PId = @PId";
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(query, new
                {
                   PId = pid
                });
            }
        }

        public List<TelephoneNumber> GetAll()
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                return con.Query<TelephoneNumber>("SELECT * FROM TelephoneNumbers").ToList();
            }
        }

        public TelephoneNumber GetById(int pid)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                return con.Query<TelephoneNumber>("SELECT * FROM TelephoneNumbers WHERE PId = @PId", new
                {
                    PId = pid
                }).FirstOrDefault();

            }
        }

    }
}
