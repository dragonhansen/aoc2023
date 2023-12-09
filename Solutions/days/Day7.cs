using System.Reflection.Metadata.Ecma335;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace Days {
    public class Day7
    {
        public static int SolvePartOne(string[] input)
        {
            Dictionary<int, List<(string, int)>> handLists = new Dictionary<int, List<(string, int)>>();
            for(int i = 1; i < 6; i++) {
                handLists.Add(i, new List<(string, int)>());
            }
            for (int i = 0; i < input.Length; i++) {
                string[] splitInput = input[i].Split(" ");
                string hand = splitInput[0];
                int bid = int.Parse(splitInput[1]);
                int distinctCards = hand.Distinct().Count();
                
                handLists[distinctCards].Add((hand, bid)); 
            }
            List<int> rankedBids = new List<int>();
            for(int i = 1; i < 6; i++) {
                rankedBids.AddRange(handLists[6-i].OrderBy(x => x.Item1, new CustomComparer()).Select(x => x.Item2).ToList());
            }
            int totalWinnings = 0;
            for(int i = 0; i < input.Length; i++) {
                Console.WriteLine(rankedBids[i]);
                totalWinnings += (i+1)*rankedBids[i];
            }
            return totalWinnings;
        }

        public static int SolvePartTwo(string[] input)
        {
            return 0;
        }
        public static void SolveDay7()
        {
            string[] lines = File.ReadAllLines("../inputs/input7.txt");
            string[] input = {"32T3K 765",
                            "T55J5 684",
                            "KK677 28",
                            "KTJJT 220",
                            "QQQJA 483"};
            Console.WriteLine($"Part one: {SolvePartOne(input)}");
            Console.WriteLine("Part two: ");
        }
    }
}

public class CustomComparer : IComparer<string>
    {
        private string sortOrder = "23456789TJQKA";
        public int Compare(string x, string y)
        {
            for (int i = 0; i < 5; i++)
            {
                int indexX = sortOrder.IndexOf(x[i]);
                int indexY = sortOrder.IndexOf(y[i]);

                if (indexX != indexY)
                {
                    return indexX.CompareTo(indexY);
                }
            }
            return 0;
        }
    }
