using game1.Model;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace game1.View;

public class MapElementView : MapElement
{
    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, Box, Color);
    }
    public override void LoadContent(ContentManager content)
    {
        Texture = content.Load<Texture2D>($"mapIcons/{PointType}");
    }
}
