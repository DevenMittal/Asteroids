using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class Ship : ISprite
    {
        public Texture2D image { get; set; }
        public Color tint { get; set; }
        public Rectangle rect { get; set; }
        public Vector2 position { get; set; }
        public Vector2 speed { get; set; }

        public Vector2 origin => new Vector2(image.Width / 2, image.Height / 2);

        // in radians
        public float angle;
        public float anglestep;

        public int speedscale;

        public Vector2 AngledSpeed
        {
            get
            {
                float tempx = (float) (Math.Cos(angle) * speedscale);
                float tempy = (float)(Math.Sin(angle) * speedscale);

                return new Vector2(tempx, tempy);
            }
        }
        
        public Ship(Texture2D image, Color tint, Rectangle rect, Vector2 position)
        {
            this.image = image;
            this.tint = tint;
            this.rect = rect;
            this.position = position;

            angle = 0f;
            anglestep = 0.1f;
            speedscale = 2;

        }
        
        public void Move()
        {
            //if(Keyboard.GetState().IsKeyDown(Keys.W))
            //{
            //    position -= new Vector2(0,speed.Y);
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.S))
            //{
            //    position += new Vector2(0, speed.Y);
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.D))
            //{
            //    position += new Vector2(speed.X, 0);
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.A))
            //{
            //    position -= new Vector2(speed.X, 0);
            //}
            

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                position += AngledSpeed*speed;
            }


            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                angle += anglestep;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                angle -= anglestep;
            }


        }


        public void Draw(SpriteBatch sb)
        {
            sb.Draw(image, position, null, tint, angle, origin, 1.0f, SpriteEffects.None, 1);
            //sb.Draw(image, position, tint);
        }


    }
}
