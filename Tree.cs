using Godot;

namespace ThreeAges;

public partial class Tree : StaticBody2D
{
	// Called when the node enters the scene tree for the first time.
	private Area2D _collisionBody;
	private Sprite2D _sprite;

	public override void _Ready()
	{
		// Randomize sprite when spawning
		Node2DHelpers.RandomizeTexture(this, "res://textures/flora/trees/tree01.png",6);

		// Handle making the sprite more transparent when the Player is behind them
		_collisionBody = (Area2D) GetNode("Area2D");
		_collisionBody.BodyEntered += body =>
		{
			if (body.Name == "Player")
				Modulate = new Color(1, 1, 1, 0.5f);
		};
		_collisionBody.BodyExited += _ =>
		{
			Modulate = new Color(1, 1, 1);
		};
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}