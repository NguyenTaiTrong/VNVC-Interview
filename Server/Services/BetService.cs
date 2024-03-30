using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.DAL.Entity;
using Server.DTO;
using Server.Repositories;
using Server.Request.Bet;

namespace Server.Services
{
    public interface IBetService
    {
        int saveBet(CreateBetRequest createBetRequest);
        List<EventWithBetAndUser> get();
    }

    public class BetService : IBetService
    {
        readonly IBetRepository _betRepository;
        public BetService(IBetRepository betRepository)
        {
            _betRepository = betRepository;
        }
        public int saveBet(CreateBetRequest createBetRequest)
        {
            Bet bet = new Bet();
            bet.UserId = createBetRequest.UserId;
            bet.BetNumber = createBetRequest.BetNumber;
            bet.EventId = createBetRequest.EventId;
            bet.BetResultId = createBetRequest.BetResultId;
            return _betRepository.save(bet);
        }

        public List<EventWithBetAndUser> get()
        {
            return _betRepository.get();
        }
    }
}