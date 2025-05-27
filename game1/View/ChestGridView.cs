using game1.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace game1.View;

public class ChestGridView : ChestGrid
{
    public override void Draw(SpriteBatch spriteBatch)
    {
        var distance = k;
        var itemWidth = 30 * k;
        var itemHeight = 30 * k;

        for (var i = 0; i < Items.Count; i++)
        {
            Items[i].Box = new Rectangle(Box.X + i % 4 * (itemWidth + distance),
                Box.Y + (i / 4) * (itemHeight + distance * 10),
                itemWidth, itemHeight);

            Items[i].Draw(spriteBatch);
        }
    }
    public override void LoadContent(ContentManager content)
    {
        foreach (var item in Items)
        {
            item.LoadContent(content);
        }
    }
}
