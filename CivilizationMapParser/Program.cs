using System;
using System.Collections.Generic;
using System.IO;

namespace CivilizationMapParser
{
	class Program
	{
		static void Main(string[] args)
		{
			ReadSourceFile(AskForPath());
			WriteRegionTileInfo();
		}

		static readonly List<RegionTile> Regions = new List<RegionTile>();

		static string AskForPath()
		{
			Console.WriteLine("Provide path to Source file below:");
			return Console.ReadLine();
		}

		static void ReadSourceFile(string path)
		{
			string[] lines = File.ReadAllLines(path);
			RegionTile Region = null;
			int count = 0;

			for (int i = 0; i < lines.Length; i++)
			{
				char[] charsToTrim = new char[] { ' ', ';', '"', '(', ')', '[', ']', '{', '}' };

				if (Region == null)
				{
					Region = new RegionTile();
				}
				else if (!String.IsNullOrEmpty(Region.Name) && 
						Region.NumberOfVectors != 0 && 
						Region.Vertices != null &&
						Region.Triangles != null &&
						!Regions.Contains(Region))
				{
					Regions.Add(Region);
					Region = new RegionTile();
				}


				//Region initial info: name, borders, squares
				if (lines[i].Contains("tile.name = "))
				{
					string name = lines[i].Substring(lines[i].IndexOf('"'));
					name = name.Trim(charsToTrim);
					Region.Name = name;

					Console.WriteLine(Region.Name);
					Console.WriteLine();
				}
				if (lines[i].Contains("int[] tris = new int[]"))
				{
					string trianglesString = lines[i].Substring(lines[i].IndexOf('{'));
					trianglesString = trianglesString.Trim(charsToTrim).Replace(" ", "");
					string[] numAsStr = trianglesString.Split(',');

					for (int k = 0; k < numAsStr.Length - 1; k++)
					{
						int n = Convert.ToInt32(numAsStr[k]);
						Region.Triangles.Add(n);
					}
				}
				if (lines[i].Contains("Vector3[] vertices = new Vector3"))
				{
					string numOfVString = lines[i].Substring(lines[i].LastIndexOf('['));
					int numOfVectors = Convert.ToInt32(numOfVString.Trim(charsToTrim).Replace(" ", ""));
					Region.NumberOfVectors = numOfVectors;
				}
				if (lines[i].Contains("vertices["))
				{
					string vertices = lines[i].Substring(lines[i].IndexOf('('), lines[i].IndexOf(')') - lines[i].IndexOf('('));
					int indexOfVLength = lines[i].IndexOf(']') - lines[i].IndexOf('[') - 1;
					string pieceOfLineWithIndexOfVertice = lines[i].Substring(lines[i].IndexOf('[') + 1, indexOfVLength);
					int indexOfVertice = Convert.ToInt32(pieceOfLineWithIndexOfVertice);
					vertices = vertices.Trim(charsToTrim).Replace("y", "0");

					if (Region.Vertices == null)
					{
						Region.InitializeVertices(Region.NumberOfVectors);
						Region.Vertices[indexOfVertice] = vertices;
					}
					else
					{
						Region.Vertices[indexOfVertice] = vertices;
					}
				}

				//Region additional info: positions of temple, city, market, influence token, tower, army and resourses in the region
				if (lines[i].Contains("positions.AddCity(new Vector3"))
				{
					if (Region.CityPosition == null)
					{
						Region.InitializeCityPosition();
						count = 0;

					}
					if (Region.CityPosition != null)
					{
						string cityPosition = lines[i].Substring(lines[i].LastIndexOf('('));
						cityPosition = cityPosition.Trim(charsToTrim).Replace(" ", "");
						Region.CityPosition[count] = cityPosition.Replace("y", "0");
						count += 1;
					}

					Console.WriteLine(Region.CityPosition[0]);
					Console.WriteLine(Region.CityPosition[1]);
				}
				if (lines[i].Contains("positions.AddResource(new Vector3"))
				{
					if (Region.ResoursePositionAndType == null)
					{
						Region.InitializeResoursePositionAndType();
						count = 0;
					}
					if (Region.ResoursePositionAndType != null)
					{
						string resoursePosition = lines[i].Substring(lines[i].LastIndexOf('('), lines[i].IndexOf(')') - lines[i].LastIndexOf('('));
						resoursePosition = resoursePosition.Trim(charsToTrim).Replace(" ", "");
						string resourseType = lines[i].Substring(lines[i].LastIndexOf('.') + 1);
						resourseType = resourseType.Trim(charsToTrim).Replace(" ", "");
						Region.ResoursePositionAndType[count] = resoursePosition.Replace("y", "0") + "; " + resourseType.Replace("y", "0");
						count += 1;
					}

					Console.WriteLine(Region.ResoursePositionAndType[0]);
					Console.WriteLine(Region.ResoursePositionAndType[1]);
				}
				if (lines[i].Contains("positions.TemplePosition = new Vector3"))
				{
					string templePosition = lines[i].Substring(lines[i].LastIndexOf('('));
					templePosition = templePosition.Trim(charsToTrim).Replace(" ", "");
					Region.TemplePosition = templePosition.Replace("y", "0");

					Console.WriteLine(Region.TemplePosition);
				}
				if (lines[i].Contains("positions.InfluenceTilePosition = new Vector3"))
				{
					string influenceTilePosition = lines[i].Substring(lines[i].LastIndexOf('('));
					influenceTilePosition = influenceTilePosition.Trim(charsToTrim).Replace(" ", "");
					Region.InfluenceTilePosition = influenceTilePosition.Replace("y", "0");

					Console.WriteLine(Region.InfluenceTilePosition);
				}
				if (lines[i].Contains("positions.TowerPosition = new Vector3("))
				{
					string towerPosition = lines[i].Substring(lines[i].LastIndexOf('('));
					towerPosition = towerPosition.Trim(charsToTrim).Replace(" ", "");
					Region.TowerPosition = towerPosition.Replace("y", "0");

					Console.WriteLine(Region.TowerPosition);
				}
				if (lines[i].Contains("positions.ArmyPosition = new Vector3"))
				{
					string armyPosition = lines[i].Substring(lines[i].LastIndexOf('('));
					armyPosition = armyPosition.Trim(charsToTrim).Replace(" ", "");
					Region.ArmyPosition = armyPosition.Replace("y", "0");

					Console.WriteLine(Region.ArmyPosition);
				}
				if (lines[i].Contains("positions.MarketPosition = new Vector3"))
				{
					string marketPosition = lines[i].Substring(lines[i].LastIndexOf('('));
					marketPosition = marketPosition.Trim(charsToTrim).Replace(" ", "");
					Region.MarketPosition = marketPosition.Replace("y", "0");

					Console.WriteLine(Region.MarketPosition);
				}
			}
		}

