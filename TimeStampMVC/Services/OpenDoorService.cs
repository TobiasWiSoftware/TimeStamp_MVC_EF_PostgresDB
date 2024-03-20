using Microsoft.EntityFrameworkCore;
using TimeStampLibary.Models;
using TimeStampMVC.Repository;
using System;
using System.Threading.Tasks;
using TimeStampMVC.Data;
using System.Net;
namespace TimeStampMVC.Services
{


    public class OpenDoorService : IOpenDoorService
    {
        private readonly IOpenDoorRepository _openDoorRepository;
        private readonly ICardRepository _cardRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IStampRepository _stampRepository;

        public OpenDoorService(IOpenDoorRepository openDoorRepository, ICardRepository cardRepository, IEmployeeRepository employeerepository, IStampRepository stampRepository)
        {
            _openDoorRepository = openDoorRepository;
            _cardRepository = cardRepository;
            _employeeRepository = employeerepository;
            _stampRepository = stampRepository;
        }

        public async Task<OpenDoorResponseDto> OpenDoorAsync(OpenDoorRequestDto request)
        {
            OpenDoorResponseDto response = new OpenDoorResponseDto() { Status = false};

            try
            {

                if (request.BadgeId != null)
                {
                    // Query to get the owner of the employee card
                    CardModel? assignedBadge = _cardRepository.GetCard(request.BadgeId);

                    if (assignedBadge == null || assignedBadge.IsActive == false)
                    {
                        response.Status = false;
                        response.Datetime = DateTime.Now;
                    }
                    else
                    {
                        if (assignedBadge.Employee == null)
                        {
                            response.Status = false;
                            response.Datetime = DateTime.Now;
                        }
                        else // If card and employee are valid
                        {
                            await _stampRepository.AddStampAsync(new StampModel
                            {

                                Card = assignedBadge,
                                TimeStamp = DateTime.UtcNow,
                                StampType = StampType.DoorStamp
                            });

                            response = new OpenDoorResponseDto
                            {
                                Status = true,
                                EmployeeGivenName = assignedBadge.Employee.GivenName,
                                EmployeeSurname = assignedBadge.Employee.Surname,
                                Datetime = DateTime.UtcNow
                            };
                        }
                    }



                }

                // Call another API to open the door
                var doorResult = await _openDoorRepository.OpenDoorApiCallAsync();

                if (!doorResult)
                {
                    response.Status = false;
                }

            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error in OpenDoorService: {ex.Message}");
            }

            return response;
        }
    }

}
