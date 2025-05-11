using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using game1.Model;
using game1.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;

namespace game1.View
{
    public class MapElementView : MapElement
    {
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Box, Color);
        }
        public override void LoadContent(ContentManager content)
        {
            Texture = content.Load<Texture2D>($"mapIcons/{PointType}");
        }
    }
}
