using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DAL.Entity
{
    public class Bet : BaseEntity
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
        public int BetNumber { get; set; }
        public int BetResultId { get; set; }
        // public string bet_type { get; set; }
        // public decimal odds { get; set; }
    }
}