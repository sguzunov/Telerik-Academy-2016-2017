namespace People
{
    public class PersonFactory
    {
        public Person CreatePerson(int age)
        {
            var person = new Person()
            {
                Age = age
            };

            if (age % 2 == 0)
            {
                person.Name = "Bad boy";
                person.Gender = Gender.Male;
            }
            else
            {
                person.Name = "Hot chick";
                person.Gender = Gender.Female;
            }

            return person;
        }
    }
}
