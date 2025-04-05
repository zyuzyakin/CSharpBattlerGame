using game1.Controller;
using game1.View;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1.Model
{
    public class ExitButton : Button
    {
        public ExitButton()
        {
            Box = new Rectangle(100, 800, 150, 150);
            Text = "Exit";
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
