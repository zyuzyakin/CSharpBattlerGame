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
    public class State : GameObject
    {
        public List<GameObject> StateElements { get; set; }
        public Texture2D Background { get; set; }
        public Game1 Game { get; set; }
        public ContentManager Content { get; set; }
        public GraphicsDevice GraphicDevice { get; set; }


        public State(Game1 game, ContentManager content, GraphicsDevice graphicsDevice)
        {
            StateElements = new List<GameObject>();
            Game = game;
            Content = content;
            GraphicDevice = graphicsDevice;
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        { 

        }
    }
}
