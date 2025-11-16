using Godot;
using System;

public partial class Global : Node
{
    public static float TimeInGame {get; private set;}
    public static int MusicSound {get; set;}
    public static int SFXSound {get; set;}

    public static bool Play {get; set;} = true;

    public static float GroundHP {get; set;} = 100;

    public static AbilityEnum CurrentAbility {get; set;} = AbilityEnum.NONE;

    public static float AbilityDuratation {get; set;}

    public override void _Process(double delta)
    {
        if (GroundHP < 1) Play = false;

        TimeInGame = TimeInGame += (float)delta;

        GetNode<Label>("../main/Camera2D/controls/HP label").Text = $"HP: {(int)GroundHP}/100";
        GetNode<Label>("../main/Camera2D/controls/Ability label").Text = $"CURRENT ABILITY: {CurrentAbility}\nTIME: {Math.Round(AbilityDuratation, 1)}";

        if (!Play)
        GetTree().ChangeSceneToFile("res://scenes/gameover.tscn");

        if (CurrentAbility == AbilityEnum.REGENERATION)
            GroundHP += (float)delta;

        if (GroundHP > 100)
            GroundHP = 100;

        if (AbilityDuratation < 0)
            CurrentAbility = AbilityEnum.NONE;
        else 
            AbilityDuratation -= (float)delta;
    }
}
