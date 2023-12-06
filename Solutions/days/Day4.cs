using System.Globalization;

namespace Days {
    public class Day4
    {
        public static (int, int) SolveBothParts(string[] input)
        {
            int sum = 0;
            int[] cardCopies = new int[input.Length];
            for(int i = 0; i < input.Length; i++) {
                string line = input[i];
                string[] splitInput = line.Split(':')[1].Split('|');
                string[] winnerNumbers = splitInput[0].Split(' ');
                string[] myNumbers = splitInput[1].Split(' ');
                int points = 1;
                bool zeroPoints = true;
                foreach(String myNumber in myNumbers) {
                    // Have to make this check because the input is formatted in a dumb way
                    if (myNumber.Equals("")) {
                        continue;
                    }
                    if(winnerNumbers.Contains(myNumber)) {
                        zeroPoints = false;
                        points *= 2;
                    }
                }
                if(zeroPoints) {
                    continue;
                }
                // We want to add a copy of the next [points] cards
                // Aditionally we look how many copies we have of the current card and add that value
                for(int j = 1; j < Math.Log2(points/2) + 2; j++) {
                    cardCopies[i+j] += 1 + cardCopies[i];
                }
                sum += points/2;
            }
            return (sum, cardCopies.Sum() + input.Length);
        }
        public static void SolveDay4()
        {
            string[] lines = File.ReadAllLines("../inputs/input4.txt");
            (int, int) solution = SolveBothParts(lines);
            Console.WriteLine($"Part one: {solution.Item1}");
            Console.WriteLine($"Part two: {solution.Item2}");
        }
    }
}
