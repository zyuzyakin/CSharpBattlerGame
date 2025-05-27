using game1.View;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using static game1.Controller.MouseInputManager;

namespace game1.Model
{
    public class ChestGrid : GameObject
    {
        public List<ItemView> Items { get; set; }
        public ChestGrid()
        {
            Box = new Rectangle(40 * k, 40 * k, 1000 * k, 30 * k);
            RefreshChestGrid();
        }
        public void RefreshChestGrid()
        {
            Items = new List<ItemView>();
            var rnd = new Random();
            for (var i = 0; i < 3; i++)
            {
                Items.Add(
                    new ItemView()
                    {
                        ItemType = (ItemType)Enum.GetValues(typeof(ItemType))
                                    .GetValue(rnd.Next(0, 7)),
                        IsAtShop = false
                    });
            }
        }

        public override void Update(GameTime gameTime, BirdGame game)
        {
            foreach (var item in Items)
            {
                if (!item.IsEnabled) continue;

                if (OnLeftClick(item, Color.ForestGreen))
                {
                    if (game.gameState.PlayerArsenal.AddItem(item,
                        game.shopState.Money))
                    {
                        item.IsEnabled = false;
                        item.IsVisible = false;
                    }
                }
            }
        }
    }
}
