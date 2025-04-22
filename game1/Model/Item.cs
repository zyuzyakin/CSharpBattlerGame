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
        shield, healpotion, boots, ice,
        //Для атаки
        sword, hammer, bow, arrow, bomb
    }
    public class Item : GameObject
    {

        public SpriteFont Font { get; set; }

        public int Charge { get; set; } // процент заряда

        public Texture2D ChargeBarTexture { get; set; }
        public int ChargePerPeriod { get; set; } // заряд за 1 интервал

        public ItemType ItemType { get; set; }
        public bool IsEnabled { get; set; }

        public bool IsItOwned { get; set; }

        public int Cost { get; set; } 

        public int TotalElapsed { get; set; } = 0; // сколько времени прошло
        public int Period { get; set; } = 50; // период обновления в миллисекундах
        public Item()
        {
            IsEnabled = true;
            ChargePerPeriod = 5;

        }
        public Item(Item item)
        {
            Texture = item.Texture;
            ChargeBarTexture = item.ChargeBarTexture;
            ItemType = item.ItemType;
            
            IsEnabled = true;
            IsItOwned = true;
            Font = item.Font;
            ChargePerPeriod = item.ChargePerPeriod;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            DrawFrame(spriteBatch, Charge / 5);

            DrawBarFrame(spriteBatch, Charge / 5);

            spriteBatch.DrawString(Font, $"{ItemType}",
                new Vector2(Box.X + 100, Box.Y + 250), Color.White, 0f, 
                new Vector2(0,0), 0.4f, SpriteEffects.None, 0);

            if (IsEnabled && !IsItOwned)
            {
                spriteBatch.DrawString(Font, Cost.ToString(),
                new Vector2(Box.X, Box.Y), Color.Yellow);
            }
        }
        public void DrawFrame(SpriteBatch spriteBatch, int frame)
        {
            int FrameWidth = Texture.Width / 20;

            Rectangle sourcerect = new Rectangle(FrameWidth * frame, 0,
                FrameWidth, Texture.Height);

            spriteBatch.Draw(Texture, Box, sourcerect, Color);
        }
        public void DrawBarFrame(SpriteBatch spriteBatch, int frame)
        {
            int FrameWidth = ChargeBarTexture.Width / 20;

            Rectangle sourcerect = new Rectangle(FrameWidth * frame, 0,
                FrameWidth, ChargeBarTexture.Height);

            spriteBatch.Draw(ChargeBarTexture, new Rectangle(Box.X, Box.Y + 220, 300, 200), 
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
                }
            }
        }
        public void Act(GameTime gameTime, Game1 game)
        {
            switch (ItemType)
            {
                case ItemType.sword: 
                    game.gameState.CurrentEnemy.HealthPoints -= 1;
                    break;
                case ItemType.shield:
                    game.gameState.Player.ShieldPoints += 1;
                    break;
                case ItemType.bomb:
                    
                    break;
                case ItemType.ice:
                    
                    break;
                case ItemType.healpotion:
                    game.gameState.Player.Heal(1);
                    break;
            }
            
        }

        public override void LoadContent(ContentManager content)
        {
            Texture = content.Load<Texture2D>($"items/{ItemType}sheet");
            ChargeBarTexture = content.Load<Texture2D>($"items/barsheet");
            Font = content.Load<SpriteFont>("fonts/Hud");
        }
    }
}