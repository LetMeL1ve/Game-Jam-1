using Godot;
using System;

public partial class Settings : Node2D
{
    public void onMusicChanged(float value)
    {
        Global.MusicSound = (int)value;
        GetNode<Label>("Value Label2").Text = $"{value}%";
    }

    public void onSFXChanged(float value)
    {
        Global.SFXSound = (int)value;
        GetNode<Label>("Value Label").Text = $"{value}%";
    }
}
