using System.Net.Http.Headers;

namespace Days;
public class Day2 {
    private static string[] lines = File.ReadAllLines("../inputs/input2.txt");

    public static int SolvePartOne(string[] calibrationDocument) {
        int sum = 0;
        foreach (String line in calibrationDocument) {
            string[] substrings = line.Split(' ').Select(s => s.Trim(':', ',')).ToArray();
            int gameID = int.Parse(substrings[1]);
            int[] colourAmounts = {0,0,0};
            bool gameIsValid = true;
            for(int i = 2; i < substrings.Length; i+=2) {
                int amount = int.Parse(substrings[i]);
                String colour = substrings[i+1];
                IncrementColourAmount(amount, colour, colourAmounts);
                if(!CheckIfGameIsValid(colourAmounts)) {
                    gameIsValid = false;
                    break;
                }
                if(colour[colour.Length - 1].Equals(';')) {
                    colourAmounts = new int[]{0,0,0};
                }
            }
            if(!gameIsValid) {
                continue;
            }
            sum += gameID;
        }
        return sum;
    }
    
    private static void IncrementColourAmount(int amount, String colour, int[] colourAmounts) {
        if (colour.StartsWith("red")) {
            colourAmounts[0] += amount;
        }
        if (colour.StartsWith("green")) {
            colourAmounts[1] += amount;
        }
        if (colour.StartsWith("blue")) {
            colourAmounts[2] += amount;
        }
    }

    private static bool CheckIfGameIsValid(int[] colourAmounts) {
        if (colourAmounts[0] > 12) {
            return false;
        }
        if (colourAmounts[1] > 13) {
            return false;
        }
        if (colourAmounts[2] > 14) {
            return false;
        }
        return true;
    }
    public static int SolvePartTwo(string[] calibrationDocument) {
        return 0;
    }

    public static void SolveDayTwo() {
        Console.WriteLine($"Part one: {SolvePartOne(lines)}");
        Console.WriteLine($"Part two: {SolvePartTwo(lines)}");
    }
}