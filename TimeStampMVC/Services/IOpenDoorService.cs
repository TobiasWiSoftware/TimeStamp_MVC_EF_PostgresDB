using TimeStampLibary.Models;

namespace TimeStampMVC.Services
{
    public interface IOpenDoorService
    {
        Task<OpenDoorResponseDto> OpenDoorAsync(OpenDoorRequestDto request);

    }
}
