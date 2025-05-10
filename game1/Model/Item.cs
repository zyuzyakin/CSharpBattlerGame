using game1.Controller;
using game1.View;
using game1.View.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace game1.Model
{
    public enum ItemType
    {   
        //Защитные
        shield, healpotion, ice,
        //Для атаки
        sword, hammer, bow, bomb
    }
    public class Item : GameObject
    {
        private SpriteFont font;
        public Texture2D ChargeBarTexture { get; set; }

        public int Charge { get; set; } // процент заряда
        public int ChargePerPeriod { get; set; } // заряд за 1 интервал

        public ItemType ItemType { get; set; }

        
        public int Level { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsVisible { get; set; }


        public bool IsAtShop { get; set; }

        public int Cost { get; set; } 
        public int TotalElapsed { get; set; } // сколько времени прошло
        public int Period { get; set; } // период обновления в миллисекундах
        public int ItemIteration { get; set; }

        public Item()
        {
            IsEnabled = true;
            IsVisible = true;
            Level = 1;
            Period = 50;
            ChargePerPeriod = 2;
        }

        public Item(Item item)
        {
            Texture = item.Texture;
            ChargeBarTexture = item.ChargeBarTexture;
            ItemType = item.ItemType;
            Period = 50;
            Level = item.Level;
            IsEnabled = true;
            IsVisible = true;
            IsAtShop = false;
            font = item.font;
            ChargePerPeriod = item.ChargePerPeriod;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!IsEnabled) return;

            DrawFrame(spriteBatch, Charge / 5);

            DrawBarFrame(spriteBatch, Charge / 5);

            spriteBatch.DrawString(font, $"{ItemType}/{Level}",
                new Vector2(Box.X, Box.Y + Box.Height + (int)(Box.Height * 0.25)), Color.White, 
                0f, new Vector2(0,0), 0.4f * tk, SpriteEffects.None, 0);

            if (IsEnabled && IsAtShop)
            {
                spriteBatch.DrawString(font, Cost.ToString(),
                new Vector2(Box.X, Box.Y + k), Color.Yellow,
                0f, new Vector2(0, 0), tk, SpriteEffects.None, 0f);
            }
        }
        public void DrawFrame(SpriteBatch spriteBatch, int frame)
        {
            var FrameWidth = Texture.Width / 20;

            Rectangle sourcerect = new Rectangle(FrameWidth * frame, 0,
                FrameWidth, Texture.Height);

            spriteBatch.Draw(Texture, Box, sourcerect, Color);
        }
        public void DrawBarFrame(SpriteBatch spriteBatch, int frame)
        {
            var FrameWidth = ChargeBarTexture.Width / 20;

            Rectangle sourcerect = new Rectangle(FrameWidth * frame, 0,
                FrameWidth, ChargeBarTexture.Height);

            spriteBatch.Draw(ChargeBarTexture, new Rectangle(Box.X, Box.Y + (int)(Box.Height * 0.75), Box.Width, (int)(Box.Height * 0.75)), 
                sourcerect, Color.White);
        }
        public override void Update(GameTime gameTime, Game1 game)
        {
            if (game.gameState.IsPaused) return;

            if (!IsEnabled) return;
            
            TotalElapsed += gameTime.ElapsedGameTime.Milliseconds;

            if (TotalElapsed >= Period)
            {
                TotalElapsed -= Period;
                Charge += ChargePerPeriod;
                        
                if (Charge >= 100)
                {
                    Charge = 0;
                    Act(gameTime, game);
                    ItemIteration++;
                }
            }
        }
        public void Act(GameTime gameTime, Game1 game)
        {
            switch (ItemType)
            {
                case ItemType.sword:
                    SwordAct(game);
                    break;
                case ItemType.shield:
                    ShieldAct(game);
                    break;
                case ItemType.bomb:
                    BombAct(game);
                    break;
                case ItemType.ice:
                    IceAct(game);
                    break;
                case ItemType.healpotion:
                    HealPotionAct(game);
                    break;
                case ItemType.bow:
                    BowAct(game);
                    break;
                case ItemType.hammer:
                    HammerAct(game);
                    break;
            }
            
        }
        public void SwordAct(Game1 game) => 
            game.gameState.CurrentEnemy.HealthPoints -= 5 * Level;
        public void ShieldAct(Game1 game) =>
            game.gameState.Player.ShieldPoints += 1 * Level;
        public void BombAct(Game1 game)
        {
            game.gameState.CurrentEnemy.HealthPoints -= 30 * Level;
            IsEnabled = false;
        }
        public void IceAct(Game1 game)
        {
            game.gameState.CurrentEnemy.Charge
                 = Math.Max(game.gameState.CurrentEnemy.Charge - 5 * Level, 0);
        }
        public void HealPotionAct(Game1 game)
        {
            game.gameState.Player.Heal(1 * Level);
        }
        public void BowAct(Game1 game)
        {   
            game.gameState.CurrentEnemy.HealthPoints -= 1 * Level;
            Period = Math.Max(10, Period - ItemIteration * Level);
        }
        public void HammerAct(Game1 game)
        {
            var rnd = new Random();
            game.gameState.CurrentEnemy.HealthPoints -= (1 + rnd.Next(0, 7)) * Level;
        }
        public override void LoadContent(ContentManager content)
        {
            Texture = content.Load<Texture2D>($"items/{ItemType}sheet");
            ChargeBarTexture = content.Load<Texture2D>($"items/barsheet");
            font = content.Load<SpriteFont>("fonts/Hud");
        }
    }
}