using Godot;
using System;

public partial class Airdrop : Area2D
{
    public float Weight;
    private float _speed;

    private bool _animation = false;

    public override void _PhysicsProcess(double delta)
    {
        if (!_animation)
            Position += new Vector2(0, _speed);
        _speed += Weight * 9.8f * (float)delta;
    }

    public void onAreaEntered(Area2D area)
    {
        if (area is Bullet)
        {
            AnimatedSprite2D anim = GetNode<AnimatedSprite2D>("explosion");
            _animation = true;
            GetNode<Sprite2D>("Sprite2D").Visible = false;
            GetNode<Sprite2D>("parachute").Visible = false;

            anim.Visible = true;
            anim.Play("sky_explosion");
            return;
        } 
        if (area is Area2D) 
        {
            Global.GroundHP = Global.GroundHP - Weight * 10.0f;
            GetTree().Root.GetNode<Node2D>("main").GetNode<Camera>("Camera2D").Shake();
            QueueFree();
        }
    }
    public void onAnimationFinished()
    {
        QueueFree();
        spawnAbility();
    }

    public void spawnAbility()
    {
        Random rd = new Random();
        if (rd.Next(1, 7) != 3) return;

        GetTree().Root.AddChild(new Ability());
    }
}
