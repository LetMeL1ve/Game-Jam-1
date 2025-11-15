using Godot;

public partial class Camera : Camera2D
{
    public float ShakeStrength = 4f;
    public float ShakeDuration = 0.3f;

    private float _timeLeft = 0f;
    private RandomNumberGenerator _rng = new RandomNumberGenerator();
    private Vector2 _originalOffset;

    public override void _Ready()
    {
        _originalOffset = Offset;
    }

    public override void _Process(double delta)
    {
        if (_timeLeft > 0)
        {
            _timeLeft -= (float)delta;

            Offset = _originalOffset
                     + new Vector2(
                         _rng.RandfRange(-ShakeStrength, ShakeStrength),
                         _rng.RandfRange(-ShakeStrength, ShakeStrength)
                       );
        }
        else
        {
            Offset = _originalOffset;
        }
    }

    public void Shake()
    {
        _timeLeft = ShakeDuration;
    }
}
