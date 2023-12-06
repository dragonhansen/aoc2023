using Days;
namespace Test {
    [TestClass]
    public class TestDay5
    {
        [TestMethod]
        public void TestPartOne()
        {
            string[] input = File.ReadAllLines("../../../../inputs/day5example.txt");
            Assert.AreEqual(35, Day5.SolvePartOne(input));
            // Test code here
        }
        [TestMethod]
        public void TestPartTwo()
        {
            // Test code here
        }
    }
}
