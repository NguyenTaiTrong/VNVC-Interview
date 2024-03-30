using Microsoft.AspNetCore.Mvc;
using Server.DAL.Entity;
using Server.DTO;
using Server.Request.User;
using Server.Services;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("getById")]
        public User Get([FromBody] ProfileRequest profileRequest)
        {
            // Need set update model response
            return _userService.getUserByPhone(profileRequest.PhoneNumber);
        }

        [HttpGet]
        [Route("profile")]
        public UserCacheDTO GetProfile()
        {
            // Need set update model response
            return _userService.getProfile();
        }

        [HttpGet]
        public List<User> getAll()
        {
            // Need set update model response
            return _userService.getAll();
        }

        [HttpPost]
        public int Save([FromBody] CreateUserRequest createUserRequest)
        {
            return _userService.createUser(createUserRequest);
        }
    }
}
