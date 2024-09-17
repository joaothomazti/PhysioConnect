using Microsoft.EntityFrameworkCore;
using Physio.Application.Interfaces;
using Physio.Domain.Models;
using Physio.Infrastructure.Context;

namespace Physio.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Client> GetClientByIdAsync(string clientId)
        {
            return await _context.Clients.FirstOrDefaultAsync(x => x.Id == clientId);
        }

        public async Task<Physiotherapist> GetPhysioByIdAsync(string physiotherapistId)
        {
            return await _context.Physiotherapists.FirstOrDefaultAsync(p => p.Id == physiotherapistId);
        }
    }
}
