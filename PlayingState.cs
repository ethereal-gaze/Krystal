using Krystal.Graphics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Krystal;

public class PlayingState : IGameState
{
    private TestMesh _tm;
    private Camera _camera;
    private Texture2D _textureTest;

    public PlayingState()
    {
        _tm = new TestMesh();
        _camera = new Camera();
        _textureTest = new Texture2D("Assets/Textures/Grass.png");
    }
    
    public void Update(FrameEventArgs e, ref KeyboardState keyboardState, ref GameWindow gameWindow)
    {
        if (gameWindow.CursorState == CursorState.Grabbed)
            _camera.ProcessFreecamMovement(ref keyboardState, (float)e.Time, gameWindow.MouseState.Position);
    }

    public void Render(ref RenderHandler renderHandler)
    {
        _textureTest.Bind();
        renderHandler.Draw(_tm, ref _camera);
    }
}