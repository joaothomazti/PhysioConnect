namespace Physio.Domain.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string ClientId { get; set; }
        public Client Client { get; set; }
        public string PhysiotherapistId { get; set; }
        public Physiotherapist Physiotherapist { get; set; }
        public bool IsCanceled { get; set; }
    }
}
