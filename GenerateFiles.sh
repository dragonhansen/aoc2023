#!/bin/bash

read -p "Enter a number: " day_number

solution_file="Solutions/days/Day${day_number}.cs"

echo "Generating C# solution file..."

# Boilerplate code for C# solution file
echo "namespace Days {" >> "$solution_file"
echo "    public class Day${day_number}" >> "$solution_file"
echo "    {" >> "$solution_file"
echo "        public static int SolvePartOne(string[] input)" >> "$solution_file"
echo "        {" >> "$solution_file"
echo "            return 0;" >> "$solution_file"
echo "        }" >> "$solution_file"
echo ""
echo "        public static int SolvePartTwo(string[] input)" >> "$solution_file"
echo "        {" >> "$solution_file"
echo "            return 0;" >> "$solution_file"
echo "        }" >> "$solution_file"
echo ""
echo "        public static void SolveDay${day_number}()" >> "$solution_file"
echo "        {" >> "$solution_file"
echo "            string[] lines = File.ReadAllLines(\"../inputs/input${day_number}.txt\");" >> "$solution_file"
echo "            Console.WriteLine(\"Part one: \");" >> "$solution_file"
echo "            Console.WriteLine(\"Part two: \");" >> "$solution_file"
echo "        }" >> "$solution_file"
echo "    }" >> "$solution_file"
echo "}" >> "$solution_file"

echo "C# solution file generated:"
echo "$solution_file"

test_file="Test/days/TestDay${day_number}.cs"

echo "Generating C# test file..."

# Boilerplate code for C# test file
echo "using Days;" >> "$test_file"
echo "namespace Test {" >> "$test_file"
echo "    [TestClass]" >> "$test_file"
echo "    public class TestDay${day_number}" >> "$test_file"
echo "    {" >> "$test_file"
echo "        [TestMethod]" >> "$test_file"
echo "        public void TestPartOne()" >> "$test_file"
echo "        {" >> "$test_file"
echo "            // Test code here" >> "$test_file"
echo "        }" >> "$test_file"
echo ""
echo "        [TestMethod]" >> "$test_file"
echo "        public void TestPartTwo()" >> "$test_file"
echo "        {" >> "$test_file"
echo "            // Test code here" >> "$test_file"
echo "        }" >> "$test_file"
echo "    }" >> "$test_file"
echo "}" >> "$test_file"

echo "C# test file generated:"
echo "$test_file"

# Generate empty input txt file
input_file="inputs/input${day_number}.txt"
touch "$input_file"
echo "Input file generated:"
echo "$input_file"