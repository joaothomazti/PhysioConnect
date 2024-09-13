namespace Physio.Domain.Models
{
    public class Physiotherapist : User
    {
        public List<Appointment> Appointments { get; set; }
        public List<Video> Videos { get; set; }
    }
}
