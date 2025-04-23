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
    public abstract class State : GameObject
    {
        public Texture2D Background { get; set; }
        public Game1 Game { get; set; }
        public ContentManager Content { get; set; }
        public GraphicsDevice GraphicDevice { get; set; }


        public State(Game1 game, ContentManager content, GraphicsDevice graphicsDevice)
        {
            Game = game;
            Content = content;
            GraphicDevice = graphicsDevice;
        }

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime, Game1 game);

    }
}
