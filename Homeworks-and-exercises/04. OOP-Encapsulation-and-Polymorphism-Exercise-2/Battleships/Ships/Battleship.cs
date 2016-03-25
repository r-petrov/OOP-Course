using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.Interfaces;

namespace Battleships.Ships
{
    public abstract class Battleship : Ship, IAttack
    {
        protected Battleship(string name, double lengthInMeters, double volume) : base(name, lengthInMeters, volume)
        {
        }

        protected void DestroyTarget(Ship targetShip)
        {
            targetShip.IsDestroyed = true;
        }

        public abstract string Attack(Ship targetShip);
    }
}
