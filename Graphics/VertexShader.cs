using OpenTK.Graphics.OpenGL4;

namespace Krystal.Graphics
{
    public class VertexShader : Shader
    {
        public VertexShader(string shaderSource) : base(shaderSource, ShaderType.VertexShader) {}
    }
}

