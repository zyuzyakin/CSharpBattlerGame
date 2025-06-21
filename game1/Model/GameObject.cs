using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace game1.Model
{
    public class GameObject
    {
        public static int k = 5;
        public static float tk = k / 10f;
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public Rectangle Box { get; set; }

        public Color Color { get; set; } = Color.White;

        public virtual void Draw(SpriteBatch spriteBatch) 
        { 
        }
        
        public virtual void Update(GameTime gameTime, BirdGame game)
        {
        }
       
        public virtual void LoadContent(ContentManager content)
        { 
        }
    }
}
