using Assets.Scripts.Enums;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class InternalPositions
    {
        public InternalPositions()
        {
            ResourcesPositions = new Dictionary<Vector3, Resource>();
            CitiesPositions = new List<Vector3>();
        }
        public Vector3 InfluenceTilePosition { get; set; }
        public Vector3 TowerPosition { get; set; }
        public Dictionary<Vector3, Resource> ResourcesPositions { get; private set; }
        public List<Vector3> CitiesPositions { get; private set; }
        public Vector3 MarketPosition { get; set; }
        public Vector3 TemplePosition { get; set; }
        public Vector3 ArmyPosition { get; set; }
        public Vector3 FleetPosition { get; set; }

        public void AddResource(Vector3 position, Resource resource)
        {
            ResourcesPositions.Add(position, resource);
        }

        public void AddCity(Vector3 city)
        {
            CitiesPositions.Add(city);
        }
    }
}
