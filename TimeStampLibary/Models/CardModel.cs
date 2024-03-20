using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeStampLibary.Models
{
    public class CardModel
    {
        public int Id { get; set; }
        public int EmloyeeId { get; set; }
        public string CardNumber { get => _cardNumber; }

        private string _cardNumber = string.Empty;
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool ForTime { get; set; }
        public bool ForDoor { get; set; }
        public bool IsActive { get; set; }
        public EmployeeModel? Employee { get; set; }

        public CardModel()
        {
            
        }

        public CardModel(DateTime issueDate, DateTime expiryDate, bool forTime, bool forDoor, bool status, EmployeeModel employee)
        {
            IssueDate = issueDate;
            ExpiryDate = expiryDate;
            ForTime = forTime;
            ForDoor = forDoor;
            IsActive = status;
            Employee = employee;
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
