using Krystal.Graphics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Krystal
{
    public class GameStateHandler
    {
        private Dictionary<GameState, IGameState> _states;
        
        public GameState State { get; set; } = GameState.Playing;
        
        public enum GameState
        {
            Playing,
            Loading,
            Paused
        }

        public GameStateHandler()
        {
            _states = new Dictionary<GameState, IGameState>();
            _states.Add(GameState.Playing, new PlayingState());
        }

        public void Update(FrameEventArgs e, KeyboardState keyboardState, GameWindow gameWindow)
        {
            _states[State].Update(e, ref keyboardState, ref gameWindow);
        }

        public void Render(FrameEventArgs e, ref RenderHandler renderHandler)
        {
            _states[State].Render(ref renderHandler);
        }
    } 
}
