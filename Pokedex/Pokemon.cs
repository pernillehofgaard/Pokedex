using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex
{
	public class Pokemon
	{
		private string name { get; set; }
		private Type primaryType { get; set; }
		private Type secondaryType { get; set; }
		private string nextEvelution { get; set; }

		public Pokemon(string name, Type primaryType, Type secondaryType, string nextEvelution)
		{
			this.name = name;
			this.primaryType = primaryType;
			this.secondaryType = secondaryType;
			this.nextEvelution = nextEvelution;
		}

		
		public override string ToString()
		{
			string devideSign = "/";
			if(primaryType == secondaryType)
			{
				devideSign = "";
				return "\nName: " + name + "\nType: " + primaryType + devideSign + "\nEvolves into: " + nextEvelution;
			}
			else
			{
				return "\nName: " + name + "\nType: " + primaryType + devideSign + secondaryType + "\nEvolves into: " + nextEvelution;

			}
		}
	}
}
