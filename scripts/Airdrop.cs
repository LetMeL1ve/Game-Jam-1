using Godot;
using System;

public partial class Airdrop : CharacterBody2D
{
    private float _weight = 0.2f;
    private float _speed;

    public override void _PhysicsProcess(double delta)
    {
        Position += new Vector2(0, _speed);
        _speed += _weight * 9.8f * (float)delta;

        MoveAndSlide();
    }
}
