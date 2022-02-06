using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Tower : Unit
    {
        public override int Attack => 6;
        public override int MoveRadius => 0;
    }
}
