using static System.Console;

namespace Craps
{
    internal class Program
    {
        private static void Main()
        {
            var cup = new Cup();

            WriteLine($"You rolled {cup.Sum()} ({cup.Dice1.Eyes} and {cup.Dice2.Eyes}) on your first roll.");

            if (cup.IsSeven() || cup.IsEleven())
            {
                WriteLine("Congratulations, you've won the game.");
                ReadKey();
            }
            else if (cup.IsSnakeEyes() || cup.IsThree() || cup.IsTwelve())
            {
                WriteLine("We're sorry, you've lost the game.");
                ReadKey();
            }
            else
            {
                WriteLine("Please press Enter to roll again...");
                ReadKey();

                var newCup = new Cup();

                WriteLine($"You rolled {newCup.Sum()} ({newCup.Dice1.Eyes} and {newCup.Dice2.Eyes}) on your second roll.");

                do
                {
                    if (newCup.IsSeven())
                    {
                        WriteLine($"Congratulations, you rolled {newCup.Sum()} and you've won the game.");
                        ReadKey();
                        break;
                    }

                    if (newCup == cup)
                    {
                        WriteLine($"Congratulations, you rolled a {newCup.Dice1.Eyes} and a {newCup.Dice2.Eyes} the same as the first roll. You've won the game.");
                        ReadKey();
                        break;
                    }

                    WriteLine("Please press Enter to roll again...");
                    ReadKey();

                    newCup.Roll();

                    WriteLine($"You rolled {newCup.Sum()} ({newCup.Dice1.Eyes} and {newCup.Dice2.Eyes})");
                } while (true);
            }
        }
    }
}
