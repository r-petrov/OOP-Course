using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using TheSlum.GameEngine;

namespace TheSlum
{
    public class CustomEngine : Engine
    {
        protected override void ExecuteCommand(string[] inputParams)
        {
            string command = inputParams[0].ToLower();
            switch (command)
            {
                case "create":
                    this.CreateCharacter(inputParams);
                    break;
                case "add":
                    this.AddItem(inputParams);
                    break;
                default:
                    base.ExecuteCommand(inputParams);
                    break;
            }
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            //Team team;
            //Team.TryParse(inputParams[5], out team);
            Character newCharacter;
            string cases = inputParams[1].ToLower();

            switch (cases)
            {
                case "warrior":
                    newCharacter = new Warrior(
                        inputParams[2], 
                        int.Parse(inputParams[3]), 
                        int.Parse(inputParams[4]), 
                        200,
                        100,
                        150,
                        (Team)Enum.Parse(typeof(Team), inputParams[5], true),
                        2);
                    characterList.Add(newCharacter);
                    break;
                case "mage":
                    newCharacter = new Mage(
                        inputParams[2], 
                        int.Parse(inputParams[3]), 
                        int.Parse(inputParams[4]), 
                        150,
                        50,
                        300,
                        (Team)Enum.Parse(typeof(Team), inputParams[5], true),
                        5);
                    characterList.Add(newCharacter);
                    break;
                case "healer":
                    newCharacter = new Healer(
                        inputParams[2], 
                        int.Parse(inputParams[3]), 
                        int.Parse(inputParams[4]),
                        75,
                        50,
                        60,
                        (Team)Enum.Parse(typeof(Team), inputParams[5], true),
                        6);
                    characterList.Add(newCharacter);
                    break;
            }
        }

        protected new void AddItem(string[] inputParams)
        {
            Character characterAcceptingItem = GetCharacterById(inputParams[1]);
            Item itemToBeAccepted;
            string newItem = inputParams[2];

            switch (newItem)
            {
                case "axe":
                    itemToBeAccepted = new Axe(inputParams[3]);
                    characterAcceptingItem.AddToInventory(itemToBeAccepted);
                    break;
                case "shield":
                    itemToBeAccepted = new Shield(inputParams[3]);
                    characterAcceptingItem.AddToInventory(itemToBeAccepted);
                    break;
                case "injection":
                    itemToBeAccepted=new Injection(inputParams[3]);
                    characterAcceptingItem.AddToInventory(itemToBeAccepted);
                    break;
                case "Pill":
                    itemToBeAccepted = new Pill(inputParams[3]);
                    characterAcceptingItem.AddToInventory(itemToBeAccepted);
                    break;
                default:
                    Console.WriteLine("No such item!");
                    break;
            }
        }
    }
}
