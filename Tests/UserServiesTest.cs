using System;
using System.Collections.Generic;
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
    }
}
