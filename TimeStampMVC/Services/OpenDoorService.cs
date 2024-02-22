using Microsoft.EntityFrameworkCore;
using TimeStampLibary.Models;
using TimeStampMVC.Repository;
using System;
using System.Threading.Tasks;
using TimeStampMVC.Data;
namespace TimeStampMVC.Services
{


    public class OpenDoorService : IOpenDoorService
    {
        private readonly IOpenDoorRepository _openDoorRepository;
        private readonly ApplicationDbContext _context;

        public OpenDoorService(IOpenDoorRepository openDoorRepository, ApplicationDbContext context)
        {
            _openDoorRepository = openDoorRepository;
            _context = context;
        }

        public async Task<OpenDoorResponseDto> OpenDoorAsync(OpenDoorRequestDto request)
        {
            try
            {
                

                // Query to get the owner of the employee card
                var assignedBadge = await _context.Employee
                    .FirstOrDefaultAsync(b => b.CardNumber == request.BadgeId);

                if (assignedBadge == null)
                {
                    return new OpenDoorResponseDto { Status = false, Employeename = null, Datetime = null };
                }

                // Simulate stamper lookup based on stampId
                var stamper = await _context.Stamper
                    .FirstOrDefaultAsync(s => s.StamperId == request.StampId);

                if (stamper == null)
                {
                    return new OpenDoorResponseDto { Status = false, Employeename = null, Datetime = null };
                }

                // Call another API to open the door
                var doorResult = await _openDoorRepository.OpenDoorApiCallAsync();

                if (!doorResult)
                {
                    return new OpenDoorResponseDto { Status = false, Employeename = null, Datetime = null };
                }

                // Return the result
                var result = new OpenDoorResponseDto
                {
                    Status = true,
                    Employeename = $"{assignedBadge.GivenName} {assignedBadge.Surname}",
                    Datetime = DateTime.UtcNow
                };

                return result;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error in OpenDoorService: {ex.Message}");
                throw;
            }
        }
    }

}
