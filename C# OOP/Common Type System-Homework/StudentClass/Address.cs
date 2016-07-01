namespace StudentClass
{
    using System;

    internal class Address : IAddress, ICloneable
    {
        public Address(string city, string country, int number, string street)
        {
            this.City = city;
            this.Country = country;
            this.Number = number;
            this.Street = street;
        }

        public string City { get; set; }

        public string Country { get; set; }

        public int Number { get; set; }

        public string Street { get; set; }

        public object Clone()
        {
            var clonedAddress = this.MemberwiseClone();
            return clonedAddress;
        }

        public override bool Equals(object obj)
        {
            Address address = obj as Address;
            if (address == null)
            {
                return false;
            }

            return this.City.Equals(address.City) &&
                this.Country.Equals(address.Country) &&
                this.Number.Equals(address.Number) &&
                this.Street.Equals(address.Street);
        }

        public override int GetHashCode()
        {
            int hashCode = 17;
            unchecked
            {
                hashCode = hashCode * 23 + this.City.GetHashCode();
                hashCode = hashCode * 23 + this.Country.GetHashCode();
                hashCode = hashCode * 23 + this.Number.GetHashCode();
                hashCode = hashCode * 23 + this.Street.GetHashCode();
            }

            return hashCode;
        }

        public override string ToString()
        {
            return $"City: {this.City}, Country: {this.Country}";
        }
    }
}
