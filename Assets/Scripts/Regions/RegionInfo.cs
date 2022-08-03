using Assets.Scripts.Buildings;
using Assets.Scripts.Enums;
using System;
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

        public List<City> GetCities(GameObject cityTile)
        {
            var result = new List<City>();
            if (Cities == null) return result;

            string[] substrings = Cities.Split(new[] { ':', ';' });

            if (substrings.Length == 5)
            {
                var city1 = ParseToken<City>(substrings[1], substrings[2]);
                city1.Tile = cityTile;
                result.Add(city1);

                var city2 = ParseToken<City>(substrings[3], substrings[4]);
                city2.Tile = cityTile;
                result.Add(city2);
            }
            else if (substrings.Length == 3)
            {
                var city1 = ParseToken<City>(substrings[1], substrings[2]);
                city1.Tile = cityTile;
                result.Add(city1);
            }
            return result;
        }

        public List<Resource> GetResources(GameObject resourceTile)
        {
            var result = new List<Resource>();
            if (Resources == null) return result;

            string[] substrings = Resources.Split(new[] { ':', ';' });

            if (substrings.Length == 4)
            {
                Resource resource = ParseToken<Resource>(substrings[1], substrings[2]);
                resource.Tile = resourceTile;
                resource.ResourceType = (ResourceType)Enum.Parse(typeof(ResourceType), substrings[3]);
                result.Add(resource);
            }
            else if (substrings.Length == 7)
            {
                Resource resource1 = ParseToken<Resource>(substrings[1], substrings[2]);
                resource1.Tile = resourceTile;
                resource1.ResourceType = (ResourceType)Enum.Parse(typeof(ResourceType), substrings[3]);
                result.Add(resource1);

                Resource resource2 = ParseToken<Resource>(substrings[4], substrings[5]);
                resource2.Tile = resourceTile;
                resource2.ResourceType = (ResourceType)Enum.Parse(typeof(ResourceType), substrings[6]);
                result.Add(resource2);
            }
            return result;
        }

        private T ParseToken<T>(string id, string coordsStr) where T : Building , new()
        {
            T building = new T();
            building.Id = int.Parse(id);
            string substr = coordsStr.Replace("f", "");
            string[] coords = substr.Split(',');
            float x = float.Parse(coords[0], CultureInfo.InvariantCulture.NumberFormat);
            float y = float.Parse(coords[1], CultureInfo.InvariantCulture.NumberFormat);
            float z = float.Parse(coords[2], CultureInfo.InvariantCulture.NumberFormat);

            building.Position = new Vector3(x, y, z);

            return building;
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
