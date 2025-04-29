using game1.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
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
        public Button RestartGameButton { get; set; }

        public GameState(Game1 game, ContentManager content, GraphicsDevice graphicsDevice) : base(game, content, graphicsDevice)
        {
            StateElements = new List<GameObject>();
            Background = content.Load<Texture2D>("backgrounds/bgbattle");

            Player = new Player();


            RestartGameButton = new Button()
            {
                Box = new Rectangle(20 * k, 20 * k, 70 * k, 40 * k),
                Text = "ВЫ ПРОИГРАЛИ\n\n\nНОВАЯ ИГРА",
                IsEnabled = false,
                OnClick = Button.StartGame
            };

            BackToMapButton = new Button()
            {
                Box = new Rectangle(170 * k, 30 * k, 20 * k, 15 * k),
                Text = "НАЗАД К\nКАРТЕ",
                IsEnabled = false,
                OnClick = Button.BackToMap

            };

            PauseButton = new Button()
            {
                Box = new Rectangle(170 * k, 10 * k, 15 * k, 15 * k),
                Text = "ПАУЗА",
                OnClick = Button.PauseUnpauseGame
            };

            StateElements.Add(Player);
            StateElements.Add(Player.PlayerArsenal);
            StateElements.Add(BackToMapButton);
            StateElements.Add(PauseButton);
            StateElements.Add(RestartGameButton);
            //StateElements.Add(game.shopState.Money);

            foreach (var e in StateElements)
            {
                e.LoadContent(content);
            }
            //Player.LoadContent(content);
            //BackToMapButton.LoadContent(content);
            //PauseButton.LoadContent(content);
            //Player.PlayerArsenal.LoadContent(content);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(Background, new Rectangle(0, 0, 200 * k, 150 * k), Color.White);

            foreach (var e in StateElements)
            {
                e.Draw(spriteBatch);
            }

            CurrentEnemy.Draw(spriteBatch);

            spriteBatch.End();
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            CurrentEnemy.Update(gameTime, game);
            foreach (var e in StateElements)
            {
                e.Update(gameTime, game);
            }
        }
    }
}
