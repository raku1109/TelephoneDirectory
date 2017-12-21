using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TelephoneDirectory.Entities;
using Dapper;

namespace TelephoneDirectory.SqlRespository
{
    public class TelephoneNumberDbOperations
    {
        public const string ConnectionString = "Data Source=BALA;Initial Catalog=TelephoneDirectory;Integrated Security=True";

        public int Create(TelephoneNumber telephoneNumber)
        {
            const string query =
                @"INSERT into TelephoneNumbers (UId, PhoneNumber, NumberType) VALUES (@uid,@phoneNumber,@numberType) ;
                                  SELECT SCOPE_IDENTITY() ;
";

            using (var con = new SqlConnection(ConnectionString))
            {
                return con.Query<int>(query, new
                {
                    pid = telephoneNumber.PId,
                    uid = telephoneNumber.UId,
                    phoneNumber = telephoneNumber.PhoneNumber,
                    numberType = telephoneNumber.NumberType
                }).FirstOrDefault();


            }

        }

        public void Update( TelephoneNumber telephoneNumber)
        {
            const string query = @"UPDATE TelephoneNumbers SET PhoneNumber = @number, NumberType = @type,UID = @uid WHERE PId=@pid";

            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(query, new
                {
                    uid = telephoneNumber.UId,
                    type = telephoneNumber.NumberType,
                    number = telephoneNumber.PhoneNumber,
                    pid = telephoneNumber.PId
                });
            }
          

        }

        public void Delete(TelephoneNumber telephoneNumber)
        {
            const string query = "DELETE FROM TelephoneNumbers WHERE PId = @pid";
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Execute(query, new
                {
                  pid = telephoneNumber.PId
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
