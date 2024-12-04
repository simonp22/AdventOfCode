namespace AdventOfCode._2024.Day02 {
    internal class Day02 : ISolution {
        public string SolvePartOne(string input) {
            string[] lines = AdventHelper.LineSplitInput(input);
            IEnumerable<int[]> samplesArray = lines.Select(input => input.Split(" ").Select(int.Parse).ToArray());

            int safeSamples = samplesArray.Count(SafeSample);

            return safeSamples.ToString();
        }

        public string SolvePartTwo(string input) {
            string[] lines = AdventHelper.LineSplitInput(input);
            IEnumerable<int[]> samplesArray = lines.Select(input => input.Split(" ").Select(int.Parse).ToArray());

            // Foreach sample, generate a list of all possible combinations with 1 element removed
            int problemDampenerSafeSamples = samplesArray.Count(samples => GenerateProblemDampenerSamples(samples).Any(SafeSample));

            return problemDampenerSafeSamples.ToString();
        }

        private IEnumerable<int[]> GenerateProblemDampenerSamples(int[] samples) {
            List<int[]> combinationsList = new List<int[]>();
            combinationsList.Add(samples);

            // Generate all possible combinations with 1 element removed
            for (int i = 0; i < samples.Length; i++) {
                int[] sample = new int[samples.Length - 1];
                Array.Copy(samples, 0, sample, 0, i);
                Array.Copy(samples, i + 1, sample, i, samples.Length - i - 1);
                combinationsList.Add(sample);
            }

            return combinationsList;
        }

        bool SafeSample(int[] sample) {
            bool isOrderIncreasing = sample.SequenceEqual(sample.OrderBy(x => x).ToArray());
            bool isOrderDecreasing = sample.SequenceEqual(sample.OrderByDescending(x => x).ToArray());
            bool areAnyElementsTheSame = sample.GroupBy(x => x).Any(x => x.Count() > 1);

            bool isIncremental = (isOrderDecreasing || isOrderIncreasing) && !areAnyElementsTheSame;
            if (isIncremental) {
                // Ensure no 2 adjacent values differ by more than 3
                for (int i = 0; i < sample.Length - 1; i++) {
                    if (Math.Abs(sample[i] - sample[i + 1]) > 3) {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

    }
}
