using game1.Model;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;

namespace game1.View
{
    public class ItemView : Item
    {
        public SpriteFont Font { get; set; }
        public Texture2D ChargeBarTexture { get; set; }

        public ItemView() : base()
        {
        }
        public ItemView(ItemView item) : base(item)
        {
            Texture = item.Texture;
            ChargeBarTexture = item.ChargeBarTexture;
            Font = item.Font;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!IsEnabled) return;

            DrawFrame(spriteBatch, Charge / 5);

            DrawBarFrame(spriteBatch, Charge / 5);

            spriteBatch.DrawString(Font, $"{ItemType}/{Level}",
                new Vector2(Box.X, Box.Y + Box.Height + (int)(Box.Height * 0.25)), Color.White,
                0f, new Vector2(0, 0), 0.4f * tk, SpriteEffects.None, 0);

            if (IsEnabled && IsAtShop)
            {
                spriteBatch.DrawString(Font, Cost.ToString(),
                new Vector2(Box.X, Box.Y + k), Color.Yellow,
                0f, new Vector2(0, 0), tk, SpriteEffects.None, 0f);
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

            spriteBatch.Draw(ChargeBarTexture, new Rectangle(Box.X, Box.Y + (int)(Box.Height * 0.75), Box.Width, (int)(Box.Height * 0.75)),
                sourcerect, Color.White);
        }

        public override void LoadContent(ContentManager content)
        {
            Texture = content.Load<Texture2D>($"items/{ItemType}sheet");
            ChargeBarTexture = content.Load<Texture2D>($"items/barsheet");
            Font = content.Load<SpriteFont>("fonts/Hud");
        }
    }
}
