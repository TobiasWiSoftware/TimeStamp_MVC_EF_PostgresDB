using System.Security;

namespace TimeStampLibary.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string? GivenName { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? CardNumber { get => _cardNumber; }

        private string _cardNumber = string.Empty;


        public EmployeeModel()
        {
            SetCardNumber();
        }

        // The employee model constructor with parameters
        public EmployeeModel(string givenName, string surname, string email)
        {
            GivenName = givenName;
            Surname = surname;
            Email = email;
            SetCardNumber();
        }



        private void SetCardNumber()
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                int num = random.Next(0, 36);
                if (num < 10)
                {
                    _cardNumber += num.ToString();
                }
                else
                {
                    _cardNumber += ((char)(num + 87)).ToString();
                }
            }
        }

    }
}
