using Godot;
using System;

public partial class Global : Node
{
    public static float TimeInGame {get; private set;}
    public static int MusicSound {get; set;}
    public static int SFXSound {get; set;}

    public static bool Play {get; private set;} = true;

    public static float GroundHP {get; set;} = 100;

    public override void _Process(double delta)
    {
        if (GroundHP < 1) Play = false;
        TimeInGame = TimeInGame += (float)delta;
        GetNode<Label>("../main/Camera2D/controls/HP label").Text = $"HP: {(int)GroundHP}/100";
    }
}
