using System;
using System.Collections.Generic;
using NUnit.Framework;
using TelephoneDirectory.Entities;
using TelephoneDirectory.Services;
using TelephoneDirectory.SqlRespository;

namespace Tests
{
    [TestFixture]
    internal class UserServicesTest
    {
        [TestCase(null, null)]
        [TestCase(null, "Mumbai")]
        [TestCase("Rakesh", null)]
        [TestCase("qwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopq",
            "qwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopq")]
        [TestCase("qwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopq", "Mumbai")]
        [TestCase("Rakesh", "qwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopq")]
        public void Create_User_With_Invalid_Data_Using_Validations_Should_Throw_SqlException(string name,
            string address)
        {
            var repo = new MockUserDbOperation();
            var userServices = new UserServices(repo);
            var user = new User {Name = name, Address = address};

            Assert.IsFalse(userServices.Create(user));
        }

        [TestCase(null, null)]
        [TestCase("Rocky", null)]
        [TestCase(null, "Goa")]
        [TestCase("qwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopq",
            "qwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopq")]
        [TestCase("qwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopq")]
        [TestCase("qwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopq", "Delhi")]
        public void Update_Called_Via_Services_With_Invalid_Data_Should_Fail(int id, string newName, string newAddress)
        {
            var repo = new MockUserDbOperation();
            var userServices = new UserServices(repo);
            var user = new User {Id = id, Name = newName, Address = newAddress};


            userServices.Update(user);
        }
        //Mocking


        [Test]
        public void Create_User_Via_Service_With_Valid_Data()
        {
            IUserDbOperations repo = new MockUserDbOperation();
            var userServices = new UserServices(repo);
            var user = new User {Name = "Rakesh", Address = "Mumbai"};
            userServices.Create(user);

            Assert.IsTrue(user.Id > 0);
        }

        [Test]
        public void Update_Called_Via_Service_With_Valid_Data()
        {
            var repo = new MockUserDbOperation();
            var userServices = new UserServices(repo);
            var user = new User {Id = 1, Name = "Bala", Address = "Mumbai"};

            Assert.IsTrue(userServices.Update(user));

            
        }

        [Test]

        public void Delete_Called_Via_Service_With_Valid_Data()
        {
            var repo = new MockUserDbOperation();
            var userServices = new UserServices(repo);
            var user = new User() {Id = 4};

            Assert.IsTrue(userServices.Delete(user));
        }


        [Test]

        public void Delete_Called_Via_Service_With_Invalid_Data()
        {
            var repo = new MockUserDbOperation();
            var userService = new UserServices(repo);
            var user = new User() {Id = 0};

            Assert.IsFalse(userService.Delete(user));
        }
    }

    public class MockUserDbOperation : IUserDbOperations
    {
        public int Create(User user)
        {
            return 1;
        }

        public void Update(User user)
        {
        }

        public void Delete(User user)
        {
        }

        public List<User> GetAll()
        {
            return new List<User>
            {
                new User
                {
                    Id = 1,
                    Name = "Test",
                    Address = "Test",
                    Created = DateTime.Now,
                    PhoneNumbers = new List<TelephoneNumber>
                    {
                        new TelephoneNumber
                        {
                            PId = 1,
                            NumberType = "Test",
                            PhoneNumber = "1234",
                            UId = 1
                        }
                    }
                }
            };
        }

        public User GetById(User user)
        {
            return new User
            {
                Id = 1,
                Name = "Test",
                Address = "Test",
                Created = DateTime.Now,
                PhoneNumbers = new List<TelephoneNumber>
                {
                    new TelephoneNumber
                    {
                        PId = 1,
                        NumberType = "Test",
                        PhoneNumber = "1234",
                        UId = 1
                    }
                }
            };
        }
    }
}