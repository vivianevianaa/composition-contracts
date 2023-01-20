using Contracts.Entities.Enums;

namespace Contracts.Entities
{
    public class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();
        public Department Department { get; set; } = new Department();

        public Worker()
        {

        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContract(HourContract contract) 
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract) 
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month) 
        {
            double sum = BaseSalary; //every worker has a base salary

            foreach (HourContract contract in Contracts) 
            {
                if (contract.Date.Month == month && contract.Date.Year == year) 
                {
                    sum = sum + contract.TotalValue();
                }                
            }

            return sum;
        }
    }
}