using Physio.Application.Dtos.Appointment;
using Physio.Domain.Models;

namespace Physio.Application.Mappers
{
    public static class AppointmentMapper
    {
        public static AppointmentDto ToAppointmentDto(this Appointment appointment)
        {
            return new AppointmentDto
            {
                Id = appointment.Id,
                DateTime = appointment.DateTime,
                ClientId = appointment.ClientId,
                PhysiotherapistId = appointment.PhysiotherapistId,
            };
        }

        public static Appointment ToAppointmentFromCreateDto(this CreateAppointmentDto appointmentDto, string clientId, string physiotherapistId)
        {
            return new Appointment
            {
                DateTime = appointmentDto.DateTime,
                ClientId = clientId,
                PhysiotherapistId = physiotherapistId
            };
        }

        public static Appointment ToAppointmentFromUpdateDto(this UpdateAppointmentDto appointmentDto)
        {
            return new Appointment
            {
                DateTime = appointmentDto.DateTime,
                IsCanceled = appointmentDto.IsCanceled,
            };
        }
    }
}
