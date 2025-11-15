using Godot;
using System;

public partial class Menu : Node2D
{
    public void onPlayDown()
    {
        GetTree().ChangeSceneToFile("scenes/main.tscn");
    }
    public void onSettingsDown()
    {
        GetTree().ChangeSceneToFile("scenes/settings.tscn");
    }
    public void onQuitDown()
    {
        GetTree().Quit();
    }
}
