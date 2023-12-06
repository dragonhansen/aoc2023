using System.Diagnostics;

namespace Days {
    public class Day5
    {
        public static int SolvePartOne(string[] input)
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
                long destintation = int.Parse(values[0]); 
                long source = int.Parse(values[1]); 
                long range = int.Parse(values[2]); 
                for (int j = 0; j < range; j++) {
                    maps[mapNumber].Add(source+j, destintation+j);
                }
            }
            for(int i = 0; i < seeds.Length; i++) {
                long seed = int.Parse(seeds[i]);
                for(int j = 0; j < mapNumber+1; j++) {
                    Dictionary<long, long> currentMap = maps[j];
                    if(!currentMap.ContainsKey(seed)) {
                            continue;
                        }
                    
                    seed = currentMap.GetValueOrDefault(seed);
                }
                Console.WriteLine(seed);
                
            }
            return 0;
        }
        public static int SolvePartTwo(string[] input)
        {
            return 0;
        }
        public static void SolveDay5()
        {
            string[] lines = File.ReadAllLines("../inputs/input5.txt");
            string[] test = File.ReadAllLines("../inputs/day5example.txt");
            SolvePartOne(test);
            Console.WriteLine("Part one: ");
            Console.WriteLine("Part two: ");
        }
    }
}
