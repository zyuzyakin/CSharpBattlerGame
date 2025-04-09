using game1.Model;
using game1.Model.Buttons;
using game1.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
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

        public Money Money { get;  set; }

        public ExitShopButton ExitShopButton { get; set; }

        public ShopState(Game1 game, ContentManager content, GraphicsDevice graphicsDevice) : base(game, content, graphicsDevice)
        {
            ShopGrid = new ShopGrid();
            
            RefreshShop();

            ExitShopButton = new ExitShopButton();
            Money = new Money();
            

            var BaseFont = Content.Load<SpriteFont>("fonts/Hud");
            Money.Texture = Content.Load<Texture2D>("controls/button");
            Money.Font = BaseFont;
            ExitShopButton.Texture = Content.Load<Texture2D>("controls/button");
            ExitShopButton.Font = BaseFont;

        }
        public void RefreshShop()
        {
            ShopGrid.Items = new List<Item>()
            {
                new Item(){ItemType = ItemType.sword, TextureName = "sword", Cost = 5, ChargePerElapsed = 1},
                new Item(){ItemType = ItemType.shield, TextureName = "shield", Cost = 2}
            };

            foreach (var item in ShopGrid.Items)
            {
                item.Texture = Content.Load<Texture2D>($"items/{item.TextureName}");
                item.Font = Content.Load<SpriteFont>("fonts/Hud");
            }
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
