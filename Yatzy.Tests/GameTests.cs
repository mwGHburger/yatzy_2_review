using System.Collections.Generic;
using Moq;
using Xunit;

namespace Yatzy.Tests
{
    public class GameTests
    {
        // TODO: Testing Whole Systems & Automate inputs
        // [Fact]
        public void ShouldCallCertainMethodWhenGameRuns()
        {
            var diceHand = new List<Dice> {
                new Dice(),
                new Dice(),
                new Dice(),
                new Dice(),
                new Dice()
            };
            
            // Mock object inputs
            var mockCategory = new Mock<Category>();
            mockCategory.Setup(x => x.Categories).Returns(new List<string>());
            var mockPlayer = new Mock<Player>(diceHand);

            var mockScore = new Mock<Score>();
            var mockUI = new Mock<UI>();
            mockUI.Setup(x => x.GetInput()).Returns("yes");

            var game = new Game(mockCategory.Object, mockPlayer.Object, mockScore.Object, mockUI.Object);
            game.Run();
            
            mockPlayer.Verify(x => x.RunRollTurn(3, It.IsAny<IUserInput>()));
            
        }
    }
}