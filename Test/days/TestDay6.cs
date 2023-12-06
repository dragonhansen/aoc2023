using Days;
namespace Test {
    [TestClass]
    public class TestDay6
    {
        string[] input = {"Time:      7  15   30", "Distance:  9  40  200"};
        [TestMethod]
        public void TestPartOne()
        {
            Assert.AreEqual(288, Day6.SolvePartOne(input));
        }
        [TestMethod]
        public void TestPartTwo()
        {
            // Test code here
            Assert.AreEqual(71503, Day6.SolvePartTwo(input));
        }
    }
}
