using MartianRobot.Commands.Interfaces;
using MartianRobot.Models;
using MartianRobot.Models.Enums;

namespace MartianRobot.Commands;

public class LeftCommand : IRobotCommand
{
    public void Execute(Robot robot, Grid grid)
    {
        robot.Orientation = robot.Orientation switch
        {
            Orientation.N => Orientation.W,
            Orientation.W => Orientation.S,
            Orientation.S => Orientation.E,
            Orientation.E => Orientation.N,
            _ => robot.Orientation
        };
    }
}
