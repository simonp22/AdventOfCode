using AdventOfCode;
using System.Reflection;

int year = DateTime.Today.Year;
int day = DateTime.Today.Day;

year = 2024;
day = 1;

try {
    if (args.Length != 0 && args.Length == 2) {
        year = Convert.ToInt32(args[0]);
        day = Convert.ToInt32(args[1]);
    }
    else if (args.Length != 0) {
        Console.WriteLine("Invalid number of arguments.");
        return;
    }
}
catch (FormatException) {
    Console.WriteLine("Invalid arguments.");
    return;
}

// Get possible solutions to run
Type[] iSolutions = Assembly.GetEntryAssembly()!.GetTypes().Where(t => t.GetTypeInfo().IsClass && typeof(ISolution).IsAssignableFrom(t)).ToArray();

// Get the correct solution
ISolution? solution = iSolutions.Select(x => Activator.CreateInstance(x) as ISolution).First(y => y.Day == day && y.Year == year);

if (solution == null) {
    Console.WriteLine("Solution not found.");
    return;
}

solution.RunSolution();