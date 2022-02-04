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
			char[] charsToTrim = new char[] { ' ', ';', '"', '(', ')', '[', ']', '{', '}' };

			for (int i = 0; i < lines.Length; i++)
			{
				InitializeRegion(ref Region);
				
				ReadRegionName(lines[i], charsToTrim, Region);
				ReadTriangles(lines[i], charsToTrim, Region);
				ReadVectors(lines[i], charsToTrim, Region);

				ReadCityPosition(lines[i], charsToTrim, Region, ref count);
				ReadResoursePosition(lines[i], charsToTrim, Region, ref count);
				ReadTemplePosition(lines[i], charsToTrim, Region);
				ReadInfluenceTilePosition(lines[i], charsToTrim, Region);
				ReadTowerPosition(lines[i], charsToTrim, Region);
				ReadArmyPosition(lines[i], charsToTrim, Region);
				ReadMarketPosition(lines[i], charsToTrim, Region);
			}
		}

		static void InitializeRegion(ref RegionTile Region)
		{
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
		}

		static void ReadRegionName(string line, char[] charsToTrim, RegionTile Region)
		{
			if (line.Contains("tile.name = "))
			{
				string name = line.Substring(line.IndexOf('"'));
				name = name.Trim(charsToTrim);
				Region.Name = name;
			}
		}

		static void ReadTriangles(string line, char[] charsToTrim, RegionTile Region)
		{
			if (line.Contains("int[] tris = new int[]"))
			{
				string[] numAsStr = ExtractDataFromLine(line, '{', charsToTrim).Split(',');

				for (int k = 0; k < numAsStr.Length - 1; k++)
				{
					int n = Convert.ToInt32(numAsStr[k]);
					Region.Triangles.Add(n);
				}
			}
		}

		static void ReadVectors(string line, char[] charsToTrim, RegionTile Region)
		{
			if (line.Contains("Vector3[] vertices = new Vector3"))
			{
				Region.NumberOfVectors = Convert.ToInt32(ExtractDataFromLine(line, '[', charsToTrim));
			}
			if (line.Contains("vertices["))
			{
				string vertices = line.Substring(line.IndexOf('('), line.IndexOf(')') - line.IndexOf('('));
				int indexOfVLength = line.IndexOf(']') - line.IndexOf('[') - 1;
				string pieceOfLineWithIndexOfVertice = line.Substring(line.IndexOf('[') + 1, indexOfVLength);
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
		}

		static void ReadCityPosition(string line, char[] charsToTrim, RegionTile Region, ref int count)
		{
			if (line.Contains("positions.AddCity(new Vector3"))
			{
				if (Region.CityPosition == null)
				{
					Region.InitializeCityPosition();
					count = 0;

				}
				if (Region.CityPosition != null)
				{
					Region.CityPosition[count] = ExtractDataFromLine(line, '(', charsToTrim);
					count += 1;
				}
			}
		}

		static void ReadResoursePosition(string line, char[] charsToTrim, RegionTile Region, ref int count)
		{
			if (line.Contains("positions.AddResource(new Vector3"))
			{
				if (Region.ResoursePositionAndType == null)
				{
					Region.InitializeResoursePositionAndType();
					count = 0;
				}
				if (Region.ResoursePositionAndType != null)
				{
					string resoursePosition = line.Substring(line.LastIndexOf('('), line.IndexOf(')') - line.LastIndexOf('('));
					resoursePosition = resoursePosition.Trim(charsToTrim).Replace(" ", "");
					string resourseType = line.Substring(line.LastIndexOf('.') + 1);
					resourseType = resourseType.Trim(charsToTrim).Replace(" ", "");
					Region.ResoursePositionAndType[count] = resoursePosition.Replace("y", "0") + "; " + resourseType.Replace("y", "0");
					count += 1;
				}
			}
		}

		static void ReadTemplePosition(string line, char[] charsToTrim, RegionTile Region)
		{
			if (line.Contains("positions.TemplePosition = new Vector3"))
			{
				Region.TemplePosition = ExtractDataFromLine(line, '(', charsToTrim);
			}
		}

		static void ReadInfluenceTilePosition(string line, char[] charsToTrim, RegionTile Region)
		{
			if (line.Contains("positions.InfluenceTilePosition = new Vector3"))
			{
				Region.InfluenceTilePosition = ExtractDataFromLine(line, '(', charsToTrim);
			}
		}

		static void ReadTowerPosition(string line, char[] charsToTrim, RegionTile Region)
		{
			if (line.Contains("positions.TowerPosition = new Vector3("))
			{
				Region.TowerPosition = ExtractDataFromLine(line, '(', charsToTrim);
			}
		}

		static void ReadArmyPosition(string line, char[] charsToTrim, RegionTile Region)
		{
			if (line.Contains("positions.ArmyPosition = new Vector3"))
			{
				Region.ArmyPosition = ExtractDataFromLine(line, '(', charsToTrim);
			}
		}

		static void ReadMarketPosition(string line, char[] charsToTrim, RegionTile Region)
		{
			if (line.Contains("positions.MarketPosition = new Vector3"))
			{
				Region.MarketPosition = ExtractDataFromLine(line, '(', charsToTrim);
			}
		}

		static string ExtractDataFromLine(string line, char character, char[] charsToTrim)
		{
			string position = line.Substring(line.LastIndexOf(character));
			position = position.Trim(charsToTrim).Replace(" ", "");
			return position.Replace("y", "0");
		}

		static void WriteRegionTileInfo()
		{
			using StreamWriter file = new("RegionsInfo.txt");

			foreach (RegionTile region in Regions)
			{
				WriteRegionName(file, region);
				WriteVectors(file, region);
				WriteTriangles(file, region);

				WriteCityPosition(file, region);
				WriteTemplePosition(file, region);
				WriteMarketPosition(file, region);
				WriteResoursePositionAndType(file, region);
				WriteTowerPosition(file, region);
				WriteArmyPosition(file, region);
				WriteInfluenceTilePosition(file, region);

				file.WriteLine();
			}
		}

		static void WriteRegionName(StreamWriter file, RegionTile region)
		{
			file.WriteLine(region.Name);
			file.WriteLine(region.NumberOfVectors.ToString());
		}

		static void WriteVectors(StreamWriter file, RegionTile region)
		{
			for (int i = 0; i < region.NumberOfVectors; i++)
			{
				file.Write(region.Vertices[i].ToString() + ", ");
			}
			file.WriteLine();
		}

		static void WriteTriangles(StreamWriter file, RegionTile region)
		{
			foreach (int angle in region.Triangles)
			{
				file.Write(angle.ToString() + ", ");
			}
			file.WriteLine();
		}

		static void WriteCityPosition(StreamWriter file, RegionTile region)
		{
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
		}

		static void WriteTemplePosition(StreamWriter file, RegionTile region)
		{
			if (region.TemplePosition != null)
			{
				file.WriteLine("Temple Tile: " + region.TemplePosition);
			}
		}
		static void WriteMarketPosition(StreamWriter file, RegionTile region)
		{
			if (region.MarketPosition != null)
			{
				file.WriteLine("Market Tile: " + region.MarketPosition);
			}
		}

		static void WriteResoursePositionAndType(StreamWriter file, RegionTile region)
		{
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
		}

		static void WriteTowerPosition(StreamWriter file, RegionTile region)
		{
			if (region.TowerPosition != null)
			{
				file.WriteLine("Tower Tile: " + region.TowerPosition);
			}
		}

		static void WriteArmyPosition(StreamWriter file, RegionTile region)
		{
			if (region.ArmyPosition != null)
			{
				file.WriteLine("Army Tile: " + region.ArmyPosition);
			}
		}

		static void WriteInfluenceTilePosition(StreamWriter file, RegionTile region)
		{
			if (region.InfluenceTilePosition != null)
			{
				file.WriteLine("Influence Tile: " + region.InfluenceTilePosition);
			}
		}
	}
}
