using MathGame.Models;

namespace MathGame;

internal class Menu
{
    GameEngine engine = new();
    internal void ShowMenu()
    {
        var name = Helpers.GetName();
        Console.WriteLine($"Hello {name}. It's {DateTime.UtcNow}. This is your math game!");

        bool gameIsOn = true;
        do
        {
            Console.WriteLine("This is the main menu, please select a game\n1-Addition\n2-Subtraction\n3-Multiplication\n4-Division\n5-Random game\n6-History\n7-Quit game");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int option))
            {
                switch (option)
                {
                    case 1:
                        engine.Operation(GameType.Addition);
                        break;
                    case 2:
                        engine.Operation(GameType.Subtraction);
                        break;
                    case 3:
                        engine.Operation(GameType.Multiplication);
                        break;
                    case 4:
                        engine.Operation(GameType.Division);
                        break;
                    case 5:
                        engine.Operation(GameType.Random,true);
                        break;
                    case 6:
                        Helpers.GetHistory();
                        break;
                    case 7:
                        gameIsOn = false;
                        break;
                    default:
                        break;
                }
            }
            else
                Console.WriteLine("Invalid option (put a number between 1-6)");
        } while (gameIsOn);

    }

}