using MartianRobot.Commands.Interfaces;
using MartianRobot.Models.Enums;

namespace MartianRobot.Models;

public class Robot
{
    public Position Position { get; set; }
    public Orientation Orientation { get; set; }
    public bool IsLost { get; set; }

    private readonly Grid _grid;

    public Robot(Position start, Orientation orientation, Grid grid)
    {
        Position = start;
        Orientation = orientation;
        _grid = grid;
    }

    public void Execute(IRobotCommand command)
    {
        if (IsLost) return;
        command.Execute(this, _grid);
    }

    public void TurnLeft()
    {
        Orientation = Orientation switch
        {
            Orientation.N => Orientation.W,
            Orientation.W => Orientation.S,
            Orientation.S => Orientation.E,
            Orientation.E => Orientation.N,
            _ => Orientation
        };
    }

    public void TurnRight()
    {
        Orientation = Orientation switch
        {
            Orientation.N => Orientation.E,
            Orientation.E => Orientation.S,
            Orientation.S => Orientation.W,
            Orientation.W => Orientation.N,
            _ => Orientation
        };
    }

    public void MoveForward()
    {
        var next = Orientation switch
        {
            Orientation.N => new Position(Position.X, Position.Y + 1),//Given in problem statement that Y increases northwards
            Orientation.S => new Position(Position.X, Position.Y - 1),//assuming Y decreases southwards (these I am inferring from what is given)
            Orientation.E => new Position(Position.X + 1, Position.Y),//assuming X increases eastwards (these I am inferring from what is given)
            Orientation.W => new Position(Position.X - 1, Position.Y),//assuming X decreases westwards (these I am inferring from what is given)
            _ => Position
        };

        if (_grid.IsOffGrid(next))
        {
            if (_grid.HasRobotScent(Position))
                return;

            _grid.AddRobotScent(Position);
            IsLost = true;
            return;
        }

        Position = next;
    }

    public override string ToString()
        => $"{Position.X} {Position.Y} {Orientation}" + (IsLost ? " LOST" : "");
}
