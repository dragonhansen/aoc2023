using System.Text.RegularExpressions;

using System.Net.Http.Headers;
namespace Days
{
    public class Day3
    {
        public static int SolvePartOne(string[] lines)
        {
            int sum = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string digitPattern = @"\d+";
                MatchCollection digitMatches = Regex.Matches(line, digitPattern);
                foreach (Match match in digitMatches)
                {
                    string number = match.Value;
                    int begin = match.Index;
                    int end = begin + number.Length - 1;
                    if (CheckIfNumberIsPartNumber(begin, end, i, lines))
                    {
                        sum += int.Parse(number);
                    }
                }
            }
            return sum;
        }

        private static bool CheckIfNumberIsPartNumber(int begin, int end, int i, string[] lines)
        {
            string line = lines[i];
            if (begin > 0 && !line[begin - 1].Equals('.'))
            {
                return true;
            }
            if (end < line.Length - 1 && !line[end + 1].Equals('.'))
            {
                return true;
            }
            for (int j = begin - 1; j < end + 2; j++)
            {
                if (j < 0 || j > line.Length - 1)
                {
                    continue;
                }
                if (i > 0 && !lines[i - 1][j].Equals('.') || i < lines.Length - 1 && !lines[i + 1][j].Equals('.'))
                {
                    return true;
                }
            }
            return false;
        }

        public static int SolvePartTwo(string[] lines)
        {
            List<MatchCollection> allDigitMatches = new List<MatchCollection>();
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string digitPattern = @"\d+";
                MatchCollection digitMatches = Regex.Matches(line, digitPattern);
                allDigitMatches.Add(digitMatches);
            }
            int sum = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string asteriskPattern = @"[*]+";
                MatchCollection asteriskMatches = Regex.Matches(line, asteriskPattern);
                foreach (Match asteriskMatch in asteriskMatches)
                {
                    sum += CalculateGearRatio(i, asteriskMatch, allDigitMatches, lines.Length);
                }
            }
            return sum;
        }

        private static int CalculateGearRatio(int i, Match asteriskMatch, List<MatchCollection> allDigitMatches, int inputLength)
        {
            List<int> adjacentPartNumbers = new List<int>();
            if (i > 0)
            {
                foreach (Match digitMatch in allDigitMatches[i - 1])
                {
                    if (digitMatch.Index - 1 <= asteriskMatch.Index && asteriskMatch.Index <= digitMatch.Index + digitMatch.Length)
                    {
                        adjacentPartNumbers.Add(int.Parse(digitMatch.Value));
                    }
                }
            }
            if (i < inputLength - 1)
            {
                foreach (Match digitMatch in allDigitMatches[i + 1])
                {
                    if (digitMatch.Index - 1 <= asteriskMatch.Index && asteriskMatch.Index <= digitMatch.Index + digitMatch.Length)
                    {
                        adjacentPartNumbers.Add(int.Parse(digitMatch.Value));
                    }
                }
            }
            foreach (Match digitMatch in allDigitMatches[i])
            {
                if (digitMatch.Index + digitMatch.Length - 1 == asteriskMatch.Index - 1)
                {
                    adjacentPartNumbers.Add(int.Parse(digitMatch.Value));
                }
                if (digitMatch.Index - 1 == asteriskMatch.Index)
                {
                    adjacentPartNumbers.Add(int.Parse(digitMatch.Value));
                }
            }
            if (adjacentPartNumbers.Count() == 2)
            {
                return adjacentPartNumbers[0] * adjacentPartNumbers[1];
            }
            return 0;
        }

        public static void SolveDay3()
        {
            string[] lines = File.ReadAllLines("../inputs/input3.txt");
            Console.WriteLine($"Part one: {SolvePartOne(lines)}");
            Console.WriteLine($"Part two: {SolvePartTwo(lines)}");
        }
    }
}
