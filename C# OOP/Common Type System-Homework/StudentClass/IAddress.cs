namespace StudentClass
{
    using System;

    internal interface IAddress : ICloneable
    {
        int Number { get; set; }

        string Street { get; set; }

        string Country { get; set; }

        string City { get; set; }
    }
}
