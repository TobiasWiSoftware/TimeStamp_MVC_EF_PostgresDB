using TimeStampLibary.Models;

namespace TimeStampMVC.Repository
{

    public interface IStampRepository
    {
        Task AddStampAsync(StampModel stamp);
        Task<StampModel?> GetStampAsync(string id);
        Task<StampModel?> GetLastStamp(CardModel card);
    }
}
