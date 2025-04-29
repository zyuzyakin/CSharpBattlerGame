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
        public int MaxSize { get; set; }
        public PlayerArsenal()
        {
            Box = new Rectangle(50 * k, 90 * k, 100 * k, 40 * k);
            Items = new List<Item>();
            MaxSize = 8;
        }
        public void CombineItems()
        {
            
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            var distance = k;
            var itemWidth = 20 * k;
            var itemHeight = 20 * k;

            for (var i = 0; i < Items.Count; i++)
            {
                Items[i].Box = new Rectangle(Box.X + i % (MaxSize/2) * (itemWidth + distance),
                    Box.Y + (i / (MaxSize / 2)) * (itemHeight + 6 * distance),
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
