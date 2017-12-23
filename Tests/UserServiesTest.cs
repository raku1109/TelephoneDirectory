using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TelephoneDirectory.SqlRespository;
using TelephoneDirectory.Entities;


namespace Tests
{
    [TestFixture]
    class UserServiesTest
    {
        [Test]
        public void Create_User_Via_Service()
        {
            var userServices = new UserServices.UserServices();
            var user = new User() {Name = "Rakesh",Address = "Mumbai"};
            userServices.Create(user);

            

            Assert.IsTrue(user.Id >0);
            Assert.Pass();

        }

        [TestCase(null,null)]
        [TestCase(null,"Mumbai")]
        [TestCase("Rakesh",null)]
        [TestCase("qwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopq", "qwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopq")]
        [TestCase("qwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopq","Mumbai")]
        [TestCase("Rakesh", "qwertyuiopqwertyuiopqwertyuiopqwertyuiopqwertyuiopq")]

        public void Create_User_With_Invalid_Data_Using_Validations_Should_Throw_SqlException(string name, string address)
        {
            var userServices = new UserServices.UserServices();
            var user = new User() {Name = name, Address = address};

            Assert.IsFalse(userServices.Create(user));
        }
    }
}
