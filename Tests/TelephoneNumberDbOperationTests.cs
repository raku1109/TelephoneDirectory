using System.Linq;
using Dapper;
using NUnit.Framework;
using TelephoneDirectory.SqlRespository;
using TelephoneDirectory.Entities;
using System.Data.SqlClient;
using System.IO.Pipes;

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

        [TestCase(null,null,null)]
        [TestCase(1,null,null)]
        [TestCase(null,"+91 9820275604",null)]
        [TestCase(null,null,"Work")]

        public void When_Create_Is_Called_With_Invalid_Data_It_Should_Throw_A_SqlException(int uid, string number, string type)
        {
            var telephoneDbOperation = new TelephoneNumberDbOperations();
            var telephone = new TelephoneNumber() {UId= uid,PhoneNumber = number,NumberType = type};
            Assert.Throws<SqlException>(() => telephoneDbOperation.Create(telephone));

        }

        [TestCase(1, "123456789012345678901234567890123456789012345678901","Home")]
        [TestCase(2,"+91 8082427435", "abcdefghijklmnopqrstuvwxyz1234567890qwertyuiop12345")]

        public void When_Create_Is_Called_With_Data_Of_Exceeded_Length_It_Should_Throw_A_SqlException(int uid, string number, string type)
        {
            var telephoneDbOperation = new TelephoneNumberDbOperations();
            var telephone = new TelephoneNumber() { UId = uid, PhoneNumber = number, NumberType = type };
            Assert.Throws<SqlException>(() => telephoneDbOperation.Create(telephone));
        }

        [Test]

        public void When_Update_Is_Called_After_Inserting_Valid_Data_It_Should_Update()
        {
            var telephoneDbOperation = new TelephoneNumberDbOperations();
            var telephone = new TelephoneNumber() {UId = 2,PhoneNumber = "+91 9930774145",NumberType = "Work"};
            var pid = telephoneDbOperation.Create(telephone);

            telephone.UId = 3;
            telephone.PhoneNumber = "+91 9820175604";
            telephone.NumberType = "Home";

            telephone.PId = pid;

            telephoneDbOperation.Update(telephone);

            using (var con = new SqlConnection(TelephoneNumberDbOperations.ConnectionString))
            {
                var createdNumber = con.Query<TelephoneNumber>($"SELECT * FROM TelephoneNumbers WHERE PId = {pid}")
                    .FirstOrDefault();
                   

                Assert.AreEqual(createdNumber.PhoneNumber,telephone.PhoneNumber);
                Assert.AreEqual(createdNumber.NumberType,telephone.NumberType);
            }





        }
    }
}
