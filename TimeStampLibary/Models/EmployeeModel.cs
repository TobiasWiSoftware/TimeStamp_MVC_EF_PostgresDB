using System.Security;

namespace TimeStampLibary.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string? GivenName { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public List<CardModel>? Cards { get; set; }

        public EmployeeModel()
        {
        }

        // The employee model constructor with parameters
        public EmployeeModel(string givenName, string surname, string email)
        {
            GivenName = givenName;
            Surname = surname;
            Email = email;
        }

    }
}
