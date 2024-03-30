using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Request
{
    public class CreateBetRequest
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
        public int BetNumber { get; set; }
        public int BetResultId { get; set; }
    }
}