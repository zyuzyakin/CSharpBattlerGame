using game1.Controller;
using game1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1.Model.ItemTypes
{
    public class Shield : Item
    {
        public Shield()
        {
            TextureName = "cat_purr";
            IsAtShop = true;
            Cost = 2;
        }
        public override void Update(GameTime gameTime, Game1 game)
        {
            if (IsAtShop)
            {
                if (InputManager.Hover(Box))
                {
                    Color = Color.LightBlue;
                    if (InputManager.LeftClicked)
                    {
                        game.shopState.Money.MoneyValue -= Cost;
                        IsAtShop = false;
                        game.gameState.ItemGrid.Items.Add(new Shield()
                        {
                            Texture = this.Texture,
                            IsAtShop = false,
                            Font = this.Font
                        });
                        Color = Color.Red;
                    }
                }
                else
                {
                    Color = Color.White;
                }
            }
        }
    }
}
