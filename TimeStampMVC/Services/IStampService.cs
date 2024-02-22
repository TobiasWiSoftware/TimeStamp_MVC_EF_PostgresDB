using TimeStampLibary.Models;

namespace TimeStampMVC.Services
{
    public interface IStampService
    {
        Task<StampResponseDto> AddStampAsync(StampRequestDto stampRequest);

    }
}
