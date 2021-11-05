using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyChatApp.Database.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
