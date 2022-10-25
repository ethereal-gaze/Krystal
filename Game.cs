using System.Reflection;
using Krystal.Graphics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Krystal
{
    public class Game : GameWindow
    {
        private readonly GameStateHandler _gameStateHandler;
        private RenderHandler _renderHandler;

        public Game(int initialWidth, int initialHeight, string initialTitle) : base(GameWindowSettings.Default,
            new NativeWindowSettings { Size = (initialWidth, initialHeight), Title = initialTitle })
        {
            _renderHandler = new RenderHandler();
            _gameStateHandler = new GameStateHandler();
        }

        protected override void OnLoad()
        {
            var loadableInstances = from t in Assembly.GetExecutingAssembly().GetTypes()
                where (t.GetInterfaces().Contains(typeof(ILoadable)) && !t.IsAbstract) && t.GetConstructor(Type.EmptyTypes) != null
                select Activator.CreateInstance(t) as ILoadable;

            foreach (var instance in loadableInstances)
            {
                instance.Load();
            }
            
            _gameStateHandler.State = GameStateHandler.GameState.Playing;
            CursorState = CursorState.Normal;
        }
        
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            if (IsKeyPressed(Keys.Escape))
                CursorState = CursorState.Normal;
            if ((IsMouseButtonPressed(MouseButton.Left) && IsFocused) && CursorState != CursorState.Grabbed)
                CursorState = CursorState.Grabbed;
            
            _gameStateHandler.Update(e, KeyboardState,  this);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color4.Black);
            
            _renderHandler.Update(e);
            _gameStateHandler.Render(e, ref _renderHandler);
            
            SwapBuffers();
        }
    } 
}
