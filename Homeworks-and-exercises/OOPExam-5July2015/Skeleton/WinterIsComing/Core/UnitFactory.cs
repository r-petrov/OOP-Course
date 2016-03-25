namespace WinterIsComing.Core
{
    using System;
    using Contracts;
    using Models;

    public static class UnitFactory
    {
        public static IUnit Create(UnitType type, string name, int x, int y)
        {
            IUnit unit = null;

            switch (type)
            {
                case UnitType.Warrior:
                    unit = new Warrior(x, y, name, 1, 120, 180, 70, 60);
                    break;
                case UnitType.Mage:
                    unit = new Mage(x, y, name, 2, 80, 80, 40, 120);
                    break;
                case UnitType.IceGiant:
                    unit = new IceGiant(x, y, name, 1, 150, 300, 60, 50);
                    break;
            }

            return unit;
        }
    }
}
