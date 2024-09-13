using Physio.Domain.Models;

namespace Physio.Application.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
