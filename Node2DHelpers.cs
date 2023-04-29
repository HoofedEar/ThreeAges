namespace ThreeAges;

public static class Node2DHelpers
{
    /// <summary>
    /// Randomizes the Texture of a Node2D. Index starts at 1, and ends in maxIndex
    /// </summary>
    /// <param name="obj">The Node2D (must have a node named Sprite2D)</param>
    /// <param name="resPath">Path to the first resource in the group (must end in '1.png')</param>
    /// <param name="maxIndex">Max index to find in texture group</param>
    public static void RandomizeTexture(Node2D obj, string resPath, int maxIndex)
    {
        resPath = resPath.Replace("1.png", "");
        var index = GD.RandRange(1, maxIndex);
        var sprite = (Sprite2D) obj.GetNode("Sprite2D");
        var indexedSprite = ResourceLoader.Load($"{resPath}{index}.png") as Texture;
        sprite.Texture = (Texture2D) indexedSprite;	
    }
}