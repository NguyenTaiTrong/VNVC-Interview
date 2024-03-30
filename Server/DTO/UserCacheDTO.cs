using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DTO
{
    public class UserCacheDTO
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Phone { get; set; }
    public DateTime BirthDay { get; set; }
}
}