using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionModels.Core
{
	public class Employee : Person
	{
		public string Title { get; internal set; }

		public Employee(string name, DateTime dateOfBirth, string title) : base(name, dateOfBirth)
		{
			Title = title;
		}
	}

	public static class EmployeeExtensions
	{
		public static void Promote(this Employee employee, string title, string officeAddress)
		{
			employee.Title = title;
			var address = employee.AddAddress(officeAddress);
			address.Name(title + " office");
		}
	}
}
