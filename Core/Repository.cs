using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExtensionModels.Core
{
    public interface IRepository<T> where T : class
    {
        T FindById(int id);
        void Save(T model);
    }

    public class PersonRepository : IRepository<Person>
	{
		public Person FindById(int id)
		{
			var person = new Person("Dan Lash", April.Fifth(1984));
			person.AddAddress("4972 Wilcox, Holt, MI 48842");
			person.AddAddress("897 N Highland Ave NE, APT BT2, Atlanta, GA 30306");
			return person;
		}

		public void Save(Person model)
		{
		}
	}

	public class EmployeeRepository : IRepository<Employee>
	{
		public Employee FindById(int id)
		{
			var employee = new Employee("Steve Harman", April.TwentySecond(1982), "Developer");
			employee.AddAddress("35 German Way, Columbus, OH 201894");

			return employee;
		}

		public void Save(Employee model)
		{
		}
	}

    public static class April
    {
        public static DateTime Fifth(int year) { return new DateTime(year, 4, 5); }
		public static DateTime TwentySecond(int year) { return new DateTime(year, 4, 22); }
    }
}