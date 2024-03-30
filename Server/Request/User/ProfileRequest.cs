using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Request.User
{
    public class ProfileRequest
    {
        [Required]
        public string PhoneNumber { get; set; }
    }
}