using Godot;

namespace ThreeAges;

public partial class Global : Node2D
{
	private PackedScene _tree;

	public override void _Ready()
	{
		_tree = GD.Load<PackedScene>("res://tree.tscn");
	}

	public override void _PhysicsProcess(double delta)
	{
		
	}

	public override void _Input(InputEvent @event)
	{
		if (!@event.IsActionPressed("debug_tree")) return;
		
		var node = (StaticBody2D)_tree.Instantiate();

		var spawnX = GD.RandRange(200, 800);
		var spawnY = GD.RandRange(200, 800);
			
		AddChild(node);
			
		node.Position = new Vector2
		{
			X = spawnX,
			Y = spawnY
		};
	}
}