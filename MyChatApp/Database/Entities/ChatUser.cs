using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyChatApp.Database.Entities
{
    public class ChatUser
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int ChatId { get; set; }
        [ForeignKey("UserId")]
        public Chat Chat { get; set; }
    }
}
