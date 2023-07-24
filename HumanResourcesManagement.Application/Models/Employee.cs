using System;
using HumanResourcesManagement.Application.Components;

namespace HumanResourcesManagement.Application.Models
{
    public class Employee
    {
        #region FIELDS
        private string firstName;
        private string lastName;
        private string age;
        private string email;

        private double hoursOfWorkUnpaidYet;
        private double calculatedWage;
        private double hourlyRate;
        private static double taxRate = 0.02;

        private DateTime birthDate;
        private Address address;
        #endregion

        #region CONSTRUCTOR(S)
        public Employee(string firstName, string lastName, string age, string email, DateTime birthDate, double? hourlyRate)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Email = email;
            BirthDate = birthDate;
            HourlyRate = hourlyRate ?? 10;
        }

        public Employee(string firstName, string lastName, string age, string email, DateTime birthDate) : this(firstName, lastName, age, email, birthDate, 0.0)
        {
        }

        public Employee(string firstName, string lastName, string age, string email, DateTime birthDate, double? hourlyRate, string addressLine, string city, string state, string zipCode)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Email = email;
            BirthDate = birthDate;
            HourlyRate = hourlyRate ?? 10;
            Address = new Address(addressLine, city, state, zipCode);
        }
        #endregion

        #region PROPERTIES
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public double HoursOfWorkUnpaidYet
        {
            get { return hoursOfWorkUnpaidYet; }
            set { hoursOfWorkUnpaidYet = value; }
        }

        public double CalculatedWage
        {
            get { return calculatedWage; }
            set { calculatedWage = value; }
        }

        public double? HourlyRate
        {
            get { return hourlyRate; }
            set { hourlyRate = value ?? 10; }
        }

        public double TaxRate
        {
            get { return taxRate; }
            set { taxRate = value; }
        }

        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        public Address Address
        {
            get { return address; }
            set { address = value; }
        }
        #endregion

        #region METHODS
        // Display employee information
        public void DisplayEmployeeInfo()
        {
            Console.WriteLine($"\nFirst Name: {FirstName}\n" +
                $"Last Name: {LastName}\n" +
                $"Age: {Age}\n" +
                $"Email: {Email}\n" +
                $"Birth Date: {BirthDate}\n" +
                //$"Address: {Address.AddressLine}, {Address.City}, {Address.State} {Address.ZipCode}\n" +
                $"Hourly Rate: {HourlyRate}");
        }

        // Increase hours worked
        protected void PerformWork(double hours)
        {
            HoursOfWorkUnpaidYet += hours;
            Console.WriteLine($"{FirstName} {LastName} performed {hours} hours of work and has total of {HoursOfWorkUnpaidYet} hours of work done.");
        }

        protected void PerformWork()
        {
            PerformWork(1.0);
        }

        // Calculate and pay wage
        protected double ReceiveWage(bool resetHours = true)
        {
            double wageBeforeTax = HourlyRate.Value * HoursOfWorkUnpaidYet;
            double taxAmount = wageBeforeTax * TaxRate;

            CalculatedWage = wageBeforeTax - taxAmount;
            Console.WriteLine($"{FirstName} has earned ${CalculatedWage} for {HoursOfWorkUnpaidYet} hour(s) after tax deductions that amount to ${taxAmount}");

            if (resetHours)
                HoursOfWorkUnpaidYet = 0.0;

            return CalculatedWage;
        }

        // Give bonus
        public virtual void GiveBonus()
        {
            Console.WriteLine($"{FirstName} got the default bonus of $100");
        }
        #endregion

    }
}

