using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheSlum.Interfaces;

namespace TheSlum
{
    public class Healer : Character, IHeal
    {
        public Healer(string id, int x, int y, int healthPoints, int defensePoints, int healingPoints, Team team, int range)
            : base(id, x, y, healthPoints, defensePoints, team, range)
        {
            this.HealingPoints = healingPoints;
        }

        public int HealingPoints { get; set; }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var minHealthPoints = int.MaxValue;
            Character targetToGet = null;

            foreach (var target in targetsList)
            {
                if (target.HealthPoints < minHealthPoints)
                {
                    minHealthPoints = target.HealthPoints;
                    targetToGet = target;
                }
            }

            return targetToGet;

            //var targets =
            //    from target in targetsList
            //    where target.IsAlive == true && target.Team == this.Team && target != this
            //    orderby target.HealthPoints
            //    select target;

            //return targets.FirstOrDefault();
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            this.ApplyItemEffects(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
            this.RemoveItemEffects(item);
        }

        public override string ToString()
        {
            string result = base.ToString() + String.Format(", Healing: {0}", this.HealingPoints);
            return result;
        }
    }
}
