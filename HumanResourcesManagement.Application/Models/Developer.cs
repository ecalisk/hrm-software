using System;
namespace HumanResourcesManagement.Application.Models
{
    public class Developer : Employee
    {
        public Developer(string firstName, string lastName, string age, string email, DateTime birthDate, double? hourlyRate) : base(firstName, lastName, age, email, birthDate, hourlyRate)
        {
        }
    }
}
