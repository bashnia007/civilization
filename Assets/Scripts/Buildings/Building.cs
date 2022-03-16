using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Buildings
{
    public abstract class Building
    {
        public virtual int Price { get; set; }
        public abstract bool Add();
        public virtual Vector3 Position { get; set; }
    }
}
