using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.DTO;
using Client.Models;
using Client.Request;
using Newtonsoft.Json;

namespace Client.Services
{
    public class BetService
    {
        private readonly HttpClient _client;

        internal BetService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7266/");
        }

        public async Task<int> saveBet(CreateBetRequest createBetRequest)
        {
            var jsonContent = JsonConvert.SerializeObject(createBetRequest);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync("Bet", content);
            string responseData = await response.Content.ReadAsStringAsync();
            int isSuccess = JsonConvert.DeserializeObject<int>(responseData);
            return isSuccess;
        }

        public async Task<List<EventWithBetAndUser>> getAllBet()
        {
            HttpResponseMessage response = await _client.GetAsync("Bet");
            string responseData = await response.Content.ReadAsStringAsync();
            List<EventWithBetAndUser> bets = JsonConvert.DeserializeObject<List<EventWithBetAndUser>>(responseData);
            return bets;
        }
    }
}