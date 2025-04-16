using game1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System.Collections.Generic;

namespace game1.Model
{
    public class Enemy : GameObject
    {
        public int MaxHealthPoints { get; set; }
        public int HealthPoints { get; set; }
        public bool IsDefeated { get; set; }

        public int Damage { get; set; }
        public SpriteFont Font { get; set; }

        public string Text { get; set; }
        public int Charge { get; set; }
        public int ChargePerPeriod { get; set; }

        public Texture2D ChargeBarTexture { get; set; }
        public int currentTime { get; set; } = 0; // сколько времени прошло
        public int period { get; set; } = 50; // частота обновления в миллисекундах

        public Enemy()
        {
            MaxHealthPoints = 30;
            HealthPoints = 30;
            Damage = 5;
            Text = "";
            ChargePerPeriod = 1;

            Position = new Vector2(800, 80);
            Box = new Rectangle(800, 80, 400, 400);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!IsDefeated)
            {
                spriteBatch.Draw(Texture, Box, Color);

                string hpDisplay = $"HP:{HealthPoints}/{MaxHealthPoints}";

                spriteBatch.DrawString(Font, hpDisplay, new Vector2(Box.X, Box.Y + Box.Height)
                    + new Vector2(0.0f, 0.0f), Color.White);

                spriteBatch.DrawString(Font, Damage.ToString(), new Vector2(Box.X + Box.Width, Box.Y + Box.Height)
                    + new Vector2(0.0f, 0.0f), Color.Red);

                DrawBarFrame(spriteBatch, Charge / 5);

                
            }
        }

        public void DrawBarFrame(SpriteBatch spriteBatch, int frame)
        {
            int FrameWidth = ChargeBarTexture.Width / 20;
            Vector2 position = new Vector2(Box.X + Box.Width + 20, Box.Y + 340);
            Vector2 scale = new Vector2(1.5f, 1);

            Rectangle sourcerect = new Rectangle(FrameWidth * frame, 0,
                FrameWidth, ChargeBarTexture.Height);

            spriteBatch.Draw(ChargeBarTexture, position, sourcerect, Color.White,
                0f, new Vector2(0, 0), scale, SpriteEffects.None, 0f);
        }

        public override void Update(GameTime gameTime, Game1 game)
        {   
            if(HealthPoints <= 0)
            {
                IsDefeated = true;
                game.gameState.IsPaused = true;
                game.gameState.PauseButton.IsEnabled = false;
            }
            if (!IsDefeated)
            {
                if (!game.gameState.IsPaused)
                {
                    currentTime += gameTime.ElapsedGameTime.Milliseconds;
                    if (currentTime > period)
                    {
                        currentTime -= period;
                        Charge += ChargePerPeriod;
                        Text = Charge.ToString();
                        if (Charge >= 100)
                        {
                            Charge = 0;
                            AtackPlayer(gameTime, game);
                        }
                    }
                }
            }
        }
        public void AtackPlayer(GameTime gameTime, Game1 game)
        {
            
            game.gameState.Player.ShieldPoints -= Damage;

            if (game.gameState.Player.ShieldPoints < 0)
                game.gameState.Player.HealthPoints += game.gameState.Player.ShieldPoints;

            if (game.gameState.Player.ShieldPoints < 0) 
                game.gameState.Player.ShieldPoints = 0;
        }

        public override void LoadContent(ContentManager content)
        {
            Texture = content.Load<Texture2D>("enemies/ptichka");
            Font = content.Load<SpriteFont>("fonts/Hud");
            ChargeBarTexture = content.Load<Texture2D>("enemies/mobbarsheet");
        }
    }
}
