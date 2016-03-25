using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheSlum.Interfaces;

namespace TheSlum
{
    public class Mage : Character, IAttack
    {
        public Mage(string id, int x, int y, int healthPoints, int defensePoints, int attackPoints, Team team, int range)
            : base(id, x, y, healthPoints, defensePoints, team, range)
        {
            this.AttackPoints = attackPoints;
        }

        public int AttackPoints { get; set; }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            //double maxDistance = this.Range;
            
            //IDictionary<double, Character> characters = new Dictionary<double, Character>();

            //for (int i = 0; i < targetsList.Count(); i++)
            //{
            //    double distance = Math.Sqrt(
            //    (this.X - targetsList.ToList()[i].X) * (this.X - targetsList.ToList()[i].X) +
            //    (this.Y - targetsList.ToList()[i].Y) * (this.Y - targetsList.ToList()[i].Y));

            //    if (distance <= maxDistance)
            //    {
            //        characters.Add(distance, targetsList.ToList()[i]);
            //    }
            //}

            //Character lastTarget = characters[characters.Max(k => k.Key)];
            //return lastTarget;

            var target =
               targetsList.LastOrDefault(character => (character.Team != this.Team && character.IsAlive == true));
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
