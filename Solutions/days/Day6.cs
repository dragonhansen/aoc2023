using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace Days {
    public class Day6
    {
        public static int SolvePartOne(string[] input)
        {
            string pattern = @"\d+";
            int[] times = Regex.Matches(input[0], pattern).Cast<Match>().Select(m => int.Parse(m.Value)).ToArray();
            int[] records = Regex.Matches(input[1], pattern).Cast<Match>().Select(m => int.Parse(m.Value)).ToArray();
            int product = 1;
            for(int i = 0; i < times.Length; i++) {
                int record = records[i];
                int time = times[i];
                int sum = CalcualteAmountOfWaysToBeatRecord(record, time);
                product *= sum;
            }
            return product;
        }
        public static int SolvePartTwo(string[] input)
        {
            string pattern = @"\d+";
            string[] times = Regex.Matches(input[0], pattern).Cast<Match>().Select(m => m.Value).ToArray();
            string[] records = Regex.Matches(input[1], pattern).Cast<Match>().Select(m => m.Value).ToArray();
            long time = long.Parse(String.Join("", times));
            long record = long.Parse(String.Join("", records));
            return CalcualteAmountOfWaysToBeatRecord(record, time);
        }

        private static int CalcualteAmountOfWaysToBeatRecord(long record, long time) {
            int sum = 0;
            // Small optimization - start from the minimum required speed to break record given that you had all the available time
            long minimumSpeedToBeatReacord = record/time;
            for (long speed = minimumSpeedToBeatReacord; speed < time + 1; speed++) { 
                    long remainingTime = time - speed;
                    long travelledDistance = remainingTime*speed;
                    if(travelledDistance > record) {
                        sum ++;
                        continue;
                    }
                    // Small optimization - from this point until the end, there will not be broken any records
                    if(sum > 0) {
                        break;
                    }
                }
            return sum;
        }
        public static void SolveDay6()
        {
            string[] lines = File.ReadAllLines("../inputs/input6.txt");
            Console.WriteLine($"Part one: {SolvePartOne(lines)}");
            Console.WriteLine($"Part two: {SolvePartTwo(lines)}");
        }
    }
}
