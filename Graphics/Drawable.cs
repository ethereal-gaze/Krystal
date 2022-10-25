using Krystal.Graphics.Scene;

namespace Krystal.Graphics
{
    /// <summary>
    /// Defines a class that can be passed to the Renderer to be drawn.
    /// </summary>
    public abstract class Drawable : Object3D
    {
        private FragmentShader _fragmentShader = new FragmentShader("Assets/Shaders/core.frag");
        private VertexShader _vertexShader = new VertexShader("Assets/Shaders/core.vert");
        private ShaderProgram _shaderProgram = new ShaderProgram();

        /// <summary>
        /// ID of the loaded Texture this drawable will be using.
        /// </summary>
        public int TextureID { get; protected set; }

        protected Drawable()
        {
            UpdateProgram();
        }
        
        /// <summary>
        /// Updates the contained shader program, typically called after one of the shaders change.
        /// </summary>
        private void UpdateProgram()
        {
            _shaderProgram = new ShaderProgram();
            _shaderProgram.AttachShader(_vertexShader);
            _shaderProgram.AttachShader(_fragmentShader);
            _shaderProgram.LinkProgram();
        }

        /// <summary>
        /// The fragment shader this Drawable will be rendered using.
        /// </summary>
        public FragmentShader FragShader
        {
            set
            {
                _fragmentShader = value;
                UpdateProgram();
            }
        }

        /// <summary>
        /// The vertex shader this Drawable will be rendered using
        /// </summary>
        public VertexShader VertShader
        {
            set
            {
                _vertexShader = value;
                UpdateProgram();
            }
        }
        
        /// <summary>
        /// The created shader program this Drawable will use for rendering.
        /// </summary>
        public ShaderProgram Program => _shaderProgram;

        /// <summary>
        /// The mesh this Drawable will submit to the renderer.
        /// </summary>
        public Mesh Model { get; protected set; }
    }   
}

