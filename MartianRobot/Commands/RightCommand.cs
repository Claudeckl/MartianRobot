using MartianRobot.Commands.Interfaces;
using MartianRobot.Models;
using MartianRobot.Models.Enums;

namespace MartianRobot.Commands;

public class RightCommand : IRobotCommand
{
    public void Execute(Robot robot, Grid grid)
    {
        robot.Orientation = robot.Orientation switch
        {
            Orientation.N => Orientation.E,
            Orientation.E => Orientation.S,
            Orientation.S => Orientation.W,
            Orientation.W => Orientation.N,
            _ => robot.Orientation
        };
    }
}
