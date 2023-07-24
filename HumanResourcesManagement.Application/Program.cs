using HumanResourcesManagement.Application;
using HumanResourcesManagement.Application.Models;

string userMenuChoice = "";
List<Employee> Employees = new List<Employee>();

Console.ForegroundColor = ConsoleColor.DarkCyan;
Console.WriteLine("Human Resources Management Application v0.1");
Utilities.checkForExistingEmployeesFile();
Console.ForegroundColor = ConsoleColor.DarkYellow;
Console.WriteLine("Press any key to continue to menu..");
Console.ResetColor();
Console.ReadKey();

// Applicaiton main loop
do
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("\tMENU\n");
    Console.ResetColor();
    Console.WriteLine("1: Register Employee\n" +
        "2: View All Employees\n" +
        "3: Save Data\n" +
        "4: Load Data\n" +
        "9: Quit Application\n\n");

    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("Please make a selection..");
    Console.ResetColor();

    userMenuChoice = Console.ReadLine();

    switch (userMenuChoice)
    {
        case "1":
            Console.Clear();
            Utilities.RegisterEmployee(Employees);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nRegister successful. Press any key to continue..");
            Console.ResetColor();
            Console.ReadKey();
            break;
        case "2":
            Console.Clear();
            Utilities.ViewEmployees(Employees);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nPress any key to continue..");
            Console.ResetColor();
            Console.ReadKey();
            break;
        case "3":
            Console.Clear();
            Utilities.SaveData(Employees);
            break;
        case "4":
            Console.Clear();
            Utilities.LoadData(Employees);
            break;
        case "9":
            Environment.Exit(0);
            break;
        default:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid Input");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Press any key to go back..");
            Console.ResetColor();
            Console.ReadKey();
            break;
    }
} while (userMenuChoice != "9");

