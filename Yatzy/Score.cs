using System.Linq;
using System.Collections.Generic;
using System;
namespace Yatzy
{
    public class Score
    {
        public int Total {get; set;}

        public void AddScoreToTotal(int score)
        {
            Total += score;
        }

        public int CalculateScore(int[] roll, string category)
        {
            switch(category)
            {
                case "yatzy":
                    return ScoreForYatzy(roll);
                case "full house":
                    return ScoreForFullHouse(roll);
                case "large straight":
                    var largeStraight = new int[5] {2,3,4,5,6};
                    return ScoreForStraight(roll, largeStraight);
                case "small straight":
                    var smallStraight = new int[5] {1,2,3,4,5};
                    return ScoreForStraight(roll, smallStraight);    
                case "four of a kind":
                    return ScoreForNumberOfKind(roll, 4, 1);
                case "three of a kind":
                    return ScoreForNumberOfKind(roll, 3, 1);
                case "two pairs":
                    return ScoreForNumberOfKind(roll, 2, 2);
                case "pair":
                    return ScoreForNumberOfKind(roll, 2, 1);
                case "sixes":
                    return ScoreFor(roll, 6);
                case "fives":
                    return ScoreFor(roll, 5);
                case "fours":
                    return ScoreFor(roll, 4);
                case "threes":
                    return ScoreFor(roll, 3);
                case "twos":
                    return ScoreFor(roll, 2);
                case "ones":
                    return ScoreFor(roll, 1);
                case "chance":
                    return ScoreForChance(roll);
                default:
                    return 0;
            }

        }

        private int ScoreForYatzy(int[] roll)
        {
            if (FindRecurringNumbers(roll, 5).Count == 1)
            {
                return 50;
            }
            return 0;
        }

        private int ScoreForFullHouse(int[] roll)
        {
            if (FindRecurringNumbers(roll, 3).Count == 1 && FindRecurringNumbers(roll, 2).Count > 1)
            {
                return SumAllRolledValues(roll);
            }
            return 0;
        }

        private int ScoreForStraight(int[] roll, int[] straight)
        {
            Array.Sort(roll);
            if (roll.SequenceEqual(straight))
            {
                return SumAllRolledValues(roll);
            }
            return 0;
        }

        private int ScoreForNumberOfKind(int[] roll, int timesRecurring, int quantity)
        {
            var score = 0;
            var recurringNumberList = FindRecurringNumbers(roll, timesRecurring);
            if(recurringNumberList.Count > 0 && quantity <= recurringNumberList.Count)
            {
                for(int i = 0; i < quantity; i++)
                {
                    score += recurringNumberList[i];
                }
                return score * timesRecurring;
            }
            return score;
        }

        private List<int> FindRecurringNumbers(int[] roll, int numberOfTimes)
        {
            var pairsList = new List<int>();
            for(int i = 6; i > 0; i--)
            {
                if (Array.FindAll(roll, x => x == i).Length >= numberOfTimes)
                {
                    pairsList.Add(i);
                }
            }
            return pairsList;
        }

        private int ScoreFor(int[] roll, int num)
        {
            var frequency = Array.FindAll(roll, x => x == num).Length;
            return num * frequency;
        }

        private int ScoreForChance(int[] roll)
        {
            return SumAllRolledValues(roll);
        }
            
        private int SumAllRolledValues(int[] roll)
        {
            var score = 0;
            foreach(int num in roll)
            {
                score += num;
            }
            return score;
        }
    }
}

