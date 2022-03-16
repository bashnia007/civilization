using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Regions
{
    public class City : Tile
    {
        public bool Add()
        {
            if (MapSettings.CitiesAvailable > 0 && IsPlaceCorrect())
            {
                MapSettings.CitiesAvailable--;
                return true;
            }
            return false;
        }

        private bool IsPlaceCorrect()
        {
            return true;
        }
    }
}
