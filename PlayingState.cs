using Krystal.Graphics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Krystal;

public class PlayingState : IGameState
{
    private readonly TestMesh _tm = new();
    private Camera _camera = new();
    
    public void Update(FrameEventArgs e, ref KeyboardState keyboardState, ref GameWindow gameWindow)
    {
        if (gameWindow.CursorState == CursorState.Grabbed)
            _camera.ProcessFreecamMovement(ref keyboardState, (float)e.Time, gameWindow.MouseState.Position);
    }

    public void Render(ref RenderHandler renderHandler)
    {
        renderHandler.Draw(_tm, ref _camera);
    }
}