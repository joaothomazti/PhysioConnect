namespace Physio.Application.Dtos.Appointment
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string ClientId { get; set; }
        public string PhysiotherapistId { get; set; }
    }
}
