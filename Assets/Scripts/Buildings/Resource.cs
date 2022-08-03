using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Buildings
{
    public class Resource : Building
    {
        public ResourceType ResourceType;

        public override bool Add()
        {
            if (MapSettings.ResourcesAvailable > 0)
            {
                MapSettings.ResourcesAvailable--;
                return true;
            }
            return false;
        }
    }
}
