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

        public string TextureName { get; set; }

        public SpriteFont Font { get; set; }

        public bool IsAtShop { get; set; }
        
        public int Cost { get; set; }

        public Item()
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Box, Color);
            spriteBatch.DrawString(Font, Order == 0 ? "" : Order.ToString(), 
                new Vector2(Box.X, Box.Y), Color);

            if (IsAtShop)
            {
                spriteBatch.DrawString(Font, Cost.ToString(),
                new Vector2(Box.X, Box.Y), Color.Yellow);
            }
        }

        public override void Update(GameTime gameTime, Game1 game)
        {

        }
    }
}