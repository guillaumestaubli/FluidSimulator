using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluidSimulator
{
    public static class Config
    {
        /// <summary>
        /// 30 [ms] => env. 60 FPS
        /// </summary>
        public const uint FRAME_DURATION = 30;

        /// <summary>
        /// 1280 x 720
        /// </summary>
        public static readonly Vector2u WINDOW_SIZE = new Vector2u(1280, 720);
    }
}
