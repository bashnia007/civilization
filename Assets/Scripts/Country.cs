﻿using Assets.Scripts.Buildings;
using System;
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
        public List<Building> Buildings { get; set; }

        public Country(string name, Material material)
        {
            Name = name;
            Material = material;
            Regions = new List<Region>();
            Units = new List<Unit>();
            Buildings = new List<Building>();
        }
        public bool AddUnit(Unit unit, Region region)
        {
            Type type = unit.GetType();
            if (Units.Where(u => u.GetType() == type).Count() < MapSettings.UnitsCount[type])
            {
                unit.Location = region;
                Units.Add(unit);
                return true;
            }

            return false;
        }

        public bool ConstructBuilding(Building building, Region region, Vector3 position)
        {
            if (building.Add())
            {
                building.Position = position;
                Buildings.Add(building);
                return true;
            }
            return false;
        }
    }
}
