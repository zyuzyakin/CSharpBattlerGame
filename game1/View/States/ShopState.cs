using game1.Model;
using game1.Model.Buttons;
using game1.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1.View.States
{
    public class ShopState : State
    {
        public ShopGrid ShopGrid { get; set; }

        public Money Money { get; set; }

        public Button ExitShopButton { get; set; }

        public ShopState(Game1 game, ContentManager content, GraphicsDevice graphicsDevice) : base(game, content, graphicsDevice)
        {   
            ShopGrid = new ShopGrid();

            RefreshShop();

            ExitShopButton = new Button()
            {
                Box = new Rectangle(1800, 1300, 150, 150),
                Text = "exit\nshop",
                OnClick = Button.ExitShop
            };

            Money = new Money();

            Money.LoadContent(content);
            ExitShopButton.LoadContent(content);

        }
        public void RefreshShop()
        {
            ShopGrid.Items = new List<Item>()
            {
                new Item(){ItemType = ItemType.sword,  Cost = 1},
                new Item(){ItemType = ItemType.shield, Cost = 2}
            };

            ShopGrid.LoadContent(Content);
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Game.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            ShopGrid.Draw(spriteBatch);
            Game.gameState.Player.PlayerArsenal.Draw(spriteBatch);
            ExitShopButton.Draw(spriteBatch);
            Money.Draw(spriteBatch);

            spriteBatch.End();

        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            ExitShopButton.Update(gameTime, game);
            ShopGrid.Update(gameTime, game);
            Money.Update(gameTime, game);
        }

    }
}
