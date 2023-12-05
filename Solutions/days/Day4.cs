namespace Days {
    public class Day4
    {
        public static int SolvePartOne(string[] input)
        {
            int sum = 0;
            foreach(String line in input) {
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
                sum += points/2;
            }
            return sum;
        }
        public static int SolvePartTwo(string[] input)
        {
            return 0;
        }
        public static void SolveDay4()
        {
            string[] lines = File.ReadAllLines("../inputs/input4.txt");
            Console.WriteLine($"Part one: {SolvePartOne(lines)}");
            Console.WriteLine("Part two: ");
        }
    }
}
