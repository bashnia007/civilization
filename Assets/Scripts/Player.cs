using Assets.Scripts.Buildings;
using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Player
    {
        public Country Country { get; set; }
        public List<Resource> AvailableResources { get; private set; }
        public int MoneyAmount { get; private set; }

        public void AddResource(Resource resourceType)
        {
            this.AvailableResources.Add(resourceType);
        }

        public void GetResources()
        {
            AvailableResources = Country.GatherResources();
        }

        public void GetTaxes()
        {
            MoneyAmount = Country.GatherTaxes();
        }
    }
}
