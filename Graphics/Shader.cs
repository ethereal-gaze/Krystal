using OpenTK.Graphics.OpenGL4;

namespace Krystal.Graphics
{
    /// <summary>
    /// Defines a Shader (https://www.khronos.org/opengl/wiki/Shader)
    /// </summary>
    public class Shader
    {
        /// <summary>
        /// The OpenGL reserved name for the shader on in Video Memory.
        /// </summary>
        public int Handle { get; }
        public ShaderType Type { get; }

        /// <summary>
        /// Compiles this shader from the provided source
        /// </summary>
        /// <param name="path">path to the source</param>
        /// <exception cref="Exception">Failed compilation</exception>
        protected void _compileShader(string path)
        {
            GL.ShaderSource(Handle, File.ReadAllText(path));
            
            GL.CompileShader(Handle);
            GL.GetShader(Handle, ShaderParameter.CompileStatus, out var code);

            if (code == (int)All.True) return;
            
            var log = GL.GetShaderInfoLog(Handle);
            throw new Exception($"Unable to compile shader ({path}): {log}");
        }
        
        public Shader(string sourcePath, ShaderType type)
        {
            this.Type = type;
            
            if (!File.Exists(sourcePath))
                throw new Exception($"({sourcePath}) File not found or access denied");
            
            Handle = GL.CreateShader(Type);
            _compileShader(sourcePath);
        }
    }
}

