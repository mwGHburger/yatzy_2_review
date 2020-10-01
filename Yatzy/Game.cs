using System;
using System.Collections.Generic;

namespace Yatzy
{
    public class Game
    {
        public Game(Category category, Player player, Score score, UI ui)
        {
            Category = category;
            Player = player;
            Score = score;
            UIConsole = ui;
        }

        public UI UIConsole {get; set;}
        public Category Category {get; set;}
        public Player Player {get; set;}
        public Score Score {get; set;}
        public void Run()
        {
            UI.DisplayText("Beginning Yatzy Game!\n");
            
            while(Category.Categories.Count > 0)
            {
                UI.DisplayText($"Number of categories {Category.Categories.Count}\n");
                Player.RunRollTurn(3, UIConsole);
                
                UI.DisplayText($"\nPlayer's final dice hand is: ");
                UI.DisplayDiceHand(Player.DiceHand);
                
                // TODO: Refactor
                var hasSelectedCategory = true;
                while(hasSelectedCategory)
                {
                    UI.DisplayText("\nChoose a Category: ");
                    UI.DisplayCategories(Category.Categories);
                    var selectedCategory = UIConsole.GetInput();
                    try 
                    {
                        if (Category.ValidateCategoryInput(selectedCategory))
                        {
                            hasSelectedCategory = false;
                        }
                        else
                        {
                            throw new Exception();
                        }
                        Category.RemoveCategory(selectedCategory);
                        Player.FormatDiceHand();
                        Score.AddScoreToTotal(Score.CalculateScore(Player.DiceHandValues, selectedCategory));
                        UI.DisplayText($"\nYour total is now: {Score.Total}\n");
                    }
                    catch(Exception)
                    {
                        UI.DisplayText("Invalid input! Please select a category: ");
                    }
                }
                Player.Reset();
            }
            UI.DisplayText("Game ending...");
            
        }
    }
}
