using game1.Controller;
using game1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1.Model.Buttons
{
    public class ExitShopButton : Button
    {
        public ExitShopButton()
        {
            Box = new Rectangle(600, 600, 150, 150);
            Text = "exit shop";
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            if (InputManager.Hover(Box))
            {
                Color = Color.Blue;
                if (InputManager.LeftClicked)
                {
                    game.ChangeState(game.GameState);
                    game.ShopState.RefreshShop();
                }
            }
            else
            {
                Color = Color.White;
            }
        }
    }
}
