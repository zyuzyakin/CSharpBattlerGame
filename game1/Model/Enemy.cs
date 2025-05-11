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
        adware, spyware, miner
    }
    public class Enemy : GameObject
    {   
        public EnemyType EnemyType { get; set; }
        public int HealthPoints { get; set; }
        public bool IsDefeated { get; set; }

        public int MoneyReward { get; set; }
        public int Damage { get; set; }
        public string Text { get; set; }
        public int Charge { get; set; }
        public int ChargePerPeriod { get; set; }
        public int TotalElapsed { get; set; } // сколько времени прошло
        public int Period { get; set; } // частота обновления в миллисекундах
        public int AtackIteration { get; set; }

        public Enemy(EnemyType type)
        {
            Box = new Rectangle(70 * k, 30 * k, 50 * k, 50 * k);
            Text = "";
            ChargePerPeriod = 1;
            Period = 10;
            EnemyType = type;

            switch (EnemyType)
            {
                case EnemyType.adware:
                    MoneyReward = 10;
                    HealthPoints = 150;
                    Damage = 1;
                    break;
                case EnemyType.spyware:
                    MoneyReward = 20;
                    HealthPoints = 250;
                    Damage = 2;
                    break;
                case EnemyType.miner:
                    MoneyReward = 20;
                    HealthPoints = 350;
                    Damage = 3;
                    break;
            }
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

                game.gameState.BackToMapButton.IsEnabled = true;

                game.gameState.PlayerArsenal.RefreshItems();

                if (EnemyType == EnemyType.miner)
                {
                    game.gameState.RestartGameButton.Text = "ВЫ ВЫИГРАЛИ!\n\n\nНОВАЯ ИГРА!";
                    game.gameState.RestartGameButton.IsEnabled = true;
                    game.gameState.BackToMapButton.IsEnabled = false;
                }
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
                    AtackPlayer(game);
                    AtackIteration++;
                }
            }
        }
        public void AtackPlayer(Game1 game)
        {
            game.gameState.Player.ShieldPoints -= Damage;
            Damage += AtackIteration / 10;
            if (game.gameState.Player.ShieldPoints < 0)
                game.gameState.Player.HealthPoints += game.gameState.Player.ShieldPoints;

            if (game.gameState.Player.ShieldPoints < 0) 
                game.gameState.Player.ShieldPoints = 0;
        }

    }
}
