namespace AdventOfCode {
    interface ISolution {
        string SolvePartOne(string input);
        string SolvePartTwo(string input);

        int Day => int.Parse(GetType().FullName!.Split(".").Last().Substring(3));
        int Year => int.Parse(GetType().FullName!.Split(".")[1].Substring(1, 4));

        string SolutionDirectory => Path.Combine(Environment.CurrentDirectory, Year.ToString(), $"Day{Day:D2}");
        void RunSolution() {
            // Get input file
            string inputFile = Path.Combine(SolutionDirectory, "input.txt");
            string rawInput = File.ReadAllText(inputFile);

            Console.WriteLine($"Day {Day:D2} - {Year}");
            // Solve Part one
            Console.WriteLine("Part 1: " + SolvePartOne(rawInput));
            // Solve Part two
            Console.WriteLine("Part 2: " + SolvePartTwo(rawInput));
        }

    }
}
