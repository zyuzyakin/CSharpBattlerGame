using game1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System.Collections.Generic;

namespace game1.Model
{
    public class GameObject
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }

        public Rectangle Box { get; set; }

        public Color Color { get; set; } = Color.White;

        public virtual void Draw(SpriteBatch spriteBatch) 
        { 

        }
        
        public virtual void Update(GameTime gameTime, Game1 game)
        {

        }
       
        public virtual void LoadContent(ContentManager content)
        { 

        }
 
    }
}
