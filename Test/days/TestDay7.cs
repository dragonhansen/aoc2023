using Days;
namespace Test {
    [TestClass]
    public class TestDay7
    {
        string[] input = {"32T3K 765",
                            "T55J5 684",
                            "KK677 28",
                            "KTJJT 220",
                            "QQQJA 483"};
        [TestMethod]
        public void TestPartOne()
        {
            Assert.AreEqual(6440, Day7.SolvePartOne(input));
            // Test code here
        }
        [TestMethod]
        public void TestPartTwo()
        {
            // Test code here
        }
    }
}
