using game1.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace game1.View;

public class PlayerView : Player
{
    public SpriteFont Font { get; set; }

    public override void Draw(SpriteBatch spriteBatch)
    {
        string hpDisplay = $"ЗДОРОВЬЕ:\n{HealthPoints}/{MaxHealthPoints}!";
        string shieldDisplay = $"ЗАЩИТА:{ShieldPoints}!";

        spriteBatch.DrawString(Font, hpDisplay,
            new Vector2(Box.X, Box.Y + Box.Height + k), Color.White,
            0f, new Vector2(0, 0), tk, SpriteEffects.None, 0f);
        spriteBatch.DrawString(Font, shieldDisplay,
            new Vector2(Box.X, Box.Y + Box.Height + 15 * k), Color.White,
            0f, new Vector2(0, 0), tk, SpriteEffects.None, 0f);
    }

    public override void LoadContent(ContentManager content)
    {
        Font = content.Load<SpriteFont>("fonts/Hud");
    }
}
