using Godot;

namespace ThreeAges;

public partial class Player : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 100;

	private Vector2 _target;

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("left_click"))
		{
			_target = GetGlobalMousePosition();
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		Velocity = Position.DirectionTo(_target) * Speed;

		if (Position.DistanceTo(_target) > 10)
		{
			MoveAndSlide();
		}
	}
}