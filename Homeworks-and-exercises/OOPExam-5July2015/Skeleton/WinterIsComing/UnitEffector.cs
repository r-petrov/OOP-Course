using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinterIsComing.Contracts;

namespace WinterIsComing
{
    public class UnitEffector : IUnitEffector
    {
        public void ApplyEffect(IEnumerable<IUnit> units)
        {
            foreach (var unit in units)
            {
                unit.HealthPoints += 50;
            }
        }
    }
}
