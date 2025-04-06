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
    public abstract class State
    {

        public ContentManager Content { get; set; }
        public GraphicsDevice GraphicDevice { get; set; }


        public State(Game1 game, ContentManager content, GraphicsDevice graphicsDevice)
        {
            Content = content;
            GraphicDevice = graphicsDevice;
        }

        public abstract void Draw(Game1 game, GameTime gameTime, SpriteBatch spriteBatch, Matrix globalTransformation);

        public abstract void Update(GameTime gameTime, Game1 game);

    }
}
