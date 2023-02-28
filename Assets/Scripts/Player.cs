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
        public List<ResourceType> AvailableResources { get; private set; }
        public int MoneyAmount { get; private set; }

        public void AddResourceCard(ResourceType resourceType)
        {
            this.AvailableResources.Add(resourceType);
        }

        public void AddMoney(int amount)
        {
            MoneyAmount += amount;
        }
    }
}
