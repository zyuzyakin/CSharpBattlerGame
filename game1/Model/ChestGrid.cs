using game1.Controller;
using game1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;
using System.Reflection.Metadata;

namespace game1.Model
{
    public class ChestGrid : GameObject
    {
        public List<Item> Items { get; set; }
        public ChestGrid()
        {
            Box = new Rectangle(40 * k, 40 * k, 1000 * k, 30 * k);
            RefreshShopGrid();
        }
        public void RefreshShopGrid()
        {
            Items = new List<Item>()
            {
                new Item(){ItemType = ItemType.sword},
                new Item(){ItemType = ItemType.shield},
                new Item(){ItemType = ItemType.bomb},
            };
        }

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

        public override void Update(GameTime gameTime, Game1 game)
        {
            
            foreach (var item in Items)
            {
                if (!item.IsEnabled) continue;
                if (InputManager.Hover(item.Box))
                {
                    item.Color = Color.ForestGreen;
                    if (InputManager.LeftClicked)
                    {
                        game.gameState.Player.PlayerArsenal.AddItem(item,
                                game.shopState.Money);
                        item.IsEnabled = false;
                        item.Color = Color.Transparent;
                    }
                }
                else
                {
                    item.Color = Color.White;
                }
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
