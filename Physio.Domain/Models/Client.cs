namespace Physio.Domain.Models
{
    public class Client : User
    {
        public List<Appointment> Appointments { get; set; }
    }
}
