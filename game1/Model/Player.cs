using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System.Collections.Generic;

namespace game1.Model
{
    public class Player : GameObject
    {
        public int HealthPoints { get; set; }

        public Player()
        {
            Position = new Vector2(80, 700);
            Box = new Rectangle(80, 700, 480, 480);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(Texture, Box, Color);
        }
    }
}
