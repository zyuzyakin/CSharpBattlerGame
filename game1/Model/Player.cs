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

        public int ShieldPoints { get; set; }
        public PlayerArsenal PlayerArsenal { get; set; }
        public SpriteFont Font { get; set; }

        public Player()
        {
            HealthPoints = 40;
            MaxHealthPoints = 40;
            PlayerArsenal = new PlayerArsenal();
            Position = new Vector2(80, 700);
            Box = new Rectangle(80, 700, 480, 480);
        }
        public override void Update(GameTime gameTime, Game1 game)
        {
            PlayerArsenal.Update(gameTime, game);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            string hpDisplay = $"HP:{HealthPoints}/{MaxHealthPoints}";
            string shieldDisplay = "SHIELD:" + (ShieldPoints == 0 ? "" : ShieldPoints.ToString());

            spriteBatch.Draw(Texture, Box, Color);

            spriteBatch.DrawString(Font, hpDisplay, new Vector2(Box.X, Box.Y + Box.Height) 
                + new Vector2(0.0f, 10.0f), Color.White);
            spriteBatch.DrawString(Font, shieldDisplay, new Vector2(Box.X, Box.Y + Box.Height)
                + new Vector2(0.0f, 70.0f), Color.White);
        }
    }
}
