using OpenTK.Graphics.OpenGL4;

namespace Krystal.Graphics
{
    public class FragmentShader : Shader
    {
        public FragmentShader(string shaderSource) : base(shaderSource, ShaderType.FragmentShader) {}
    }
}

