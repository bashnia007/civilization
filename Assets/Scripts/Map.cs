using Assets.Scripts;
using Assets.Scripts.Enums;
using Assets.Scripts.Regions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Map : MonoBehaviour
{
    [Header("Art stuff")]
    [SerializeField] private Material material;
    [SerializeField] private Material greenColor;
    [SerializeField] private Material blueColor;
    [SerializeField] private Material redColor;
    [SerializeField] private Material yellowColor;
    [SerializeField] private Material whiteColor;

    [SerializeField] private GameObject influenceTile;
    [SerializeField] private GameObject resourceTile;
    [SerializeField] private GameObject cityTile;
    [SerializeField] private GameObject templeTile;
    [SerializeField] private GameObject marketTile;
    [SerializeField] private GameObject armyFigure;
    [SerializeField] private GameObject towerFigure;
    [SerializeField] private GameObject fleetFigure;

    private Camera currentCamera;
    private GameObject hoveredMapTile;

    public static List<Country> Countries = new List<Country>();

    void Start()
    {
        MapCreator.GenerateRegions();
        MapCreator.DrawMap(transform, material);

        PrepareInitialSets();
        DrawInitialSets();
    }
    /*
    private void PlaceFigures()
    {
        foreach (Region region in Regions)
        {
            var influence = Instantiate(influenceTile, region.Area.transform.localPosition + region.InternalPositions.InfluenceTilePosition, Quaternion.Euler(90, 0, 0));
            influence.GetComponent<MeshRenderer>().material = greenColor;

            foreach(var resources in region.InternalPositions.ResourcesPositions)
            {
                var resource = Instantiate(resourceTile, region.Area.transform.localPosition + resources.Key, Quaternion.identity);
            }

            foreach (var cities in region.InternalPositions.CitiesPositions)
            {
                var city = Instantiate(cityTile, region.Area.transform.localPosition + cities, Quaternion.identity);
            }

            if (region.InternalPositions.MarketPosition != Vector3.zero)
            {
                var market = Instantiate(marketTile, region.Area.transform.localPosition + region.InternalPositions.MarketPosition, Quaternion.identity);
            }

            if (region.InternalPositions.TemplePosition != Vector3.zero)
            {
                var temple = Instantiate(templeTile, region.Area.transform.localPosition + region.InternalPositions.TemplePosition, Quaternion.identity);
            }

            if (region.InternalPositions.ArmyPosition != Vector3.zero)
            {
                var warrior = Instantiate(armyFigure, region.Area.transform.localPosition + region.InternalPositions.ArmyPosition, Quaternion.Euler(0, -60, 0));
            }

            if (region.InternalPositions.TowerPosition != Vector3.zero)
            {
                var tower = Instantiate(towerFigure, region.Area.transform.localPosition + region.InternalPositions.TowerPosition, Quaternion.identity);
            }

            if (region.InternalPositions.FleetPosition != Vector3.zero)
            {
                var fleet = Instantiate(fleetFigure, region.Area.transform.localPosition + region.InternalPositions.FleetPosition, Quaternion.Euler(0, 0, 45));

                foreach (Transform child in fleet.transform)
                {
                    child.GetComponent<MeshRenderer>().material = greenColor;
                }
            }
        }
    }
    */
    

    private void Update()
    {
        if (!currentCamera)
        {
            currentCamera = Camera.main;
            return;
        }

        RaycastHit info;
        Ray ray = currentCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out info, 100, LayerMask.GetMask("MapTile", "Hover")))
        {
            GameObject hited = info.transform.gameObject;
            //GameObject mapTile = mapTiles.FirstOrDefault(m => m.name == hited.name);

            if (hoveredMapTile == null)
            {
                hited.layer = LayerMask.NameToLayer("Hover");
                hoveredMapTile = hited;

            }
        }
        else
        {
            if (hoveredMapTile != null)
            {
                hoveredMapTile.layer = LayerMask.NameToLayer("MapTile");
                hoveredMapTile = null;
            }
        }
    }

    private void PrepareInitialSets()
    {
        var greece = new Country("Greece", blueColor);
        greece.Regions.Add(MapCreator.Regions.First(r => r.Area.name == "Greece"));
        greece.Regions.Add(MapCreator.Regions.First(r => r.Area.name == "Makedonia"));
        greece.Regions.Add(MapCreator.Regions.First(r => r.Area.name == "Frakia"));

        var rome = new Country("Rome", greenColor);
        rome.Regions.Add(MapCreator.Regions.First(r => r.Area.name == "Italia"));
        rome.Regions.Add(MapCreator.Regions.First(r => r.Area.name == "Apulea"));
        rome.Regions.Add(MapCreator.Regions.First(r => r.Area.name == "Lombardia"));

        var carthago = new Country("Carthago", redColor);
        carthago.Regions.Add(MapCreator.Regions.First(r => r.Area.name == "Carthago"));
        carthago.Regions.Add(MapCreator.Regions.First(r => r.Area.name == "Numidia"));
        carthago.Regions.Add(MapCreator.Regions.First(r => r.Area.name == "West Mavritania"));

        var babylon = new Country("Babylon", whiteColor);
        babylon.Regions.Add(MapCreator.Regions.First(r => r.Area.name == "Babylon"));
        babylon.Regions.Add(MapCreator.Regions.First(r => r.Area.name == "Mesopotamia"));
        babylon.Regions.Add(MapCreator.Regions.First(r => r.Area.name == "Aravia"));

        var egypt = new Country("Egypt", yellowColor);
        egypt.Regions.Add(MapCreator.Regions.First(r => r.Area.name == "Lower Egypt"));
        egypt.Regions.Add(MapCreator.Regions.First(r => r.Area.name == "Upper Egypt"));
        egypt.Regions.Add(MapCreator.Regions.First(r => r.Area.name == "South Kirenaika"));

        Countries.Add(greece);
        Countries.Add(rome);
        Countries.Add(carthago);
        Countries.Add(babylon);
        Countries.Add(egypt);
    }

    private void DrawInitialSets()
    {
        foreach (var country in Countries)
        {
            foreach (var region in country.Regions)
            {
                DrawInfluence(region, country.Material);
            }
        }
    }

    private void DrawInfluence(Region region, Material material)
    {
        var influence = Instantiate(influenceTile, region.Area.transform.localPosition + region.Info.GetInfluence().Value, Quaternion.Euler(90, 0, 0));
        influence.GetComponent<MeshRenderer>().material = material;
        influence.transform.parent = region.Area.transform;
    }

}
