using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Buildings
{
    public class City : Building
    {
        public override bool Add()
        {
            if (MapSettings.CitiesAvailable > 0)
            {
                MapSettings.CitiesAvailable--;
                return true;
            }
            return false;
        }
    }
}
