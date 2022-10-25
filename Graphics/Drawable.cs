using Krystal.Graphics.Scene;

namespace Krystal.Graphics
{
    public class Drawable : Object3D
    {
        private FragmentShader _fragmentShader = new FragmentShader("Assets/Shaders/core.frag");
        private VertexShader _vertexShader = new VertexShader("Assets/Shaders/core.vert");
        private ShaderProgram _shaderProgram = new ShaderProgram();

        public int TextureID { get; protected set; }

        public Drawable()
        {
            UpdateProgram();
        }
        
        private void UpdateProgram()
        {
            _shaderProgram = new ShaderProgram();
            _shaderProgram.AttachShader(_vertexShader);
            _shaderProgram.AttachShader(_fragmentShader);
            _shaderProgram.LinkProgram();
        }

        public FragmentShader FragShader
        {
            set
            {
                _fragmentShader = value;
                UpdateProgram();
            }
        }

        public VertexShader VertShader
        {
            set
            {
                _vertexShader = value;
                UpdateProgram();
            }
        }
        
        public ShaderProgram Program => _shaderProgram;

        public Mesh Model { get; protected set; }
    }   
}

