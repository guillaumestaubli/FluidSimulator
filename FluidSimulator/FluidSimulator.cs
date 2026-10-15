using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace FluidSimulator
{
    public class FluidSimulator
    {
        private RenderWindow _renderWindow;

        private Stopwatch _clock;

        public FluidSimulator()
        {
            _clock = new Stopwatch();

            VideoMode vmRenderWindow = new VideoMode(Config.WINDOW_SIZE);

            _renderWindow = new RenderWindow(vmRenderWindow, "C# - SFML - FluidSimulator - RenderWindow", Styles.Close, State.Windowed);
            _renderWindow.SetVerticalSyncEnabled(true);
            _renderWindow.Closed += CloseRenderWindow;
        }

        public void Run(bool debug = false)
        {
            _clock.Start();

            while (_renderWindow.IsOpen)
            {
                _renderWindow.DispatchEvents();

                if(_clock.ElapsedMilliseconds >= Config.FRAME_DURATION)
                {
                    _clock.Restart();

                    _renderWindow.Clear(Color.Black);

                    _renderWindow.Display();
                }
            }
        }

        private void CloseRenderWindow(object? sender, EventArgs e)
        {
            _renderWindow.Close();
        }
    }
}
