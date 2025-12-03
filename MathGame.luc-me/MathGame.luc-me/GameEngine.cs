using MathGame.Models;

namespace MathGame;

internal class GameEngine
{
    internal void Operation(Models.GameType gameType, bool random = false)
    {
        int firstNumber;
        int secondNumber;
        Console.Clear();
        Console.WriteLine($"{gameType} game selected");
        var difficulty = Helpers.SelectDifficulty();
        int score = 0;
        var timer = System.Diagnostics.Stopwatch.StartNew();
        for (int i = 0; i < 5; i++)
        {
            var randomNumbers = Helpers.GetRandomNumbers(difficulty);
            firstNumber = randomNumbers.firstNumber;
            secondNumber = randomNumbers.secondNumber;
            if (random)
                gameType = Helpers.GetRandomGame();
            switch (gameType)
            {
                case Models.GameType.Addition:
                    Console.WriteLine($"{firstNumber} + {secondNumber}");
                    break;
                case Models.GameType.Subtraction:
                    Console.WriteLine($"{firstNumber} - {secondNumber}");
                    break;
                case Models.GameType.Multiplication:
                    Console.WriteLine($"{firstNumber} * {secondNumber}");
                    break;
                case Models.GameType.Division:
                    Console.WriteLine($"{firstNumber} / {secondNumber}");
                    break;
            }
            var result = Helpers.ValidationInput(Console.ReadLine());
            if (ValidationResult(result, firstNumber, secondNumber, gameType))
                score++;
        }
        timer.Stop();
        Console.WriteLine($"Game over. Your final score is: {score}");
        Console.WriteLine($"Time taken: {timer.Elapsed.TotalSeconds:F2} seconds");
        if (random)
            gameType = GameType.Random;
        Helpers.AddHistory(gameType, score, difficulty, timer.Elapsed.TotalSeconds);
    }
    private static bool ValidationResult(string result, int firstNumber, int secondNumber, Models.GameType gametype)
    {
        switch (gametype)
        {
            case Models.GameType.Addition:
                if (result == Convert.ToString(firstNumber + secondNumber))
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next cuestion");
                    Console.ReadLine();
                    return true;
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect! Type any key for the next cuestion");
                    Console.ReadLine();
                    return false;
                }
            case Models.GameType.Subtraction:
                if (result == Convert.ToString(firstNumber - secondNumber))
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next cuestion");
                    Console.ReadLine();
                    return true;
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect! Type any key for the next cuestion");
                    Console.ReadLine();
                    return false;
                }
            case Models.GameType.Multiplication:
                if (result == Convert.ToString(firstNumber * secondNumber))
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next cuestion");
                    Console.ReadLine();
                    return true;
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect! Type any key for the next cuestion");
                    Console.ReadLine();
                    return false;
                }
            case Models.GameType.Division:
                if (result == Convert.ToString(firstNumber / secondNumber))
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next cuestion");
                    Console.ReadLine();
                    return true;
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect! Type any key for the next cuestion");
                    Console.ReadLine();
                    return false;
                }
            default:
                return false;
        }
    }

}