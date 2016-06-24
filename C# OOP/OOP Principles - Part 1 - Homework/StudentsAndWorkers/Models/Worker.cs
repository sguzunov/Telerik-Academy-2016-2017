namespace StudentsAndWorkers.Models
{
    using System;
    using StudentsAndWorkers.Models.Contracts;

    internal class Worker : Human, IWorker
    {
        public Worker(string firstName, string lastName, byte workHoursPerDay, decimal weekSalary) : base(firstName, lastName)
        {
            this.WorkHoursPerDay = workHoursPerDay;
            this.WeekSalary = weekSalary;
        }

        public decimal WeekSalary { get; set; }

        public byte WorkHoursPerDay { get; set; }

        public decimal MoneyPerHour(byte workDays)
        {
            decimal moneyPerHour = this.WeekSalary / workDays * this.WorkHoursPerDay;
            return moneyPerHour;
        }
    }
}
