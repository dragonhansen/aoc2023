using System.Text.RegularExpressions;
namespace Days {
    public class Day3
    {
        public static int SolvePartOne(string[] input)
        {
            int sum = 0;
            for(int i = 0; i<input.Length; i++) {
                string line = input[i];
                string pattern = @"\d+";
                MatchCollection matches = Regex.Matches(line, pattern);
                foreach(Match match in matches) {
                    string number = match.Value;
                    int begin = match.Index;
                    int end = begin + number.Length-1;
                    if(CheckIfNumberIsPartNumber(begin, end, i, input)) {
                        sum += int.Parse(number);
                    }
                }
            }
            return sum;
        }

        private static bool CheckIfNumberIsPartNumber(int begin, int end, int i, string[] lines)
        {
            string line = lines[i];
            if(begin > 0 && !line[begin-1].Equals('.')) {
                return true;
            }
            if(end < line.Length-1 && !line[end+1].Equals('.')) {
                return true;
            }
            for(int j = begin-1; j < end+2; j++) {
                if(j < 0 || j > line.Length-1) {
                    continue;
                }
                if(i > 0 && !lines[i-1][j].Equals('.') || i < lines.Length-1 && !lines[i+1][j].Equals('.')) {
                    return true;
                }
            }
            return false;
        }

        public static int SolvePartTwo(string[] input)
        {
            return 0;
        }
        public static void SolveDay3()
        {
            string[] lines = File.ReadAllLines("../inputs/input3.txt");
            string[] input = {"467..114..",
                        "...*......",
                        "..35..633.",
                        "......#...",
                        "617*......",
                        ".....+.58.",
                        "..592.....",
                        "......755.",
                        "...$.*....",
                        ".664.598.."};
            Console.WriteLine(SolvePartOne(lines));
            Console.WriteLine("Part one: ");
            Console.WriteLine("Part two: ");
        }
    }
}
