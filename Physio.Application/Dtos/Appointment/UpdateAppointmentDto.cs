namespace Physio.Application.Dtos.Appointment
{
    public class UpdateAppointmentDto
    {
        public DateTime DateTime { get; set; }
        public bool IsCanceled { get; set; }
    }
}
