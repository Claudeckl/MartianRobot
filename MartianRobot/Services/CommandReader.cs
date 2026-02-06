using MartianRobot.Commands;
using MartianRobot.Commands.Interfaces;
using MartianRobot.Models.Enums;

namespace MartianRobot.Services
{
    public class CommandReader
    {
        public IRobotCommand ReadCommand(string c) => c switch
        {
            "L" => new LeftCommand(),
            "R" => new RightCommand(),
            "F" => new ForwardCommand(),
            _ => throw new ArgumentException($"Unknown command: {c}")
        };

        public Orientation ParseOrientation(string value)
            => Enum.Parse<Orientation>(value);
    }
}
