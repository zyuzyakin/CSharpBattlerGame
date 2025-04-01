using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System.Collections.Generic;

namespace game1.Model
{
    public class Enemy : GameObject
    {
        public int HealthPoints { get; set; }

        public Enemy()
        {
            Position = new Vector2(800, 80);
            Box = new Rectangle(800, 80, 400, 400);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(Texture, Box, Color);
        }
    }
}
