using game1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System.Collections.Generic;


namespace game1.Model
{
    public class PlayerArsenal : GameObject
    {   
        public List<Item> Items { get; set; }

        public int ArrowsCount { get; set; }
        public int MaxSize { get; set; }
        public PlayerArsenal()
        {
            Box = new Rectangle(50 * k, 100 * k, 100 * k, 40 * k);
            Items = new List<Item>();
            MaxSize = 16;
        }
        
        public override void Draw(SpriteBatch spriteBatch)
        {
            var distance = k;
            var itemWidth = 15 * k;
            var itemHeight = 15 * k;

            for (var i = 0; i < Items.Count; i++)
            {
                Items[i].Box = new Rectangle(Box.X + i % 8 * (itemWidth + distance),
                    Box.Y + (i / 8) * (itemHeight + distance),
                    itemWidth, itemHeight);
                Items[i].Draw(spriteBatch);
            }
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            foreach (var item in Items)
            {
                item.Update(gameTime, game);
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
