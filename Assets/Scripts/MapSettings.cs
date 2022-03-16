using System;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public class MapSettings
    {
        public static int CitiesAvailable;
        public static int ResourcesAvailable;
        public static int MarketsAvailable;
        public static int TemplesAvailable;

        public static Dictionary<Type, int> UnitsCount = new Dictionary<Type, int>();
        
        public MapSettings(int players)
        {
            switch (players)
            {
                case 3:
                    ResourcesAvailable = 18;
                    CitiesAvailable = 8;
                    MarketsAvailable = 8;
                    TemplesAvailable = 4;
                    break;
                case 4:
                    ResourcesAvailable = 23;
                    CitiesAvailable = 10;
                    MarketsAvailable = 10;
                    TemplesAvailable = 5;
                    break;
                case 5:
                    ResourcesAvailable = 28;
                    CitiesAvailable = 12;
                    MarketsAvailable = 12;
                    TemplesAvailable = 6;
                    break;
            }

            UnitsCount.Add(typeof(Tower), 5);
            UnitsCount.Add(typeof(Fleet), 5);
            UnitsCount.Add(typeof(Legion), 8);
        }
    }
}
