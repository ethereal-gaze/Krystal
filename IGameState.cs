using Krystal.Graphics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace Krystal
{
    public interface IGameState
    {
        void Update(FrameEventArgs e, ref KeyboardState keyboardState, ref GameWindow gameWindow);
        void Render(ref RenderHandler renderHandler);
    }
}

