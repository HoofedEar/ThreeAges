using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

namespace ThreeAges;

public partial class clickarea : Area2D
{
    private double _time;

    public override void _Ready()
    {
        // BodyEntered += HandleProcess;
        // AreaEntered += body => GD.Print(body.Name);
    }

    public override void _PhysicsProcess(double delta)
    {
        _time += delta;
        if (Math.Abs((float) _time - 0.1f) < 0.001)
        {
            ProduceDropdown();
            QueueFree();
        }

        base._PhysicsProcess(delta);
    }

    private void ProduceDropdown()
    {
        // Maybe this should just interact with the closest object?
        var list = GetOverlappingBodies();
        var other = GetOverlappingAreas();
        List<Node2D> nodesClicked = new();

        foreach (var node in list)
        {
            if (nodesClicked.Contains(node)) continue;
            nodesClicked.Add(node);
            GD.Print($"{node.Name} found.");
        }

        foreach (var area in other)
        {
            var node = (Node2D) area.GetParent();
            if (nodesClicked.Contains(node)) continue;
            nodesClicked.Add(node);
            GD.Print($"{node.Name} found.");
        }
        
        if (!nodesClicked.Any()) return;
        
        nodesClicked = nodesClicked.OrderBy(n => Position.DistanceTo(n.Position)).ToList();

        var player = (Player) GetParent().GetNode("Player");
        var last = nodesClicked.Last();
        var target = new Vector2
        {
            X = last.Position.X,
            Y = last.Position.Y + 20
        };
        player.MoveTarget = target;
    }

    private void HandleProcess(Node2D body)
    {
        GD.Print(body.Name);
    }
}