using Physio.Domain.Models;

namespace Physio.Application.Interfaces
{
    public interface IAppointment
    {
        Task<Appointment> CreateAsync(Appointment appointmentModel);
        Task<List<Appointment>> GetAppointmentsByClientIdAsync(string clientId);
        Task<List<Appointment>> GetAppointmentsByPhysiotherapistIdAsync(string physiotherapistId);
        Task<Appointment?> GetAppointmentById(int id);

    }
}
