using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Krystal
{
    internal static class Program
    {
        public static void Main()
        {
            var game = new Game(800, 600, "Krystal");
            game.Run();
        }
    }
}
