using game1.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1.View.States
{
    public class MapState : State
    {
        public Map Map { get; set; }
        public Button UpdateMapButton { get; set; }
        private Texture2D Description;

        public MapState(Game1 game, ContentManager content, GraphicsDevice graphicsDevice) : base(game, content, graphicsDevice)
        {
            Background = content.Load<Texture2D>("backgrounds/bgshop");
            Description = content.Load<Texture2D>("mapIcons/legend");

            Map = new Map();
            Map.LoadContent(content);

            UpdateMapButton = new Button()
            {
                Box = new Rectangle(140 * k, 60 * k, 50 * k, 15 * k),
                Text = "ОБНОВИТЬ!",
                OnClick = Button.UpdateMap
            };
            UpdateMapButton.LoadContent(content);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(Background, new Rectangle(0, 0, 200 * k, 150 * k), Color.White);
            spriteBatch.Draw(Description, new Rectangle(130 * k, 80 * k, 60 * k, 60 * k), Color.White);
            Map.Draw(spriteBatch);
            UpdateMapButton.Draw(spriteBatch);
            Game.shopState.Money.Draw(spriteBatch);

            spriteBatch.End();
        }
        
        public override void Update(GameTime gameTime, Game1 game)
        {
            Map.Update(gameTime, game);
            UpdateMapButton.Update(gameTime, game);
            Game.shopState.Money.Update(gameTime, game);
        }
    }
}
