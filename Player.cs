using Godot;

namespace ThreeAges;

public partial class Player : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 100;
	private PackedScene _clickArea;

	public override void _Ready()
	{
		_clickArea = GD.Load<PackedScene>("res://clickarea.tscn");
	}

	private void GetInput()
	{
		var inputDirection = Input.GetVector("left", "right", "up", "down");
		Velocity = inputDirection * Speed;
	}

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("left_click"))
		{
			// TODO attempt to pick up an item
			var gmp = GetGlobalMousePosition();
			var area = (Area2D) _clickArea.Instantiate();

			GetParent().AddChild(area);
			area.MoveToFront();
			area.Position = gmp;
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
		GetInput();
		MoveAndSlide();
	}
}