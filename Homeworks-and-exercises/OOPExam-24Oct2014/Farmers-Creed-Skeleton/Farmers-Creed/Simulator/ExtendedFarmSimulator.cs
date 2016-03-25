using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarmersCreed.Interfaces;
using FarmersCreed.Simulator;

namespace FarmersCreed
{
    public class ExtendedFarmSimulator : FarmSimulator
    {
        protected override void ProcessInput(string input)
        {
            base.ProcessInput(input);

            string[] inputCommands = input.Split(' ');

            string action = inputCommands[0];

            switch (action)
            {
                case "feed":
                    string animalId = inputCommands[1];
                    string foodId = inputCommands[2];
                    var food = this.GetProductById(foodId);
                    int quantity = int.Parse(inputCommands[3]);

                    if (food.Quantity < quantity)
                    {
                        throw new InvalidOperationException("Food presence in the farm is not enough for feeding the animal.");
                    }
                    //!!!!!!!!!!!!
                    this.farm.Feed(GetAnimalById(animalId), (IEdible)food, quantity);
                    food.Quantity -= quantity;

                    break;
                case "water":
                    string plantId = inputCommands[1];
                    var plant = this.GetPlantById(plantId);
                    this.farm.Water(plant);
                    break;
                case "exploit":
                    string farmUnit = inputCommands[1];
                    string farmUnitId = inputCommands[2];

                    if (farmUnit == "animal")
                    {
                        this.farm.Exploit(this.GetAnimalById(farmUnitId));
                    }
                    else
                    {
                        this.farm.Exploit(this.GetPlantById(farmUnitId));
                    }
                    break;
            }

            //if (action != "status")
            //{
            //    this.farm.UpdateFarmState();
            //}
        }

        protected override void AddObjectToFarm(string[] inputCommands)
        {
            base.AddObjectToFarm(inputCommands);

            string type = inputCommands[1];
            string id = inputCommands[2];

            switch (type)
            {
                case "CherryTree":
                    var cherryTree = new CherryTree(id, 14, 4, 3);
                    this.farm.Plants.Add(cherryTree);
                    break;
                case "TobaccoPlant":
                    var tobaccoPlant = new TobaccoPlant(id, 12, 10, 4);
                    this.farm.Plants.Add(tobaccoPlant);
                    break;
                case "Cow":
                    var cow = new Cow(id, 15, 6);
                    this.farm.Animals.Add(cow);
                    break;
                case "Swine":
                    var swine = new Swine(id, 20, 1);
                    this.farm.Animals.Add(swine);
                    break;
                default:
                    break;
            }
        }
    }
}
