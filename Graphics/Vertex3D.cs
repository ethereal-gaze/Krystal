namespace Krystal.Graphics
{
    public struct Vertex3D
    {
        public float x, y, z;
        public float uv_x, uv_y;

        public Vertex3D(float X = 0, float Y = 0, float Z = 0, float UV_X = 0, float UV_Y = 0)
        {
            x = X;
            y = Y;
            z = Z;
            uv_x = UV_X;
            uv_y = UV_Y;
        }
    }
}

