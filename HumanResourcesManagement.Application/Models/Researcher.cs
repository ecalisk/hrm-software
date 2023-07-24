using System;
namespace HumanResourcesManagement.Application.Models
{
    public class Researcher : Employee
    {
        public Researcher(string firstName, string lastName, string age, string email, DateTime birthDate, double? hourlyRate) : base(firstName, lastName, age, email, birthDate, hourlyRate)
        {
        }
    }
}

