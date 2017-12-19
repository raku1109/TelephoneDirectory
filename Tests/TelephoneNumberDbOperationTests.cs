using System.Linq;
using Dapper;
using NUnit.Framework;
using TelephoneDirectory.SqlRespository;
using TelephoneDirectory.Entities;
using System.Data.SqlClient;

namespace Tests
{
    [TestFixture]
    public class TelephoneNumberDbOperationTests
    {
        [Test]
        public void When_Create_Is_Called_With_Valid_Data_It_Should_Save()
        {
            var telephoneDbOperation = new TelephoneNumberDbOperations();
            var telephone = new TelephoneNumber() {UId = 1,PhoneNumber = "+91 895678268",NumberType = "Office"};
            telephoneDbOperation.Create(telephone);

            using (var conn = new SqlConnection(TelephoneNumberDbOperations.ConnectionString))
            {
                var createdNumber = conn.Query<TelephoneNumber>("SELECT * FROM TelephoneNumbers WHERE UId = '1'").FirstOrDefault();

                Assert.IsNotNull(createdNumber);
                Assert.AreEqual(telephone.UId, createdNumber.UId);
                Assert.AreEqual(telephone.PhoneNumber, createdNumber.PhoneNumber);
                Assert.AreEqual(telephone.NumberType, createdNumber.NumberType);

            }
        }
    }
}
