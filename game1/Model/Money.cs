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
    public class Money : Button
    {
        public int MoneyValue { get; set; } = 50;

        public Money()
        {
            Box = new Rectangle(1600, 100, 150, 150);
            Text = $"Money:{MoneyValue}";
        }
        
        public override void Update(GameTime gameTime, Game1 game)
        {
            Text = $"Money:{MoneyValue}";
        }
    }
}
