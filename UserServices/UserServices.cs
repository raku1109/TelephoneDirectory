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
            int id = userServices.Create(user);

            user.Id = id;

            return true;

        }

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
            List<User> list = userServices.GetAll();
            return list;
        }
    } 
}
