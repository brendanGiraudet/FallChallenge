﻿using System;
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

                var brewCommands = commands.Where(c => c.Type.Equals(CommandType.Brew)).ToList();
                System.Console.Error.WriteLine("***** BREWS *****");
                brewCommands.ForEach(System.Console.Error.WriteLine);

                var castCommands = commands.Where(c => c.Type.Equals(CommandType.Cast)).ToList();
                System.Console.Error.WriteLine("***** CASTS *****");
                castCommands.ForEach(System.Console.Error.WriteLine);

                var inventories = GetInventories();
                System.Console.Error.WriteLine("***** INVENTORIES *****");
                inventories.ForEach(System.Console.Error.WriteLine);

                var myIventory = inventories.First();

                var doableCommand = GetTheDoableCommand(myIventory, brewCommands);

                if (doableCommand != null)
                {
                    Console.WriteLine($"{doableCommand.GetCommandTypeAsString()} {doableCommand.Id}");
                    continue;
                }

                var mostDoableCommand = GetTheMostDoableCommand(myIventory, brewCommands);
                var bestCast = GetTheBestCast(myIventory, mostDoableCommand, castCommands);

                if (bestCast.Castable)
                {
                    Console.WriteLine($"{bestCast.GetCommandTypeAsString()} {bestCast.Id}");
                }

                Console.WriteLine($"REST");
            }
        }

        public static Command GetTheBestCast(Inventory inventory, Command command, List<Command> castCommands)
        {
            throw new NotImplementedException();
        }

        public static Command GetTheMostDoableCommand(Inventory inventory, List<Command> commands)
        {
            var theMostDoableCommand = commands.First();
            var bestNumberOfAction = GetNumberOfActionToBuildMissingIngredients(inventory, theMostDoableCommand);
            foreach (var command in commands)
            {
                var numberOfAction = GetNumberOfActionToBuildMissingIngredients(inventory, command);
                if(bestNumberOfAction > numberOfAction)
                {
                    theMostDoableCommand = command;
                    bestNumberOfAction = numberOfAction;
                }
            }
            return theMostDoableCommand;
        }

        private static int GetNumberOfActionToBuildMissingIngredients(Inventory inventory, Command command)
        {
            var numberOfaction = 0;

            var numberOfMissingBlueIngredients = inventory.NumberOfBlueIngredient + command.NumberOfBlueIngredient;

            var numberOfMissingGreenIngredients = inventory.NumberOfGreenIngredient + command.NumberOfGreenIngredient;

            if(numberOfMissingBlueIngredients > 0)
                numberOfMissingBlueIngredients = 0;

            numberOfaction+= numberOfMissingBlueIngredients;

            
            if(numberOfMissingGreenIngredients > 0)
                numberOfMissingGreenIngredients = 0;
            else
                numberOfaction += numberOfMissingGreenIngredients * 2 - numberOfMissingBlueIngredients;

            var numberOfMissingOrangeIngredients = inventory.NumberOfOrangeIngredient + command.NumberOfOrangeIngredient;
            if(numberOfMissingOrangeIngredients > 0)
                numberOfMissingOrangeIngredients = 0;
            else
                numberOfaction += numberOfMissingOrangeIngredients * 3 - ;

            var numberOfMissingYellowIngredients = inventory.NumberOfYellowIngredient + command.NumberOfYellowIngredient;
            if(numberOfMissingYellowIngredients > 0)
                numberOfMissingYellowIngredients = 0;
            else
                numberOfaction = numberOfMissingYellowIngredients * 4;

            return numberOfaction;
        }

        public static Command GetTheDoableCommand(Inventory inventory, List<Command> commands)
        {
            var sortedCommandsByPrice = commands.OrderByDescending(c => c.Price);

            return sortedCommandsByPrice.FirstOrDefault(c => HaveEnoughIngredient(inventory, c));
        }

        public static bool HaveEnoughIngredient(Inventory inventory, Command command)
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

                commands.Add(new Command
                {
                    Id = int.Parse(inputs[0]),
                    Type = GetCommandType(inputs[1]),
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
        static CommandType GetCommandType(string commandType)
        {
            switch (commandType)
            {
                case "BREW":
                default:
                    return CommandType.Brew;
                case "CAST":
                    return CommandType.Cast;
                case "OPPONENT_CAST":
                    return CommandType.OpponentCast;
            }
        }
    }
    public enum CommandType
    {
        Brew,
        Cast,
        OpponentCast
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
        public CommandType Type { get; set; }

        public string GetCommandTypeAsString()
        {
            switch (Type)
            {
                case CommandType.Brew:
                default:
                    return "BREW";
                case CommandType.Cast:
                    return "CAST";
            }
        }
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