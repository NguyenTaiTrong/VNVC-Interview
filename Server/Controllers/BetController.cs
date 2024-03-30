using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.DAL.Entity;
using Server.DTO;
using Server.Request.Bet;
using Server.Services;

namespace Server.Controllers
{
    [Route("[controller]")]
    public class BetController : Controller
    {
        private readonly ILogger<BetController> _logger;
        IBetService _betService;

        public BetController(ILogger<BetController> logger, IBetService betService)
        {
            _betService = betService;
            _logger = logger;
        }

        [HttpPost]
        public int save([FromBody] CreateBetRequest createBetRequest)
        {
            return _betService.saveBet(createBetRequest);
        }

        [HttpGet]
        public List<EventWithBetAndUser> get()
        {
            return _betService.get();
        }
    }
}