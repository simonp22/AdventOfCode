namespace AdventOfCode {
    interface ISolution {
        string SolvePartOne(string[] input);
        string SolvePartTwo(string[] input);

        int Day => int.Parse(GetType().FullName!.Split(".").Last().Substring(3));
        int Year => int.Parse(GetType().FullName!.Split(".")[1].Substring(1, 4));

        string SolutionDirectory => Path.Combine(Environment.CurrentDirectory, Year.ToString(), $"Day{Day:D2}");
        void RunSolution() {
            // Get input file
            string inputFile = Path.Combine(SolutionDirectory, "input.txt");
            string rawInput = File.ReadAllText(inputFile);
            if (rawInput.EndsWith("\n")) rawInput = rawInput[..^1];
            string[] inputArray = rawInput.Split("\n");

            Console.WriteLine($"Day {Day:D2} - {Year}");
            // Solve Part one
            Console.WriteLine("Part 1: " + SolvePartOne(inputArray));
            // Solve Part two
            Console.WriteLine("Part 2: " + SolvePartTwo(inputArray));
        }
    }
}
