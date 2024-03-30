using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DAL.Entity
{
    public class BetResult : BaseEntity
    {
        public int Result { get; set; } // Foreign key referencing the Bet entity
        public double WinningAmount { get; set; } = 0; // Amount won by the user if the bet is successful
        public DateTime ResultTime { get; set; } = DateTime.UtcNow; // Time when the result was determined
    }
}