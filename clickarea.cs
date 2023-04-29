namespace ThreeAges;

public partial class ClickArea : Area2D
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
            HandleClick();
            QueueFree();
        }

        base._PhysicsProcess(delta);
    }

    private void HandleClick()
    {
        // Maybe this should just check for CollisionAreas, instead of all areas
        // Bodies are fine, it can be useful for animals later on
        var list = GetOverlappingBodies();
        var other = GetOverlappingAreas();
        List<Node2D> nodesClicked = new();
        var player = (Player) GetParent().GetNode("Player");

        foreach (var node in list)
        {
            if (nodesClicked.Contains(node)) continue;
            if (player.Position.DistanceTo(node.Position) == 0) continue; 
            nodesClicked.Add(node);
            // GD.Print($"{node.Name} found.");
            // GD.Print($"{node} Distance: {player.Position.DistanceTo(node.Position)}");
        }

        foreach (var area in other)
        {
            var node = (Node2D) area.GetParent();
            if (nodesClicked.Contains(node)) continue;
            if (player.Position.DistanceTo(node.Position) == 0) continue; // Since this is the player 
            nodesClicked.Add(node);
            // GD.Print($"{node.Name} found.");
            // GD.Print($"{node} Distance: {player.Position.DistanceTo(node.Position)}");
        }
        
        if (!nodesClicked.Any()) return;
        
        nodesClicked = nodesClicked.OrderBy(n => player.Position.DistanceTo(n.Position)).ToList();
        
        var last = nodesClicked.Last();
        GD.Print(player.Position.DistanceTo(last.Position) < 44
            ? $"Close enough to {last}"
            : $"Not close enough to {last}");
    }

    private void HandleProcess(Node2D body)
    {
        GD.Print(body.Name);
    }
}