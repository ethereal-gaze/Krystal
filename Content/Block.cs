namespace Krystal.Content;

/// <summary>
/// Defines a block and its properties.
/// </summary>
public abstract class Block : ContentType
{
    /// <summary>
    /// Value that determines how long it will take for a block to be destroyed.
    /// </summary>
    public float Hardness { get; private set; }
    
    /// <summary>
    /// ID of the loaded texture this block will use
    /// </summary>
    public int TextureId { get; private set; }
    
    /// <summary>
    /// Whether or not the black is transparent or not. Used for AI and rendering.
    /// </summary>
    public bool Transparent { get; private set; }
    
    /// <summary>
    /// The display name of this block.
    /// </summary>
    public string Name { get; private set; }

    protected override void SetDefaults()
    {
        Hardness = 1.0f;
        TextureId = 0;
        Transparent = false;
        Name = GetType().ToString();
    }

    /// <summary>
    /// Actions to perform when this block type is broken, typically includes dropping an ItemEntity
    /// </summary>
    public virtual void OnBreak() {}
    
    /// <summary>
    /// Actions to perform when this block type is placed.
    /// </summary>
    public virtual void OnPlace() {}
    
    /// <summary>
    /// Actions to perform while this block is being broken.
    /// </summary>
    public virtual void WhileBreaking() {}
    
    /// <summary>
    /// Behaviour of the block while it's placed
    /// </summary>
    public virtual void PlacedBehaviour() {}
}