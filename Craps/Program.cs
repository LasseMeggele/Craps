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
                var c = new Cup();

                WriteLine("Please press Enter to roll again...");
                ReadKey();
                WriteLine($"You rolled {c.Sum()} ({c.Dice1.Eyes} and {c.Dice2.Eyes}) on your second roll.");

                do
                {
                    if (c.IsSeven())
                    {
                        WriteLine($"Congratulations, you rolled {c.Sum()} and you've won the game.");
                        ReadKey();
                        break;
                    }

                    if (c == cup)
                    {
                        WriteLine($"Congratulations, you rolled a {c.Dice1.Eyes} and a {c.Dice2.Eyes} the same as the first roll. You've won the game.");
                        ReadKey();
                        break;
                    }

                    WriteLine("Please press Enter to roll again...");
                    ReadKey();

                    c.Roll();

                    WriteLine($"You rolled {c.Sum()} ({c.Dice1.Eyes} and {c.Dice2.Eyes})");
                } while (true);
            }
        }
    }
}
