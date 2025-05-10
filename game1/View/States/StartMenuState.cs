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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace game1.View.States
{
    public class StartMenuState : State
    {
        private Texture2D Logo;
        public Button PlayButton { get; set; }
        public Button ExitButton { get; set; }

        public StartMenuState(Game1 game, ContentManager content, GraphicsDevice graphicsDevice) : base(game, content, graphicsDevice)
        {
            Background = content.Load<Texture2D>("backgrounds/bgshop");
            Logo = content.Load<Texture2D>("logo");

            PlayButton = new Button(
                new Rectangle(10 * k, 100 * k, 50 * k, 15 * k),
                "НАЧАТЬ ИГРУ!",
                Button.StartGame,
                true);

            ExitButton = new Button(
                new Rectangle(10 * k, 120 * k, 50 * k, 15 * k),
                "ВЫХОД!",
                Button.ExitGame,
                true);


            PlayButton.LoadContent(content);
            ExitButton.LoadContent(content);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(Background, new Rectangle(0, 0, 200 * k, 150 * k), Color.White);
            spriteBatch.Draw(Logo, new Rectangle(10 * k, 30*k, 150 * k, 50 * k), Color.White);
            
            PlayButton.Draw(spriteBatch);
            ExitButton.Draw(spriteBatch);
           
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            PlayButton.Update(gameTime, game);
            ExitButton.Update(gameTime, game);
        }
    }
}
