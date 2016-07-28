namespace SchoolSystem.Contracts
{
    public interface ISchool
    {
        void AddStudent(IStudent student);

        bool RemoveStudent(IStudent student);

        void AddCourse(ICourse course);

        bool RemoveCourse(ICourse course);
    }
}
