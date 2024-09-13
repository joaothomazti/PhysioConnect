using Physio.Domain.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Physio.Application.Dtos.Account
{
    public class RegisterDto
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public UserType UserType { get; set; }
    }
}
