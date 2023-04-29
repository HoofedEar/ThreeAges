using Godot;

namespace ThreeAges;

public partial class Player : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 100;

	public Vector2 MoveTarget;
	private PackedScene _clickArea;

	public override void _Ready()
	{
		_clickArea = GD.Load<PackedScene>("res://clickarea.tscn");
	}

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("left_click"))
		{
			MoveTarget = GetGlobalMousePosition();
		}
		
		if (@event.IsActionPressed("right_click"))
		{
			var gmp = GetGlobalMousePosition();
			var area = (Area2D) _clickArea.Instantiate();

			GetParent().AddChild(area);
			area.MoveToFront();
			area.Position = gmp;
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		Velocity = Position.DirectionTo(MoveTarget) * Speed;

		if (Position.DistanceTo(MoveTarget) > 10)
		{
			MoveAndSlide();
		}
	}
}