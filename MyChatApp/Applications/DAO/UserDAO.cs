using MyChatApp.Applications.Repository;
using MyChatApp.Database;
using MyChatApp.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyChatApp.Applications.DAO
{
    public class UserDAO : IUserDAO
    {
        private readonly AppDbContext context;
        public UserDAO(AppDbContext _context)
        {
            context = _context;
        }
        public bool Insert(User model)
        {
            this.context.Users.Add(model);
           return this.context.SaveChanges() >0;
        }
        public User GetUserByUserName(string username)
        {
            var result = this.context.Users.FirstOrDefault(item => item.Username == username);
            return result;
        }

        public int Login(string username,string password)
        {
            var result = this.context.Users.FirstOrDefault(item => item.Username == username);
            if(result != null)
            {
                if(result.StatusAction != Database.Enum.StatusAction.Lock)
                {
                    if(result.Password == password)
                    {
                        return 2;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    return 0;
                }
            }
            return 3;
        }

        public bool CheckUsername(string username)
        {
            var result = this.context.Users.Count(item => item.Username == username);
            if (result == 0)
            {
                return true;
            }
            return false;
        }

        public bool CheckTel(string tel)
        {
            var result = this.context.Users.Count(item => item.Tel == tel);
            if (result == 0)
            {
                return true;
            }
            return false;
        }
    }
}
