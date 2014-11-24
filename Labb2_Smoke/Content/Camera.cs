using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb2_Smoke.Content
{
    class Camera
    {
        private float scale;
        private static int border = 10;

        public Camera(int width, int heigth)
        {
            int scaleX = (width - border * 2);
            int scaleY = (heigth - border * 2);

            scale = scaleX;
            if (scaleY < scaleX)
            {
                scale = scaleY;
            }
        }

        public Rectangle scaleSmoke(float xPos, float yPos, float splitterSize)
        {
            int vSize = (int)(splitterSize * scale);

            Vector2 smokeVector = scaleSmokeVector(xPos, yPos);

            return new Rectangle((int)smokeVector.X, (int)smokeVector.Y, vSize, vSize);
        }

        public Vector2 scaleSmokeVector(float xPos, float yPos)
        {
            int vX = (int)(xPos * scale + border);
            int vY = (int)(yPos * scale + border);

            return new Vector2(vX, vY);
        }

        public float getScale
        {
            get { return scale; }
        }
    }
}
