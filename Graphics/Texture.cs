using System.Net.Mime;
using OpenTK.Graphics.OpenGL4;
using StbImageSharp;

namespace Krystal.Graphics
{
    public class Texture2D
    {
        private readonly int _textureHandle = GL.GenTexture();
        
        public void LoadTextureFromFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();
            
            // (OpenGL standard reads images in reverse, so this is needed)
            StbImage.stbi_set_flip_vertically_on_load(1);

            var image = ImageResult.FromStream(File.OpenRead(path), ColorComponents.RedGreenBlueAlpha);
                
            Bind();
            
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            
            
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)All.LinearMipmapLinear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)All.Nearest);
           
            
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height,
                0, PixelFormat.Rgba, PixelType.UnsignedByte, image.Data);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
        }

        public Texture2D(string path)
        {
            LoadTextureFromFile(path);
        }
        
        public void Bind()
        {
            GL.BindTexture(TextureTarget.Texture2D, _textureHandle);
        }
    }
}
