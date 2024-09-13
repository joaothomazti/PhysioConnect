namespace Physio.Application.Dtos.Account
{
    public class ResultDto
    {
        public bool Success { get; set; }
        public string[] Errors { get; set; }
        public object Data { get; set; }
    }
}
