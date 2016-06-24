namespace SchoolSystem.Models.Contracts
{
    internal interface ITeacher
    {
        void AddDiscipline(IDiscipline discipline);

        void RemoveDiscipline(IDiscipline discipline);
    }
}
