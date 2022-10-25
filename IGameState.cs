using Krystal.Graphics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace Krystal
{
    public interface IGameState
    {
        /// <summary>
        /// Per frame calculations and tasks
        /// </summary>
        /// <param name="e"></param>
        /// <param name="keyboardState"></param>
        /// <param name="gameWindow"></param>
        void Update(FrameEventArgs e, ref KeyboardState keyboardState, ref GameWindow gameWindow);
        
        /// <summary>
        /// Rendering tasks for each frame
        /// </summary>
        /// <param name="renderHandler"></param>
        void Render(ref RenderHandler renderHandler);
    }
}

