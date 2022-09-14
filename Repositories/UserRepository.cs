using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.EntityFrameworkCore;
using ModernUI.Models;

namespace ModernUI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationContext context;

        public UserRepository()
        {
            context = new ApplicationContext();
            context.Database.EnsureCreated();
            context.Users.Load();
        }
        
        public bool AuthenticateUser(NetworkCredential credential)
        {
            string username = credential.UserName;
            string password = credential.Password;

            return context.Users.Any(u => u.Username == username && u.Password == password);
        }

        public void Add(UserModel userModel)
        {
            context.Users.Add(userModel);
            context.SaveChanges();
        }

        public void Edit(UserModel userModel)
        {
            context.Users.Update(userModel);
            context.SaveChanges();
        }

        public void Remove(int id)
        {
            UserModel? user = GetById(id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        public UserModel? GetById(int id)
        {
            return context.Users.Find(id);
        }

        public IEnumerable<UserModel> GetByAll()
        {
            return context.Users;
        }
    }
}