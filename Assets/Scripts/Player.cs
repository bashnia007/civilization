using Assets.Scripts.Buildings;
using Assets.Scripts.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts
{
    public class Player
    {
        public Country Country { get; set; }
        public List<Resource> AvailableResources { get; private set; }
        public int MoneyAmount { get; private set; }
        public bool IsMe { get; set; }

        public void AddResource(Resource resourceType)
        {
            AvailableResources.Add(resourceType);
        }

        public void GetResources()
        {
            AvailableResources = Country.GatherResources();
        }

        public void GetTaxes()
        {
            MoneyAmount = Country.GatherTaxes();
        }

        public void SpendMoney(int count = 1)
        {
            MoneyAmount -= count;
        }

        public void SpendResources(List<ResourceType> resourceTypes)
        {
            foreach (var resourceType in resourceTypes)
            {
                var exisitingResource = AvailableResources.First(r => r.ResourceType == resourceType);
                AvailableResources.Remove(exisitingResource);
            }
        }
    }
}
