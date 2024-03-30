using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models
{
    public class User : BaseModel
    {
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string BirthDay { get; set; }
    }
}