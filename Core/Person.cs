using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExtensionModels.Core
{
    public class Person
    {
        public Person(string name, DateTime dateOfBirth)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            _addresses = new List<string>();
        }

        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        public IEnumerable<string> Addresses { get { return _addresses; } }
        internal IList<string> _addresses { get; set; }
    }

    public static class PersonExtensions 
    {
        
        public static int CalculateAge(this Person person, IClock clock)
        {
            var asOfDate = clock.Current;
            var dateOfBirth = person.DateOfBirth;

            int age = asOfDate.Year - dateOfBirth.Year;

            if (asOfDate.Month < dateOfBirth.Month || (asOfDate.Month == dateOfBirth.Month && asOfDate.Day < dateOfBirth.Day))
                age--;

            return age;
        } //http://wiki.lessthandot.com/index.php/ASP.NET:_Calculate_a_person's_age_from_their_date_of_birth

        public static void AddAddress(this Person person, string address)
        {
            person._addresses.Add(address);
        }
    }
}