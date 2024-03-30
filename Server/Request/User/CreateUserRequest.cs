using System.ComponentModel.DataAnnotations;

namespace Server.Request.User
{
    public class CreateUserRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public DateTime BirthDay { get; set; }
    }
}