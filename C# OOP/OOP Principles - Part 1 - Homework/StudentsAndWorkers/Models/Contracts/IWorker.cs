namespace StudentsAndWorkers.Models.Contracts
{
    interface IWorker
    {
        decimal WeekSalary { get; set; }

        byte WorkHoursPerDay { get; set; }

        decimal MoneyPerHour(byte workDays);
    }
}
