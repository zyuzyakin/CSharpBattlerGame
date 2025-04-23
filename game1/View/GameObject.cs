using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System.Collections.Generic;

namespace game1.View
{
    public class GameObject
    {
        public static int k { get; set; } = 10;
        public static float tk { get; set; } = k / 10f;
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
