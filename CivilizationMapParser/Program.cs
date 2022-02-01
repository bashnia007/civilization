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

				if (lines[i].Contains("tile.name = "))
				{
					string name = lines[i].Substring(lines[i].IndexOf('"'));
					name = name.Trim(charsToTrim);
					Region.Name = name;
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
				file.WriteLine();

			}
		}
	}
}
