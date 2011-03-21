using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionModels.Core
{
	public class Address
	{
		public string Name { get; internal set; }
		public string Line1 { get; private set; }

		internal Address(string name, string line1)
		{
			Name = name;
			Line1 = line1;
		}

		public static Address Parse(string address)
		{
			return new Address(string.Empty, address);
		}

		public override string ToString()
		{
			return Line1;
		}
	}

	public static class AddressExtensions
	{
		public static void Name(this Address address, string name)
		{
			address.Name = name;
		}
	}
}
