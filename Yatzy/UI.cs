using System;
using System.Collections.Generic;

namespace Yatzy
{
    public class UI : IUserInput
    {
        public virtual string GetInput(){
            return Console.ReadLine();
        }

        public static void DisplayText(string input)
        {
            Console.WriteLine($"{input}");
        }

        public static void DisplayDiceHand(List<Dice> diceHand)
        {
            var display = "";
            foreach(Dice dice in diceHand)
            {
                display = String.Concat(display, $"[{dice.Value}] ");
            }
            Console.WriteLine(display);
        }

        public static void DisplayCategories(List<string> categories)
        {
            var availableCategories = "";
            foreach(string category in categories)
            {
                availableCategories = String.Concat(availableCategories, $"[{category}] ");
            }
            Console.WriteLine(availableCategories);
        }
    }
}