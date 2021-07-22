using System.ComponentModel.DataAnnotations;

namespace OnlineTestSystem.Api.Models.Dto
{
    public record UserLoginModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; init; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; init; }
    }
}
