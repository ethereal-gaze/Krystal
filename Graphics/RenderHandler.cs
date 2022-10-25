using OpenTK.Graphics.OpenGL4;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using OpenTK.Windowing.Common;

namespace Krystal.Graphics
{
    public class RenderHandler
    {
        private readonly int _vertexArray = GL.GenVertexArray();
        private readonly int _vertexBuffer = GL.GenBuffer();
        private readonly int _indexBuffer = GL.GenBuffer();
        private FrameEventArgs _frameEventArgs;

        public RenderHandler()
        {
            GL.BindVertexArray(_vertexArray);
                GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBuffer);
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, _indexBuffer);
                
                GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 
                    Unsafe.SizeOf<Vertex3D>(), 0);
                GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, Unsafe.SizeOf<Vertex3D>(),
                    3 * sizeof(float));
                
                GL.EnableVertexAttribArray(0);
                GL.EnableVertexAttribArray(1);
        }
        public void Update(FrameEventArgs e)
        {
            _frameEventArgs = e;
        }
        public void Draw(Drawable drawable, ref Camera camera)
        {
            GL.BufferData(BufferTarget.ArrayBuffer,
                drawable.Model.vertices.Count * Unsafe.SizeOf<Vertex3D>(),
                ref CollectionsMarshal.AsSpan(drawable.Model.vertices)[0],
                BufferUsageHint.StaticDraw);
            
            GL.BufferData(BufferTarget.ElementArrayBuffer,
                    drawable.Model.indices.Count * sizeof(ushort),
                    ref CollectionsMarshal.AsSpan(drawable.Model.indices)[0],
                    BufferUsageHint.StaticDraw);

            drawable.Program.Use();
            drawable.Program.SetMatrix4Uniform("glModel", drawable.Matrix);
            drawable.Program.SetMatrix4Uniform("glView", camera.OrientalMatrix);
            drawable.Program.SetMatrix4Uniform("glProjection", camera.FrustumMatrix);
            drawable.Program.SetFloatUniform("deltaTime", (float)_frameEventArgs.Time);
            
            GameContent.Get<Texture2D>(drawable.TextureID).Bind();
            
            GL.DrawElements(PrimitiveType.Triangles, drawable.Model.indices.Count, DrawElementsType.UnsignedShort, 0);
        }
    }
}
