using System;
using Xunit;

namespace Yatzy.Tests
{
    public class DiceTests
    {
        [Fact]
        public void ShouldReturnADiceRollValueBetween1And6()
        {
            var minValue = 1;
            var maxValue = 6;
            var dice = new Dice();

            dice.Roll();

            Assert.InRange(dice.Value, minValue, maxValue);
        }
    }
}
