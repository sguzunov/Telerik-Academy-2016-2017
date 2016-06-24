namespace AnimalHierarchy.Models
{
    using System;

    internal interface ISound
    {
        void ProduceSound(Action<string> action);
    }
}
