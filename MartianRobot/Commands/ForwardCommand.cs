using MartianRobot.Commands.Interfaces;
using MartianRobot.Models;
using MartianRobot.Models.Enums;

namespace MartianRobot.Commands;

public class ForwardCommand : IRobotCommand
{
    public void Execute(Robot robot, Grid grid)
    {
        if (robot.IsLost) return;

        var next = robot.Orientation switch
        {
            Orientation.N => new Position(robot.Position.X, robot.Position.Y + 1),
            Orientation.S => new Position(robot.Position.X, robot.Position.Y - 1),
            Orientation.E => new Position(robot.Position.X + 1, robot.Position.Y),
            Orientation.W => new Position(robot.Position.X - 1, robot.Position.Y),
            _ => robot.Position
        };

        if (grid.IsOffGrid(next))
        {
            if (grid.HasRobotScent(robot.Position))
                return;

            grid.AddRobotScent(robot.Position);
            robot.IsLost = true;
            return;
        }

        robot.Position = next;
    }
}
