using game1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace game1.Model
{
    public class Item : GameObject
    {   

        public int Order { get; set; }

        public SpriteFont Font { get; set; }

        public Item()
        {
        }
        public void Act()
        {

        }
        public override void Draw(Game1 game, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Box, Color);
            spriteBatch.DrawString(Font, Order == 0 ? "" : Order.ToString(), 
                new Vector2(Box.X, Box.Y), Color);
        }

        public override void Update(GameTime gameTime, Game1 game)
        {

        }
    }
}