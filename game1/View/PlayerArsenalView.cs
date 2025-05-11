using game1.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace game1.View
{
    public class PlayerArsenalView : PlayerArsenal
    {

        public override void Draw(SpriteBatch spriteBatch)
        {
            var distance = k;
            var itemWidth = 20 * k;
            var itemHeight = 20 * k;

            for (var i = 0; i < Items.Count; i++)
            {
                Items[i].Box = new Rectangle(Box.X + i % (MaxSize / 2) * (itemWidth + distance),
                    Box.Y + (i / (MaxSize / 2)) * (itemHeight + 6 * distance),
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
}
