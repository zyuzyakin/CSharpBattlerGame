using game1.Controller;
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
        public void Update(GameTime gameTime)
        {
            if (InputManager.Hover(Box))
            {
                
                Color = Color.Black;

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
        public void Draw(SpriteBatch _spriteBatch)
        {
            string value = $"HP:{HealthPoints}/{MaxHealthPoints}";

            _spriteBatch.Draw(Texture, Box, Color);

            _spriteBatch.DrawString(Font, value, new Vector2(Box.X, Box.Y + Box.Height) 
                + new Vector2(1.0f, 1.0f), Color.White);
        }
    }
}
