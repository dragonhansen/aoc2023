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
            // Your test code here
            Assert.AreEqual(Day3.SolvePartOne(input), 4361);
        }
        [TestMethod]
        public void TestPartTwo()
        {
            // Your test code here
        }
    }
}
