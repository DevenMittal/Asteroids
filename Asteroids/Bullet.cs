using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class Bullet : ISprite
    {
        public Texture2D image { get; set ; }
        public Color tint { get; set; }
        public Rectangle rect { get; set; }
        public Vector2 position { get; set; }
        public Vector2 speed { get; set; }
        public float angle;
        public int speedscale;
        public Vector2 Anglespeed
        {
            get
            {
                float tempx = (float)(Math.Cos(angle) * speedscale);
                float tempy = (float)(Math.Sin(angle) * speedscale);

                return new Vector2(tempx, tempy);
            }
        }
                
                
                          
        public Vector2 origin { get; set; }

        

        public Bullet(Texture2D image, Color tint, Rectangle rect, Vector2 position, Vector2 origin, float angle)
        {
            this.image = image;
            this.tint = tint;
            this.rect = rect;
            this.position = position;
            this.speed = speed;
            this.origin = origin;
            this.angle = angle;
            speedscale = 2;
        }

        public void Move()
        {

            position += Anglespeed*speed;
            //angle = anglestep;

            
        }





        // use ship origin
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(image, position, null, tint, angle, origin, 1.0f, SpriteEffects.None, 1);

        }
    }
}
