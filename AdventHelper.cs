namespace AdventOfCode {
    internal static class AdventHelper {
        internal static string[] LineSplitInput(string rawInput) {
            if (rawInput.EndsWith("\n")) rawInput = rawInput[..^1];
            return rawInput.Split("\n");
        }
    }
}
