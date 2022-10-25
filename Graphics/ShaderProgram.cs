using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace Krystal.Graphics
{
    public class ShaderProgram
    {
        private readonly int _handle = GL.CreateProgram();

        private int UniformLocation(string name) => GL.GetUniformLocation(_handle, name);
        public void AttachShader(Shader shader)
        {
            GL.AttachShader(_handle, shader.Handle);
        }

        public void LinkProgram()
        {
            GL.LinkProgram(_handle);

            GL.GetProgram(_handle, GetProgramParameterName.LinkStatus, out var code);

            if (code == (int)All.True) return;

            var info = GL.GetProgramInfoLog(_handle);
            throw new Exception($"Error linking shader program: {info}");
        }

        public void Use()
        {
            GL.UseProgram(_handle);
        }

        public void SetMatrix4Uniform(string name, Matrix4 matrix)
        {
            GL.UniformMatrix4(GL.GetUniformLocation(_handle, name), false, ref matrix);
        }

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