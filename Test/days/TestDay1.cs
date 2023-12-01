using Days;
namespace Test;

[TestClass]
public class TestDay1
{
    [TestMethod]
    public void TestMethod1()
    {
        string[] input = {"one5lvxpfbnlfq"};   
        Assert.AreEqual(Day1.SolvePartOne(input), 55); 
    }
}