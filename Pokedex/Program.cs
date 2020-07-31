using System;
using System.Security.Cryptography;

namespace Pokedex
{
	class Program
	{
		static void Main(string[] args)
		{
			var ajourhold = new ajourhold();
			Console.WriteLine(
@"              _                              " + "\n" +
@"  _ __   ___ | | _____ _ __ ___   ___  _ __  " + "\n" +
@" | '_ \ / _ \| |/ / _ \ '_ ` _ \ / _ \| '_ \ " + "\n" +
@" | |_) | (_) |   <  __/ | | | | | (_) | | | |" + "\n" +
@" | .__/ \___/|_|\_\___|_| |_| |_|\___/|_| |_|" + "\n" +
@" |_| ");


			bool keepGoing = true;
			while (keepGoing)
			{
				Console.WriteLine("\nWhat would you like to do?\n" +
								  "1 - Open pokedex \n" +
								  "2 - Add pokemon to your pokemon list \n" +
								  "3 - Search after pokemon \n" +
								  "4 - Open my pokemons \n" +
								  "5 - Open weakness chart \n" +
								  "6 - Quit \n");

				var option = Convert.ToInt32(Console.ReadLine());

				switch (option)
				{
					case 1:
						Console.WriteLine("\nOpening pokedex");
						ajourhold.seePokedex();
						break;


					case 2:
						Console.WriteLine("Name of caugth pokemon: ");
						var pokemonName = Console.ReadLine().ToUpper();

						bool pokemonExists = ajourhold.pokemonExistsInPokedex(pokemonName);
						if (pokemonExists)
						{
							Type primaryType = ajourhold.returnPrimaryType(pokemonName);
							Type secondaryType = ajourhold.returnSecondaryType(pokemonName);

							Console.WriteLine("CP of pokemon: ");
							int pokemonCP = Convert.ToInt32(Console.ReadLine());

							ajourhold.addToMyPokemons(pokemonName, primaryType, secondaryType, pokemonCP);
							Console.WriteLine("Saved in myPokemon.txt");
						}
						else
						{
							Console.WriteLine("Pokemon doesn't exist in pokedex");
						}

						break;


					case 3:
						Console.WriteLine("Enter name of pokemon: ");
						string name = Console.ReadLine();
						
						Pokemon pokemon = ajourhold.findPokemon(name);
						if(pokemon != null)
						{
							Console.WriteLine(pokemon);
						}
						else
						{
							Console.WriteLine("Couldn't find Pokemon");
						}
						
						break;


					case 4:
						ajourhold.seeMyPokemons();
						break;


					case 5:
						Console.WriteLine("Enter type: ");
						string type = Console.ReadLine();
						ajourhold.openWeaknessChart(type);
						break;


					case 6:
						Console.WriteLine("\nQuiting");
						keepGoing = false;
						break;
					default:
						Console.WriteLine("\nThat's not an option");
						break;
				}
			}

		}
	}
}
