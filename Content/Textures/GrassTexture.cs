using Krystal.Graphics;

namespace Krystal.Content.Textures
{
    public class GrassTexture : Texture2D
    {
        protected override void SetDefaults()
        {
            TextureFile = "Assets/Textures/Grass.png";
            Name = "Grass";
            base.SetDefaults();
        }
    }
}

