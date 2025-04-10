using game1.Controller;
using game1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1.Model.Buttons
{
    public class Button : GameObject
    {
        public bool IsEnabled { get; set; } 
        public SpriteFont Font { get; set; }
        public string Text { get; set; }
        public Button()
        {
            IsEnabled = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsEnabled)
            {
                spriteBatch.Draw(Texture, Box, Color);
                spriteBatch.DrawString(Font, Text, new Vector2(Box.X, Box.Y), Color);
            }
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
        }

        public void Update(GameTime gameTime, Game1 game, Action buttonClicked)
        {
            if (IsEnabled)
            {
                if (InputManager.Hover(Box))
                {
                    Color = Color.Green;
                    if (InputManager.LeftClicked)
                    {
                        buttonClicked();
                    }
                }
                else
                {
                    Color = Color.White;
                } 
            }
        }

        
    }
}
