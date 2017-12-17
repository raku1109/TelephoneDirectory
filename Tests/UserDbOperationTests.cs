using System.Data.SqlClient;
using System.Linq;
using NUnit.Framework;
using TelephoneDirectory.Entities;
using TelephoneDirectory.SqlRespository;
using Dapper;
using NUnit.Framework.Interfaces;

namespace Tests
{
    [TestFixture] // this is an attribute                          
    public class UserDbOperationTests
    {
        [Test]
        public void When_Create_Is_Called_With_Valid_Data()
        {
            var userDbOperation = new UserDbOperations();
            var user = new User() {Address = "Mumbai", Name = "Harish"};
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

        [Test]
        public void When_Create_Is_Called_With_Name_As_Null_It_Throws_SqlException()
        {
            var userDbOperation = new UserDbOperations();
            var user = new User() {Name = null, Address = "Mumbai"};
            Assert.Throws<SqlException>(() => userDbOperation.Create(user));
        }

        [Test]
        public void When_Create_Is_Called_With_Address_As_Null_It_Throws_SqlException()
        {
            var userDbOperation = new UserDbOperations();
            var user = new User() {Name = "SomeName", Address = null};
            Assert.Throws<SqlException>(() => userDbOperation.Create(user));
        }

        [TestCase(null, null)]
        [TestCase(null, "someValue")]
        [TestCase("xyz", null)]
        public void When_Create_Is_Called_With_Invalid_Data_Throws_SqlException(string name, string address)
        {
            var userDbOperation = new UserDbOperations();
            var user = new User() {Name = name, Address = address};
            Assert.Throws<SqlException>(() => userDbOperation.Create(user));
        }

        [TestCase("", "")]
        [TestCase("ValidName", "Valid Address")]
        [TestCase("1", "1")]
        [TestCase("", "ValidAddress")]
        [TestCase("ValidName", "")]

        public void When_Create_Is_Called_With_Valid_Data_SavesData(string name, string address)
        {
            var userDbOperation = new UserDbOperations();
            var user = new User() {Address = address, Name = name};
            var id = userDbOperation.Create(user);
            user.Id = id;
            Assert.That(id > 0);

            using (var conn = new SqlConnection(UserDbOperations.ConnectionString))
            {
                var createdUser = conn.Query<User>($"SELECT * FROM Users WHERE Id={id}").FirstOrDefault();

                Assert.IsNotNull(createdUser);

                Assert.AreEqual(user.Name, createdUser.Name);
                Assert.AreEqual(user.Address, createdUser.Address);
                Assert.That(createdUser.Id > 0);

                conn.Execute($"DELETE FROM Users WHERE Id={id}");
            }
        }

        [TestCase("abcdefghijklmnopqrstuvwxyz1234567890qwertyuiop12345",
            "abcdefghijklmnopqrstuvwxyz1234567890qwertyuiop12345")]
        [TestCase("abcdefghijklmnopqrstuvwxyz1234567890qwertyuiop12345", "hi")]
        [TestCase("hello", "abcdefghijklmnopqrstuvwxyz1234567890qwertyuiop12345")]

        public void When_Create_Is_Called_With_Parameters_Having_Exceeded_Length_Should_Throw_SqlException(string name,
            string address)
        {
            var userDbOperation = new UserDbOperations();
            var user = new User() {Name = name, Address = address};
            Assert.Throws<SqlException>(() => userDbOperation.Create(user));
        }

        [Test]
        public void When_Update_Is_Called_After_Inserting_Valid_Data_It_Should_Update()
        {
            var userDbOperation = new UserDbOperations();
            var user = new User() {Name = "Rakesh", Address = "Bangalore"};
            var id = userDbOperation.Create(user);

            user.Name = "Vijaya";
            user.Address = "Mumbai";
            user.Id = id;
           

            userDbOperation.Update(user);

            using (var conn = new SqlConnection(UserDbOperations.ConnectionString))
            {
                var createdUser = conn.Query<User>($"SELECT * FROM Users WHERE Id={id}").FirstOrDefault();

                Assert.AreEqual(createdUser.Name, user.Name);
                Assert.AreEqual(createdUser.Address, user.Address);
            }

        }

    }
}

