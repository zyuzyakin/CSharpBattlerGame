using game1.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace game1.View;

public class ButtonView : Button
{
    public SpriteFont Font { get; set; }

    public override void Draw(SpriteBatch spriteBatch)
    {
        if (IsEnabled)
        {
            spriteBatch.Draw(Texture, Box, Color);
            spriteBatch.DrawString(Font, Text, new Vector2(Box.X + k, Box.Y + k), Color,
                0f, new Vector2(0, 0), tk, SpriteEffects.None, 0f);
        }
    }

    public override void LoadContent(ContentManager content)
    {
        Texture = content.Load<Texture2D>("controls/longbutton");
        Font = content.Load<SpriteFont>("fonts/Hud");
    }
}
