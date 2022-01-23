using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Region
    {
        public GameObject Area { get; private set; }
        public InternalPositions InternalPositions { get; private set; }

        public Region(GameObject area, InternalPositions positions)
        {
            Area = area;
            InternalPositions = positions;
        }
    }
}
