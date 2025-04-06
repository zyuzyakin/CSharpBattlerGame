using game1.Controller;
using game1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System.Collections.Generic;

namespace game1.Model.Buttons
{
    public class EndTurnButton : Button
    {
        public EndTurnButton()
        {
            Box = new Rectangle(100, 1300, 150, 150);
            Text = "END\nTURN";
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            if (InputManager.Hover(Box))
            {
                Color = Color.Blue;
            }
            else
            {
                Color = Color.White;
            }
        }
    }
}
