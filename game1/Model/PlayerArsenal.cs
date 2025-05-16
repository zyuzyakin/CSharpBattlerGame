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
        public List<ItemView> Items { get; set; }
        public int MaxSize { get; set; }

        public Dictionary<ItemType,int> ItemsCount { get; set; }
        public PlayerArsenal()
        {
            Box = new Rectangle(55 * k, 90 * k, 100 * k, 40 * k);
            Items = new List<ItemView>();
            ItemsCount = new Dictionary<ItemType, int>();
            MaxSize = 8;

            foreach (var elem in Enum.GetValues(typeof(ItemType)))
            {
                ItemsCount.Add((ItemType)elem, 0);
            }
        }
        public bool AddItem(ItemView item, Money money)
        {
            if (money.MoneyValue >= item.Cost && Items.Count < MaxSize)
            {
                money.MoneyValue -= item.Cost;
                Items.Add(new ItemView(item));
                return true;
            }
            return false;
        }
        
        public void RefreshItems()
        {
            var result = new List<ItemView>();

            foreach (var item in Items)
            {
                result.Add(new ItemView(item));
            }
            Items = result;
        }
        public void CombineItems(BirdGame game)
        {
            var result = new List<ItemView>();
            
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
                        result.Add(new ItemView() { ItemType = elem.Key, 
                            Level = level, IsAtShop = false });
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

        public override void Update(GameTime gameTime, BirdGame game)
        {
            foreach (var item in Items)
            {
                item.Update(gameTime, game);
            }
        }
    }
}
