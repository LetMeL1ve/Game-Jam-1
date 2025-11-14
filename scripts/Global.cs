using Godot;
using System;

public partial class Global : Node
{
    public static float TimeInGame {get; private set;}

    public override void _Process(double delta)
    {
       TimeInGame = TimeInGame += (float)delta;
    }
}
