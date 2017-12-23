using System.Collections.Generic;
using TelephoneDirectory.Entities;
using TelephoneDirectory.SqlRespository;

namespace UserServices
{
    internal class TelephoneNumberServices
    {
        public bool Create(TelephoneNumber telephone)
        {
            var numberServices = new TelephoneNumberDbOperations();

            if (IsValid(telephone))
            {
                var pid = numberServices.Create(telephone);
                telephone.PId = pid;
                return true;
            }
            
            return false;
        }

        private bool IsValid(TelephoneNumber telephone)
        {
            if (telephone.PhoneNumber == null || telephone.NumberType == null || telephone.UId == 0)
                return false;
            if (telephone.PhoneNumber.Length > 50 || telephone.NumberType.Length > 50)
                return false;
            return true;
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
            var number = numberServices.GetAll();
            return number;
        }
    }
}