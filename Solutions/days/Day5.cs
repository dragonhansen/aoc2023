using System.Diagnostics;

namespace Days {
    public class Day5
    {
        public static long SolvePartOne(string[] input)
        {
            string[] seeds = input[0].Split(": ")[1].Split(" ");
            List<Dictionary<long, long>> maps = new List<Dictionary<long, long>>();
            int mapNumber = -1;
            for(int i = 1; i < input.Length; i++) {
                string line = input[i];
                if(line.Equals("")) {
                    maps.Add(new Dictionary<long, long>());
                    mapNumber ++;
                    i++;
                    continue;
                }
                string[] values = line.Split(" ");
                long destintation = long.Parse(values[0]); 
                long source = long.Parse(values[1]); 
                long range = long.Parse(values[2]); 
                for (int j = 0; j < range; j++) {
                    maps[mapNumber].Add(source+j, destintation+j);
                }
            }
            long[] locationNumbers = new long[seeds.Length];
            for(int i = 0; i < seeds.Length; i++) {
                long seed = int.Parse(seeds[i]);
                for(int j = 0; j < mapNumber+1; j++) {
                    Dictionary<long, long> currentMap = maps[j];
                    if(!currentMap.TryGetValue(seed, out long destination)) {
                        continue;
                    }
                    seed = destination;
                }
                locationNumbers[i] = seed;
            }
            return locationNumbers.Min();
        }
        public static int SolvePartTwo(string[] input)
        {
            return 0;
        }
        public static void SolveDay5()
        {
            string[] lines = File.ReadAllLines("../inputs/input5.txt");
            string[] test = File.ReadAllLines("../inputs/day5example.txt");
            Console.Write($"Part one: {SolvePartOne(lines)}");
            Console.WriteLine("Part two: ");
        }
    }
}
