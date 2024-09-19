using Microsoft.EntityFrameworkCore;
using Physio.Application.Interfaces;
using Physio.Domain.Models;
using Physio.Infrastructure.Context;

namespace Physio.Infrastructure.Repository
{
    public class AppointmentRepository : IAppointment
    {
        private readonly ApplicationDbContext _context;
        public AppointmentRepository(ApplicationDbContext applicationDb) 
        {
            _context = applicationDb;
        }
        public async Task<Appointment> CreateAsync(Appointment appointmentModel)
        {
            await _context.AddAsync(appointmentModel);
            await _context.SaveChangesAsync();
            return appointmentModel;
           
        }

        public async Task<Appointment?> GetAppointmentById(int id)
        {
            return await _context.Appointments.FindAsync(id);
        }

        public async Task<List<Appointment>> GetAppointmentsByClientIdAsync(string clientId)
        {
            return await _context.Appointments
                .Where(a => a.ClientId == clientId)
                .ToListAsync();
        }
       
        public async Task<List<Appointment>> GetAppointmentsByPhysiotherapistIdAsync(string physiotherapistId)
        {
            return await _context.Appointments
                .Where(a => a.PhysiotherapistId == physiotherapistId && !a.IsCanceled)
                .ToListAsync();
        }
    }
}
