using Godot;
using System;

public partial class AirdropSpawner : Node2D
{
    private float _step;

    private Timer timer;

    public override void _Ready()
    {
        timer = GetNode<Timer>("Timer");
    }

    public override void _Process(double delta)
    {
        _step = 5 - Global.TimeInGame / 120;
    }

    private void onTimeout()
    {
        spawnAirdrop();
        timer.Start(_step);
    }
    private void spawnAirdrop()
    {
        PackedScene airdropScene = GD.Load<PackedScene>("res://scenes/airdrop.tscn");
        Airdrop airdrop = airdropScene.Instantiate<Airdrop>();

        airdrop.Scale = new Vector2(1, 1);
        airdrop.TextureFilter = TextureFilterEnum.Nearest;

        Random rd = new Random();

        int screenWidth = (int)GetViewportRect().Size.X;
        airdrop.Position = new Vector2(rd.Next(0, screenWidth), -50);

        AddChild(airdrop);
    }
}
