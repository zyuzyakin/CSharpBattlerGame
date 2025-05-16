using game1.Controller;
using game1.View;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using static game1.Controller.MouseInputManager;


namespace game1.Model;

public class ShopGrid : GameObject
{
    public List<ItemView> Items { get; set; }
    public ShopGrid()
    {
        Box = new Rectangle(10 * k, 10 * k, 1000 * k, 30 * k);
        RefreshShopGrid();
    }

    public void RefreshShopGrid()
    {
        Items = new List<ItemView>();
        var rnd = new Random();
        for (var i = 0; i < 7; i++)
        {
            Items.Add(
                new ItemView()
                {
                    ItemType = (ItemType)Enum.GetValues(typeof(ItemType))
                                .GetValue(i),
                    IsAtShop = true,
                    Cost = rnd.Next(1, 3)
                });
        }
    }

    public override void Update(GameTime gameTime, BirdGame game)
    {   
        foreach (var item in Items)
        {
            if (OnLeftClick(item, Color.Green))
            {
                game.gameState.PlayerArsenal.AddItem(item,
                        game.shopState.Money);
            }
        }
    }
}
