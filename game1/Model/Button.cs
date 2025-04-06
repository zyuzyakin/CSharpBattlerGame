using game1.Controller;
using game1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1.Model
{
    public abstract class Button : GameObject
    {
        public SpriteFont Font { get; set; }
        public string Text { get; set; }
        public Button()
        {

        }

        public override void Draw(Game1 game, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Box, Color);
            spriteBatch.DrawString(Font, Text, new Vector2(Box.X, Box.Y), Color);
        }
    }
}
