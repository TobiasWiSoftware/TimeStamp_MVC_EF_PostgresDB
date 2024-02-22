using System.Security;

namespace TimeStampLibary.Models
{
    public class StampModel
    {
        public int Id { get; set; }
        public string BadgeId { get; set; }
        public DateTime TimeStamp { get; set; }
        public StamperModel Stamper { get; set; }
        public string Status { get; set; }
    }

}
