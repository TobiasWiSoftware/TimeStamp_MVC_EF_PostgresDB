using Microsoft.AspNetCore.Mvc;
using TimeStampLibary.Models;
using TimeStampMVC.Services;

namespace TimeStampMVC.Controllers
{
    [ApiController]
    [Route("stamp")]
    public class StampController : Controller
    {
        private readonly IStampService? _stampService;
        public StampController(IStampService stampService)
        {
            _stampService = stampService;
        }

        // Adding a new 
        [HttpPost("new")]
        public async Task<IActionResult> AddStamp([FromBody] StampRequestDto stampRe)
        {
            try
            {
                var res = new StampResponseDto();
                res.Status = false;

                if (_stampService != null)
                {
                    res = await _stampService.AddStampAsync(stampRe);
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
