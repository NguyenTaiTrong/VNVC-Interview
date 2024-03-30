using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Bet : BaseModel
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
        public int BetNumber { get; set; }
    }
}