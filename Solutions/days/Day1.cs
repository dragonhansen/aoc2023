using System.Text.RegularExpressions;
namespace Days;
public class Day1 {
    private static string[] lines = File.ReadAllLines("../inputs/input1.txt");

    public static int SolvePartOne(string[] calibrationDocument) {
        int digitSum = 0;
        foreach (String line in calibrationDocument) {
            String digitString = Regex.Replace(line, "[^0-9.]", "");
            String calibrationValue = "" + digitString.First() + digitString.Last();
            digitSum += int.Parse(calibrationValue);
        }
        return digitSum;
    }

    public static int SolvePartTwo(string[] calibrationDocument) {
        string[] spelledDigits = {"one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
        int digitSum = 0;
        foreach (String line in calibrationDocument) {
            String tempLine = line;
            for (int i = 1; i < 10; i++) {
                String spelledDigit = spelledDigits[i-1];
                // Not the most elegant soltion but the first and last letter of a spelled digit are inserted arond the acutal spelled digit
                // this is done to account for cases such as oneight, sevenine, etc
                tempLine = tempLine.Replace(spelledDigit, spelledDigit[0] + i.ToString() + spelledDigit[spelledDigit.Length-1]);
            }
            String digitString = Regex.Replace(tempLine, "[^0-9.]", "");
            String calibrationValue = "" + digitString.First() + digitString.Last();
            digitSum += int.Parse(calibrationValue);
        }
        return digitSum;
    }

    public static void SolveDayOne() {
        Console.WriteLine($"Part one: {SolvePartOne(lines)}");
        Console.WriteLine($"Part two: {SolvePartTwo(lines)}");
    }
}