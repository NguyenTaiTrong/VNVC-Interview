using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DAL.Entity
{
    public class User : BaseEntity
    {

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; } 

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }

        public DateTime BirthDay { get; set; } =  DateTime.UtcNow;

        // Add other properties as needed

    }
}