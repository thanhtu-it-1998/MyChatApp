using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyChatApp.Database.Entities
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public int ChatId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }
        public Chat Chat { get; set; }
    }
}
