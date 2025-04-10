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
                Text = "enter\nshop"
            };

            PauseButton = new Button()
            {
                Box = new Rectangle(1600, 300, 150, 150),
                Text = "pause"
            };

            var BaseFont = Content.Load<SpriteFont>("fonts/Hud");

    
            EnterShopButton.Font = BaseFont;
            PauseButton.Font = BaseFont;
            Player.Font = BaseFont;
            CurrentEnemy.Font = BaseFont;
            

            
            EnterShopButton.Texture = Content.Load<Texture2D>("controls/button");
            PauseButton.Texture = Content.Load<Texture2D>("controls/button");
            Player.Texture = Content.Load<Texture2D>("player");
            CurrentEnemy.Texture = Content.Load<Texture2D>("enemies/ptichka");
            CurrentEnemy.ChargeBarTexture = Content.Load<Texture2D>("enemies/mobbarsheet");

            foreach (var item in Player.PlayerArsenal.Items)
            {
                item.Texture = Content.Load<Texture2D>($"items/{item.TextureName}");
                item.ChargeBarTexture = Content.Load<Texture2D>($"items/barsheet");
                item.Font = BaseFont;
            }
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
            EnterShopButton.Update(gameTime, game, EnterShop);
            PauseButton.Update(gameTime, game, PauseUnpauseGame);
        }

        void EnterShop()
        { 
            Game.ChangeState(Game.shopState); 
        }
        void PauseUnpauseGame() => IsPaused = !IsPaused;
    }
}
