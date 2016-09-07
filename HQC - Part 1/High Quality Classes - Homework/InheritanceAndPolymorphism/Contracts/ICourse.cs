namespace InheritanceAndPolymorphism.Contracts
{
    using System.Collections.Generic;

    public interface ICourse
    {
        string Name { get; }

        string TecherName { get; }

        IEnumerable<IStudent> Students { get; }

        void AddStudent(IStudent student);

        bool RemoveStudent(IStudent student);
    }
}
