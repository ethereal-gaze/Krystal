namespace Krystal.Content;

public abstract class Block : ContentType
{
    public float Hardness { get; private set; }
    public int TextureID { get; private set; }
    public bool Transparent { get; private set; }
    public string Name { get; private set; }

    protected override void SetDefaults()
    {
        Hardness = 1.0f;
        TextureID = 0;
        Transparent = false;
        Name = GetType().ToString();
    }

    public virtual void OnBreak() {}
    public virtual void OnPlace() {}
    public virtual void WhileBreaking() {}
    public virtual void PlacedBehaviour() {}
}