using System;
using System.Linq;
using System.Collections.Generic;

namespace FallChallenge
{
    /**
    * Auto-generated code below aims at helping you parse
    * the standard input according to the problem statement.
    **/
    public class Player
    {
        static void Main(string[] args)
        {
            // game loop
            while (true)
            {
                var commands = GetCommands();
                System.Console.Error.WriteLine("***** COMMANDS *****");
                commands.ForEach(System.Console.Error.WriteLine);

                var inventories = GetInventories();
                var myIventory = inventories.First();
                System.Console.Error.WriteLine("***** INVENTORIES *****");
                inventories.ForEach(System.Console.Error.WriteLine);

                var bestCommand = GetTheBestCommand(myIventory, commands);

                // in the first league: BREW <id> | WAIT; later: BREW <id> | CAST <id> [<times>] | LEARN <id> | REST | WAIT
                Console.WriteLine($"BREW {bestCommand.Id}");
            }
        }
        public static Command GetTheBestCommand(Inventory inventory, List<Command> commands)
        {
            var sortedCommandsByPrice = commands.OrderByDescending(c => c.Price);
            
            return sortedCommandsByPrice.FirstOrDefault(c => HaveEnoughIngredient(inventory, c));
        }

        private static bool HaveEnoughIngredient(Inventory inventory, Command command)
        {
            return inventory.NumberOfBlueIngredient - command.NumberOfBlueIngredient >= 0
                && inventory.NumberOfGreenIngredient - command.NumberOfGreenIngredient >= 0
                && inventory.NumberOfOrangeIngredient - command.NumberOfOrangeIngredient >= 0
                && inventory.NumberOfYellowIngredient - command.NumberOfYellowIngredient >= 0;
        }

        static List<Inventory> GetInventories()
        {
            var inventories = new List<Inventory>();

            for (int i = 0; i < 2; i++)
            {
                var inputs = Console.ReadLine().Split(' ');
                inventories.Add(new Inventory
                {
                    NumberOfBlueIngredient = int.Parse(inputs[0]),
                    NumberOfGreenIngredient = int.Parse(inputs[1]),
                    NumberOfOrangeIngredient = int.Parse(inputs[2]),
                    NumberOfYellowIngredient = int.Parse(inputs[3]),
                    Score = int.Parse(inputs[4])
                });
            }

            return inventories;
        }
        static List<Command> GetCommands()
        {
            var commands = new List<Command>();
            int actionCount = int.Parse(Console.ReadLine()); // the number of spells and recipes in play
            for (int i = 0; i < actionCount; i++)
            {
                var inputs = Console.ReadLine().Split(' ');

                commands.Add(new Command{
                    Id = int.Parse(inputs[0]),
                    Type = inputs[1],
                    NumberOfBlueIngredient = int.Parse(inputs[2]),
                    NumberOfGreenIngredient = int.Parse(inputs[3]),
                    NumberOfOrangeIngredient = int.Parse(inputs[4]),
                    NumberOfYellowIngredient = int.Parse(inputs[5]),
                    Price = int.Parse(inputs[6]),
                    TomeIndex = int.Parse(inputs[7]),
                    TaxCount = int.Parse(inputs[8]),
                    Castable = inputs[9] != "0",
                    Repeatable = inputs[10] != "0"
                });
            }

            return commands;
        }
    }
    public class Inventory
    {
        public int NumberOfBlueIngredient { get; set; }
        public int NumberOfGreenIngredient { get; set; }
        public int NumberOfOrangeIngredient { get; set; }
        public int NumberOfYellowIngredient { get; set; }
        public int Score { get; set; }

        public override string ToString()
        {
            return $"blue : {NumberOfBlueIngredient} " +
                $"green : {NumberOfGreenIngredient} " +
                $"orange : {NumberOfOrangeIngredient} " +
                $"yellow : {NumberOfYellowIngredient} " +
                $"Score : {Score} ";
        }
    }
    public class Command
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int NumberOfBlueIngredient { get; set; }
        public int NumberOfGreenIngredient { get; set; }
        public int NumberOfOrangeIngredient { get; set; }
        public int NumberOfYellowIngredient { get; set; }
        public int Price { get; set; }
        public int TomeIndex { get; set; }
        public int TaxCount { get; set; }
        public bool Castable { get; set; }
        public bool Repeatable { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} " + 
                $"Type : {Type} " +
                $"blue : {NumberOfBlueIngredient} " +
                $"green : {NumberOfGreenIngredient} " +
                $"orange : {NumberOfOrangeIngredient} " +
                $"yellow : {NumberOfYellowIngredient} " +
                $"Price : {Price} ";
        }
    }
}