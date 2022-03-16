using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public abstract class Unit
    {
        private static Random random;
        static Unit()
        {
            random = new Random();
        }
        public Region Location { get; set; }
        public virtual int MoveRadius => 1;
        public virtual int Attack => ThrowAttackDice();

        private static int ThrowAttackDice()
        {
            return random.Next(1, 6);
        }
    }
}
