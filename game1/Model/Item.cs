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
            ChargePerPeriod = 5;
        }

        public Item(Item item)
        {
            Texture = item.Texture;
            ItemType = item.ItemType;
            Period = 50;
            Level = item.Level;
            IsEnabled = true;
            IsVisible = true;
            IsAtShop = false;
            ChargePerPeriod = item.ChargePerPeriod;
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
    }
}