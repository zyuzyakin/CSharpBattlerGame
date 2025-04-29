using game1.Controller;
using game1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;
using System.Reflection.Metadata;

namespace game1.Model
{
    public class ShopGrid : GameObject
    {
        public List<Item> Items { get; set; }
        public ShopGrid()
        {
            Box = new Rectangle(10 * k, 10 * k, 1000 * k, 30 * k);
            RefreshShopGrid();
        }
        public void RefreshShopGrid()
        {
            Items = new List<Item>()
            {
                new Item(){ItemType = ItemType.sword,  Cost = 1},
                new Item(){ItemType = ItemType.shield, Cost = 2},
                new Item(){ItemType = ItemType.bomb, Cost = 3, Period = 200},
                new Item(){ItemType = ItemType.ice, Cost = 1},
                new Item(){ItemType = ItemType.healpotion, Cost = 3},
                new Item(){ItemType = ItemType.bow, Cost = 2},
                new Item(){ItemType = ItemType.hammer, Cost = 2},
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
                    if (InputManager.Hover(item.Box))
                    {
                        item.Color = Color.Blue;
                        if (InputManager.LeftClicked)
                        {
                            if (game.shopState.Money.MoneyValue >= item.Cost
                                && game.gameState.Player.PlayerArsenal.Items.Count 
                                < game.gameState.Player.PlayerArsenal.MaxSize)
                            {
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

        public override void LoadContent(ContentManager content)
        {
            foreach (var item in Items)
            {
                item.LoadContent(content);
            }
        }
    }
}
