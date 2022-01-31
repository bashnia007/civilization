using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CivilizationMapParser
{
	class Program
	{
		static void Main(string[] args)
		{
			ReadSourceFile(AskForPath());
			WriteRegionTileInfo();
		}

		public static List<RegionTile> Regions = new List<RegionTile>();

		public static string AskForPath()
		{
			string path;
			Console.WriteLine("Provide path to Source file below:");
			return path = Console.ReadLine();
		}

		public static void ReadSourceFile(string path)
		{
			string[] lines = File.ReadAllLines(path);
			RegionTile Region = null;

			for (int i = 0; i < lines.Length; i++)
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

				if (Region != null && lines[i].Contains("tile.name = "))
				{
					string name = lines[i].Substring(lines[i].IndexOf('"'));
					name = name.Trim(' ', ';', '"');
					Region.Name = name;

					Console.WriteLine();
					Console.WriteLine(Region.Name);
					Console.WriteLine();
				}
				if (Region != null && lines[i].Contains("int[] tris = new int[]"))
				{
					string trianglesString = lines[i].Substring(32);
					trianglesString = trianglesString.Trim(' ', '}', '{', ';').Replace(" ", "");
					Console.WriteLine(trianglesString);
					string[] numAsStr = trianglesString.Split(',');

					Region.Triangles = new List<int>();
					for (int k = 0; k < numAsStr.Length - 1; k++)
					{
						int n = Convert.ToInt32(numAsStr[k]);
						Region.Triangles.Add(n);
					}

					for (int y = 0; y < Region.Triangles.Count - 1; y++)
					{
						Console.Write(Region.Triangles[y] + " ");
					}
				}
				if (lines[i].Contains("Vector3[] vertices = new Vector3"))
				{
					string numOfVString = lines[i].Substring(40);
					int numOfVectors = Convert.ToInt32(numOfVString.Trim(' ', ']', '[', ';').Replace(" ", ""));
					Region.NumberOfVectors = numOfVectors;

					Console.WriteLine(Region.NumberOfVectors);
				}
				if (Region != null && lines[i].Contains("vertices["))
				{
					string vertices = lines[i].Substring(lines[i].IndexOf('('), lines[i].IndexOf(')') - lines[i].IndexOf('('));
					int indexOfVLength = lines[i].IndexOf(']') - lines[i].IndexOf('[') - 1;
					int indexOfVertice = Convert.ToInt32(lines[i].Substring(lines[i].IndexOf('[') + 1, indexOfVLength));
					vertices = vertices.Trim(' ', ')', '(', ';').Replace("y", "0");

					if (Region.Vertices == null)
					{
						Region.Vertices = new string[Region.NumberOfVectors];
						Region.Vertices[indexOfVertice] = vertices;

						Console.Write(indexOfVertice + ": " + Region.Vertices[indexOfVertice] + "; ");
					}
					else if (Region.Vertices.Where(x => x == null).Count() == 0)
					{
						Console.WriteLine();
					}
					else
					{
						Region.Vertices[indexOfVertice] = vertices;

						Console.Write(indexOfVertice + ": " + Region.Vertices[indexOfVertice] + "; ");
					}
				}
			}
		}

		public static void WriteRegionTileInfo()
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
