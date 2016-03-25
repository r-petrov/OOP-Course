using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _3.PCCatalog
{
    class Program
    {
        static void Main(string[] args)
        {
            //create instance #1 from class Computer
            decimal totalPrice = 0;
            Component[] componentsComputer1 = 
            {
                new Component("processor", "AMD CPU Richland A6-Series X2 6400K (3.9GHz,1MB,65W,FM2) box, Black Edition, Radeon TM HD 8470D", 114.38m),
                new Component("RAM", "Corsair DDR3, 1866MHz 16GB 2 x 8GB DIMM, Unbuffered, 9-10-9-27, DOMINATOR® Platinum, 1.5V", 491.95m),
                new Component("HDD", "HDD 1TB SATAIII WD Velociraptor 10 000rpm 64MB", 461.49m),
                new Component("ventilators", "Corsair Hydro Series, H100i, Compatible with Intel (LGA115/1156, LGA1366, LGA2011) " +
                    "and AMD (AM2/AM2+, AM3/AM3+, FM1), 240mm x 25mm Radiator, Dual", 265.0m),
                new Component("motherboard", 
                    "ASROCK iZ87 (Socket 1150, DDR3, VGA,USB2.0,Audio Interface,PS/2,S/PDIF-out Optical,SATA III,LAN,DVI,HDMI,USB3.0) mATX", 
                    191.15m),
                new Component("graphic card", 
                "SAPPHIRE Видео Карта Radeon HD 7850 GDDR5 2GB/256bit, 860MHz/1200MHz, PCI-E 3.0 x16,DP,HDMI, 2xDVI, VGA Cooler (Double Slot)", 
                336.06m),
                new Component("box", "CM SILENCIO 650 PURE", 167.24m),
            };

            foreach (var component in componentsComputer1)
            {
                totalPrice += component.Price;
            }
            Computer computer1 = new Computer("Configuration #1", componentsComputer1, totalPrice);
            //Console.WriteLine(computer1 + "\n");

            //create instance #2 from class Computer
            totalPrice = 0;
            Component[] componentsComputer2 = 
            {
                new Component("processor", "AMD CPU Trinity A4-Series X2 5300 (3.40GHz,1MB,65W,FM2) box, Radeon TM HD 7480D", 73.84m),
                new Component("RAM", "Памет Corsair DDR3, 1600MHz 8GB 2 x 4GB DIMM, Unbuffered, 9-9-9-24, DOMINATOR® Platinum, 1.5V", 254.98m),
                new Component("HDD", "SEAGATE HDD Desktop Barracuda 7200 (3.5\",500GB,16MB,SATA III-600)", 110.05m),
                new Component("motherboard", 
                    "MB Biostar Intel NM70, s1023, Cel 847 1.1Ghz DualCore, 2 x DDR3 1333, PCIe x8, SATA III, HDMI/DSUB, PS/2, USB 3.0", 
                    115.97m),
                new Component("graphic card", 
                "GB N610D3-2GI GT610 2G DDR3", 103.65m),
                new Component("box", "CM SILENCIO 650 PURE", 167.24m),
            };

            foreach (var component in componentsComputer2)
            {
                totalPrice += component.Price;
            }
            Computer computer2 = new Computer("Configuration #2", componentsComputer2, totalPrice);
            //Console.WriteLine(computer2 + "\n");

            //create instance #3 from class Computer
            totalPrice = 0;
            Component[] componentsComputer3 = 
            {
                new Component("processor", 244m),
                new Component("RAM", 307.62m),
                new Component("HDD", 217.73m),
                new Component("ventilators", 32.13m),
                new Component("motherboard", 149.86m),
                new Component("graphic card", 336.06m),
                new Component("box", "CM SILENCIO 650 PURE", 167.24m),
            };

            foreach (var component in componentsComputer3)
            {
                totalPrice += component.Price;
            }
            //Console.WriteLine(totalPrice);
            Computer computer3 = new Computer("Configuration #3", componentsComputer3, totalPrice);
            //Console.WriteLine(computer3 + "\n");

            //create instance #4 from class Computer
            totalPrice = 0;
            Component[] componentsComputer4 = 
            {
                new Component("processor", 114.38m),
                new Component("RAM", 435.15m),
                new Component("HDD", "SEAGATE HDD Desktop Barracuda 7200 (3.5\",500GB,16MB,SATA III-600)", 110.05m),
                new Component("motherboard", 
                    "ASROCK Main Board Desktop iZ87 (S1150, DDR3, USB3.0,DVI,HDMI,USB2.0,SATA III,SATA II,e-SATA III,LAN) mATX Retail", 
                    213.52m),
                new Component("graphic card", 
                "GB N660OC-2GD GTX660 2G GDDR5", 387.30m),
                new Component("box", "CM SILENCIO 650 PURE", 167.24m),
            };

            foreach (var component in componentsComputer4)
            {
                totalPrice += component.Price;
            }
            Computer computer4 = new Computer("Configuration #4", componentsComputer4, totalPrice);
            //Console.WriteLine(computer4 + "\n");

            //create collection of all computer configurations
            var configurations = new SortedDictionary<decimal, Computer>();
            configurations.Add(computer1.Price, computer1);
            configurations.Add(computer2.Price, computer2);
            configurations.Add(computer3.Price, computer3);
            configurations.Add(computer4.Price, computer4);

            foreach (var computer in configurations)
            {
                Console.WriteLine(computer.Value + "\n");
            }
        }
    }
}
