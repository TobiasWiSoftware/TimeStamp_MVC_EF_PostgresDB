using Microsoft.AspNetCore.Mvc;
using TimeStampMVC.Services;
using TimeStampLibary.Models;


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

        [HttpPost("new")]
        public async Task<IActionResult> OpenDoor([FromBody] OpenDoorRequestDto openDoorRe)
        {
            try
            {
                var res = new OpenDoorResponseDto();
                res.Status = false;

                if (_openDoorService != null)
                {
                    res = await _openDoorService.OpenDoorAsync(openDoorRe);
                }

                if (res.Status)
                {
                    return Ok(res);
                }
                else
                {
                    return BadRequest(res);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Api error {ex.Message}");
            }
        }   

    }
}
