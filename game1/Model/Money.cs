using game1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static game1.Model.Button;
using static System.Net.Mime.MediaTypeNames;

namespace game1.Model
{
    public class Money : GameObject
    {
        public ClickEvent OnClick { get; set; }
        public bool IsEnabled { get; set; }
        private SpriteFont Font;
        public string Text { get; set; }

        public Money()
        { 

        }

        public int MoneyValue { get; set; } = 20;

        public override void Update(GameTime gameTime, Game1 game)
        {
            Text = $"ДЕНЬГИ:{MoneyValue}!";
        }
    }
}
