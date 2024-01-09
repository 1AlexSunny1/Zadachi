using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;

namespace Program
{
    class Programm
    {
        static void Main()
        {

        }
    }
    public class Person
    {
        public string name { get; init; }
        public DateTime dateOfBirth { get; init; }
        public string placeOfBirth { get; init; }
        public string passportNumber { get; init; }
        public Person(string name, DateTime dateOfBirth, string placeOfBirth, string passportNumber)
        {
            this.name = name;
            this.dateOfBirth = dateOfBirth;
            this.placeOfBirth = placeOfBirth;
            this.passportNumber = passportNumber;
        }
        public override bool Equals(object? obj)
        {
            Person? person = obj as Person;
            if (person == null) throw new ArgumentNullException();
            else
            {
                return name == person.name && DateOfBirth == person.dateOfBirth && placeOfBirth == person.placeOfBirth && passportNumber == person.passportNumber;
            }
        }
        public override int GetHashCode()
        {
            return name.Length + 2 * dateOfBirth.Month + 3 * placeOfBirth.Length + 4 * passportNumber.Length;
        }
    }
}

