using MyRESTServices.Data.Interfaces;
using MyRESTServices.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRESTServices.Data
{
        public class UserData : IUserData
        {
            public Task<Task> ChangePassword(string username, string newPassword)
            {
                
            }

            public Task<bool> Delete(int id)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<User>> GetAll()
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<User>> GetAllWithRoles()
            {
                throw new NotImplementedException();
            }

            public Task<User> GetById(int id)
            {
                throw new NotImplementedException();
            }

            public Task<User> GetByUsername(string username)
            {
                throw new NotImplementedException();
            }

            public Task<User> GetUserWithRoles(string username)
            {
                throw new NotImplementedException();
            }

            public Task<User> Insert(User entity)
            {
                throw new NotImplementedException();
            }

            public Task<User> Login(string username, string password)
            {
                throw new NotImplementedException();
            }

            public Task<User> Update(int id, User entity)
            {
                throw new NotImplementedException();
            }
        }
    }


