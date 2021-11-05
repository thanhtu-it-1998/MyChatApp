using MyChatApp.Database.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyChatApp.Database.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public StatusAction StatusAction { get; set; }
        public DateTime DOB { get; set; } 
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
        public ICollection<ChatUser> ChatUsers { get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<Friend> Friends { get; set; }

    }
}
