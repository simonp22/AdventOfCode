namespace AdventOfCode._2024.Day01 {
    internal class Day01 : ISolution {
        public string SolvePartOne(string input) {
            string[] lines = AdventHelper.LineSplitInput(input);
            // Separate into 2 lists
            IOrderedEnumerable<int> orderedList1 = orderedList(lines, 0);
            IOrderedEnumerable<int> orderedList2 = orderedList(lines, 1);

            int sum = Enumerable.Zip(orderedList1, orderedList2).Sum(x => Math.Abs(x.First - x.Second));

            return sum.ToString();
        }

        public string SolvePartTwo(string input) {
            string[] lines = AdventHelper.LineSplitInput(input);
            IOrderedEnumerable<int> orderedList1 = orderedList(lines, 0);
            IOrderedEnumerable<int> orderedList2 = orderedList(lines, 1);

            // Get counts in the right list
            var countsList = orderedList2.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

            int similarityScoreSum = orderedList1.Sum(x => countsList.ContainsKey(x) ? x * countsList[x] : 0);

            return similarityScoreSum.ToString();
        }

        IOrderedEnumerable<int> orderedList(string[]input, int column) { return input.Select(line => line.Split("   ")[column]).Select(int.Parse).OrderBy(x => x); }
    }
}
