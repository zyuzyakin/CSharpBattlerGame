using game1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace game1.Model
{
    public class Money : GameObject
    {
        public int MoneyValue { get; set; } = 20;
        public string Text { get; set; }

        public Money()
        {
            Text = $"ДЕНЬГИ:{MoneyValue}!";
        }
        
        public override void Update(GameTime gameTime, BirdGame game)
        {
            Text = $"ДЕНЬГИ:{MoneyValue}!";
        }
    }
}
