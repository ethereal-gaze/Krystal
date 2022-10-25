using OpenTK.Graphics.OpenGL4;

namespace Krystal.Graphics
{
    /// <summary>
    /// Defines a fragment shader (https://www.khronos.org/opengl/wiki/Fragment_Shader)
    /// </summary>
    public class FragmentShader : Shader
    {
        public FragmentShader(string shaderSource) : base(shaderSource, ShaderType.FragmentShader) {}
    }
}

