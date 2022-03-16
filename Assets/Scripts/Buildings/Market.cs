using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Buildings
{
    public class Market
    {
        public bool Add()
        {
            if (MapSettings.MarketsAvailable > 0 )
            {
                MapSettings.MarketsAvailable--;
                return true;
            }
            return false;
        }
    }
}
