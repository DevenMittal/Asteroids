using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class Asteroid
    {
        public Vector2 speed;
        public Texture2D image;
        public Color tint;
        public Vector2 position;
        public Rectangle hitbox;
        public Vector2 origin => new Vector2(hitbox.Width / 2, hitbox.Height / 2);

        public Asteroid(Texture2D image, Vector2 position, Vector2 speed, Color tint, Rectangle hitbox)
        {
            this.image = image;
            this.position = position;
            this.speed = speed;
            this.tint = tint;
            this.hitbox = hitbox;
        }


        public void Bounce(GraphicsDevice gd)
        {

            hitbox.X = (int)position.X;
            hitbox.Y = (int)position.Y;


            position.X += speed.X;
            position.Y += speed.Y;
            if (position.X < 0)
            {
                speed.X *= -1;
            }
            if (position.Y < 0)
            {
                speed.Y *= -1;

            }
            if (position.X +hitbox.Width> gd.Viewport.Width)
            {
                speed.X *= -1;

            }
            if (position.Y+ hitbox.Height > gd.Viewport.Height)
            {
                speed.Y *= -1;

            }

        }

        public void Collision(List<Asteroid> asteroids)
        {
            Vector2 center = new Vector2(hitbox.Width / 2, hitbox.Height / 2);
            int radius1 = (int)position.X + (int)image.Width - (int)center.X;
            int radius2 = (int)position.X + (int)image.Width - (int)center.X;

        }

       

    }
}
