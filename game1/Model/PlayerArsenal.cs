using game1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;


namespace game1.Model
{
    public class PlayerArsenal : GameObject
    {   
        public List<Item> Items { get; set; }
        public int MaxSize { get; set; }

        public Dictionary<ItemType,int> ItemsCount { get; set; }
        public PlayerArsenal()
        {
            Box = new Rectangle(50 * k, 90 * k, 100 * k, 40 * k);
            Items = new List<Item>();
            ItemsCount = new Dictionary<ItemType, int>();
            MaxSize = 8;

            foreach (var elem in Enum.GetValues(typeof(ItemType)))
            {
                ItemsCount.Add((ItemType)elem, 0);
            }
        }

        public void CombineItems(Game1 game)
        {
            var result = new List<Item>();
            
            foreach (var item in Items)
            {
                ItemsCount[item.ItemType] += (int)Math.Pow(2, item.Level-1);
            }

            foreach (var elem in ItemsCount)
            {
                var ostatok = elem.Value;

                for (int level = 4; level >= 1; level--)
                {
                    for (var a = 0; a < ostatok / (int)Math.Pow(2, level - 1); a++)
                    {
                        result.Add(new Item() { ItemType = elem.Key, 
                            Level = level, IsItOwned = true });
                    }
                    ostatok %= (int)Math.Pow(2, level - 1);
                }
            }

            foreach (var item in result)
            {
                item.LoadContent(game.Content);
            }

            Items = result;

            foreach (var elem in Enum.GetValues(typeof(ItemType)))
            {
                ItemsCount[(ItemType)elem] = 0;
            }
        }

        //TODO разделить на 2 метода
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
