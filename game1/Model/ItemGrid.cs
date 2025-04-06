
using game1.Model.ItemTypes;
using game1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System.Collections.Generic;

namespace game1.Model
{
    public class ItemGrid : GameObject
    {
        public List<Item> Items { get; set; }
        public ItemGrid()
        {
            Box = new Rectangle(500, 800, 10000, 400);
            Items = new List<Item>();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            var distance = 10;
            var itemWidth = 300;
            var itemHeight = 300;

            for (var i = 0; i < Items.Count; i++)
            {
                Items[i].Box = new Rectangle(Box.X + i * (itemWidth + distance), Box.Y,
                    itemWidth, itemHeight);
                Items[i].Draw(spriteBatch);
            }
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
        }
    }
}
