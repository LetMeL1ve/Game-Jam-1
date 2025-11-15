using Godot;
using System;

public partial class Gun : Sprite2D
{
    public override void _Process(double delta)
    {
        LookAt(GetGlobalMousePosition());

        if (Input.IsActionJustPressed("shoot"))
        {
            PackedScene packedBullet = GD.Load<PackedScene>("res://scenes/bullet.tscn");
            Bullet bullet = packedBullet.Instantiate<Bullet>();

            bullet.Scale = new Vector2(2f, 2f);
            bullet.GlobalPosition = GlobalPosition;

            Vector2 direction = (GetGlobalMousePosition() - GlobalPosition).Normalized();
            bullet.Direction = direction;

            GetTree().Root.AddChild(bullet);
        }

        Vector2 aim = GetGlobalMousePosition() - GlobalPosition;
        float angle = aim.Angle();
        GD.Print(angle);
        if (aim.X < -5)
        {
            FlipH = true;
            Position = new Vector2(-10, 5);
            Rotation = angle + Mathf.Pi;
        }
        else if (aim.X > 5)
        {
            FlipH = false;
            Position = new Vector2(10, 5);
            Rotation = angle;
        }
    }
}
