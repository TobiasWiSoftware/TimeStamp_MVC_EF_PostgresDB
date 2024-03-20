using System.Security;

namespace TimeStampLibary.Models
{
    public enum StampType
    {
        TimeStamp = 0,
        DoorStamp = 1
    }

    public enum Status
    {
        In = 0,
        Out = 1
    }
    public class StampModel
    {
        public int Id { get; set; }
        public CardModel? Card { get; set; }
        public DateTime TimeStamp { get; set; }
        public StampType StampType { get; set; }
        public Status? Status { get; set; }
    }

}
