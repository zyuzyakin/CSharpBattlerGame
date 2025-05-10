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
        public AnimatedTexture PlayerTexture { get; set; }
        public Player Player { get; private set; }
        public Enemy CurrentEnemy { get; set; }
        public bool IsPaused {get;set;}
        public Button BackToMapButton { get; private set; }
        public Button PauseButton { get; set; }
        public Button RestartGameButton { get; set; }

        public GameState(Game1 game, ContentManager content, GraphicsDevice graphicsDevice) : base(game, content, graphicsDevice)
        {
            Background = content.Load<Texture2D>("backgrounds/bgbattle");
            PlayerTexture = new AnimatedTexture(20, 24, "playerbattlesheet", 
                new Rectangle(10 * k, 80 * k, 40 * k, 40 * k));
            
            Player = new Player();

            RestartGameButton = new Button(
                new Rectangle(70 * k, 90 * k, 70 * k, 40 * k),
                "ВЫ ПРОИГРАЛИ!\n\n\nНОВАЯ ИГРА!",
                Button.StartGame,
                false);

            BackToMapButton = new Button(
                new Rectangle(140 * k, 30 * k, 50 * k, 15 * k),
                "НАЗАД!",
                Button.BackToMap,
                false);

            PauseButton = new Button(
                new Rectangle(140 * k, 10 * k, 50 * k, 15 * k),
                "ПАУЗА!",
                Button.PauseUnpauseGame,
                true
            );

            StateElements.Add(Player);
            StateElements.Add(Player.PlayerArsenal);
            StateElements.Add(BackToMapButton);
            StateElements.Add(PauseButton);
            StateElements.Add(RestartGameButton);
            StateElements.Add(PlayerTexture);

            foreach (var e in StateElements)
            {
                e.LoadContent(content);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(Background, new Rectangle(0, 0, 200 * k, 150 * k), Color.White);
            CurrentEnemy.Draw(spriteBatch);

            foreach (var e in StateElements)
                e.Draw(spriteBatch);

            spriteBatch.End();
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            CurrentEnemy.Update(gameTime, game);

            foreach (var e in StateElements)
                e.Update(gameTime, game);
        }
    }
}
