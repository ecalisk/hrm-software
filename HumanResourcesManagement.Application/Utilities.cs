using System;
using System.Text;
using HumanResourcesManagement.Application.Models;

namespace HumanResourcesManagement.Application
{
    public class Utilities
    {
        private static string directory = @"/Users/emir/Projects/HumanResourcesManagement.Application/HumanResourcesManagement.Application/data/";
        private static string fileName = "employees.txt";

        // Register a new employee
        public static void RegisterEmployee(List<Employee> Employees)
        {
            Console.WriteLine("************\n*** TYPE ***\n************\n\n" +
        "1: Employee\n" +
        "2: Manager\n" +
        "3: Developer\n" +
        "4: Researcher\n" +
        "5: Junior Researcher\n\n");

            string employeeType = "";

            // Ask for valid employee type choice until one is provided
            do
            {
                Console.WriteLine("Please choose a valid employee type:");
                employeeType = Console.ReadLine();
            } while (employeeType != "1" && employeeType != "2" && employeeType != "3"
                && employeeType != "4" && employeeType != "5");

            Console.Clear();

            Console.WriteLine("First Name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Last Name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Age:");
            string age = Console.ReadLine();

            Console.WriteLine("Email:");
            string email = Console.ReadLine();

            Console.WriteLine("Birth Date (e.g. 10/22/1987):");
            DateTime.TryParse(Console.ReadLine(), out DateTime birthDate);

            Console.WriteLine("Hourly Rate:");
            Double.TryParse(Console.ReadLine(), out double hourlyRate);

            Employee employee = null;

            switch (employeeType)
            {
                case "1":
                    employee = new Employee(firstName, lastName, age, email, birthDate, hourlyRate);
                    break;
                case "2":
                    employee = new Manager(firstName, lastName, age, email, birthDate, hourlyRate);
                    break;
                case "3":
                    employee = new Developer(firstName, lastName, age, email, birthDate, hourlyRate);
                    break;
                case "4":
                    employee = new Researcher(firstName, lastName, age, email, birthDate, hourlyRate);
                    break;
                case "5":
                    employee = new JuniorResearcher(firstName, lastName, age, email, birthDate, hourlyRate);
                    break;
            }

            Employees.Add(employee);
        }

        // View all employees
        public static void ViewEmployees(List<Employee> Employees)
        {
            foreach (Employee e in Employees)
            {
                e.DisplayEmployeeInfo();
            }
        }

        // Write current list to the text file
        public static void SaveData(List<Employee> employees)
        {
            string path = directory + fileName;
            StringBuilder dataToBeSaved = new StringBuilder();

            foreach (Employee employee in employees)
            {
                dataToBeSaved.Append($"First Name:{employee.FirstName};");
                dataToBeSaved.Append($"Last Name:{employee.LastName};");
                dataToBeSaved.Append($"Age:{employee.Age};");
                dataToBeSaved.Append($"Email:{employee.Email};");
                dataToBeSaved.Append($"Birth Date:{employee.BirthDate};");
                dataToBeSaved.Append($"Hourly Rate:{employee.HourlyRate};");
                dataToBeSaved.Append($"Type:{GetEmployeeType(employee)};");
                dataToBeSaved.Append(Environment.NewLine);
            }

            File.WriteAllText(path, dataToBeSaved.ToString());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Saved employees succesfully");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Press any key to continue to menu..");
            Console.ReadKey();
            Console.ResetColor();
        }

        // Read from text file and load to the list
        public static void LoadData(List<Employee> Employees)
        {
            Employees.Clear();
            string path = directory + fileName;
            string[] employeesAsString = File.ReadAllLines(path);

            for (int i = 0; i < employeesAsString.Length; i++)
            {
                string[] employeeSplits = employeesAsString[i].Split(";");
                string firstName = employeeSplits[0].Substring(employeeSplits[0].IndexOf(":") + 1);
                string lastName = employeeSplits[1].Substring(employeeSplits[1].IndexOf(":") + 1);
                string age = employeeSplits[2].Substring(employeeSplits[2].IndexOf(":") + 1);
                string email = employeeSplits[3].Substring(employeeSplits[3].IndexOf(":") + 1);
                DateTime birthDate = DateTime.Parse(employeeSplits[4].Substring(employeeSplits[4].IndexOf(":") + 1));
                double hourlyRate = Double.Parse(employeeSplits[5].Substring(employeeSplits[5].IndexOf(":") + 1));
                string employeeType = employeeSplits[6].Substring(employeeSplits[6].IndexOf(":") + 1);

                Employee employee = null;

                switch (employeeType)
                {
                    case "1":
                        employee = new Employee(firstName, lastName, age, email, birthDate, hourlyRate);
                        break;
                    case "2":
                        employee = new Manager(firstName, lastName, age, email, birthDate, hourlyRate);
                        break;
                    case "3":
                        employee = new Developer(firstName, lastName, age, email, birthDate, hourlyRate);
                        break;
                    case "4":
                        employee = new Researcher(firstName, lastName, age, email, birthDate, hourlyRate);
                        break;
                    case "5":
                        employee = new JuniorResearcher(firstName, lastName, age, email, birthDate, hourlyRate);
                        break;
                }

                Employees.Add(employee);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Loaded {Employees.Count} employees!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
            Console.ResetColor();
        }

        // Check if employee directoy exists, create if needed
        public static void checkForExistingEmployeesFile()
        {
            string path = directory + fileName;
            bool fileExists = File.Exists(path);

            if (fileExists)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("An existing file with Employee data is found");
                Console.ResetColor();
            }
            else
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Directory is ready for saving files.");
                    Console.ResetColor();
                }
            }
        }

        // Return employee type as a decodable string
        private static string GetEmployeeType(Employee employee)
        {
            if (employee is Manager)
                return "2";
            else if (employee is Developer)
                return "3";
            else if (employee is JuniorResearcher)
                return "5";
            else if (employee is Researcher)
                return "4";
            else if (employee is Employee)
                return "1";
            return "0";
        }
    }
}

