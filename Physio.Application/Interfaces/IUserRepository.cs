using Physio.Domain.Models;

namespace Physio.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<Client> GetClientByIdAsync(string clientId);
        Task<Physiotherapist> GetPhysioByIdAsync(string physiotherapistId);
    }
}
