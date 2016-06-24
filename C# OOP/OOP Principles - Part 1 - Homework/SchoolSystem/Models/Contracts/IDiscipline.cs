namespace SchoolSystem.Models.Contracts
{
    internal interface IDiscipline
    {
        string Name { get; }

        int NumberOfLectures { get; set; }

        int NumberOfExercises { get; set; }
    }
}
