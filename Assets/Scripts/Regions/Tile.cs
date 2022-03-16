using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Regions
{
    public abstract class Tile
    {
        public Country Owner;
        public Region Position;
    }
}
