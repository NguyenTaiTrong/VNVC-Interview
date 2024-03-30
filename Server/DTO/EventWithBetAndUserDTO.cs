using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DTO
{
    public class EventWithBetAndUser
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime EventStartTime { get; set; }
        public DateTime EventEndTime { get; set; }
        public int BetId { get; set; }
        public int UserId { get; set; }
        public int BetNumber { get; set; }
        public DateTime BetCreatedAt { get; set; }
        public DateTime UserCreatedAt { get; set; }
        public int? UserCreatedBy { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public DateTime UserBirthDay { get; set; }
        public int? Result { get; set; }
    }
}