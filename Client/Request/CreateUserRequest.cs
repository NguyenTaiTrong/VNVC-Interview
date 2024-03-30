using System.ComponentModel.DataAnnotations;

namespace Client.Request
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