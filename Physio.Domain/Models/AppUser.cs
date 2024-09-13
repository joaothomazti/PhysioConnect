using Microsoft.AspNetCore.Identity;
using Physio.Domain.Models.Enum;

namespace Physio.Domain.Models
{
    public class User : IdentityUser
    {
        public UserType UserType { get; set; }
    }
}
