using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Server.DAL.Entity;
using Server.DTO;
using Server.Repositories;
using Server.Request.User;

namespace Server.Services
{
    public interface IUserService
    {
        public int createUser(CreateUserRequest createUserRequest);
        public User getUserByPhone(string phoneNumber);
        public UserCacheDTO getProfile();
        public List<User> getAll();
    }
    public class UserService : IUserService
    {
        readonly IUserRepository _userRepository;
        private readonly IDistributedCache _distributedCache;
        private readonly DistributedCacheEntryOptions cacheOpts = new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(45) };
        public UserService(IUserRepository userRepository, IDistributedCache distributedCache)
        {
            _userRepository = userRepository;
            _distributedCache = distributedCache;
        }
        public User getUserByPhone(string phoneNumber)
        {
            var user = _userRepository.GetOneByPhone(phoneNumber).FirstOrDefault();
            // can use auto mapper
            if (user != null)
            {
                UserCacheDTO userDTO = new UserCacheDTO();
                userDTO.Id = user.Id;
                userDTO.Phone = user.Phone;
                userDTO.UserName = user.UserName;
                userDTO.BirthDay = user.BirthDay;
                this._distributedCache.SetString("user_info_cache", JsonSerializer.Serialize<UserCacheDTO>(userDTO), cacheOpts);
            }
            return user;
        }


        public UserCacheDTO getProfile()
        {
            string userDTOString = _distributedCache.GetString("user_info_cache");
            UserCacheDTO userData = JsonSerializer.Deserialize<UserCacheDTO>(userDTOString);
            return userData;
        }

        public List<User> getAll()
        {
            return _userRepository.GetAll();
        }

        public int createUser(CreateUserRequest createUserRequest)
        {
            User newUser = new User();
            newUser.UserName = createUserRequest.UserName;
            newUser.Phone = createUserRequest.Phone;
            newUser.BirthDay = createUserRequest.BirthDay;
            return _userRepository.Save(newUser);
        }
    }
}