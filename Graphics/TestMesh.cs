namespace Krystal.Graphics
{
    public class TestMesh : Drawable
    {
        public TestMesh()
        {
            var vertices = new List<Vertex3D>()
            {
                new Vertex3D(-0.5f, 0.5f, 0.0f, 0, 1),
                new Vertex3D(0.5f, 0.5f, 0.0f, 1, 1),
                new Vertex3D(0.5f, -0.5f, 0.0f, 1, 0),
                new Vertex3D(-0.5f, -0.5f, 0.0f, 0, 0)
            };

            var indices = new List<ushort>()
            {
                0, 1, 2, 2, 3, 0
            };
            
            Model = new Mesh(vertices, indices);
        }
    }
}

