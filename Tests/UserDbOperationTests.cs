using System.Data.SqlClient;
using System.Linq;
using NUnit.Framework;
using TelephoneDirectory.Entities;
using TelephoneDirectory.SqlRespository;
using Dapper;
namespace Tests
{
    [TestFixture] // this is an attribute                          
    public class UserDbOperationTests
    {
        [Test]
        public void When_Insert_Is_Called_With_Person_With_Valid_Data_Should_Save()
        {
            var userDbOperation = new UserDbOperations();
            var user = new User() { Address = "Mumbai", Name = "Harish" };
            userDbOperation.Create(user);

            using (var conn = new SqlConnection(UserDbOperations.ConnectionString))
            {
                var createdUser = conn.Query<User>("SELECT * FROM USers WHERE Name='Harish'").FirstOrDefault();

                Assert.IsNotNull(createdUser);

                Assert.AreEqual(user.Name, createdUser.Name);
                Assert.AreEqual(user.Address, createdUser.Address);
                Assert.That(createdUser.Id > 0);
            }
        }
    }
}