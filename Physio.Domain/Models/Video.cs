namespace Physio.Domain.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string PhysiotherapistId { get; set; }
        public Physiotherapist Physiotherapist { get; set; }
    }
}
