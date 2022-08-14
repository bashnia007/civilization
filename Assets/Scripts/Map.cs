using Assets.Scripts;
using Assets.Scripts.Buildings;
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

    [SerializeField] private GameObject placeTile;

    private Camera currentCamera;
    private GameObject hoveredMapTile;
    private GameObject hoveredPlaceTile;

    public static List<Country> Countries = new List<Country>();
    public static List<GameObject> Places = new List<GameObject>();
    public static GameObject Highligthed;
    public static GameObject HighligthedPlace;
    public static Country CurrentCountry;

    void Start()
    {
        MapCreator.GenerateRegions();
        MapCreator.DrawMap(transform, material);
        DrawInitialPlaces();
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

        if (Shop.AdministrationToBuild || Shop.LegionToBuild || Shop.ShipToBuild || Shop.TowerToBuild || Shop.MarketToBuild || Shop.TempleToBuild)
        {
            HighligtHoverRegion();
            BuildOnMap();
        } 
        else if (Shop.ResourceToBuild || Shop.CityToBuild)
        {
            HighlightHoverResource();
            BuildOnMap();
        }
    }

    private void DrawInitialPlaces()
    {
        foreach (var region in MapCreator.Regions)
        {
            var resources = region.Info.GetResources(resourceTile);
            var cities = region.Info.GetCities(resourceTile);

            foreach (var resource in resources)
            {
                var buildingObj = Instantiate(placeTile, region.Area.transform.localPosition + resource.Position, Quaternion.identity);
                buildingObj.transform.parent = region.Area.transform;
                buildingObj.layer = LayerMask.NameToLayer("PlaceTile");
                buildingObj.name = resource.Id.ToString();
                Places.Add(buildingObj);
            }

            foreach (var city in cities)
            {
                var buildingObj = Instantiate(placeTile, region.Area.transform.localPosition + city.Position, Quaternion.identity);
                buildingObj.transform.parent = region.Area.transform;
                buildingObj.layer = LayerMask.NameToLayer("PlaceTile");
                buildingObj.name = city.Id.ToString();
                Places.Add(buildingObj);
            }
        }
    }

    private void HighligtHoverRegion()
    {
        RaycastHit info;
        Ray ray = currentCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out info, 100, LayerMask.GetMask("MapTile", "Hover")))
        {
            Highligthed = info.transform.gameObject;

            if (hoveredMapTile == null)
            {
                Highligthed.layer = LayerMask.NameToLayer("Hover");
                hoveredMapTile = Highligthed;
            }
            else
            {
                if (hoveredMapTile.name != Highligthed.name)
                {
                    hoveredMapTile.layer = LayerMask.NameToLayer("MapTile");

                    Highligthed.layer = LayerMask.NameToLayer("Hover");
                    hoveredMapTile = Highligthed;
                }
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

    private void HighlightHoverResource()
    {
        RaycastHit info;
        Ray ray = currentCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out info, 100, LayerMask.GetMask("PlaceTile", "HoverTile")))
        {
            HighligthedPlace = info.transform.gameObject;

            if (hoveredPlaceTile == null)
            {
                HighligthedPlace.layer = LayerMask.NameToLayer("HoverTile");
                hoveredPlaceTile = HighligthedPlace;
            }
            else
            {
                if (hoveredPlaceTile.name != HighligthedPlace.name)
                {
                    hoveredPlaceTile.layer = LayerMask.NameToLayer("PlaceTile");

                    HighligthedPlace.layer = LayerMask.NameToLayer("HoverTile");
                    hoveredPlaceTile = HighligthedPlace;
                }
            }
        }
        else
        {
            if (hoveredPlaceTile != null)
            {
                hoveredPlaceTile.layer = LayerMask.NameToLayer("PlaceTile");
                hoveredPlaceTile = null;
            }
        }
    }

    private void BuildOnMap()
    {
        if (!Input.GetMouseButtonDown(0) || (Highligthed == null && HighligthedPlace == null))
        {
            return;
        }
        // TODO add validation
        if (Shop.AdministrationToBuild)
        {
            AddInfluenceToken();
        }
        if (Shop.LegionToBuild)
        {
            AddLegion();
        }
        if (Shop.ShipToBuild)
        {
            AddShip();
        }
        if (Shop.TowerToBuild)
        {
            AddTower();
        }
        if (Shop.ResourceToBuild)
        {
            AddResource();
        }
        if (Shop.CityToBuild)
        {
            AddCity();
        }
        if (Shop.MarketToBuild)
        {
            AddMarket();
        }
        if (Shop.TempleToBuild)
        {
            AddTemple();
        }
    }

    private void PrepareInitialSets()
    {
        MapSettings map = new MapSettings(5);

        var greece = new Country("Greece", blueColor);
        greece.Regions.Add(MapCreator.Regions.First(r => r.Area.name == "Greece"));
        greece.Regions.Add(MapCreator.Regions.First(r => r.Area.name == "Makedonia"));
        greece.Regions.Add(MapCreator.Regions.First(r => r.Area.name == "Frakia"));
        greece.AddUnit(new Tower(), greece.CapitalRegion);
        foreach (var city in greece.Regions[1].Info.GetResources(resourceTile))
        {
            greece.AddBuilding(city);
        }

        var rome = new Country("Rome", greenColor);
        rome.Regions.Add(MapCreator.Regions.First(r => r.Area.name == "Italia"));
        rome.Regions.Add(MapCreator.Regions.First(r => r.Area.name == "Apulea"));
        rome.Regions.Add(MapCreator.Regions.First(r => r.Area.name == "Lombardia"));
        rome.AddUnit(new Tower(), rome.CapitalRegion);
        foreach (var resource in rome.Regions[1].Info.GetResources(resourceTile))
        {
            rome.AddBuilding(resource);
        }

        var carthago = new Country("Carthago", redColor);
        carthago.Regions.Add(MapCreator.Regions.First(r => r.Area.name == "Carthago"));
        carthago.Regions.Add(MapCreator.Regions.First(r => r.Area.name == "Numidia"));
        carthago.Regions.Add(MapCreator.Regions.First(r => r.Area.name == "West Mavritania"));
        carthago.AddUnit(new Tower(), carthago.CapitalRegion);
        foreach (var resource in carthago.Regions[1].Info.GetResources(resourceTile))
        {
            carthago.AddBuilding(resource);
        }

        var babylon = new Country("Babylon", whiteColor);
        babylon.Regions.Add(MapCreator.Regions.First(r => r.Area.name == "Babylon"));
        babylon.Regions.Add(MapCreator.Regions.First(r => r.Area.name == "Mesopotamia"));
        babylon.Regions.Add(MapCreator.Regions.First(r => r.Area.name == "Aravia"));
        babylon.AddUnit(new Tower(), babylon.CapitalRegion);
        foreach (var resource in babylon.Regions[1].Info.GetResources(resourceTile))
        {
            babylon.AddBuilding(resource);
        }

        var egypt = new Country("Egypt", yellowColor);
        egypt.Regions.Add(MapCreator.Regions.First(r => r.Area.name == "Lower Egypt"));
        egypt.Regions.Add(MapCreator.Regions.First(r => r.Area.name == "Upper Egypt"));
        egypt.Regions.Add(MapCreator.Regions.First(r => r.Area.name == "South Kirenaika"));
        egypt.AddUnit(new Tower(), egypt.CapitalRegion);
        foreach (var city in egypt.Regions[1].Info.GetCities(cityTile))
        {
            egypt.AddBuilding(city);
        }
        foreach (var resource in egypt.Regions[1].Info.GetResources(resourceTile))
        {
            egypt.AddBuilding(resource);
        }

        Countries.Add(greece);
        Countries.Add(rome);
        Countries.Add(carthago);
        Countries.Add(babylon);
        Countries.Add(egypt);

        CurrentCountry = Countries[0];

        AddInitialTokens();
    }

    private void AddInitialTokens()
    {
        foreach (var country in Countries)
        {
            foreach (var city in country.CapitalRegion.Info.GetCities(cityTile))
            {
                country.AddBuilding(city);
            }

            foreach (var resource in country.CapitalRegion.Info.GetResources(resourceTile))
            {
                country.AddBuilding(resource);
            }
        }
    }

    private void DrawInitialSets()
    {
        foreach (var country in Countries)
        {
            foreach (var unit in country.Units)
            {
                DrawTower(unit.Location, country.Material);
            }
            foreach (var region in country.Regions)
            {
                DrawInfluence(region, country.Material);

                foreach (var building in country.Buildings)
                {
                    DrawBuilding(region, building);
                }
            }
        }
    }

    private void DrawInfluence(Region region, Material material)
    {
        var influence = Instantiate(influenceTile, region.Area.transform.localPosition + region.Info.GetInfluence().Value, Quaternion.Euler(90, 0, 0));
        influence.GetComponent<MeshRenderer>().material = material;
        influence.transform.parent = region.Area.transform;
    }

    private void DrawMarket(Region region)
    {
        var market = Instantiate(marketTile, region.Area.transform.localPosition + region.Info.GetMarket().Value, Quaternion.identity);
        market.transform.parent = region.Area.transform;
    }

    private void DrawTemple(Region region)
    {
        var temple = Instantiate(templeTile, region.Area.transform.localPosition + region.Info.GetTemple().Value, Quaternion.identity);
        temple.transform.parent = region.Area.transform;
    }

    private void DrawTower(Region region, Material material)
    {
        var tower = Instantiate(towerFigure, region.Area.transform.localPosition + region.Info.GetTower().Value, Quaternion.identity);
        foreach (var mesh in tower.GetComponentsInChildren<MeshRenderer>())
        {
            mesh.material = material;
        }
        tower.transform.parent = region.Area.transform;
    }

    private void DrawLegion(Region region)
    {
        var legion = Instantiate(armyFigure, region.Area.transform.localPosition + region.Info.GetArmy().Value, Quaternion.Euler(0, -60, 0));
        legion.transform.parent = region.Area.transform;
    }

    private void DrawFleet(Region region, Material material)
    {
        var fleet = Instantiate(fleetFigure, region.Area.transform.localPosition + region.Info.GetFleet().Value, Quaternion.Euler(0, 0, 45));
        fleet.GetComponent<MeshRenderer>().material = material;
        foreach (Transform child in fleet.transform)
        {
            child.GetComponent<MeshRenderer>().material = material;
        }
        fleet.transform.parent = region.Area.transform;
    }

    private void DrawBuilding(Region region, Building building)
    {
        var buildingObj = Instantiate(building.Tile, region.Area.transform.localPosition + building.Position, Quaternion.identity);
        buildingObj.transform.parent = region.Area.transform;
    }

    private void AddResource()
    {
        var regionGo = HighligthedPlace.transform.parent.gameObject;
        var region = MapCreator.Regions.First(r => r.Area.name == regionGo.name);
        var resources = region.Info.GetResources(resourceTile);
        var building = resources.First(r => r.Id.ToString() == HighligthedPlace.name);
        CurrentCountry.AddBuilding(building);
        DrawBuilding(region, building);
    }

    private void AddCity()
    {
        var regionGo = HighligthedPlace.transform.parent.gameObject;
        var region = MapCreator.Regions.First(r => r.Area.name == regionGo.name);
        var cities = region.Info.GetCities(cityTile);
        var building = cities.First(r => r.Id.ToString() == HighligthedPlace.name);
        CurrentCountry.AddBuilding(building);
        DrawBuilding(region, building);
    }

    public void AddInfluenceToken()
    {
        var region = MapCreator.Regions.First(r => r.Area.name == Map.Highligthed.name);
        CurrentCountry.Regions.Add(region);
        DrawInfluence(region, CurrentCountry.Material);
    }

    public void AddMarket()
    {
        var region = CurrentCountry.Regions.First(r => r.Area.name == Highligthed.name);
        region.HasMarket = true;
        DrawMarket(region);
    }

    public void AddTemple()
    {
        var region = CurrentCountry.Regions.First(r => r.Area.name == Highligthed.name);
        region.HasTemple = true;
        DrawTemple(region);
    }

    public void AddLegion()
    {
        var region = MapCreator.Regions.First(r => r.Area.name == Map.Highligthed.name);
        CurrentCountry.AddUnit(new Legion(), region);
        DrawLegion(region);
    }

    public void AddShip()
    {
        var region = MapCreator.Regions.First(r => r.Area.name == Map.Highligthed.name);
        CurrentCountry.AddUnit(new Fleet(), region);
        DrawFleet(region, CurrentCountry.Material);
    }

    public void AddTower()
    {
        var region = MapCreator.Regions.First(r => r.Area.name == Highligthed.name);
        CurrentCountry.AddUnit(new Tower(), region);
        DrawTower(region, CurrentCountry.Material);
    }
}
