using System;
namespace HumanResourcesManagement.Application.Models
{
    public class JuniorResearcher : Researcher
    {
        public JuniorResearcher(string firstName, string lastName, string age, string email, DateTime birthDate, double? hourlyRate) : base(firstName, lastName, age, email, birthDate, hourlyRate)
        {
        }

        public override void GiveBonus()
        {
            Console.WriteLine($"{FirstName} got the lowered bonus of $50");
        }
    }
}

