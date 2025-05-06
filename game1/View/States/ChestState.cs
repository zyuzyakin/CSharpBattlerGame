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
    public class ChestState : State
    {
        public AnimatedTexture PlayerTexture { get; set; }

        public Money Money { get; set; }
        public Button BackToMapButton { get; set; }
        
        public ChestGrid ChestGrid { get; set; }

        public ChestState(Game1 game, ContentManager content, GraphicsDevice graphicsDevice) : base(game, content, graphicsDevice)
        {
            Background = content.Load<Texture2D>("backgrounds/bgshop");

            PlayerTexture = new AnimatedTexture(20, 24, "playershopsheet",
                new Rectangle(160 * k, 40 * k, 40 * k, 40 * k));

            ChestGrid = new ChestGrid();

            BackToMapButton = new Button()
            {
                Box = new Rectangle(140 * k, 130 * k, 50 * k, 15 * k),
                Text = "НАЗАД!",
                OnClick = Button.BackToMap
            };

            Money = new Money();

            Money.LoadContent(content);
            BackToMapButton.LoadContent(content);
            PlayerTexture.LoadContent(content);
            ChestGrid.LoadContent(content);

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Game.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(Background, new Rectangle(0, 0, 200 * k, 150 * k), 
                Color.White);
            
            Game.gameState.Player.PlayerArsenal.Draw(spriteBatch);
            BackToMapButton.Draw(spriteBatch);
            Money.Draw(spriteBatch);
            ChestGrid.Draw(spriteBatch);
            PlayerTexture.Draw(spriteBatch);

            spriteBatch.End();
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            BackToMapButton.Update(gameTime, game);
            Money.Update(gameTime, game);
            PlayerTexture.Update(gameTime, game);
            ChestGrid.Update(gameTime, game);
        }

    }
}
