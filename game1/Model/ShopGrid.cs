using game1.Controller;
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
    public class ShopGrid : GameObject
    {
        public List<Item> Items { get; set; }
        public ShopGrid()
        {
            Box = new Rectangle(100, 100, 10000, 300);
            RefreshShopGrid();
        }
        public void RefreshShopGrid()
        {
            Items = new List<Item>()
            {
                new Item(){ItemType = ItemType.sword,  Cost = 1},
                new Item(){ItemType = ItemType.shield, Cost = 2},
                new Item(){ItemType = ItemType.bomb, Cost = 2, Period = 200},
                new Item(){ItemType = ItemType.ice, Cost = 2},
                new Item(){ItemType = ItemType.healpotion, Cost = 2, Period = 300},
                new Item(){ItemType = ItemType.bow, Cost = 2},
                new Item(){ItemType = ItemType.arrow, Cost = 2},

                new Item(){ItemType = ItemType.hammer, Cost = 2},
            };
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            var distance = 10;
            var itemWidth = 300;
            var itemHeight = 300;

            for (var i = 0; i < Items.Count; i++)
            {
                Items[i].Box = new Rectangle(Box.X + i % 4 * (itemWidth + distance),
                    Box.Y + (i / 4) * (itemHeight + distance),
                    itemWidth, itemHeight);

                Items[i].Draw(spriteBatch);
            }
        }

        public override void Update(GameTime gameTime, Game1 game)
        {   

            foreach (var item in Items)
            {
                if (item.IsEnabled)
                {
                    if (InputManager.Hover(item.Box))
                    {
                        item.Color = Color.Blue;
                        if (InputManager.LeftClicked)
                        {
                            if (game.shopState.Money.MoneyValue >= item.Cost
                                && game.gameState.Player.PlayerArsenal.Items.Count 
                                < game.gameState.Player.PlayerArsenal.MaxSize)
                            {
                                if (item.ItemType == ItemType.arrow)
                                    game.gameState.Player.PlayerArsenal.ArrowsCount += 1;
                                game.shopState.Money.MoneyValue -= item.Cost;
                                game.gameState.Player.PlayerArsenal.Items.Add(new Item(item));
                            }
                        }
                    }
                    else
                    {
                        item.Color = Color.White;
                    }
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
