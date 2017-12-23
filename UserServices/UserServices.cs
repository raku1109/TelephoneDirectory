using System.Collections.Generic;
using TelephoneDirectory.Entities;
using TelephoneDirectory.SqlRespository;

namespace UserServices
{
    public class UserServices
    {
        public bool Create(User user)
        {
            var userServices = new UserDbOperations();
            
            if (IsValid(user))
            {
                var id = userServices.Create(user);
                user.Id = id;
                return true;
            }
            return false;
        }


        private bool IsValid(User user)
        {
            if (user.Name == null || user.Address == null)
                return false;
            if (user.Name.Length > 50 || user.Address.Length > 50)
                return false;
            return true;
        }

        #region NotRequiredNow

        public void Update(User user)
        {
            var userServices = new UserDbOperations();
            userServices.Update(user);
        }

        public void Delete(User user)
        {
            var userServices = new UserDbOperations();
            userServices.Delete(user);
        }

        public User GetById(User user)
        {
            var userServices = new UserDbOperations();
            userServices.GetById(user);
            return user;
        }

        public List<User> GetAll()
        {
            var userServices = new UserDbOperations();
            var list = userServices.GetAll();
            return list;
        }

        #endregion
    }
}