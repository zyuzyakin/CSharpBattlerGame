using game1.Model;
using game1.View;
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

namespace game1.States
{
    public class StartMenuState : State
    {
        private Texture2D Logo;
        public ButtonView PlayButton { get; set; }
        public ButtonView ExitButton { get; set; }

        public StartMenuState(BirdGame game, ContentManager content, GraphicsDevice graphicsDevice) : base(game, content, graphicsDevice)
        {
            Background = content.Load<Texture2D>("backgrounds/bgshop");
            Logo = content.Load<Texture2D>("logo");

            PlayButton = new ButtonView()
            {
                Box = new Rectangle(10 * k, 100 * k, 50 * k, 15 * k),
                Text = "НАЧАТЬ ИГРУ!",
                OnClick = Button.StartGame
            };
            ExitButton = new ButtonView()
            {
                Box = new Rectangle(10 * k, 120 * k, 50 * k, 15 * k),
                Text = "ВЫХОД!",
                OnClick = Button.ExitGame
            };

            PlayButton.LoadContent(content);
            ExitButton.LoadContent(content);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(Background, new Rectangle(0, 0, 200 * k, 150 * k), Color.White);

            spriteBatch.Draw(Logo, new Rectangle(10*k, 30*k, 150 * k, 50 * k), Color.White);

            PlayButton.Draw(spriteBatch);
            ExitButton.Draw(spriteBatch);
           
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime, BirdGame game)
        {
            PlayButton.Update(gameTime, game);
            ExitButton.Update(gameTime, game);
        }
    }
}
