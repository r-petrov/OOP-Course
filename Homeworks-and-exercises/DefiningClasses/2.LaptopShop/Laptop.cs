using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2.LaptopShop
{
    class Laptop
    {
        private string model;
        private string manufacturer;
        private string processor;
        private int? ram;
        private string graphicsCard;
        private string hdd;
        private string screen;
        private Battery battery;
        private double? batteryLife;
        private decimal price;

        public Laptop(string model, string manufacturer, string processor, int? ram, string graphicsCard, string hdd,
            string screen, Battery battery, double? batteryLife, decimal price)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Processor = processor;
            this.RAM = ram;
            this.GraphicsCard = graphicsCard;
            this.HDD = hdd;
            this.Screen = screen;
            this.Battery = battery;
            this.BatteryLife = batteryLife;
            this.Price = price;
        }

        public Laptop(string model, string manufacturer, string processor, int? ram, string graphicsCard, string hdd,
            string screen, decimal price)
           // : this(model, manufacturer, processor, ram, graphicsCard, hdd, screen, null, 0.0, price)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Processor = processor;
            this.RAM = ram;
            this.GraphicsCard = graphicsCard;
            this.HDD = hdd;
            this.Screen = screen;
            this.Price = price;
        }

        public Laptop(string model, decimal price) // : this(model, null, null, 0, null, null, null, null, 0.0, price)
        {
            this.Model = model;
            this.Price = price;
        }

        public string Model
        {
            get { return this.model; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid model!");
                }

                this.model = value;
            }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new AggregateException("Invalid manufacturer!");
                }

                this.manufacturer = value;
            }
        }

        public string Processor
        {
            get { return this.processor; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new AggregateException("Invalid processor information!");
                }

                this.processor = value;
            }
        }

        public int? RAM
        {
            get { return this.ram; }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid RAM value!");
                }

                this.ram = value;
            }
        }

        public string GraphicsCard
        {
            get { return this.graphicsCard; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new AggregateException("Invalid graphics card information!");
                }

                this.graphicsCard = value;
            }
        }

        public string HDD
        {
            get { return this.hdd; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new AggregateException("Invalid HDD information!");
                }

                string pattern = @"^\d+";
                Regex regex = new Regex(pattern);
                Match match = regex.Match(value);

                if (!regex.IsMatch(value) || int.Parse(match.Groups[0].ToString()) <= 0)
                {
                    throw new ArgumentException("Invalid HDD value!");
                }

                this.hdd = value;
            }
        }

        public string Screen { 
            get { return this.screen; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new AggregateException("Invalid screen information!");
                }

                string pattern = @"^\d+\.?\d*";
                Regex regex = new Regex(pattern);
                Match match = regex.Match(value);

                if (!regex.IsMatch(value) || double.Parse(match.Groups[0].ToString()) <= 0)
                {
                    throw new ArgumentException("Invalid screen size value!");
                }

                this.screen = value;
            } 
        }

        public Battery Battery
        {
            get { return this.battery; }

            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentException("Invalid battery information!");
                }

                this.battery = value;
            }
        }

        public double? BatteryLife
        {
            get { return this.batteryLife; }

            set
            {
                //if (value <= 0)
                //{
                //    throw new ArgumentException("Invalid battery life value!");
                //}

                this.batteryLife = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid price value!");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            return String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9} lv.\n",
                "model".PadRight(15) + this.Model + "\n",
                string.IsNullOrWhiteSpace(this.Manufacturer) ? null : "manufacturer".PadRight(15) + this.Manufacturer + "\n",
                string.IsNullOrWhiteSpace(this.Processor) ? null : "processor".PadRight(15) + this.Processor + "\n",
                this.RAM == null ? null : "RAM".PadRight(15) + this.RAM + " GB\n",
                string.IsNullOrWhiteSpace(this.GraphicsCard) ? null : "graphics card".PadRight(15) + this.GraphicsCard + "\n",
                string.IsNullOrWhiteSpace(this.HDD) ? null : "HDD".PadRight(15) + this.HDD + "\n",
                string.IsNullOrWhiteSpace(this.Screen) ? null : "screen".PadRight(15) + this.Screen + "\n",
                Battery == null ? null : "battery".PadRight(15) + this.Battery + "\n",
                this.BatteryLife == null ? null : "battery life".PadRight(15) + this.BatteryLife + " hours\n",
                "price".PadRight(15) + this.Price);
        }
    }
}
