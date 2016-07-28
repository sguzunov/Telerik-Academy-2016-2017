namespace SchoolSystem.Contracts
{
    public interface ICourse
    {
        string Name { get; }

        void AddStudent(IStudent student);

        bool RemoveStudent(IStudent student);
    }
}