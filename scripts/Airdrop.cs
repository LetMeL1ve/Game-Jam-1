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

    public void onBodyEntered(Node2D body)
    {
        if (body is Player)
        {
            Global.Play = false;
        }
        if (body is StaticBody2D) 
        {
            Global.GroundHP = Global.GroundHP - Weight * 10.0f;
            GetTree().Root.GetNode<Node2D>("main").GetNode<Camera>("Camera2D").Shake();
            QueueFree();
        }
    }
    public void onAreaEntered(Area2D area)
    {
        if (area is Bullet || area is Shield)
        {
            AnimatedSprite2D anim = GetNode<AnimatedSprite2D>("explosion");
            _animation = true;
            GetNode<Sprite2D>("Sprite2D").Visible = false;
            GetNode<Sprite2D>("parachute").Visible = false;

            anim.Visible = true;
            anim.Play("sky_explosion");
            return;
        }
    }
    public void onAnimationFinished()
    {
        // spawn the ability while we still have a valid position
        spawnAbility();
        QueueFree();
    }

    public void spawnAbility()
    {
        Random rd = new Random();
        if (rd.Next(1, 2) != 1) return;

        // Instance the ability scene so it includes the proper scene setup
        PackedScene abilityScene = GD.Load<PackedScene>("res://scenes/ability.tscn");
        Ability ability = abilityScene.Instantiate<Ability>();
        ability.Scale = new Vector2(3, 3);
        ability.TextureFilter = TextureFilterEnum.Nearest;

        // Add to the same root 'main' Node2D so positions line up with the world
        Node2D main = GetTree().Root.GetNode<Node2D>("main");
        main.AddChild(ability);

        // Use global position so it appears where the airdrop was
        ability.GlobalPosition = GlobalPosition;
    }
}
