using MartianRobot.Models;

namespace MartianRobot.Commands.Interfaces;

public interface IRobotCommand
{
    void Execute(Robot robot, Grid grid);
}
