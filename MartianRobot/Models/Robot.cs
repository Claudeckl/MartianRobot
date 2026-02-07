using MartianRobot.Commands.Interfaces;
using MartianRobot.Models.Enums;

namespace MartianRobot.Models;

public class Robot
{
    public Position Position { get; set; }
    public Orientation Orientation { get; set; }
    public bool IsLost { get; set; }

    public Robot(Position start, Orientation orientation)
    {
        Position = start;
        Orientation = orientation;
    }

    public override string ToString()
        => $"{Position.X} {Position.Y} {Orientation}" + (IsLost ? " LOST" : "");
}
