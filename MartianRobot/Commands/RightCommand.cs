using MartianRobot.Commands.Interfaces;
using MartianRobot.Models;

namespace MartianRobot.Commands;

public class RightCommand : IRobotCommand
{
    public void Execute(Robot robot, Grid grid)
    => robot.TurnRight();
}
