using game1.Controller;
using game1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System.Collections.Generic;

namespace game1.Model
{
    public class Player : GameObject
    {
        public int MaxHealthPoints { get; set; }
        public int HealthPoints { get; set; }

        public SpriteFont Font { get; set; }

        public Player()
        {
            HealthPoints = 40;
            MaxHealthPoints = 40;
            Position = new Vector2(80, 700);
            Box = new Rectangle(80, 700, 480, 480);
        }
        public override void Update(GameTime gameTime, Game1 game)
        {
            if (InputManager.Hover(Box))
            {
                
                Color = Color.LightBlue;

                if (InputManager.LeftClicked)
                {
                    HealthPoints--;
                }
                if (InputManager.RightClicked)
                {
                    HealthPoints++;
                }
            }
            else
            {
                Color = Color.White;
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            string value = $"HP:{HealthPoints}/{MaxHealthPoints}";

            spriteBatch.Draw(Texture, Box, Color);

            spriteBatch.DrawString(Font, value, new Vector2(Box.X, Box.Y + Box.Height) 
                + new Vector2(1.0f, 1.0f), Color.White);
        }
    }
}
