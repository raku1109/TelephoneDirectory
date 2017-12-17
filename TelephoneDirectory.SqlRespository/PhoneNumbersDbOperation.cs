using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneDirectory.Entities;
using Dapper;

namespace TelephoneDirectory.SqlRespository
{
    class PhoneNumbersDbOperation
    {
        public const string ConnectionString = "Data Source=BALA;Initial Catalog=TelephoneDirectory;Integrated Security=True";

        public List<PhoneNumbers> GetById(int id)
        {
            return null;

        }

        public void UpdatePhoneNumber(PhoneNumbers  int phoneNumberId)
        {

        }


    }
}
