using System.Text.RegularExpressions;
using System.Linq;
using System.ComponentModel;

namespace Days;
class Day1 {
    private static string[] lines = File.ReadAllLines("inputs/input1.txt");

    private static void SolvePartOne(string[] calibrationDocument) {
        int digitSum = 0;
        foreach (String line in calibrationDocument) {
            String digitString = Regex.Replace(line, "[^0-9.]", "");
            String calibrationValue = "" + digitString.First() + digitString.Last();
            digitSum += int.Parse(calibrationValue);
        }
        Console.WriteLine($"Part one: {digitSum}");
    }

    private static void SolvePartTwo(string[] calibrationDocument) {
        string[] spelledDigits = {"one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
        int digitSum = 0;
        foreach (String line in calibrationDocument) {
            String tempLine = line;
            for (int i = 1; i < 10; i++) {
                String spelledDigit = spelledDigits[i-1];
                tempLine = tempLine.Replace(spelledDigit, i.ToString());
            }
            String digitString = Regex.Replace(tempLine, "[^0-9.]", "");
            String calibrationValue = "" + digitString.First() + digitString.Last();
            digitSum += int.Parse(calibrationValue);
            Console.WriteLine(calibrationValue);
            if (calibrationValue.Equals("71")) {
                break;
            }
        }
        Console.WriteLine($"Part two: {digitSum}");
    }

    public static void SolveDayOne() {
        SolvePartOne(lines);
        SolvePartTwo(lines);
    }
}