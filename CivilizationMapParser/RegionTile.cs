using System.Collections.Generic;

namespace CivilizationMapParser
{
	public class RegionTile
	{
		public string Name;
		public int NumberOfVectors;
		public List<int> Triangles;
		public string[] Vertices;
		public string TemplePosition;
		public string[] CityPosition;
		public string InfluenceTilePosition;
		public string TowerPosition;
		public string ArmyPosition;
		public string[] ResourcePositionAndType;
		public string MarketPosition;
		public string FleetPosition;
		public const int MaxAmountOfCities = 2;
		public const int MaxAmountOfResourses = 2;

		public RegionTile()
		{
			Triangles = new List<int>();
		}

		public void InitializeVertices(int numberOfVertices)
		{
			Vertices = new string[numberOfVertices];
		}

		public void InitializeCityPosition()
		{
			CityPosition = new string[MaxAmountOfCities];
		}

		public void InitializeResourcePositionAndType()
		{
			ResourcePositionAndType = new string[MaxAmountOfResourses];
		}
	}

}
