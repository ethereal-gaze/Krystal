using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace Krystal.Graphics
{
    /// <summary>
    /// Defines a shader program (https://www.khronos.org/opengl/wiki/GLSL_Object#Program_objects)
    /// </summary>
    public class ShaderProgram
    {
        private readonly int _handle = GL.CreateProgram();

        /// <summary>
        /// Gets the location of a uniform
        /// </summary>
        /// <param name="name">The name of the uniform</param>
        /// <returns>Location of the uniform</returns>
        private int UniformLocation(string name) => GL.GetUniformLocation(_handle, name);
        
        /// <summary>
        /// Attaches a shader to the program.
        /// </summary>
        /// <param name="shader">Shader to be attached.</param>
        public void AttachShader(Shader shader)
        {
            GL.AttachShader(_handle, shader.Handle);
        }

        /// <summary>
        /// Links all attached shaders together.
        /// </summary>
        /// <exception cref="Exception">Error Linking</exception>
        public void LinkProgram()
        {
            GL.LinkProgram(_handle);

            GL.GetProgram(_handle, GetProgramParameterName.LinkStatus, out var code);

            if (code == (int)All.True) return;

            var info = GL.GetProgramInfoLog(_handle);
            throw new Exception($"Error linking shader program: {info}");
        }

        /// <summary>
        /// Binds the program for use in OpenGL
        /// </summary>
        public void Use()
        {
            GL.UseProgram(_handle);
        }

        /// <summary>
        /// Sets a uniform mat4 in the program.
        /// </summary>
        /// <param name="name">Name of the uniform</param>
        /// <param name="matrix">Matrix to set it to</param>
        public void SetMatrix4Uniform(string name, Matrix4 matrix)
        {
            GL.UniformMatrix4(GL.GetUniformLocation(_handle, name), false, ref matrix);
        }
        
        /// <summary>
        /// Sets a uniform float in the program
        /// </summary>
        /// <param name="name">Name of the uniform</param>
        /// <param name="value">Float to set it to</param>
        public void SetFloatUniform(string name, float value)
        {
            GL.Uniform1(UniformLocation(name), value);
        }

        ~ShaderProgram()
        {
            Console.WriteLine($"Destroying program: {_handle}");
            GL.DeleteProgram(_handle);
        }
    }
}