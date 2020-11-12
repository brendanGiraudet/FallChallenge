using System;
using Xunit;
using System.Collections.Generic;

namespace FallChallenge.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void ShouldHaveBestCommand()
        {
            // Arrange
            var inventory = new Inventory
            {
                NumberOfBlueIngredient = 2,
                NumberOfGreenIngredient = 1,
                NumberOfOrangeIngredient = 3,
                NumberOfYellowIngredient = 2
            };
            var expectedCommand = new Command
            {
                Id = 72,
                NumberOfBlueIngredient = 0,
                NumberOfGreenIngredient = -1,
                NumberOfOrangeIngredient = -1,
                NumberOfYellowIngredient = -1,
                Price = 19
            };
            var commands = new List<Command>
            {
                new Command
                {
                    Id = 48,
                    NumberOfBlueIngredient = 0,
                    NumberOfGreenIngredient = -1,
                    NumberOfOrangeIngredient = -1,
                    NumberOfYellowIngredient = 0,
                    Price = 10
                },
                new Command
                {
                    Id = 45,
                    NumberOfBlueIngredient = -1,
                    NumberOfGreenIngredient = -1,
                    NumberOfOrangeIngredient = 0,
                    NumberOfYellowIngredient = 0,
                    Price = 8
                },
                new Command
                {
                    Id = 69,
                    NumberOfBlueIngredient = -1,
                    NumberOfGreenIngredient = -1,
                    NumberOfOrangeIngredient = -1,
                    NumberOfYellowIngredient = 0,
                    Price = 13
                },
                new Command
                {
                    Id = 66,
                    NumberOfBlueIngredient = -1,
                    NumberOfGreenIngredient = 0,
                    NumberOfOrangeIngredient = 0,
                    NumberOfYellowIngredient = 0,
                    Price = 9
                },
                expectedCommand
            };

            // Act
            var actualCommand = Player.GetTheBestCommand(inventory, commands);

            // Assert
            Assert.Equal(expectedCommand.Id, actualCommand.Id);
        }
    }
}