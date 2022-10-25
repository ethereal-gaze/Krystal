namespace Krystal.Graphics
{
    public struct Mesh
    {
        public List<Vertex3D> vertices;
        public List<ushort> indices;

        public Mesh(List<Vertex3D> Vertices, List<ushort> Indices)
        {
            vertices = Vertices;
            indices = Indices;
        }
    }
}

