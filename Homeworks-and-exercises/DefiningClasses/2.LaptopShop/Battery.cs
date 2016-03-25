using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.LaptopShop
{
    class Battery
    {
        private string type;
        private int numberOfCells;
        private int capacity;
        private double batteryLife;

        public Battery(string type, int numberOfCells, int capacity, double batteryLife)
        {
            this.Type = type;
            this.NumberOfCells = numberOfCells;
            this.Capacity = capacity;
            this.BatteryLife = batteryLife;
        }

        public Battery(string type, int numberOfCells, int capacity) : this(type, numberOfCells, capacity, 0.0)
        {
        }

        //public Battery(double batteryLife) : this(null, 0, 0, batteryLife)
        //{
        //}

        public string Type
        {
            get { return this.type; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid type!");
                }

                this.type = value;
            }
        }

        public int NumberOfCells
        {
            get { return this.numberOfCells; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The number of cells cannot be negative!");
                }

                this.numberOfCells = value;
            }
        }

        public int Capacity
        {
            get { return this.capacity; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The number of cells cannot be negative!");
                }

                this.capacity = value;
            }
        }

        public double BatteryLife
        {
            get { return this.batteryLife; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The number of cells cannot be negative!");
                }

                this.batteryLife = value;
            }
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}-cells, {2} mAh", this.Type, this.NumberOfCells, this.Capacity);
        }
    }
}
