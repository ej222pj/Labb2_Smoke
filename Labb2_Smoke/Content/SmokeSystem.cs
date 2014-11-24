using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb2_Smoke.Content
{
    class SmokeSystem
    {        
        private Camera camera;
        private List<SmokeParticle> smokeParticles = new List<SmokeParticle>();
        private float totalTime = 0;
        private static float delay = 0.2f;

        public SmokeSystem(Viewport viewPort)
        {
            camera = new Camera(viewPort.Width, viewPort.Height);
        }

        public void Update(float timeElapsed)
        {
            totalTime += timeElapsed;

            if (totalTime >= delay)
            {
                totalTime = 0;
            
            smokeParticles.Add(new SmokeParticle());
            }

            for (int i = 0; i < smokeParticles.Count; i++)
            {
                smokeParticles[i].Update(timeElapsed);

                if (smokeParticles[i].isDead())
                {
                    smokeParticles[i].Respawn();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D splitterTexture)
        {
            for (int i = 0; i < smokeParticles.Count; i++)
            {
                smokeParticles[i].Draw(spriteBatch, splitterTexture, camera);
            }
        }
    }
}
