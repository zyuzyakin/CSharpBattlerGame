using game1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System.Collections.Generic;

namespace game1.Model
{
    public abstract class GameObject
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }

        public Rectangle Box { get; set; }

        public Color Color { get; set; } = Color.White;

        public abstract void Draw(Game1 game, SpriteBatch spriteBatch);
        public abstract void Update(GameTime gameTime, Game1 game);
    }
}
