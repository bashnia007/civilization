using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class Country
    {
        public string Name { get; }
        public Region CapitalRegion => Regions.First();

        public Material Material { get; }

        public List<Region> Regions { get; set; }
        public List<Unit> Units { get; set; }

        public Country(string name, Material material)
        {
            Name = name;
            Material = material;
            Regions = new List<Region>();
        }
    }
}
