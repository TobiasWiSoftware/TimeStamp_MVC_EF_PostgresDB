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
        private readonly ICardRepository _cardRepository;
        private readonly IEmployeeRepository _employeeRepository;


        public StampService(IStampRepository stampRepository, IEmployeeRepository erepository, ICardRepository stamperRepository)
        {
            _stampRepository = stampRepository;
            _employeeRepository = erepository;
            _cardRepository = stamperRepository;
        }

        // Adding a new stamp record
        public async Task<StampResponseDto> AddStampAsync(StampRequestDto stampRequest)
        {
            try
            {
                string? cardNumber = stampRequest.CardNumber;

                // Get card object

                if (cardNumber != null)
                {
                    CardModel? card = _cardRepository.GetCard(cardNumber);

                    if (card != null)
                    {
                        EmployeeModel? em = await _employeeRepository.GetEmployeeAsync(card.Id);

                        // checks if the employee exists in the database

                        if (em != null)
                        {
                            // Check if the last stamp for the employee is "IN"
                            StampModel? lastStamp = await _stampRepository.GetLastStamp(card);

                            if (lastStamp != null)
                            {
                                Status? newstatus = null;
                                StampType newStampType;


                                if (lastStamp.StampType == StampType.TimeStamp && lastStamp.Status == Status.In)
                                {
                                    // If the last stamp is "IN", the new stamp should be "OUT"
                                    newstatus = Status.Out;
                                    newStampType = StampType.TimeStamp;
                                }
                                else if (lastStamp.StampType == StampType.TimeStamp)
                                {
                                    // If the last stamp is "OUT", the new stamp should be "IN"
                                    newstatus = Status.In;
                                    newStampType = StampType.TimeStamp;
                                }
                                else
                                {
                                    newStampType = StampType.DoorStamp;
                                }

                                // Insert a new stamp record using the repository
                                var newStamp = new StampModel
                                {
                                    TimeStamp = DateTime.UtcNow,
                                    Card = card,
                                    StampType = newStampType,
                                    Status = newstatus
                                };

                                await _stampRepository.AddStampAsync(newStamp);

                                // Return the result
                                var result = new StampResponseDto
                                {
                                    Status = true,
                                    EmployeeSurname = em.Surname,
                                    EmployeeGivenName = em.GivenName,
                                    Datetime = newStamp.TimeStamp
                                };

                                return result;
                            }


                        }
                    }
                }

                throw new Exception();

            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error in StampService: {ex.Message}");
                return new StampResponseDto { Status = false, EmployeeSurname = null, EmployeeGivenName = null, Datetime = null };
            }

        }
    }
}
