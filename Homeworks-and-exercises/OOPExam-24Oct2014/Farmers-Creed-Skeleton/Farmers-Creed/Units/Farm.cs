using System.Linq;
using System.Text;
using System.Threading;

namespace FarmersCreed.Units
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class Farm : GameObject, IFarm
    {
        public Farm(string id)
            : base(id)
        {
            this.Plants = new List<Plant>();
            this.Animals = new List<Animal>();
            this.Products = new List<Product>();
        }

        public List<Plant> Plants { get; set; }

        public List<Animal> Animals { get; set;  }

        public List<Product> Products { get; set; }

        public void AddProduct(Product product)
        {
            foreach (var p in this.Products)
            {
                if (p.Id == product.Id)
                {
                    p.Quantity += product.Quantity;
                    return;
                }
            }

            this.Products.Add(product);
        }

        public void Exploit(IProductProduceable productProducer)
        {
            var product = productProducer.GetProduct();
            this.AddProduct(product);
        }

        public void Feed(Animal animal, IEdible edibleProduct, int productQuantity)
        {
            animal.Eat(edibleProduct, productQuantity);
        }

        public void Water(Plant plant)
        {
            plant.Water();
        }

        public void ProductStateUpdate(string foodId, int quantity)
        {
            var balanceProduct = this.Products.FirstOrDefault(pr => pr.Id == foodId);

            balanceProduct.Quantity -= quantity;
        }


        public void UpdateFarmState()
        {
            if (this.Plants.Count > 0)
            {
                foreach (var plant in this.Plants)
                {
                    if (plant.GrowTime > 0)
                    {
                        plant.Grow();
                    }
                    else
                    {
                        plant.Wither();
                    }
                }
            }

            if(this.Animals.Count > 0)
            {
                foreach (var animal in this.Animals)
                {
                    animal.Starve();
                }
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(base.ToString());

            var aliveAnimals =
                from animal in this.Animals
                where animal.IsAlive || animal.Health > 0
                orderby animal.Id
                select animal;

            foreach (var animal in aliveAnimals)
            {
                output.AppendLine(animal.ToString());
            }

            var alivePlants =
                from plant in this.Plants
                where plant.IsAlive || plant.Health > 0
                orderby plant.Health, plant.Id
                select plant;

            foreach (var plant in alivePlants)
            {
                output.AppendLine(plant.ToString());
            }

            var products =
                from product in this.Products
                orderby product.ProductType.ToString(), product.Quantity descending, product.Id 
                select product;

            foreach (var product in products)
            {
                output.AppendLine(product.ToString());
            }
            return output.ToString();
        }
    }
}
