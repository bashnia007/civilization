using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Regions
{
    public class RegionInfo
    {
        public string Name { get; set; }
        public int VertexesCount { get; set; }
        public string Vertexes { get; set; }
        public string Tries { get; set; }
        public string Market { get; set; }
        public string Resources { get; set; }
        public string Tower { get; set; }
        public string Army { get; set; }
        public string Influence { get; set; }
        public string Temple { get; set; }
        public string Cities { get; set; }
        public string Fleet { get; set; }

        public Vector3[] GetVertexes()
        {
            var result = new Vector3[VertexesCount];

            string[] splitted = Vertexes.Replace("f", "").Split(new[] { ',' });

            for (int i = 0; i < VertexesCount; i++)
            {
                result[i] = new Vector3(
                    float.Parse(splitted[i * 3], CultureInfo.InvariantCulture.NumberFormat),
                    float.Parse(splitted[i * 3 + 1], CultureInfo.InvariantCulture.NumberFormat),
                    float.Parse(splitted[i * 3 + 2], CultureInfo.InvariantCulture.NumberFormat));
            }

            return result;
        }

        public int[] GetTries()
        {
            string[] splitted = Tries.Split(new[] { ',' });
            int[] result = new int[splitted.Length - 1];

            for (int i = 0; i < splitted.Length - 1; i++)
            {
                result[i] = int.Parse(splitted[i]);
            }

            return result;
        }

        public Vector3? GetMarket()
        {
            return ParseVector(Market);
        }

        public Vector3? GetTower()
        {
            return ParseVector(Tower);
        }

        public Vector3? GetArmy()
        {
            return ParseVector(Army);
        }

        public Vector3? GetInfluence()
        {
            return ParseVector(Influence);
        }

        public Vector3? GetTemple()
        {
            return ParseVector(Temple);
        }

        public Vector3? GetFleet()
        {
            return ParseVector(Fleet);
        }

        public List<Vector3?> GetCities()
        {
            var result = new List<Vector3?>();
            if (Cities == null) return result;

            int count = Cities.Count(x => x == ':')-1;
            switch (count)
            {
                case 1:
                    result.Add(ParseVector(Cities));
                    break;
                case 2:
                    int position = Cities.LastIndexOf(':');
                    result.Add(ParseVector(Cities.Substring(0, position-3)));
                    result.Add(ParseVector(Cities.Substring(position)));
                    break;
            }
            return result;
        }

        private Vector3? ParseVector(string str)
        {
            if (str == null)
                return null;
            int startPosition = str.LastIndexOf(':');
            string substr = str.Replace("f", "").Substring(startPosition+1);

            string[] coords = substr.Split(',');
            float x = float.Parse(coords[0], CultureInfo.InvariantCulture.NumberFormat);
            float y = float.Parse(coords[1], CultureInfo.InvariantCulture.NumberFormat);
            float z = float.Parse(coords[2], CultureInfo.InvariantCulture.NumberFormat);

            return new Vector3(x, y, z);
        }
    }

}
