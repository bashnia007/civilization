using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Country
    {
        public string Name { get; }
        public Region CapitalRegion => Regions.First();

        public List<Region> Regions { get; set; }
        public List<Unit> Units { get; set; }

        public Country(string name)
        {
            Name = name;
            Regions = new List<Region>();
        }
    }
}
