using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class InternalPositions
    {
        public InternalPositions()
        {
            ResourcesPositions = new List<Vector3>();
            CitiesPositions = new List<Vector3>();
        }
        public Vector3 InfluenceTilePosition { get; set; }
        public Vector3 TowerPosition { get; set; }
        public List<Vector3> ResourcesPositions { get; set; }
        public List<Vector3> CitiesPositions { get; set; }
        public Vector3 MarketPosition { get; set; }
        public Vector3 TemplePosition { get; set; }

        public void AddResource(Vector3 resource)
        {
            ResourcesPositions.Add(resource);
        }

        public void AddCity(Vector3 city)
        {
            CitiesPositions.Add(city);
        }
    }
}
