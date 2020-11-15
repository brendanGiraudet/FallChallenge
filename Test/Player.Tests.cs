using Xunit;
using System.Collections.Generic;

namespace FallChallenge.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void ShouldGetTheDoableCommand()
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
            var actualCommand = Player.GetTheDoableCommand(inventory, commands);

            // Assert
            Assert.Equal(expectedCommand.Id, actualCommand.Id);
        }

        [Fact]
        public void ShouldHaveTrueWhenGetCommandWithNotEnoughIngredient()
        {
            // Arrange
            var inventory = new Inventory
            {
                NumberOfBlueIngredient = 3,
                NumberOfGreenIngredient = 0,
                NumberOfOrangeIngredient = 0,
                NumberOfYellowIngredient = 0
            };
            var bestCommand = new Command
            {
                NumberOfBlueIngredient = -2,
                NumberOfGreenIngredient = -2,
                NumberOfOrangeIngredient = 0,
                NumberOfYellowIngredient = 0,
                Price = 19
            };

            // Act
            var haveEnoughIngredient = Player.HaveEnoughIngredient(inventory, bestCommand);

            // Assert
            Assert.True(haveEnoughIngredient);
        }

        [Fact]
        public void ShouldGetTheNumberOfACtionToBuildMissingIngredient()
        {
            // Arrange
            var inventory = new Inventory
            {
                NumberOfBlueIngredient = 3,
                NumberOfGreenIngredient = 0,
                NumberOfOrangeIngredient = 0,
                NumberOfYellowIngredient = 0
            };
            var bestCommand = new Command
            {
                NumberOfBlueIngredient = -2,
                NumberOfGreenIngredient = -2,
                NumberOfOrangeIngredient = 0,
                NumberOfYellowIngredient = 0,

            };
            var expectedNumberOfAction = 3;

            // Act
            var actualNumberOfAction = Player.GetNumberOfActionToBuildMissingIngredients(inventory, bestCommand);

            // Assert
            Assert.Equal(expectedNumberOfAction, actualNumberOfAction);
        }

        [Fact]
        public void ShouldGetTheMostDoableCommand()
        {
            // Arrange
            var inventory = new Inventory
            {
                NumberOfBlueIngredient = 3,
                NumberOfGreenIngredient = 0,
                NumberOfOrangeIngredient = 0,
                NumberOfYellowIngredient = 0
            };
            var expectedCommand = new Command
            {
                Id = 42,
                NumberOfBlueIngredient = -2,
                NumberOfGreenIngredient = -2,
                NumberOfOrangeIngredient = 0,
                NumberOfYellowIngredient = 0
            };
            var commands = new List<Command>
            {
                new Command
                {
                    Id = 61,
                    NumberOfBlueIngredient = 0,
                    NumberOfGreenIngredient = 0,
                    NumberOfOrangeIngredient = 0,
                    NumberOfYellowIngredient = -4
                },
                new Command
                {
                    Id = 48,
                    NumberOfBlueIngredient = 0,
                    NumberOfGreenIngredient = -2,
                    NumberOfOrangeIngredient = -2,
                    NumberOfYellowIngredient = 0
                },
                new Command
                {
                    Id = 77,
                    NumberOfBlueIngredient = -1,
                    NumberOfGreenIngredient = -1,
                    NumberOfOrangeIngredient = -1,
                    NumberOfYellowIngredient = -3
                },
                new Command
                {
                    Id = 66,
                    NumberOfBlueIngredient = -2,
                    NumberOfGreenIngredient = -1,
                    NumberOfOrangeIngredient = 0,
                    NumberOfYellowIngredient = -1,
                    Price = 9
                },
                expectedCommand
            };

            // Act
            var actualCommand = Player.GetTheMostDoableCommand(inventory, commands);

            // Assert
            Assert.Equal(expectedCommand.Id, actualCommand.Id);
        }

        [Fact]
        public void ShouldGetTheBestCast()
        {
            // Arrange
            var inventory = new Inventory
            {
                NumberOfBlueIngredient = 1,
                NumberOfGreenIngredient = 0,
                NumberOfOrangeIngredient = 0,
                NumberOfYellowIngredient = 0
            };
            var command = new Command
            {
                NumberOfBlueIngredient = 0,
                NumberOfGreenIngredient = 0,
                NumberOfOrangeIngredient = 0,
                NumberOfYellowIngredient = -1
            };
            var expectedCast = new Command
            {
                Id = 2,
                NumberOfBlueIngredient = -1,
                NumberOfGreenIngredient = 1,
                NumberOfOrangeIngredient = 0,
                NumberOfYellowIngredient = 0
            };
            var casts = new List<Command>
            {
                new Command
                {
                    Id = 1,
                    NumberOfBlueIngredient = 2,
                    NumberOfGreenIngredient = 0,
                    NumberOfOrangeIngredient = 0,
                    NumberOfYellowIngredient = 0
                },
                expectedCast,
                new Command
                {
                    Id = 3,
                    NumberOfBlueIngredient = 0,
                    NumberOfGreenIngredient = -1,
                    NumberOfOrangeIngredient = 1,
                    NumberOfYellowIngredient = 0
                },
                new Command
                {
                    Id = 4,
                    NumberOfBlueIngredient = 0,
                    NumberOfGreenIngredient = 0,
                    NumberOfOrangeIngredient = -1,
                    NumberOfYellowIngredient = 1
                }
            };
            // Act
            var actualCast = Player.GetTheBestCast(inventory, command, casts);

            // Assert
            Assert.Equal(expectedCast.Id, actualCast.Id);
        }
    }
}