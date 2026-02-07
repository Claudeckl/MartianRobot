using MartianRobot.Commands;
using MartianRobot.Models;
using MartianRobot.Models.Enums;

var projectRoot = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;

var inputPath = Path.Combine(projectRoot, "input.txt");
var outputPath = Path.Combine(projectRoot, "out.txt");

var lines = File.ReadAllLines(inputPath);
var outputs = new List<string>();

var gridParts = lines[0].Split(' ');
var grid = new Grid(int.Parse(gridParts[0]), int.Parse(gridParts[1]));

// CommandFactory.Register('B', new BackwardCommand());

for (int i = 1; i < lines.Length; i += 2)
{
    var posParts = lines[i].Split(' ');
    var instructions = lines[i + 1];

    var robot = new Robot(
        new Position(int.Parse(posParts[0]), int.Parse(posParts[1])),
        Enum.Parse<Orientation>(posParts[2])
    );

    foreach (var c in instructions)
    {
        var command = CommandFactory.Get(c);
        command.Execute(robot, grid);
    }

    outputs.Add(robot.ToString());
}

// Write all results to file
File.WriteAllLines(outputPath, outputs);

// Optional: also print to console
Console.WriteLine($"Execution complete. Results written to {outputPath}");