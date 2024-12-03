using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2024.Day01 {
    internal class Day01 : ISolution {
        public string SolvePartOne(string[] input) {
            // Separate into 2 lists
            var orderedList1 = input.Select(line => line.Split("   ")[0]).Select(int.Parse).OrderBy(x => x);
            var orderedList2 = input.Select(line => line.Split("   ")[1]).Select(int.Parse).OrderBy(x => x);

            int sum = Enumerable.Zip(orderedList1, orderedList2).Sum(x => Math.Abs(x.First - x.Second));

            return sum.ToString();
        }

        public string SolvePartTwo(string[] input) {
            throw new NotImplementedException();
        }
    }
}
