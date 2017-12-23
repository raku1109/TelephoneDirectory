using System.Collections.Generic;
using TelephoneDirectory.SqlRespository;
using TelephoneDirectory.Entities;

namespace UserServices
{
    class TelephoneNumberServices
    {
        public bool Create(TelephoneNumber telephone)
        {
            var numberServices = new TelephoneNumberDbOperations();
            numberServices.Create(telephone);
            return false;
        }

        public void Update(TelephoneNumber telephone)
        {
            var numberServices = new TelephoneNumberDbOperations();
            numberServices.Update(telephone);
        }

        public void Delete(TelephoneNumber telephone)
        {
            var numberServices = new TelephoneNumberDbOperations();
            numberServices.Delete(telephone);
        }

        public TelephoneNumber GetById(TelephoneNumber telephone)
        {
            var numberServices = new TelephoneNumberDbOperations();
            numberServices.GetById(telephone);
            return telephone;
        }

        public List<TelephoneNumber> GetAll()
        {
            var numberServices = new TelephoneNumberDbOperations();
            List<TelephoneNumber> number = numberServices.GetAll();
            return number;
        }
    }
}
