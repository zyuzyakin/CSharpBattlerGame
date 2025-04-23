
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
    public class Shop : GameObject
    {
        public ShopGrid ShopGrid { get; set; }
        public Shop()
        {
            ShopGrid = new ShopGrid();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            ShopGrid.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            ShopGrid.Update(gameTime, game);
        }

        public override void LoadContent(ContentManager content)
        {
            ShopGrid.LoadContent(content);
        }
    }
}
