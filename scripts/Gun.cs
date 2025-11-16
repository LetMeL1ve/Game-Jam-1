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

            if (Global.CurrentAbility == AbilityEnum.MULTISHOT)
            {
                Bullet bullet2 = packedBullet.Instantiate<Bullet>();
                Bullet bullet3 = packedBullet.Instantiate<Bullet>();

                bullet2.Scale = new Vector2(2f, 2f);
                bullet3.Scale = new Vector2(2f, 2f);

                bullet2.GlobalPosition = GlobalPosition;
                bullet3.GlobalPosition = GlobalPosition;

                bullet2.Direction = direction.Rotated(Mathf.DegToRad(30));
                bullet3.Direction = direction.Rotated(Mathf.DegToRad(-30));

                GetTree().Root.AddChild(bullet2);
                GetTree().Root.AddChild(bullet3);
            }
        }

        Vector2 aim = GetGlobalMousePosition() - GlobalPosition;
        float angle = aim.Angle();
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
