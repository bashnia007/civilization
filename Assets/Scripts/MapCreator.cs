using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using RegionInfo = Assets.Scripts.Regions.RegionInfo;

namespace Assets.Scripts
{
    public static class MapCreator
    {
        public static List<Region> Regions = new List<Region>();
        private static readonly List<RegionInfo> RegionsInfo = new List<RegionInfo>();

        public static void GenerateRegions()
        {
            try
            {
                string[] regionsInfoLines = File.ReadAllLines("Assets\\DataFiles\\RegionsInfo.txt");
                for (int i = 0; i < regionsInfoLines.Length; )
                {
                    GenerateRegion(regionsInfoLines, ref i);
                }
            }
            catch (FileNotFoundException)
            {
                Debug.LogError("Data file with regions was not found");
            }            
        }

        public static void DrawMap(Transform transform, Material material)
        {
            foreach (var regionInfo in RegionsInfo)
            {
                DrawRegion(regionInfo, transform, material);
            }
        }

        private static void GenerateRegion(string[] regionsInfoLines, ref int firstLine)
        {
            try
            {
                RegionInfo regionInfo = new RegionInfo();
                regionInfo.Name = regionsInfoLines[firstLine];
                regionInfo.VertexesCount = Convert.ToInt32(regionsInfoLines[firstLine + 1]);
                regionInfo.Vertexes = regionsInfoLines[firstLine + 2];
                regionInfo.Tries = regionsInfoLines[firstLine + 3];

                while (regionsInfoLines[firstLine++].Length != 0)
                {
                    var line = regionsInfoLines[firstLine];
                    if (line.StartsWith("Market")) regionInfo.Market = line;
                    if (line.StartsWith("Resource")) regionInfo.Resources = line;
                    if (line.StartsWith("Tower")) regionInfo.Tower = line;
                    if (line.StartsWith("Army")) regionInfo.Army = line;
                    if (line.StartsWith("Influence")) regionInfo.Influence = line;
                    if (line.StartsWith("City")) regionInfo.Cities = line;
                    if (line.StartsWith("Temple")) regionInfo.Temple = line;
                    if (line.StartsWith("Fleet")) regionInfo.Fleet = line;
                }

                RegionsInfo.Add(regionInfo);
            }
            catch(Exception)
            {
                Debug.LogError("Exception happened during region parsing");
            }
        }

        private static void DrawRegion(RegionInfo regionInfo, Transform transform, Material material)
        {
            GameObject tile = new GameObject();
            tile.transform.parent = transform;
            tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
            tile.transform.eulerAngles = new Vector3(-90, 0, 180);
            Mesh mesh = new Mesh();
            tile.AddComponent<MeshFilter>().mesh = mesh;
            tile.AddComponent<MeshRenderer>().material = material;
            int y = 0;

            mesh.vertices = regionInfo.GetVertexes();
            mesh.triangles = regionInfo.GetTries(); ;

            tile.layer = LayerMask.NameToLayer("MapTile");
            tile.AddComponent<MeshCollider>();

            tile.name = regionInfo.Name;

            Regions.Add(new Region(tile, regionInfo));
        }
    }
}
