using System;

namespace Yatzy
{
    public class Dice
    {
        public int Value { get; private set; }
        public bool IsHeld { get; set; }

        public void Roll()
        {
            Random rnd = new Random();
            int randomDiceRoll  = rnd.Next(1, 7);
            Value = randomDiceRoll;
        }
    }
}