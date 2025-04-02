using game1.Controller;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System.Collections.Generic;

namespace game1.Model
{
    public class EndTurnButton : GameObject
    {
        public SpriteFont Font { get; set; }
        public EndTurnButton()
        {
            Box = new Rectangle(100, 1300, 200, 200);
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            string value = "END\nTURN";

            _spriteBatch.Draw(Texture, Box, Color);

            _spriteBatch.DrawString(Font, value, new Vector2(Box.X, Box.Y), Color.Orange);
        }
    }
}
