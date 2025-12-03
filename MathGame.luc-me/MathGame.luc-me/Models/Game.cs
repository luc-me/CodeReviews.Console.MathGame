namespace MathGame.Models;

internal class Game
{
    public int Score { get; set; }
    public DateTime Date { get; set; }
    public GameType Type { get; set; }
    public Difficulty DificultyLevel { get; set; }
    public double TimeTaken { get; set; }

}
internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
    Random
}
internal enum Difficulty
{
    easy,
    normal,
    hard,
    expert
}