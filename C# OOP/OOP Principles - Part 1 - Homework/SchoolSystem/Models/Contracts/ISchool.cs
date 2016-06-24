namespace SchoolSystem.Models.Contracts
{
    using System.Collections.Generic;

    internal interface ISchool
    {
        string Name { get; }

        IList<ISchoolClass> SchoolClasses { get; }

        void AddClass(ISchoolClass schoolClass);

        void RemoveClass(ISchoolClass schoolClass);
    }
}
