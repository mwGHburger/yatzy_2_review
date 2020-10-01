using System.Collections.Generic;
using System;

namespace Yatzy
{
    class Program
    {
        static void Main(string[] args)
        {
            // var cat = new Category();
            // System.Console.WriteLine(cat.Categories.Count); 
            // cat.RemoveCategory("yatzy");
            // System.Console.WriteLine(cat.Categories.Count); 
            // cat.RemoveCategory("yatzy");
            // System.Console.WriteLine(cat.Categories.Count); 
            
            var diceHand = new List<Dice> {
                new Dice(),
                new Dice(),
                new Dice(),
                new Dice(),
                new Dice()
            };
            var player = new Player(diceHand);
            var game = new Game(new Category(), player, new Score(), new UI());
            game.Run();
        }
    }
}
