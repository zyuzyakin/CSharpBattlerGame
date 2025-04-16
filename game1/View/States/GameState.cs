using game1.Model;
using game1.Model.Buttons;
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
    public class GameState : State
    {
        public Player Player { get; private set; }
        public Enemy CurrentEnemy { get; private set; }
        public bool IsPaused {get;set;}
        public Button EnterShopButton { get; private set; }
        public Button PauseButton { get; set; }



        public GameState(Game1 game, ContentManager content, GraphicsDevice graphicsDevice) : base(game, content, graphicsDevice)
        {
            Player = new Player();
            
            CurrentEnemy = new Enemy();

            EnterShopButton = new Button()
            {
                Box = new Rectangle(1600, 1200, 150, 150),
                Text = "enter\nshop",
                OnClick = Button.StartGame

            };

            PauseButton = new Button()
            {
                Box = new Rectangle(1600, 300, 150, 150),
                Text = "pause",
                OnClick = Button.PauseUnpauseGame
            };


            CurrentEnemy.LoadContent(content);

            Player.LoadContent(content);
            EnterShopButton.LoadContent(content);
            PauseButton.LoadContent(content);
            Player.PlayerArsenal.LoadContent(content);

            
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Game.GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            CurrentEnemy.Draw(spriteBatch);
            Player.Draw(spriteBatch);
            Player.PlayerArsenal.Draw(spriteBatch);
            EnterShopButton.Draw(spriteBatch);
            PauseButton.Draw(spriteBatch);

            Game.shopState.Money.Draw(spriteBatch);
            

            spriteBatch.End();
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            Player.Update(gameTime, game);
            CurrentEnemy.Update(gameTime, game);
            EnterShopButton.Update(gameTime, game);
            PauseButton.Update(gameTime, game);
        }

    }
}
