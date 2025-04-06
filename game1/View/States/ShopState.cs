using game1.Model;
using game1.Model.Buttons;
using game1.Model.ItemTypes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1.View.States
{
    public class ShopState : State
    {   
        public ItemGrid ShopItemGrid { get; set; }

        public ExitShopButton ExitShopButton { get; set; }

        public ShopState(Game1 game, ContentManager content, GraphicsDevice graphicsDevice) : base(game, content, graphicsDevice)
        {
            ShopItemGrid = new ItemGrid();
            ShopItemGrid.Box = new Rectangle(100, 100, 10000, 300);
            ShopItemGrid.Items = new List<Item>() { new Sword(), new Shield() };

            ExitShopButton = new ExitShopButton();

            

            var BaseFont = Content.Load<SpriteFont>("fonts/Hud");

            ExitShopButton.Texture = Content.Load<Texture2D>("controls/button");
            ExitShopButton.Font = BaseFont;

            foreach (var item in ShopItemGrid.Items)
            {
                item.Texture = Content.Load<Texture2D>($"items/{item.TextureName}");
                item.Font = BaseFont;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, Matrix globalTransformation)
        {
            Game.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, globalTransformation);

            ShopItemGrid.Draw(spriteBatch);
            ExitShopButton.Draw(spriteBatch);

            spriteBatch.End();
            
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            ExitShopButton.Update(gameTime, game);
        }
    }
}
