using MartianRobot.Commands.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobot.Commands;

public static class CommandFactory
{
    private static readonly Dictionary<char, IRobotCommand> _commands = new()
    {
        { 'L', new LeftCommand() },
        { 'R', new RightCommand() },
        { 'F', new ForwardCommand() }
    };

    public static IRobotCommand Get(char key)
    {
        if (_commands.TryGetValue(key, out var cmd))
            return cmd;

        throw new InvalidOperationException($"Unknown command {key}");
    }

    // Future extension point
    public static void Register(char key, IRobotCommand command)
        => _commands[key] = command;
}
