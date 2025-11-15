using Godot;
using System;

public enum AbilityEnum
{
    MULTISHOT = 1,
    REGENERATOIN,
    SHIELD,
    SPEED,
    TIMESLOW
}
public partial class Ability : Area2D
{
    private static string[] names =
    {
        "multishot.png",
        "regeneration.png",
        "shield.png",
        "speed.png",
        "timeslow.png"
    };

    public  AbilityEnum ability {get; private set;}
    public override void _Ready()
    {
        Random rd = new Random();
        ability = (AbilityEnum)rd.Next(1, 5);
        Sprite2D sprite = GetNode<Sprite2D>("Sprite2D");
        sprite.Texture = GD.Load<Texture2D>("res:://assets/abilities/ability_" + names[(int)ability]);
        sprite.TextureFilter = TextureFilterEnum.Nearest;
    }
}
