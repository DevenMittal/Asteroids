using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    interface ISprite
    {
        Texture2D image { get; set; }
        Color tint { get; set; }
        Rectangle rect { get; set; }
        Vector2 position { get; set; }
        Vector2 speed { get; set; }

        void Draw(SpriteBatch sb);









    }
}
