using System.IO;
using OpenTK.Graphics.OpenGL4;
using StbImageSharp;

namespace Krystal.Graphics
{
    public class Texture2D
    {
        private readonly int _textureHandle = GL.GenTexture();
        private ImageResult _image;
        private bool _flipped;
        private string _file;

        public string TextureFile
        {
            get => _file;
            protected set
            {
                if (!File.Exists(value))
                {
                    Console.WriteLine("Failed to load texture {0}: cannot find file {1}", GetType().ToString(), value);
                    return;
                }
                    
                _file = value;
                LoadTextureFromFile();
            }
        }

        public bool Flipped
        {
            get => _flipped;
            protected set
            {
                if (_flipped == value) return;
                LoadTextureFromFile();
                _flipped = value;
            }
        }

        private void LoadTextureFromFile()
        {
            if (!Flipped)
                StbImage.stbi_set_flip_vertically_on_load(1);

            _image = ImageResult.FromStream(File.OpenRead(_file), ColorComponents.RedGreenBlueAlpha);
                
            Bind();
            
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            
            
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)All.LinearMipmapLinear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)All.Nearest);
           
            
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, _image.Width, _image.Height,
                0, PixelFormat.Rgba, PixelType.UnsignedByte, _image.Data);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
        }

        public void Bind()
        {
            GL.BindTexture(TextureTarget.Texture2D, _textureHandle);
        }

        public Texture2D(string path)
        {
            _file = path;
            LoadTextureFromFile();
        }

        ~Texture2D()
        {
            GL.DeleteTexture(_textureHandle);
        }
    }
}
