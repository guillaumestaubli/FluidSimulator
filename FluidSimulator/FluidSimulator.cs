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
        private List<Particle> _particles;

        public FluidSimulator()
        {
            _clock = new Stopwatch();

            VideoMode vmRenderWindow = new VideoMode(Config.WINDOW_SIZE);

            _renderWindow = new RenderWindow(vmRenderWindow, "C# - SFML - FluidSimulator - RenderWindow", Styles.Close, State.Windowed);
            _renderWindow.SetVerticalSyncEnabled(true);
            _renderWindow.Closed += CloseRenderWindow;

            _particles = new List<Particle>();

            Particle part_test = new Particle(new Vector2f(100.0f, 100.0f));
            part_test.Direction = Angle.FromDegrees(90.0f);
            part_test.Velocity = 9.81f;

            _particles.Add(part_test);
        }

        public void Run(bool debug = false)
        {
            _clock.Start();

            while (_renderWindow.IsOpen)
            {
                _renderWindow.DispatchEvents();

                if(_clock.ElapsedMilliseconds >= Config.FRAME_DURATION)
                {
                    UpdateParticles();

                    _renderWindow.Clear(Color.Black);

                    DrawParticles();

                    _renderWindow.Display();

                    _clock.Restart();
                }
            }
        }

        private void CloseRenderWindow(object? sender, EventArgs e)
        {
            _renderWindow.Close();
        }

        private void UpdateParticles()
        {
            foreach(Particle part in _particles)
            {
                Vector2f position = part.Position;

                Vector2f move = new Vector2f(part.Velocity, part.Direction);

                position += move;

                part.Position = position;
            }
        }

        private void DrawParticles()
        {
            foreach(Particle particle in _particles)
            {
                _renderWindow.Draw(particle.Drawable);
            }
        }
    }
}
