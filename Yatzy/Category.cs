using System;
using System.Collections.Generic;

namespace Yatzy
{
    public class Category
    {
        public List<string> Categories {get; set;} = new List<string> {
            "yatzy",
            "full house",
            "large straight",
            "small straight",
            "four of a kind",
            "three of a kind",
            "two pairs",
            "pair",
            "sixes",
            "fives",
            "fours",
            "threes",
            "twos",
            "ones",
            "chance"
        };
        
        public void RemoveCategory(string category)
        {
            Console.WriteLine($"Removing {category}");
            Categories.Remove(category);
        }

        public bool ValidateCategoryInput(string input)
        {
            return (Categories.Contains(input)) ? true : false;
        }
    }
}