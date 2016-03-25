using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheSlum.Interfaces;

namespace TheSlum
{
    public  class Warrior : Character, IAttack
    {
        public Warrior(string id, int x, int y, int healthPoints, int defensePoints, int attackPoints, Team team, int range)
            : base(id, x, y, healthPoints, defensePoints, team, range)
        {
            this.AttackPoints = attackPoints;
        }

        public int AttackPoints { get; set; }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            //double minDistance = this.Range;
            //Character firstTarget = null;

            //for (int i = 0; i < targetsList.Count(); i++)
            //{
            //    double distance = Math.Sqrt(
            //    (this.X - targetsList.ToList()[i].X) * (this.X - targetsList.ToList()[i].X) +
            //    (this.Y - targetsList.ToList()[i].Y) * (this.Y - targetsList.ToList()[i].Y));

            //    if (distance <= minDistance)
            //    {
            //        minDistance = distance;
            //        firstTarget = targetsList.ToList()[i];
            //    }
            //}

            //return firstTarget;

            var target =
                targetsList.FirstOrDefault(character => (character.Team != this.Team && character.IsAlive == true));
            return target;
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            this.ApplyItemEffects(item);
        }

        protected override void ApplyItemEffects(Item item)
        {
            base.ApplyItemEffects(item);
            this.AttackPoints += item.AttackEffect;
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
            this.RemoveItemEffects(item);
        }

        protected override void RemoveItemEffects(Item item)
        {
            base.RemoveItemEffects(item);
            this.AttackPoints -= item.AttackEffect;
        }

        public override string ToString()
        {
            string result = base.ToString() + String.Format(", Attack: {0}", this.AttackPoints);
            return result;
        }
    }
}
