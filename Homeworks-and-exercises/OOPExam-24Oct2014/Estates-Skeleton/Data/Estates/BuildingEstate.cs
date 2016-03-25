using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estates
{
    public class BuildingEstate : Estate, Interfaces.IBuildingEstate
    {
        private int rooms;

        public int Rooms
        {
            get { return this.rooms; }
            set
            {
                if (value < 0 || value > 20)
                {
                    throw new ArgumentOutOfRangeException("value", "The number of rooms should be in range [0...20]");
                }

                this.rooms = value;
            }
        }

        public bool HasElevator { get; set; }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendFormat("{0}, Rooms: {1}, Elevator: {2}",
                base.ToString(), this.Rooms, this.HasElevator ? "Yes" : "No");
        }
    }
}
