using game1.Controller;
using game1.View;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace game1.Model
{
    public class ChestGrid : GameObject
    {
        public List<ItemView> Items { get; set; }

        public Rectangle Bounds => Box;

        public ChestGrid()
        {
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
                        IsItOwned = false
                    });
            }
        }

        public override void Update(GameTime gameTime, BirdGame game)
        {
            //foreach (var item in Items)
            //{
            //    if (!item.IsEnabled) continue;

            //    if (MouseInputManager.Hover(item.Box))
            //    {
            //        item.Color = Color.ForestGreen;
            //        if (MouseInputManager.LeftClicked)
            //        {
            //            if (game.gameState.PlayerArsenal.AddItem(item,
            //                game.shopState.Money))
            //            {
            //                item.IsEnabled = false;
            //                item.IsVisible = false;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        item.Color = Color.White;
            //    }
            //}
        }
    }
}
