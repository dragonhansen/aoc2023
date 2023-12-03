using Days;
namespace Test;

[TestClass]
public class TestDay2
{
    string[] input = {
    "Game 1: 4 blue; 1 green, 2 red; 4 blue, 1 green, 6 red", 
    "Game 2: 7 red, 1 green, 4 blue; 13 red, 11 blue; 6 red, 2 blue; 9 blue, 9 red; 4 blue, 11 red; 15 red, 1 green, 3 blue",
    "Game 66: 10 blue, 2 red, 7 green; 3 red, 16 blue; 10 green, 7 red, 17 blue; 10 red, 5 green, 5 blue; 13 blue, 10 green, 6 red",
    "Game 71: 1 blue, 1 green; 6 blue, 2 red; 5 green, 1 red, 4 blue; 4 green, 3 red"
    };

    [TestMethod]
    public void TestPartOne()
    {
        // 1 + 0 + 0 + 71
        Assert.AreEqual(Day2.SolvePartOne(input), 72); 
    }

    [TestMethod]
    public void TestPartTwo()
    {
        Assert.AreEqual(Day2.SolvePartTwo(input), 6*1*4+15*1*11+10*10*17+3*5*6);
    }
}