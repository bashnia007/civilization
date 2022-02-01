using System.Collections.Generic;

namespace CivilizationMapParser
{
	public class RegionTile
	{
		public string Name;
		public int NumberOfVectors;
		public List<int> Triangles;
		public string[] Vertices;

		public RegionTile()
		{
			Triangles = new List<int>();
		}

		public void InitializeVertices(int numberOfVertices)
		{
			Vertices = new string[numberOfVertices];
		}
	}

}
