using System.Numerics;
using System.Text;
using System.Text.Json;
using Client.DTO;
using Client.Models;
using Client.Request;
using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;

namespace Client.Services
{
    internal class UserService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };

        internal UserService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7266/");
        }

        public async Task<Client.Models.User?> getUserByPhone(string phoneNumber)
        {
            var jsonContent = $"{{\"phoneNumber\": \"{phoneNumber}\"}}";
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync("User/getById", content);
            string responseData = await response.Content.ReadAsStringAsync();
            Client.Models.User user = JsonConvert.DeserializeObject<Client.Models.User>(responseData);
            return user;
        }

        public async Task<int> saveUser(CreateUserRequest createUserRequest) {
            var jsonContent = JsonConvert.SerializeObject(createUserRequest);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync("User", content);
            string responseData = await response.Content.ReadAsStringAsync();
            int user = JsonConvert.DeserializeObject<int>(responseData);
            return user;
        }
        public async Task<List<UserCacheDTO>> getAll()
        {
            HttpResponseMessage response = await _client.GetAsync("User");
            string responseData = await response.Content.ReadAsStringAsync();
            List<UserCacheDTO> userDTOs = JsonConvert.DeserializeObject<List<UserCacheDTO>>(responseData);
            return userDTOs;
        }

        public async Task<UserCacheDTO> getProfile()
        {
            HttpResponseMessage response = await _client.GetAsync("User/profile");
            string responseData = await response.Content.ReadAsStringAsync();
            UserCacheDTO userDTO = JsonConvert.DeserializeObject<UserCacheDTO>(responseData);
            return userDTO;
        }
    }
}
