using game1.Model;
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
        public PlayButton playButton;
        public ExitButton exitButton;


        public StartMenuState(Game1 game, ContentManager content, GraphicsDevice graphicsDevice) : base(game, content, graphicsDevice)
        {
            playButton = new PlayButton();
            exitButton = new ExitButton();

            playButton.Texture = content.Load<Texture2D>("controls/button");
            playButton.Font = content.Load<SpriteFont>("fonts/Hud");

            exitButton.Texture = content.Load<Texture2D>("controls/button");
            exitButton.Font = content.Load<SpriteFont>("fonts/Hud");
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, Matrix globalTransformation)
        {
            Game.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, globalTransformation);

            playButton.Draw(spriteBatch);
            exitButton.Draw(spriteBatch);
           
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            playButton.Update(gameTime, Game);
            exitButton.Update(gameTime, Game);
        }
    }
}
