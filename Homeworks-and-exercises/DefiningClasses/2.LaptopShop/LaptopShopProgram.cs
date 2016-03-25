using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.LaptopShop
{
    class LaptopShopProgram
    {
        static void Main(string[] args)
        {
            Battery battery = new Battery("Li-Ion", 4, 2550, 4.5);

            Laptop laptop = new Laptop("HP 250 G2", "Lenovo", "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)", 8, "Intel HD Graphics 4400",
                "128GB SSD", "13.3\" (33.78 cm) – 3200 x 1800 (QHD+), IPS sensor display", battery, battery.BatteryLife, 2259.00m);
            Console.WriteLine(laptop);

            Laptop laptop2 = new Laptop("HP 250 G2", 699);
            Console.WriteLine(laptop2);

            Laptop laptop3 = new Laptop("ASUS X 550 VC-XX 8", "ASUSTeK Computer Inc.", "Intel Core i5-3230M (2-core, 2.60 GHz, 3MB cache)", 8, "Intel HD Graphics 4400",
                "1TB SSD", "13.3\" (33.78 cm) – 3200 x 1800 (QHD+), IPS sensor display", 2259.00m);
            Console.WriteLine(laptop3);
        }
    }
}
