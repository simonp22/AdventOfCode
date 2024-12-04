using System.Text.RegularExpressions;

namespace AdventOfCode._2024.Day03 {
    internal class Day03 : ISolution {
        public string SolvePartOne(string input) {
            Regex regex = new Regex(@"mul\((\d{1,3})\,(\d{1,3})\)", RegexOptions.Multiline);
            MatchCollection matches = regex.Matches(input);

            int mulSum = matches.Sum(match => {
                var matchedValues = match.Groups.Values.ToList();
                int x = Convert.ToInt32(matchedValues[1].Value);
                int y = Convert.ToInt32(matchedValues[2].Value);
                return x * y;
            });

            return mulSum.ToString();
        }

        public string SolvePartTwo(string input) {
            Regex regex = new Regex(@"mul\((\d{1,3})\,(\d{1,3})\)|do\(\)|don\'t\(\)", RegexOptions.Multiline);
            MatchCollection matches = regex.Matches(input);
            int sum = 0;
            bool enabled = true;
            foreach (var match in matches.ToArray()) {
                if (match.Value == "do()") enabled = true;
                else if (match.Value == "don't()") enabled = false;
                else {
                    var matchedValues = match.Groups.Values.ToList();
                    int x = Convert.ToInt32(matchedValues[1].Value);
                    int y = Convert.ToInt32(matchedValues[2].Value);
                    if (enabled) sum += x * y;
                }
            }

            return sum.ToString();
        }


    }
}
