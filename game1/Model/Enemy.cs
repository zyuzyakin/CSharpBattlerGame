using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System.Collections.Generic;

namespace game1.Model
{
    public class Enemy : GameObject
    {
        public int MaxHealthPoints { get; set; }
        public int HealthPoints { get; set; }

        public SpriteFont Font { get; set; }

        public Enemy()
        {
            MaxHealthPoints = 10;
            HealthPoints = 10;
            Position = new Vector2(800, 80);
            Box = new Rectangle(800, 80, 400, 400);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(Texture, Box, Color);

            string value = $"HP:{HealthPoints}/{MaxHealthPoints}";
            _spriteBatch.DrawString(Font, value, new Vector2(Box.X, Box.Y + Box.Height)
                + new Vector2(1.0f, 1.0f), Color.White);
        }
    }
}
