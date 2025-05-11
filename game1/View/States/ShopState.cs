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
        public AnimatedTexture PlayerTexture { get; set; }

        public ShopGridView ShopGrid { get; set; }
        public MoneyView Money { get; set; }

        private Texture2D Description;

        public ButtonView BackToMapButton { get; set; }
        public ButtonView CombineItemsButton { get; set; }


        public ShopState(Game1 game, ContentManager content, GraphicsDevice graphicsDevice) : base(game, content, graphicsDevice)
        {
            Background = content.Load<Texture2D>("backgrounds/bgshop");
            Description = content.Load<Texture2D>("itemdescription");
            PlayerTexture = new AnimatedTexture(20, 24, "playershopsheet", 
                new Rectangle(140 * k, 90 * k, 40 * k, 40 * k));

            ShopGrid = new ShopGridView();

            ShopGrid.LoadContent(content);

            CombineItemsButton = new ButtonView()
            {
                Box = new Rectangle(5 * k, 130 * k, 50 * k, 15 * k),
                Text = "СОЕДИНИТЬ!",
                OnClick = Button.CombineItems
            };

            BackToMapButton = new ButtonView()
            {
                Box = new Rectangle(140 * k, 130 * k, 50 * k, 15 * k),
                Text = "НАЗАД!",
                OnClick = Button.BackToMap
            };

            Money = new MoneyView();

            Money.LoadContent(content);
            BackToMapButton.LoadContent(content);
            CombineItemsButton.LoadContent(content);
            PlayerTexture.LoadContent(content);

        }
        
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Game.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(Background, new Rectangle(0, 0, 200 * k, 150 * k), Color.White);
            spriteBatch.Draw(Description, 
                new Rectangle(140 * k, 30 * k, 60 * k, 60 * k), Color.White);
            ShopGrid.Draw(spriteBatch);
            Game.gameState.PlayerArsenal.Draw(spriteBatch);
            BackToMapButton.Draw(spriteBatch);
            Money.Draw(spriteBatch);
            CombineItemsButton.Draw(spriteBatch);
            PlayerTexture.Draw(spriteBatch);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            CombineItemsButton.Update(gameTime, game);
            BackToMapButton.Update(gameTime, game);
            ShopGrid.Update(gameTime, game);
            Money.Update(gameTime, game);
            PlayerTexture.Update(gameTime, game);
        }

    }
}
