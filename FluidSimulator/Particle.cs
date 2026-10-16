using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.System;
using SFML.Graphics;

namespace FluidSimulator
{
    public class Particle
    {
        private Vector2f _position;
        private float _radius;
        private float _velocity;
        private Angle _direction;
        private Color _fillColor = Color.White;

        private CircleShape _drawable = new CircleShape();

        #region GET_SET

        public Vector2f Position
        {
            get { return _position; }
            set { _position = value; UpdateDrawable(); }
        }

        public float Radius
        {
            get { return _radius; }
            set { _radius = value; UpdateDrawable(); }
        }

        public float Velocity
        {
            get { return _velocity; }
            set { _velocity = value; UpdateDrawable(); }
        }

        public Angle Direction
        {
            get { return _direction; }
            set { _direction = value; UpdateDrawable(); }
        }

        public Color FillColor
        {
            get { return _fillColor; }
            set { _fillColor = value; UpdateDrawable(); }
        }

        public IDrawable Drawable
        {
            get { return _drawable; }
        }

        #endregion

        public Particle(Vector2f center, float radius = 10.0f, float velocity = 0.0f, float deg_angle = 0.0f)
        {
            _position = center;
            _radius = radius;
            _velocity = velocity;
            _direction = Angle.FromDegrees(deg_angle);

            UpdateDrawable();
        }

        private void UpdateDrawable()
        {
            _drawable.Radius = _radius;
            _drawable.FillColor = _fillColor;
            _drawable.Origin = _drawable.GetGeometricCenter();
            _drawable.Position = _position;
        }
    }
}
