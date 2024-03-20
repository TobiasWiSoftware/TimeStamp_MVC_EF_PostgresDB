using System.Security;

namespace TimeStampLibary.Models
{
    public class StampRequestDto
    {
        public string? CardNumber { get; set; }
        public string? StampId { get; set; }
        public StampType StampType { get; set; }
    }
}