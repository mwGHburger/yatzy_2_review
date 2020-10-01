using Xunit;

namespace Yatzy.Tests
{
    public class ScoreTests
    {
        [Theory]
        [InlineData(50,0,50)]
        [InlineData(100,25,75)]
        public void ShouldAddScoreToTotal(int expectedTotal, int currentTotal, int scoreToAdd)
        {
            var score = new Score();
            score.Total = currentTotal;
            score.AddScoreToTotal(scoreToAdd);

            var actualTotal = score.Total;

            Assert.Equal(expectedTotal, actualTotal);
        }

        [Theory]
        [InlineData(50, new int[5] {1,1,1,1,1}, "yatzy")]
        [InlineData(0, new int[5] {1,1,1,2,1}, "yatzy")]
        public void ShouldReturnScoreForYatzy(int expectedScore, int[] roll, string category)
        {
            var score = new Score();

            var actualScore = score.CalculateScore(roll, category);

            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(8, new int[5] {1,1,2,2,2}, "full house")]
        [InlineData(0, new int[5] {2,2,3,3,4}, "full house")]
        [InlineData(0, new int[5] {4,4,4,4,4}, "full house")]
        public void ShouldReturnScoreForFullHouse(int expectedScore, int[] roll, string category)
        {
            var score = new Score();

            var actualScore = score.CalculateScore(roll, category);

            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(20, new int[] { 2,3,4,5,6}, "large straight")]
        [InlineData(20, new int[] { 6,5,4,2,3}, "large straight")]
        [InlineData(0, new int[] { 1,2,3,4,5}, "large straight")]
        public void ReturnScoreForLargeStraight(int expectedScore, int[] roll, string category)
        {
            var score = new Score();

            var actualScore = score.CalculateScore(roll, category);

            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(15, new int[] { 1,2,3,4,5}, "small straight")]
        [InlineData(15, new int[] { 2,1,4,3,5}, "small straight")]
        [InlineData(0, new int[] { 2,3,4,5,6}, "small straight")]
        public void ReturnScoreForSmallStraight(int expectedScore, int[] roll, string category)
        {
            var score = new Score();

            var actualScore = score.CalculateScore(roll, category);

            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(8, new int[] { 2,2,2,2,5}, "four of a kind")]
        [InlineData(0, new int[] { 2,2,2,5,5}, "four of a kind")]
        [InlineData(8, new int[] { 2,2,2,2,2}, "four of a kind")]
        public void ReturnScoreForFourOfAKind(int expectedScore, int[] roll, string category)
        {
            var score = new Score();

            var actualScore = score.CalculateScore(roll, category);

            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(9, new int[] { 3,3,3,4,5}, "three of a kind")]
        [InlineData(0, new int[] { 3,3,4,5,6}, "three of a kind")]
        [InlineData(9, new int[] { 3,3,3,3,1}, "three of a kind")]
        public void ReturnScoreForThreeOfAKind(int expectedScore, int[] roll, string category)
        {
            var score = new Score();

            var actualScore = score.CalculateScore(roll, category);

            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(8, new int[] {1,1,2,3,3},"two pairs")]
        [InlineData(0, new int[] {1,1,2,3,4},"two pairs")]
        [InlineData(6, new int[] {1,1,2,2,2},"two pairs")]
        public void ReturnScoreForTwoPairs(int expectedScore, int[] roll, string category)
        {
            var score = new Score();
            var actualScore = score.CalculateScore(roll, category);
            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(8, new int[5] {3,3,3,4,4}, "pair")]
        [InlineData(12, new int[5] {1,1,6,2,6}, "pair")]
        [InlineData(6, new int[5] {3,3,3,4,1}, "pair")]
        [InlineData(6, new int[5] {3,3,3,3,1}, "pair")]
        public void ReturnScoreForPair(int expectedScore, int[] roll, string category)
        {
            var score = new Score();

            var actualScore = score.CalculateScore(roll, category);

            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(8, new int[5] {1,1,2,4,4}, "fours")]
        [InlineData(4, new int[5] {2,3,2,5,1}, "twos")]
        [InlineData(0, new int[5] {3,3,3,4,5}, "ones")]
        public void ReturnScoreFor_Ones_Twos_Threes_Fours_Fives_Sixes(int expectedScore, int[] roll, string category)
        {
            var score = new Score();

            var actualScore = score.CalculateScore(roll, category);

            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(14, new int[5] {1,1,3,3,6}, "chance")]
        [InlineData(21, new int[5] {4,5,5,6,1}, "chance")]
        public void ReturnScoreForChance(int expectedScore, int[] roll, string category)
        {
            var score = new Score();
            
            var actualScore = score.CalculateScore(roll,category);

            Assert.Equal(expectedScore, actualScore);
        }
    }
}