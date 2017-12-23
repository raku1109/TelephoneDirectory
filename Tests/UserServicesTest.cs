using NUnit.Framework;
using TelephoneDirectory.Entities;


namespace Tests
{
    [TestFixture]
    class UserServicesTest
    {
        [Test]
        public void Create_User_Via_Service()
        {
            var userServices = new TelephoneDirectory.Services.UserServices();
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
            var userServices = new TelephoneDirectory.Services.UserServices();
            var user = new User() {Name = name, Address = address};

            Assert.IsFalse(userServices.Create(user));
    
        }

        [Test]
        public void Update_Called_Via_Service_With_Valid_Data()
        {
            var userServices = new TelephoneDirectory.Services.UserServices();
            var user = new User() {Name = "Bala",Address = "Mumbai"};

            var id = userServices.Create(user);
            user.Name = "Harish";
            user.Address = "Goa";

            userServices.Update(user);
        }
    }
}
