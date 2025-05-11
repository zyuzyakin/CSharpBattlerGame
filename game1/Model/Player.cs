using game1.Controller;
using game1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace game1.Model
{
    public class Player : GameObject
    {
        public int MaxHealthPoints { get; set; }
        public int HealthPoints { get; set; }
        public bool IsDefeated { get; set; }
        public int ShieldPoints { get; set; }

        public Player()
        {
            HealthPoints = 40;
            MaxHealthPoints = 40;
            Box = new Rectangle(8 * k, 70 * k, 48 * k, 48 * k);
        }


        public void Heal(int value)
        {
            HealthPoints += value;
            if (HealthPoints > MaxHealthPoints) 
                HealthPoints = MaxHealthPoints;
        }
        public override void Update(GameTime gameTime, BirdGame game)
        {
            if (HealthPoints <= 0)
            {
                game.gameState.RestartGameButton.IsEnabled = true;
                game.gameState.IsPaused = true;
            }
            
        }

    }
}
