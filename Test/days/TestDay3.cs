using Days;
namespace Test {
    [TestClass]
    public class TestDay3
    {
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
        [TestMethod]
        public void TestPartOne()
        {
            Assert.AreEqual(Day3.SolvePartOne(input), 4361);
        }
        [TestMethod]
        public void TestPartTwo()
        {
            Assert.AreEqual(Day3.SolvePartTwo(input), 467835);
        }
    }
}
