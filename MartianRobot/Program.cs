using MartianRobot.Models;
using MartianRobot.Services;

Console.WriteLine("Enter input (Ctrl+Z to end):");

var lines = new List<string>();
string? line;

while ((line = Console.ReadLine()) != null)
{
    lines.Add(line);
}

var gridParts = lines[0].Split(' ');
var grid = new Grid(int.Parse(gridParts[0]), int.Parse(gridParts[1]));

for (int i = 1; i < lines.Count; i += 2)
{
    var posParts = lines[i].Split(' ');
    var instructions = lines[i + 1];

    var startPos = new Position(int.Parse(posParts[0]), int.Parse(posParts[1]));
    var orientation = CommandReader.ParseOrientation(posParts[2]);

    var robot = new Robot(startPos, orientation, grid);

    foreach (var c in instructions)
    {
        var command = CommandReader.ReadCommand(c);
        robot.Execute(command);
    }

    Console.WriteLine(robot);
}
