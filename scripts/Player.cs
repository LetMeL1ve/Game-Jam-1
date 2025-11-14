using Godot;
using System;

public partial class Player : CharacterBody2D
{
    private float _speed = 0.0f;

    private float _accelartion = 40f;
    private const float _maxSpeed = 400f;

    public override void _PhysicsProcess(double delta)
    {
        if (Input.IsActionPressed("left") && _speed > -_maxSpeed)
        {
            _speed -= _accelartion;
        } 
        else if (Input.IsActionPressed("right") && _speed < _maxSpeed)
        {
            _speed += _accelartion;
        }
        else if (_speed != 0)
        {
            if (_speed < 0)
                _speed += _accelartion / 2;
            else
                _speed -= _accelartion / 2;
        }
        Position += new Vector2(_speed * (float)delta, 0);
    }
}
