using game1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;

namespace game1.Model
{   public enum EnemyType
    {
        normal, hard, boss
    }
    public class Enemy : GameObject
    {   
        public EnemyType EnemyType { get; set; }
        public int HealthPoints { get; set; }
        public bool IsDefeated { get; set; }

        public int MoneyReward { get; set; }
        public int Damage { get; set; }
        public SpriteFont Font { get; set; }

        public string Text { get; set; }
        public int Charge { get; set; }
        public int ChargePerPeriod { get; set; }

        public Texture2D ChargeBarTexture { get; set; }
        public int TotalElapsed { get; set; } // сколько времени прошло
        public int Period { get; set; } // частота обновления в миллисекундах

        public Enemy(EnemyType type)
        {
            Box = new Rectangle(80 * k, 8 * k, 40 * k, 40 * k);
            Text = "";
            ChargePerPeriod = 1;
            Period = 50;
            var rnd = new Random();
            EnemyType = type;
            switch (EnemyType)
            {
                case EnemyType.normal:
                    MoneyReward = 10;
                    HealthPoints = 150;
                    Damage = 3;
                    break;
                case EnemyType.hard:
                    MoneyReward = 20;
                    HealthPoints = 250;
                    Damage = 4;
                    break;
                case EnemyType.boss:
                    MoneyReward = 9999;
                    HealthPoints = 350;
                    Damage = 5;
                    break;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!IsDefeated)
            {
                spriteBatch.Draw(Texture, Box, Color);

                string hpDisplay = $"HP:{HealthPoints}";

                spriteBatch.DrawString(Font, hpDisplay, 
                    new Vector2(Box.X, Box.Y + Box.Height), Color.White,
                    0f, new Vector2(0, 0), tk, SpriteEffects.None, 0f);

                spriteBatch.DrawString(Font, Damage.ToString(), 
                    new Vector2(Box.X + Box.Width, Box.Y + Box.Height), Color.Red,
                    0f, new Vector2(0, 0), tk, SpriteEffects.None, 0f);

                DrawBarFrame(spriteBatch, Charge / 5);
            }
        }

        public void DrawBarFrame(SpriteBatch spriteBatch, int frame)
        {
            int FrameWidth = ChargeBarTexture.Width / 20;
            Vector2 position = new Vector2(Box.X + Box.Width + 2 * k, Box.Y + 34 * k);
            

            Rectangle sourcerect = new Rectangle(FrameWidth * frame, 0,
                FrameWidth, ChargeBarTexture.Height);

            spriteBatch.Draw(ChargeBarTexture, 
                new Rectangle(Box.X + Box.Width + 2 * k, Box.Y + 34 * k, Box.Width, 20 * k), 
                sourcerect, Color.White);
        }

        public override void Update(GameTime gameTime, Game1 game)
        {   
            if(HealthPoints <= 0)
            {
                if (!IsDefeated)
                    game.shopState.Money.MoneyValue += MoneyReward;

                IsDefeated = true;
                
                game.gameState.IsPaused = true;
                game.gameState.PauseButton.IsEnabled = false;
            }

            if (IsDefeated) return;
            if (game.gameState.IsPaused) return;
            
            TotalElapsed += gameTime.ElapsedGameTime.Milliseconds;
            if (TotalElapsed > Period)
            {
                TotalElapsed -= Period;
                Charge += ChargePerPeriod;
                Text = Charge.ToString();
                if (Charge >= 100)
                {
                    Charge = 0;
                    AtackPlayer(gameTime, game);
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
