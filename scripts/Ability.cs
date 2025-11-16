using Godot;
using System;
using System.Data;

public enum AbilityEnum
{
    NONE = 0,
    MULTISHOT,
    REGENERATION,
    SHIELD,
    SPEED,
}
public partial class Ability : CharacterBody2D
{
    private static string[] names =
    {
        "multishot.png",
        "regeneration.png",
        "shield.png",
        "speed.png",
    };

    public AbilityEnum ability {get; private set;}

    private float _yspeed = 600;
    private float _xspeed;

    private static Random rd = new Random();
    public override void _Ready()
    { 
        ability = (AbilityEnum)rd.Next(1, 5);
        Sprite2D sprite = GetNode<Sprite2D>("Sprite2D");
        sprite.Texture = GD.Load<Texture2D>("res://assets/abilities/ability_" + names[(int)ability - 1]);
        sprite.TextureFilter = TextureFilterEnum.Nearest;
        _xspeed = rd.Next(-400, 400);
        
    }
    public override void _PhysicsProcess(double delta)
    {
        MoveAndCollide(Velocity * (float)delta);

        Velocity = new Vector2(_xspeed, rd.Next((int)_yspeed, (int)(_yspeed * 1.5)));
        _yspeed *= 1.02f;
    }
}
