using Microsoft.EntityFrameworkCore;
using System.Security;
using TimeStampLibary.Models;
using TimeStampMVC.Data;
using TimeStampMVC.Repository;

namespace TimeStampMVC.Services
{
    public class StampService : IStampService
    {
        private readonly IStampRepository _stampRepository;
        private readonly IStamperRepository _stamperRepository;
        private readonly IEmployeeRepository _employeeRepository;
       

        public StampService(IStampRepository stampRepository, IEmployeeRepository erepository, IStamperRepository stamperRepository)
        {
            _stampRepository = stampRepository;
            _employeeRepository = erepository;
            _stamperRepository = stamperRepository;
        }

        // Adding a new stamp record
        public async Task<StampResponseDto> AddStampAsync(StampRequestDto stampRequest)
        {
            try
            {
                // checks if the employee exists in the database
                var assignedBadge = await _employeeRepository.GetEmployeeByCardIdAsync(stampRequest.BadgeId);

                if (assignedBadge == null)
                {
                    return new StampResponseDto { Status = false, Employeename = null, Datetime = null };
                }

                // Simulate stamper lookup based on stampId
                var stamperVar = await _stampRepository.GetStampAsync(stampRequest.StampId);
                StamperModel stamper = stamperVar.Stamper;


                if (stamper == null)
                {
                    return new StampResponseDto { Status = false, Employeename = null, Datetime = null };
                }

                // Check if the last stamp for the employee is "IN"
                var lastStamp = await _stampRepository.GetLastStamp(assignedBadge.Id);

                var newStatus = (lastStamp != null && lastStamp.Status == "IN") ? "OUT" : "IN";

                // Insert a new stamp record using the repository
                var newStamp = new StampModel
                {
                    BadgeId =  stampRequest.BadgeId,
                    TimeStamp = DateTime.UtcNow,    
                    Stamper = stamper,
                    Status = newStatus
                };

                await _stampRepository.AddStampAsync(newStamp);

                // Return the result
                var result = new StampResponseDto
                {
                    Status = true,
                    Employeename = $"{assignedBadge.GivenName} {assignedBadge.Surname}",
                    Datetime = newStamp.TimeStamp
                };

                return result;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error in StampService: {ex.Message}");
                throw;
            }

            throw new NotImplementedException();
        }
    }
}
