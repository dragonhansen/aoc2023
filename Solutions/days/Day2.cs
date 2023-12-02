using System.Net.Http.Headers;

namespace Days;
public class Day2
{
    private static string[] lines = File.ReadAllLines("../inputs/input2.txt");
    private static int sum = 0;
    private static int powerSum = 0;
    public static void ParseInput(string[] calibrationDocument)
    {
        foreach (String line in calibrationDocument)
        {
            string[] substrings = line.Split(' ').Select(s => s.Trim(':', ',')).ToArray();
            int gameID = int.Parse(substrings[1]);
            Dictionary<string, int> colourAmounts = new Dictionary<string, int>();
            Dictionary<string, int> colourMinima = new Dictionary<string, int>();
            bool gameIsValid = true;
            for (int i = 2; i < substrings.Length; i += 2)
            {
                int amount = int.Parse(substrings[i]);
                String colour = substrings[i + 1];
                bool finalDraw = false;
                if (colour.EndsWith(';'))
                {
                    finalDraw = true;
                    colour = colour.Substring(0, colour.Length - 1);
                }
                colourAmounts.Add(colour, amount);
                if (!CheckIfGameIsValid(colourAmounts))
                {
                    gameIsValid = false;
                }
                if (finalDraw | i == substrings.Length - 2)
                {
                    SetMinima(colourAmounts, colourMinima);
                    colourAmounts.Clear();
                }
            }
            if (gameIsValid)
            {
                sum += gameID;
            }
            powerSum += colourMinima.Values.Aggregate(1, (current, value) => current * value);
        }
    }

    private static bool CheckIfGameIsValid(Dictionary<string, int> colourAmounts)
    {
        if (colourAmounts.GetValueOrDefault("red") > 12)
        {
            return false;
        }
        if (colourAmounts.GetValueOrDefault("green") > 13)
        {
            return false;
        }
        if (colourAmounts.GetValueOrDefault("blue") > 14)
        {
            return false;
        }
        return true;
    }

    private static void SetMinima(Dictionary<string, int> colourAmounts, Dictionary<string, int> colourMinima)
    {
        string[] keys = { "red", "green", "blue" };
        foreach (String key in keys)
        {
            if (colourAmounts.GetValueOrDefault(key) > colourMinima.GetValueOrDefault(key))
            {
                colourMinima[key] = colourAmounts[key];
            }
        }
    }

    public static void SolveDayTwo()
    {
        ParseInput(lines);
        Console.WriteLine($"Part one: {sum}");
        Console.WriteLine($"Part two: {powerSum}");
    }
}