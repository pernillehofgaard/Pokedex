using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex
{
	public class MyPokemons : Pokemon
	{
		private int CP;

		public MyPokemons(string name, Type primaryType, Type secondaryType, string nextEvelution, int CP)
			: base(name, primaryType, secondaryType, nextEvelution)
		{
			CP = CP;
		}

		public override string ToString()
		{
			return base.ToString();
		}
	}
}
