using game1.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace game1.View.States
{
    public class GameState : State
    {   
        
        public Player Player { get; private set; }
        public Enemy CurrentEnemy { get; set; }
        public bool IsPaused {get;set;}
        public Button BackToMapButton { get; private set; }
        public Button PauseButton { get; set; }



        public GameState(Game1 game, ContentManager content, GraphicsDevice graphicsDevice) : base(game, content, graphicsDevice)
        {
            Background = content.Load<Texture2D>("backgrounds/bgbattle");
            Player = new Player();
            
            

            BackToMapButton = new Button()
            {
                Box = new Rectangle(180 * k, 120 * k, 15 * k, 15 * k),
                Text = "назад",
                OnClick = Button.BackToMap

            };

            PauseButton = new Button()
            {
                Box = new Rectangle(160 * k, 30 * k, 15 * k, 15 * k),
                Text = "pause",
                OnClick = Button.PauseUnpauseGame
            };


            

            Player.LoadContent(content);
            BackToMapButton.LoadContent(content);
            PauseButton.LoadContent(content);
            Player.PlayerArsenal.LoadContent(content);

            
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Game.GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            spriteBatch.Draw(Background, new Rectangle(0, 0, 200 * k, 150 * k), Color.White);

            CurrentEnemy.Draw(spriteBatch);
            Player.Draw(spriteBatch);
            Player.PlayerArsenal.Draw(spriteBatch);
            BackToMapButton.Draw(spriteBatch);
            PauseButton.Draw(spriteBatch);

            Game.shopState.Money.Draw(spriteBatch);
            

            spriteBatch.End();
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            Game.shopState.Money.Update(gameTime, game);
            Player.Update(gameTime, game);
            CurrentEnemy.Update(gameTime, game);
            BackToMapButton.Update(gameTime, game);
            PauseButton.Update(gameTime, game);
        }
    }
}
