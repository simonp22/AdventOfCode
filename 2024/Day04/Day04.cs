
namespace AdventOfCode._2024.Day04 {
    internal class Day04 : ISolution {
        string word = "XMAS";
        string word2 = "MAS";
        string word3 = "SAM";
        string[] map;
        Dictionary<Direction, Tuple<int, int>> Directions = new() {
            { Direction.UP,         new Tuple<int, int>(0, -1)  },
            { Direction.DOWN,       new Tuple<int, int>(0, 1)   },
            { Direction.RIGHT,      new Tuple<int, int>(1, 0)   },
            { Direction.LEFT,       new Tuple<int, int>(-1, 0)  },
            { Direction.UPLEFT,     new Tuple<int, int>(-1, -1) },
            { Direction.UPRIGHT,    new Tuple<int, int>(1, -1)  },
            { Direction.DOWNLEFT,   new Tuple<int, int>(-1, 1)  },
            { Direction.DOWNRIGHT,  new Tuple<int, int>(1, 1)   }
        };

        public string SolvePartOne(string input) {
            map = AdventHelper.LineSplitInput(input);
            int width = map[0].Length;
            int height = map.Length;

            int wordMatches = 0;
            // Loop through the map char by char
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    foreach (var direction in Directions) {
                        wordMatches += CountMatch(word, x, y, direction);
                    }
                }
            }

            return wordMatches.ToString();
        }
        public string SolvePartTwo(string input) {
            map = AdventHelper.LineSplitInput(input);
            int width = map[0].Length;
            int height = map.Length;

            int wordMatches = 0;
            // Loop through the map char by char
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    // MAS / MAS
                    wordMatches += CountMatch(word2, x, y, Directions.First(x => x.Key == Direction.DOWNRIGHT)) * CountMatch(word2, x + 2, y, Directions.First(x => x.Key == Direction.DOWNLEFT));
                    // SAM / SAM
                    wordMatches += CountMatch(word3, x, y, Directions.First(x => x.Key == Direction.DOWNRIGHT)) * CountMatch(word3, x + 2, y, Directions.First(x => x.Key == Direction.DOWNLEFT));
                    // MAS / SAM
                    wordMatches += CountMatch(word2, x, y, Directions.First(x => x.Key == Direction.DOWNRIGHT)) * CountMatch(word3, x + 2, y, Directions.First(x => x.Key == Direction.DOWNLEFT));
                    // SAM / MAS
                    wordMatches += CountMatch(word3, x, y, Directions.First(x => x.Key == Direction.DOWNRIGHT)) * CountMatch(word2, x + 2, y, Directions.First(x => x.Key == Direction.DOWNLEFT));

                }
            }

            return wordMatches.ToString();
        }

        private int CountMatch(string word, int x, int y, KeyValuePair<Direction, Tuple<int, int>> direction) {
            int wordMatches = 0;
            for (int i = 0; i < word.Length; i++) {
                int newX = x + direction.Value.Item1 * i;
                int newY = y + direction.Value.Item2 * i;
                if (newX < 0 || newX >= map[0].Length || newY < 0 || newY >= map.Length) {
                    break;
                }
                if (map[newY][newX] != word[i]) {
                    break;
                }
                if (i == word.Length - 1) {
                    wordMatches++;
                }
            }
            return wordMatches;
        }

        enum Direction {
            UP,
            DOWN,
            LEFT,
            RIGHT,
            UPLEFT,
            UPRIGHT,
            DOWNLEFT,
            DOWNRIGHT
        }
    }
}