		static void WriteRegionTileInfo()
		{
			using StreamWriter file = new("RegionsInfo.txt");

			foreach (RegionTile region in Regions)
			{				
				file.WriteLine(region.Name);
				file.WriteLine(region.NumberOfVectors.ToString());
				
				for (int i = 0; i < region.NumberOfVectors; i++)
				{
					file.Write(region.Vertices[i].ToString() + ", ");
				}
				file.WriteLine();

				foreach (int angle in region.Triangles)
				{
					file.Write(angle.ToString() + ", ");
				}
				file.WriteLine();

				if (region.CityPosition != null)
				{
					if (region.CityPosition[0] != null)
					{
						file.Write("City Tiles: 1: " + region.CityPosition[0]);
					}
					if (region.CityPosition[1] != null)
					{
						file.Write("; 2: " + region.CityPosition[1]);
						file.WriteLine();
					}
					else file.WriteLine();
				}
				
				if (region.TemplePosition != null)
				{
					file.WriteLine("Temple Tile: " + region.TemplePosition);
				}

				if (region.MarketPosition != null)
				{
					file.WriteLine("Market Tile: " + region.MarketPosition);
				}

				if (region.ResoursePositionAndType != null)
				{
					if (region.ResoursePositionAndType[0] != null)
					{
						file.Write("Resourse Tiles: 1: " + region.ResoursePositionAndType[0]);
					}
					if (region.ResoursePositionAndType[1] != null)
					{
						file.Write("; 2: " + region.ResoursePositionAndType[1]);
						file.WriteLine();
					}
					else file.WriteLine();
				}
				
				if (region.TowerPosition != null)
				{
					file.WriteLine("Tower Tile: " + region.TowerPosition);
				}

				if (region.ArmyPosition != null)
				{
					file.WriteLine("Army Tile: " + region.ArmyPosition);
				}

				if (region.InfluenceTilePosition != null)
				{
					file.WriteLine("Influence Tile: " + region.InfluenceTilePosition);
				}
				file.WriteLine();
			}
		}
	}
}
