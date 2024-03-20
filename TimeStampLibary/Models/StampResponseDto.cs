namespace TimeStampLibary.Models
{
    public class StampResponseDto
    {
        public bool Status { get; set; }
        public string? EmployeeGivenName { get; set; }
        public string? EmployeeSurname { get; set; }
        public DateTime? Datetime { get; set; } 
    }
}