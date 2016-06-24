namespace SchoolSystem.Models.Contracts
{
    using System.Collections.Generic;

    internal interface ISchoolClass
    {
        string Identifier { get; }

        IList<Teacher> Teachers { get; }

        void AddTeacher(Teacher teacher);

        void RemoveTeacher(Teacher teacher);
    }
}
