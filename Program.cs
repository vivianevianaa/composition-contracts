using Contracts.Entities.Enums;
using Contracts.Entities;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter department's name: ");
        string deptName = Console.ReadLine();

        Console.WriteLine("----- Enter worker data -----");

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Level (Junior/MidLevel/Senior): ");
        WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());

        Console.Write("Base salary: ");
        double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Department dept = new Department(deptName);
        Worker worker = new Worker(name, level, baseSalary, dept);

        Console.Write("How many contracts to this worker? ");
        int num = int.Parse(Console.ReadLine());

        for(int i = 1; i <= num; i++) 
        {
            Console.WriteLine($"----- Enter #{i} contract data: -----" );

            Console.Write("Date (DD/MM/YYYY): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.Write("Value per hour: ");
            double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Duration (hours): ");
            int hours = int.Parse(Console.ReadLine());

            HourContract contract = new HourContract(date, value, hours);

            worker.AddContract(contract);
        }

        Console.WriteLine();
        Console.Write("Enter month and year to calculate income (MM/YYYY): ");
        DateTime dateContract = DateTime.Parse(Console.ReadLine());
        int month = dateContract.Month;
        int year = dateContract.Year;

        Console.WriteLine("Name: " + worker.Name);
        Console.WriteLine("Department: " + worker.Department.Name);
        Console.WriteLine($"Income for {month}/{year}: " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));
    }
}