using System.ComponentModel.DataAnnotations;

namespace Physio.Application.Dtos.Appointment
{
    public class CreateAppointmentDto
    {
        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public string PhysiotherapistId { get; set; }
    }
}
