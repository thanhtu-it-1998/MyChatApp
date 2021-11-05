using MyChatApp.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyChatApp.Applications.Repository
{
    public interface IUserDAO
    {
        public bool Insert(User model);
        public User GetUserByUserName(string username);
        public bool CheckUsername(string username);
        public bool CheckTel(string tel);
        public int Login(string username, string password);
    }
}
