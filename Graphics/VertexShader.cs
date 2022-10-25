using OpenTK.Graphics.OpenGL4;

namespace Krystal.Graphics
{
    /// <summary>
    /// Defines a Vertex Shader https://www.khronos.org/opengl/wiki/Vertex_Shader
    /// </summary>
    public class VertexShader : Shader
    {
        public VertexShader(string shaderSource) : base(shaderSource, ShaderType.VertexShader) {}
    }
}

