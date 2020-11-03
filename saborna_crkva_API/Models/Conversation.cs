using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace saborna_crkva_API.Models
{
    public class Conversation
    {
        public int Id { get; set; }
        [ForeignKey("UserOneId")]
        public User UserOne { get; set; }
        public int UserOneId { get; set; }
        [ForeignKey("UserTwoId")]
        public User UserTwo { get; set; }
        public int UserTwoId { get; set; }
        public bool UserOneRead { get; set; }
        public bool UserTwoRead { get; set; }

    }
}
