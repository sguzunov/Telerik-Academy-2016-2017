namespace StudentClass
{
    using System;
    using System.Text;

    internal class Student : ICloneable, IComparable<Student>
    {
        public Student(
            string firstName,
            string middleName,
            string lastName,
            string sSN,
            IAddress address,
            string mobilePhone,
            string email,
            byte course,
            SpecialtyType specialty,
            UniversityType university,
            FacultyType faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = sSN;
            this.Address = address;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Course = course;
            this.Specialty = specialty;
            this.University = university;
            this.Faculty = faculty;
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string SSN { get; set; }

        public IAddress Address { get; set; }

        public string MobilePhone { get; set; }

        public string Email { get; set; }

        public byte Course { get; set; }

        public SpecialtyType Specialty { get; set; }

        public UniversityType University { get; set; }

        public FacultyType Faculty { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null && this.GetType() != obj.GetType())
            {
                return false;
            }

            Student student = obj as Student;
            bool areEqual = this.FirstName.Equals(student.FirstName) &&
                this.MiddleName.Equals(student.MiddleName) &&
                this.LastName.Equals(student.LastName) &&
                this.SSN.Equals(student.SSN) &&
                this.Course.Equals(student.Course) &&
                this.Specialty.Equals(student.Specialty) &&
                this.Faculty.Equals(student.Faculty) &&
                this.University.Equals(student.University);
            return areEqual;
        }

        public override int GetHashCode()
        {
            int hashCode = 17;
            unchecked
            {
                hashCode = hashCode * 23 + this.FirstName.GetHashCode();
                hashCode = hashCode * 23 + this.MiddleName.GetHashCode();
                hashCode = hashCode * 23 + this.LastName.GetHashCode();
                hashCode = hashCode * 23 + this.SSN.GetHashCode();
                hashCode = hashCode * 23 + this.Address.GetHashCode();
                hashCode = hashCode * 23 + this.MobilePhone.GetHashCode();
                hashCode = hashCode * 23 + this.Email.GetHashCode();
                hashCode = hashCode * 23 + this.Course.GetHashCode();
                hashCode = hashCode * 23 + this.Specialty.GetHashCode();
                hashCode = hashCode * 23 + this.University.GetHashCode();
                hashCode = hashCode * 23 + this.Faculty.GetHashCode();
            }

            return hashCode;
        }

        public override string ToString()
        {
            var stringRepresentation = new StringBuilder();
            stringRepresentation.AppendLine($"First name: {this.FirstName} Middle name: {this.MiddleName} Last name: {this.LastName}");
            stringRepresentation.AppendLine($"SSN: {this.SSN}");
            stringRepresentation.AppendLine($"From: {this.Address}");
            stringRepresentation.AppendLine($"Counrse: {this.Course}");
            stringRepresentation.AppendLine($"Specialty: {this.Specialty}");
            stringRepresentation.AppendLine($"Faculty: {this.Faculty}");
            stringRepresentation.AppendLine($"University: {this.University}");

            return stringRepresentation.ToString();
        }

        public object Clone()
        {
            Student student = this.MemberwiseClone() as Student;
            student.Address = this.Address.Clone() as IAddress;
            return student;
        }

        public int CompareTo(Student student)
        {
            if (this.FirstName != student.FirstName)
            {
                return this.FirstName.CompareTo(student.FirstName);
            }

            if (this.MiddleName != student.MiddleName)
            {
                return this.MiddleName.CompareTo(student.MiddleName);
            }

            if (this.LastName != student.LastName)
            {
                return this.LastName.CompareTo(student.LastName);
            }

            if (this.SSN != student.SSN)
            {
                return this.SSN.CompareTo(student.SSN);
            }

            if (this.Course != student.Course)
            {
                return this.Course.CompareTo(student.Course);
            }

            if (this.Specialty != student.Specialty)
            {
                return this.Specialty.CompareTo(student.Specialty);
            }

            if (this.Faculty != student.Faculty)
            {
                return this.Faculty.CompareTo(student.Faculty);
            }

            if (this.University != student.University)
            {
                return this.University.CompareTo(student.University);
            }

            return 0;
        }

        public static bool operator ==(Student firstStudent, Student secondStudent)
        {
            return firstStudent.Equals(secondStudent);
        }

        public static bool operator !=(Student firstStudent, Student secondStudent)
        {
            return !firstStudent.Equals(secondStudent);
        }
    }
}
