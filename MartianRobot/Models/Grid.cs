namespace MartianRobot.Models;

public class Grid
{
    private readonly int _maxX;
    private readonly int _maxY;

    // Scent positions
    private readonly HashSet<Position> _robotScents = new HashSet<Position>();

    public Grid(int maxX, int maxY)
    {
        _maxX = maxX;
        _maxY = maxY;
    }

    public bool IsOffGrid(Position position)
        => position.X < 0 || position.Y < 0 || position.X > _maxX || position.Y > _maxY;

    public bool HasRobotScent(Position position) => _robotScents.Contains(position);

    public void AddRobotScent(Position position) => _robotScents.Add(position);
}