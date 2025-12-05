using MathGame.Models;
using System;

namespace MathGame;

internal class Helpers
{
    internal static List<Game> history = new();
    internal static (int firstNumber, int secondNumber) GetRandomNumbers(Difficulty difficultyLevel)
    {
        int maxNumber = GetDifficultyRange(difficultyLevel);
        Random seed = new();
        int first = seed.Next(1, maxNumber);
        int second = seed.Next(1, maxNumber);
        return (first, second);
    }
    internal static (int firstNumber, int secondNumber) GetDivisionNumbers(Difficulty difficultyLevel)
    {
        int first;
        int second;
        do
        {
            var randomNumbers = GetRandomNumbers(difficultyLevel);
            first = randomNumbers.firstNumber;
            second = randomNumbers.secondNumber;
        } while ((first % second != 0) || (first == second) || (first == 1) || (second == 1));
        return (first, second);
    }

    internal static int GetDifficultyRange(Difficulty difficultyLevel)
    {
        return difficultyLevel switch
        {
            Difficulty.easy => 9,
            Difficulty.normal => 19,
            Difficulty.hard => 99,
            Difficulty.expert => 999,
            _ => 9
        };
    }

    internal static GameType GetRandomGame()
    {
        Random seed = new();
        int gameType = seed.Next(1, 4);
        return gameType switch
        {
            1 => GameType.Addition,
            2 => GameType.Subtraction,
            3 => GameType.Multiplication,
            4 => GameType.Division,
            _ => GameType.Addition
        };
    }

    internal static string GetName()
    {
        var name = "";
        Console.WriteLine("Please type your name");
        name = Console.ReadLine();
        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Your name is empty");
            name = Console.ReadLine();
        }
        return name;
    }
    internal static void AddHistory(GameType gameType, int score, Difficulty diff, double time)
    {
        history.Add(new Models.Game
        {
            Type = gameType,
            Score = score,
            Date = DateTime.Now,
            DificultyLevel = diff,
            TimeTaken = time
        });
    }
    internal static Difficulty SelectDifficulty()
    {
        Console.WriteLine("Choose difficulty\n 1 - Easy\n 2 - Normal\n 3 - Hard\n 4 - Expert");
        var option = Console.ReadLine();
        int temp;
        while (string.IsNullOrEmpty(option) || !Int32.TryParse(option, out temp) || (temp < 1) || (temp > 4))
        {
            Console.WriteLine("Your answer need to be a valid option. Try again.");
            option = Console.ReadLine();
        }
       Difficulty diff =  temp switch
        {
            1 => Difficulty.easy,
            2 => Difficulty.normal,
            3 => Difficulty.hard,
            4 => Difficulty.expert,
            _ => Difficulty.easy
        };

        Console.WriteLine($"You have selected {diff} difficulty. Numbers will be between 1 and {GetDifficultyRange(diff)}");
        return diff;
    }
    internal static void GetHistory()
    {
        Console.Clear();
        Console.WriteLine("Games history");
        foreach (var game in history)
            Console.WriteLine($"{game.Date} -- {game.Type} : {game.DificultyLevel} => {game.Score} pts in {game.TimeTaken:F2} seconds");
        Console.WriteLine("Type any key to continue");
        Console.ReadLine();
    }
    internal static string? ValidationInput(string? result)
    {
        int num;
        while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out num))
        {
            Console.WriteLine("Your answer need to be an integer. Try again.");
            result = Console.ReadLine();
        }
        return result;
    }

}