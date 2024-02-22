using Microsoft.AspNetCore.Mvc;
using TimeStampMVC.Services;


namespace TimeStampMVC.Controllers
{
    [ApiController]
    [Route("door")]
    public class OpenDoorController : ControllerBase
    {
        private readonly IOpenDoorService? _openDoorService;
        public OpenDoorController(IOpenDoorService? openDoorService)
        {
            _openDoorService = openDoorService;
        }

    }
}
