using Godot;
using System;

public partial class Bullet : Area2D
{
    public Vector2 Direction {get; set;}
    private float _speed = 30.0f;
    public override void _PhysicsProcess(double delta)
    {
        Position += Direction * _speed;
        _speed *= 0.99f;
        if (_speed < 10.0f) _speed = 10.0f;

        if (!GetViewportRect().HasPoint(Position)) QueueFree();

        Rotation = Direction.Angle();
    }
}
