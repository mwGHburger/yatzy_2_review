using System.Collections.Generic;
using Moq;
using Xunit;

namespace Yatzy.Tests
{
    public class PlayerTests
    {
        List<Dice> diceHand = new List<Dice>()
            {
                new Dice(),
                new Dice(),
                new Dice(),
                new Dice(),
                new Dice()
            };
        

        const int maximumRolls = 3;
        
        [Fact]
        public void ShouldRollDiceHand()
        {
            var player = new Player(diceHand);

            player.RollDiceHand();

            var diceValueTotal = 0;
            foreach(Dice die in player.DiceHand)
            {
                diceValueTotal += die.Value;
            }

            Assert.InRange(diceValueTotal, 6, 30);
        }

        [Fact]
        public void SelectedCategoryPropertyShould_ReturnString()
        {
            var player = new Player(diceHand);
            player.SelectCategory("yatzy");
            Assert.Equal("yatzy", player.SelectedCategory);
        }

        [Fact]
        public void ShouldBeAbleToDecideWhetherToHoldDice()
        {
            var player = new Player(diceHand);
            var mockConsoleParser = new Mock<UI>();
            mockConsoleParser.Setup(x => x.GetInput()).Returns("yes");
            player.RollDiceHand();
            player.ChooseDiceToHold(mockConsoleParser.Object);
            Assert.True(diceHand[0].IsHeld);
        }

        [Fact]
        public void ShouldIncreaseRollCountBy1()
        {
            var player = new Player(diceHand);
            var expectedRollCount = 1;
            player.IncreaseRollCount();
            Assert.Equal(expectedRollCount, player.RollCount);
        }

        // Test Should reroll hand for dice not held
        [Fact]
        public void ShouldNotReRollDiceHeldDuringRunRollTurn()
        {
            var mockConsoleParser = new Mock<UI>();
            mockConsoleParser.Setup(x => x.GetInput()).Returns("yes");

            var player = new Player(diceHand);
            player.RollDiceHand();
            var expected = player.DiceHand[1].Value;
            player.DiceHand[1].IsHeld = true;
            player.RunRollTurn(maximumRolls, mockConsoleParser.Object);
            Assert.Equal(expected, player.DiceHand[1].Value);
        }

        [Fact]
        public void ShouldResetTurnAfterRound()
        {
            var mockConsoleParser = new Mock<UI>();
            mockConsoleParser.Setup(x => x.GetInput()).Returns("yes");

            var player = new Player(diceHand);
            player.RunRollTurn(maximumRolls, mockConsoleParser.Object);
            player.Reset();
            Assert.False(player.DiceHand[0].IsHeld);
            Assert.Equal(0,player.RollCount);
        }

        [Fact] 
        public void ShouldNotLetPlayersHaveMoreThan3DiceRolls()
        {
            var mockConsoleParser = new Mock<UI>();
            mockConsoleParser.Setup(x => x.GetInput()).Returns("no");
            var player = new Player(diceHand);
            var expectedRollCount = 3;
            player.RunRollTurn(maximumRolls, mockConsoleParser.Object);
            Assert.Equal(expectedRollCount, player.RollCount);
        }
    }
}