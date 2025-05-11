using game1.Controller;
using game1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace game1.Model
{
    public class ChestGrid : GameObject
    {
        public List<Item> Items { get; set; }
        public ChestGrid()
        {
            RefreshChestGrid();
        }
        public void RefreshChestGrid()
        {
            Items = new List<Item>();
            var rnd = new Random();
            for (var i = 0; i < 3; i++)
            {
                Items.Add(
                    new Item()
                    {
                        ItemType = (ItemType)Enum.GetValues(typeof(ItemType))
                                    .GetValue(rnd.Next(0, 7)),
                        IsAtShop = false
                    });
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
                        if (game.gameState.Player.PlayerArsenal.IsItAbleToAddItem())
                        {
                            game.gameState.Player.PlayerArsenal.AddItem(item);
                            item.IsEnabled = false;
                            item.IsVisible = false;
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
}
