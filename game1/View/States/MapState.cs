using game1.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace game1.View.States
{
    public class MapState : State
    {
        public Map Map { get; set; }

        public MapState(Game1 game, ContentManager content, GraphicsDevice graphicsDevice) : base(game, content, graphicsDevice)
        {
            Background = content.Load<Texture2D>("backgrounds/bgshop");
            Map = new Map();
            Map.LoadContent(content);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(Background, new Rectangle(0, 0, 200 * k, 150 * k), Color.White);
            Map.Draw(spriteBatch);

            Game.shopState.Money.Draw(spriteBatch);

            spriteBatch.End();
        }
        
        public override void Update(GameTime gameTime, Game1 game)
        {
            Map.Update(gameTime, game);
        }
    }
}
