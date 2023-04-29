global using Godot;
global using System;
global using System.Collections.Generic;
global using System.Linq;

namespace ThreeAges;

public partial class Global : Node2D
{
	private PackedScene _tree;

	public override void _Ready()
	{
		_tree = GD.Load<PackedScene>("res://tree.tscn");
		for (var x = 0; x < 500; x++)
		{
			var node = (StaticBody2D) _tree.Instantiate();

			var spawnX = GD.RandRange(-1000, 1000);
			var spawnY = GD.RandRange(-1000, 1000);

			AddChild(node);

			node.Position = new Vector2
			{
				X = spawnX,
				Y = spawnY
			};
		}
	}

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("debug_tree"))
		{
			var node = (StaticBody2D) _tree.Instantiate();

			var spawnX = GD.RandRange(-800, 800);
			var spawnY = GD.RandRange(-800, 800);

			AddChild(node);

			node.Position = new Vector2
			{
				X = spawnX,
				Y = spawnY
			};
		}
	}
}