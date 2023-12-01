using Days;
namespace Test;

[TestClass]
public class TestDay1
{
    string[] input = {"one5lvxpfbnlfq", "1781lcxvgz1sixrlxtdhgj","three2kxrhnvkrsv9","1bklbbkdh2sevenjkcckrkhm"};   

    [TestMethod]
    public void TestPartOne()
    {
        // 55 + 11 + 29 + 12
        Assert.AreEqual(Day1.SolvePartOne(input), 55+11+29+12); 
    }

    [TestMethod]
    public void TestPartTwo()
    {
        // 15 + 16 + 39 + 17
        Assert.AreEqual(Day1.SolvePartTwo(input), 15+16+39+17); 
    }
}