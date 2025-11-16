using Godot;
using System;

public partial class Player : CharacterBody2D
{
    private float _speed = 0.0f;

    private float _accelartion = 40f;
    private float _maxSpeed = 400f;

    public override void _PhysicsProcess(double delta)
    {
        if (Global.CurrentAbility == AbilityEnum.SPEED)
        {
            _accelartion = 80f;
            _maxSpeed = 800f;
        }
        else
        {
            _accelartion = 40f;
            _maxSpeed = 400f;
        }

        AnimatedSprite2D sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        if (Input.IsActionPressed("left") && _speed > -_maxSpeed)
        {
            _speed -= _accelartion;
            sprite.FlipH = true;
            sprite.Play("run");
        } 
        else if (Input.IsActionPressed("right") && _speed < _maxSpeed)
        {
            _speed += _accelartion;
            sprite.FlipH = false;
            sprite.Play("run");

        }
        else if (_speed != 0)
        {
            if (_speed < 0)
                _speed += _accelartion / 2;
            else
                _speed -= _accelartion / 2;
            sprite.Play("run");
        }
        else 
            sprite.Play("idle");

        Position += new Vector2(_speed * (float)delta, 0);

        Vector2 screenSize = GetViewportRect().Size;
        if (Position.X < 10)  Position = new Vector2(10, Position.Y);
        if (Position.X > screenSize.X - 10)  Position = new Vector2(screenSize.X - 10, Position.Y);

        if (Global.CurrentAbility == AbilityEnum.SHIELD)
        {
            GetNode<AnimatedSprite2D>("AnimatedSprite2D").Modulate = new Color(1, 1, 1, 0.5f);
            CollisionLayer = 2;
        }
        else
        {
            GetNode<AnimatedSprite2D>("AnimatedSprite2D").Modulate = new Color(1, 1, 1, 1);
            CollisionLayer = 1;
        }
            
    }

    public void onBodyEntered(Node2D body)
    {
        if (body is Ability)
        {
            Global.CurrentAbility = ((Ability)body).ability;
            Global.AbilityDuratation = 10.0f;
            body.QueueFree();
        }
    }
}
