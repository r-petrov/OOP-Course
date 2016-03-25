using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinterIsComing.Contracts;
using WinterIsComing.Models;

namespace WinterIsComing
{
    public abstract class Unit : IUnit
    {
        private int x;
        private int y;
        private string name;
        private readonly int range;
        protected ICombatHandler combatHandler;
        protected Unit(int x, int y, string name, int range, int attackPoints, int healthPoints, int defensePoints, int energyPoints)
        {
            this.X = x;
            this.Y = y;
            this.Name = name;
            this.range = range;
            this.AttackPoints = attackPoints;
            this.HealthPoints = healthPoints;
            this.DefensePoints = defensePoints;
            this.EnergyPoints = energyPoints;
        }
    
        public int X
        {
            get { return this.x; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The X value should be a positive integer.");
                }
                this.x = value;
            }
        }

        public int Y
        {
            get { return this.y; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The Y value should be a positive integer.");
                }
                this.y = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name of units cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int Range
        {
            get { return this.range; }
        }

        public int AttackPoints { get; set; }

        public int HealthPoints { get; set; }

        public int DefensePoints { get; set; }

        public int EnergyPoints { get; set; }

        public abstract ICombatHandler CombatHandler { get; }

        public abstract UnitType Type { get; protected set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(String.Format(">{0} - {1} at ({2},{3})", this.Name, this.Type, this.X, this.Y));

            if (this.HealthPoints > 0)
            {
                result.AppendLine(String.Format("-Health points = {0}", this.HealthPoints));
                result.AppendLine(String.Format("-Attack points = {0}", this.AttackPoints));
                result.AppendLine(String.Format("-Defense points = {0}", this.DefensePoints));
                result.AppendLine(String.Format("-Energy points = {0}", this.EnergyPoints));
                result.Append(String.Format("-Range = {0}", this.Range));
            }
            else
            {
                result.AppendLine("(Dead)");
            }
            
            return result.ToString();
        }
    }
}
