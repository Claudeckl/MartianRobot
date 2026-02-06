using MartianRobot.Commands.Interfaces;
using MartianRobot.Models;

namespace MartianRobot.Commands;

public class LeftCommand : IRobotCommand
{
    public void Execute(Robot robot, Grid grid)
    {
        robot.TurnLeft();
    }
}
