using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace MovePeopleDataToXML
{
    public class Startup
    {
        private static void Main()
        {
            var people = ReadPeopleData("../../Files/people.txt");
            WritePeopleDataToXMLFile("../../Files/people.xml", people);

            Console.WriteLine("Done");
        }

        private static void WritePeopleDataToXMLFile(string fileUrl, IEnumerable<IPerson> people)
        {
            var peopleElement = new XElement("people");
            foreach (var person in people)
            {
                var personElement = new XElement("person",
                        new XElement("firstName", person.FirstName),
                        new XElement("lastName", person.LastName),
                        new XElement("phoneNumber", person.PhoneNumber)
                    );
                peopleElement.Add(personElement);
            }

            peopleElement.Save(fileUrl);
        }

        private static IEnumerable<IPerson> ReadPeopleData(string fileUrl)
        {
            var people = new List<IPerson>();
            using (StreamReader reader = new StreamReader(fileUrl))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var person = ParsePersonData(line);
                    people.Add(person);

                    line = reader.ReadLine();
                }
            }

            return people;
        }

        private static IPerson ParsePersonData(string data)
        {
            var tokens = data.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length != 3)
            {
                throw new ArgumentException("Person must have first name, last name, phone number!");
            }

            string firstName = tokens[0];
            string lastName = tokens[1];
            string phoneNumber = tokens[2];
            var person = new Person(firstName, lastName, phoneNumber);

            return person;
        }
    }
}
