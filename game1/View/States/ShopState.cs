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
        public Shop Shop { get; set; }

        public Money Money { get; set; }

        public Button BackToMapButton { get; set; }

        public ShopState(Game1 game, ContentManager content, GraphicsDevice graphicsDevice) : base(game, content, graphicsDevice)
        {
            Background = content.Load<Texture2D>("backgrounds/bgshop");

            Shop = new Shop();

            Shop.LoadContent(content);

            BackToMapButton = new Button()
            {
                Box = new Rectangle(180 * k, 130 * k, 15 * k, 15* k),
                Text = "назад",
                OnClick = Button.BackToMap
            };

            Money = new Money();

            Money.LoadContent(content);
            BackToMapButton.LoadContent(content);

        }
        
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Game.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(Background, new Rectangle(0, 0, 200 * k, 150 * k), Color.White);
            Shop.Draw(spriteBatch);
            Game.gameState.Player.PlayerArsenal.Draw(spriteBatch);
            BackToMapButton.Draw(spriteBatch);
            Money.Draw(spriteBatch);

            spriteBatch.End();

        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            
            BackToMapButton.Update(gameTime, game);
            Shop.Update(gameTime, game);
            Money.Update(gameTime, game);
        }

    }
}
