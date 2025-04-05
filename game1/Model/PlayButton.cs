using game1.Controller;
using game1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1.Model
{
    public class PlayButton : Button
    {
        public PlayButton()
        {
            Box = new Rectangle(100, 600, 150, 150);
            Text = "Play";
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            if (InputManager.Hover(Box))
            {
                Color = Color.Blue;
                if (InputManager.LeftClicked)
                {
                    game.ChangeState(game.gameState);
                }
            }
            else
            {
                Color = Color.White;
            }
        }
    }
}
