using game1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace game1.View
{
    public class EnemyView : Enemy
    {
        public EnemyView(EnemyType type) : base(type)
        {

        }

        public SpriteFont Font { get; set; }

        public Texture2D ChargeBarTexture { get; set; }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!IsDefeated)
            {
                DrawFrame(spriteBatch, Charge / 5);

                DrawBarFrame(spriteBatch, Charge / 5);
                string hpDisplay = $"HP:{HealthPoints}!";

                spriteBatch.DrawString(Font, hpDisplay,
                    new Vector2(Box.X, Box.Y + Box.Height), Color.White,
                    0f, new Vector2(0, 0), tk, SpriteEffects.None, 0f);

                spriteBatch.DrawString(Font, Damage.ToString(),
                    new Vector2(Box.X + Box.Width, Box.Y + Box.Height), Color.Red,
                    0f, new Vector2(0, 0), tk, SpriteEffects.None, 0f);
            }
        }
        public void DrawFrame(SpriteBatch spriteBatch, int frame)
        {
            int FrameWidth = Texture.Width / 10;
            int FrameHeight = Texture.Height / 2;


            Rectangle sourcerect = new Rectangle(FrameWidth * (frame % 10), FrameHeight * (frame / 10),
                FrameWidth, FrameHeight);

            spriteBatch.Draw(Texture, Box, sourcerect, Color);
        }
        public void DrawBarFrame(SpriteBatch spriteBatch, int frame)
        {
            int FrameWidth = ChargeBarTexture.Width / 20;

            Rectangle sourcerect = new Rectangle(FrameWidth * frame, 0,
                FrameWidth, ChargeBarTexture.Height);

            spriteBatch.Draw(ChargeBarTexture,
                new Rectangle(Box.X + Box.Width + 2 * k, Box.Y + 34 * k, Box.Width, 30 * k),
                sourcerect, Color.White);
        }

        public override void LoadContent(ContentManager content)
        {
            Texture = content.Load<Texture2D>($"enemies/{EnemyType}sheet");
            Font = content.Load<SpriteFont>("fonts/Hud");
            ChargeBarTexture = content.Load<Texture2D>("enemies/mobbarsheet");
        }
    }
}
