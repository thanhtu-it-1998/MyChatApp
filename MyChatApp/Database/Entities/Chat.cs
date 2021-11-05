using MyChatApp.Database.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyChatApp.Database.Entities
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ChatType Type { get; set; }
        public int NumberMember { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<ChatUser> ChatUsers { get; set; }
    }
}
