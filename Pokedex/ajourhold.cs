using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Pokedex
{
	public class ajourhold
	{
		string pokedexPath = @"C:\Users\Pernille\Desktop\C#\Pokedex\pokedex.txt"; // file placement
		string myPokemonPath = @"C:\Users\Pernille\Desktop\C#\Pokedex\myPokemon.txt"; // file placement
		string weaknessChart = @"C:\Users\Pernille\Desktop\C#\Pokedex\weaknesses.txt"; // file placement

		public void seePokedex()
		{
			StreamReader reader = new StreamReader(pokedexPath); // 
			string firstline = reader.ReadLine() ?? "\n"; // reades firstline in file

			while (firstline != "") // as long as firstline is not empty, keep reading
			{
				//reades info in file
				string pokemonName = reader.ReadLine() ?? "\n"; //second line - name of pokemon
				string primaryType = reader.ReadLine() ?? "\n"; //third line - primary type of pokemon
				string secondaryType = reader.ReadLine() ?? "\n"; //fourth line - secondary type of pokemon
				string nextEvolution = reader.ReadLine() ?? "\n"; //fifth line - evolves to

				//if the pokemons has two types we want to devide them like this: type1/type2
				//if the pokemon has one type we dont want to devide the type and only show the one type
				var devidesign = "/";
				if(primaryType == secondaryType)
				{
					devidesign = "";
					secondaryType = "";
				}

				//if the pokemon doens't have a next evelutoion it displays "End of evulution"
				if(nextEvolution == "NULL")
				{
					nextEvolution = "End of evultion";
				}

				//print info about pokemon, exept id
				Console.WriteLine("Name: "+ pokemonName + " \nType: " + primaryType + devidesign + secondaryType + "\nEvolves into: " + nextEvolution + "\n"); 

				//reades firstline again and goes back to loop
				firstline = reader.ReadLine() ?? "\n";
			}

			
		}

		public void addToMyPokemons(string name, Type primaryType, Type secondaryType, int CP)
		{
			StreamWriter write = new StreamWriter(myPokemonPath,true);
			write.WriteLine(name);
			write.WriteLine(primaryType);
			write.WriteLine(secondaryType);
			write.WriteLine(CP);

			write.Close();
		}

		public Pokemon findPokemon(string pokemonName)
		{
			StreamReader reader = new StreamReader(pokedexPath);
			// reads first line in file
			string pokemonId = reader.ReadLine() ?? "\n";

			bool pokemonFound = false;
			while(!pokemonFound) //while pokemon is not found keep reading
			{
				string name = reader.ReadLine() ?? "\n";
				string primaryType = reader.ReadLine() ?? "\n";
				string secondaryType = reader.ReadLine() ?? "\n";
				string nextEvolution = reader.ReadLine() ?? "\n";

				if (name == pokemonName.ToUpper())
				{					
					if(nextEvolution == "NULL")
					{
						nextEvolution = "End of evolution";
					}


					Type primary = returnPrimaryType(name);
					Type secondary = returnSecondaryType(name);
					Pokemon pokemon = new Pokemon(name, primary, secondary, nextEvolution);

					return pokemon;
					
				}
				
				string pokemondId = reader.ReadLine() ?? "\n";
			}

			reader.Close();
			return null;
		}

		public void seeMyPokemons()
		{
			StreamReader reader = new StreamReader(myPokemonPath,true);
			string pokemonName = reader.ReadLine() ?? "\n";

			while (pokemonName != "")
			{
				
				string primaryType = reader.ReadLine() ?? "\n";
				string secondaryType = reader.ReadLine() ?? "\n";
				string cp = reader.ReadLine() ?? "\n";

				Console.WriteLine("Name: " + pokemonName + "\nType: " + primaryType + "/" + secondaryType + "\nCP: " + cp + "\n");

				pokemonName = reader.ReadLine() ?? "\n";
			}
			reader.Close();
			
		}
		
		// Checks if entered pokemonname exists in pokedex. You can't register a pokemons who doesn't exists
		public bool pokemonExistsInPokedex(string pokename)
		{
			bool exists = false;
			StreamReader reader = new StreamReader(pokedexPath);

			string pokemonId = reader.ReadLine() ?? "\n";
			while(pokemonId != "")
			{
				string name = reader.ReadLine() ?? "\n";
				string primaryType = reader.ReadLine() ?? "\n";
				string secondaryType = reader.ReadLine() ?? "\n";
				string nextEvolution = reader.ReadLine() ?? "\n";

				if(pokename == name)
				{
					exists = true;
				}

				pokemonId = reader.ReadLine() ?? "\n";
			}
			reader.Close();
			return exists;
		}

		public void openWeaknessChart(string enteredType)
		{
			StreamReader reader = new StreamReader(weaknessChart);

			string type = reader.ReadLine() ?? "\n";
			while(type != null)
			{
				string weakAgainst = reader.ReadLine() ?? "\n";

				if(enteredType.ToUpper() == type.ToUpper())
				{
					Console.WriteLine(type + "-TYPE POKEMON ARE WEAK AGAINST: " + weakAgainst + "- POKEMONS");
				}

				type = reader.ReadLine() ?? "\n";
			}
		}

		//returns the primary type of entered pokemon
		public Type returnPrimaryType(string pokemonName)
		{
			Type primaryType = Type.UNKNOWN;
			StreamReader reader = new StreamReader(pokedexPath);

			string pokemonid = reader.ReadLine() ?? "\n";
			while(pokemonid != "")
			{
				string name = reader.ReadLine() ?? "\n";
				string primary = reader.ReadLine() ?? "\n";
				string secondary = reader.ReadLine() ?? "\n";
				string nextEvolution = reader.ReadLine() ?? "\n";

				if(pokemonName == name)
				{
					if(primary == "BUG")
					{
						primaryType = Type.BUG;
					}
					else if (primary == "DRAGON")
					{
						primaryType = Type.DRAGON;
					}
					else if (primary == "ELECTRIC")
					{
						primaryType = Type.ELECTRIC;
					}
					else if (primary == "FAIRY")
					{
						primaryType = Type.FAIRY;
					}
					else if (primary == "FIGHTING")
					{
						primaryType = Type.FIGHTING;
					}
					else if (primary == "FIRE")
					{
						primaryType = Type.FIRE;
					}
					else if (primary == "FLYING")
					{
						primaryType = Type.FLYING;
					}
					else if (primary == "GRASS")
					{
						primaryType = Type.GRASS;
					}
					else if (primary == "GHOST")
					{
						primaryType = Type.GHOST;
					}
					else if (primary == "GROUND")
					{
						primaryType = Type.GROUND;
					}
					else if (primary == "ICE")
					{
						primaryType = Type.ICE;
					}
					else if (primary == "NORMAL")
					{
						primaryType = Type.NORMAL;
					}
					else if (primary == "POISON")
					{
						primaryType = Type.POISON;
					}
					else if (primary == "PSYCHIC")
					{
						primaryType = Type.PSYCHIC;
					}
					else if (primary == "ROCK")
					{
						primaryType = Type.ROCK;
					}
					else if (primary == "WATER")
					{
						primaryType = Type.WATER;
					}
					else
					{
						primaryType = Type.UNKNOWN;
					}

				}
				pokemonid = reader.ReadLine() ?? "\n";
			}

			//Console.WriteLine(primaryType);
			reader.Close();
			return primaryType;
		}

		//returns the secondary type of entered pokemon
		public Type returnSecondaryType(string pokemonName)
		{
			Type secondaryType = Type.UNKNOWN;
			StreamReader reader = new StreamReader(pokedexPath);

			string pokemonid = reader.ReadLine() ?? "\n";
			while (pokemonid != "")
			{
				string name = reader.ReadLine() ?? "\n";
				string primary = reader.ReadLine() ?? "\n";
				string secondary = reader.ReadLine() ?? "\n";
				string nextEvolution = reader.ReadLine() ?? "\n";


				if (pokemonName == name)
				{
					if (secondary == "BUG")
					{
						secondaryType = Type.BUG;
					}
					else if (secondary == "DRAGON")
					{
						secondaryType = Type.DRAGON;
					}
					else if (secondary == "ELECTRIC")
					{
						secondaryType = Type.ELECTRIC;
					}
					else if (secondary == "FAIRY")
					{
						secondaryType = Type.FAIRY;
					}
					else if (secondary == "FIGHTING")
					{
						secondaryType = Type.FIGHTING;
					}
					else if (secondary == "FIRE")
					{
						secondaryType = Type.FIRE;
					}
					else if (secondary == "FLYING")
					{
						secondaryType = Type.FLYING;
					}
					else if (secondary == "GRASS")
					{
						secondaryType = Type.GRASS;
					}
					else if (secondary == "GHOST")
					{
						secondaryType = Type.GHOST;
					}
					else if (secondary == "GROUND")
					{
						secondaryType = Type.GROUND;
					}
					else if (secondary == "ICE")
					{
						secondaryType = Type.ICE;
					}
					else if (secondary == "NORMAL")
					{
						secondaryType = Type.NORMAL;
					}
					else if (secondary == "POISON")
					{
						secondaryType = Type.POISON;
					}
					else if (secondary == "PSYCHIC")
					{
						secondaryType = Type.PSYCHIC;
					}
					else if (secondary == "ROCK")
					{
						secondaryType = Type.ROCK;
					}
					else if (secondary == "WATER")
					{
						secondaryType = Type.WATER;
					}
					else
					{
						secondaryType = Type.UNKNOWN;
					}

				}

				pokemonid = reader.ReadLine() ?? "\n";
			}

			//Console.WriteLine(secondaryType);
			reader.Close();
			return secondaryType;
		}


	}
}
