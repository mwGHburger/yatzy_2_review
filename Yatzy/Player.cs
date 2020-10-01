using System;
using System.Collections.Generic;

namespace Yatzy
{
    public class Player
    {
        public Player(List<Dice> diceHand)
        {
            DiceHand = diceHand;
            DiceHandValues = new int[5];
        }

        public List<Dice> DiceHand { get; private set; } = new List<Dice>()
        {
            new Dice(),
            new Dice(),
            new Dice(),
            new Dice(),
            new Dice()
        };
        public string SelectedCategory { get; set;}
        public int RollCount { get; set;}
        public int[] DiceHandValues { get; set;}

        public void RollDiceHand()
        {
            foreach(Dice dice in DiceHand)
            {
                if(!dice.IsHeld)
                {
                    dice.Roll();
                }
            }
        }

        public void FormatDiceHand()
        {
            var DiceValues = new int[5];
            for(int i = 0; i < DiceHand.Count; i++)
            {
                DiceHandValues[i] = DiceHand[i].Value;
            }
        }

        public void SelectCategory(string category)
        {
            SelectedCategory = category;
        }

        public void ChooseDiceToHold(IUserInput input)
        {
            UI.DisplayText("Now decide which dice you want to hold: ");
            
            int counter = 1;
            foreach(Dice dice in DiceHand)
            {
                if(dice.IsHeld)
                {
                    counter++;
                    continue;
                } 
                System.Console.WriteLine($"[Dice {counter}] Want to hold {dice.Value}?");
                var response = input.GetInput();
                if(response == "yes")
                {
                    System.Console.WriteLine("Decided to hold!");
                    dice.IsHeld = true;
                }
                counter++;
            }
        }

        public void Reset()
        {
            UI.DisplayText("Resetting player dice hand.");
            foreach(Dice dice in DiceHand)
            {
                dice.IsHeld = false;
            }
            RollCount = 0;
        }
        public void IncreaseRollCount()
        {
            UI.DisplayText("Increased player roll count.");
            RollCount += 1;
        }

        public bool CheckHeldAllDice()
        {
            foreach(Dice dice in DiceHand)
            {
                if (!dice.IsHeld)
                {
                    return false;
                }
            }
            return true;
        }

        public void RunRollTurn(int maximumRolls, IUserInput input)
        {
            while(RollCount < maximumRolls)
            {   
                if (CheckHeldAllDice()) { return; }
                UI.DisplayText($"Roll Turn: {RollCount + 1}");
                RollDiceHand();
                UI.DisplayDiceHand(DiceHand);
                IncreaseRollCount();
                if (RollCount < maximumRolls)
                {
                    ChooseDiceToHold(input);
                }
            }
        }

    }
}