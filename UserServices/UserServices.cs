using System.Collections.Generic;
using TelephoneDirectory.Entities;
using TelephoneDirectory.SqlRespository;

namespace TelephoneDirectory.Services
{
    public class UserServices
    {
        private readonly IUserDbOperations _repo;

        public UserServices(IUserDbOperations repo)
        {
            _repo = repo;
        }


        public bool Create(User user)
        {
            if (IsValid(user))
            {
                var id = _repo.Create(user);
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


        public bool Update(User user)
        {
            if (IsValidUpdate(user))
            {
                _repo.Update(user);
                return true;
            }
            
            return false;
        }

        private bool IsValidUpdate(User user)
        {
            if (user.Id == 0)
                return false;
            if (user.Name == null || user.Address == null)
                return false;
            if (user.Name.Length > 50 || user.Address.Length > 50)
                return false;
            return true;
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
    }
}