using TimeStampLibary.Models;

namespace TimeStampMVC.Repository
{
    public interface IStamperRepository
    {
        StamperModel? GetStamper(int id);
        IEnumerable<StamperModel> GetAllStampers();
        StamperModel AddStamper(StamperModel stamper);
        StamperModel UpdateStamper(StamperModel stamper);
        StamperModel? DeleteStamper(int id);
    }
}
