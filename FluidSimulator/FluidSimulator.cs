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
            _renderWindow.MouseButtonReleased += MouseButtonReleased;
            _renderWindow.MouseButtonPressed += MouseButtonPressed;

            _particles = new List<Particle>();

            Particle part_left = new Particle(new Vector2f(100.0f, 100.0f));
            part_left.Direction = Angle.FromDegrees(45.0f);
            part_left.Velocity = 5.0f;
            part_left.FillColor = Color.Red;

            _particles.Add(part_left);

            Particle part_right = new Particle(new Vector2f(500.0f, 100.0f));
            part_right.Direction = Angle.FromDegrees(135.0f);
            part_right.Velocity = 5.0f;
            part_right.FillColor = Color.Blue;

            _particles.Add(part_right);
        }

        public void Run(bool debug = false)
        {
            _clock.Start();

            while (_renderWindow.IsOpen)
            {
                _renderWindow.DispatchEvents();

                if (_clock.ElapsedMilliseconds >= Config.FRAME_DURATION)
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

        private void MouseButtonReleased(object? sender, MouseButtonEventArgs e)
        {
            if (e.Button == Mouse.Button.Left)
            {
                Particle part = new Particle(new Vector2f(e.Position.X, e.Position.Y));

                _particles.Add(part);
            }
        }

        private void MouseButtonPressed(object? sender, MouseButtonEventArgs e)
        {

        }

        private void UpdateParticles()
        {
            foreach (Particle part in _particles)
            {
                Vector2f position = part.Position;

                Vector2f move = new Vector2f(part.Velocity, part.Direction);

                position += move;

                part.Position = position;

                // detect collisions with border
                if (part.Position.X - part.Radius < 0 || part.Position.X + part.Radius > Config.WINDOW_SIZE.X)
                {
                    Vector2f corrected_move = move;

                    corrected_move.X *= -1.0f;

                    part.Position -= move;
                    part.Position += corrected_move;

                    if (corrected_move.Y > 0) // go down
                    {
                        double angle = Math.Tanh(corrected_move.X / corrected_move.Y);


                    }
                    else if (corrected_move.Y < 0) // go up
                    {

                    }
                }

                if (part.Position.Y - part.Radius < 0 || part.Position.Y + part.Radius > Config.WINDOW_SIZE.Y)
                {
                    Vector2f corrected_move = move;

                    corrected_move.Y *= -1.0f;

                    part.Position -= move;
                    part.Position += corrected_move;

                    if (corrected_move.X > 0) // go right
                    {

                    }
                    else if (corrected_move.X < 0) // go left
                    {

                    }
                }

                // detect collisions with other particles
            }
        }

        private void DrawParticles()
        {
            foreach (Particle particle in _particles)
            {
                _renderWindow.Draw(particle.Drawable);
            }
        }
    }
}
