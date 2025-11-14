using Godot;
using System;

public partial class Ground : Area2D
{
    public void onEntered(Node2D body)
    {
        body.QueueFree();
    }
}
