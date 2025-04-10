using game1.Model.Buttons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace game1.View.States
{
    public class StartMenuState : State
    {
        public Button playButton { get; set; }
        public Button exitButton;


        public StartMenuState(Game1 game, ContentManager content, GraphicsDevice graphicsDevice) : base(game, content, graphicsDevice)
        {
            playButton = new Button()
            {
                Box = new Rectangle(100, 600, 150, 150),
                Text = "Play",
            };
            exitButton = new Button()
            {
                Box = new Rectangle(100, 800, 150, 150),
                Text = "Exit",
            };

            playButton.Texture = content.Load<Texture2D>("controls/button");
            playButton.Font = content.Load<SpriteFont>("fonts/Hud");

            exitButton.Texture = content.Load<Texture2D>("controls/button");
            exitButton.Font = content.Load<SpriteFont>("fonts/Hud");
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Game.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            playButton.Draw(spriteBatch);
            exitButton.Draw(spriteBatch);
           
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            playButton.Update(gameTime, game, StartGame);
            exitButton.Update(gameTime, game, ExitGame);
        }

        void StartGame() => Game.ChangeState(Game.shopState);
        void ExitGame() => Game.Exit();


    }
}
