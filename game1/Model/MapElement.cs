using game1.Controller;
using game1.Model;
using game1.View;
using game1.View.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace game1.Model
{   
    public enum PointType
    {
        Shop,Battle,HardBattle,Boss,Chest
    }
    public class MapElement : GameObject
    {
        public int LevelNumber { get; set; }
        public PointType PointType { get; set; }
        public List<MapElement> Next { get; set; }
        public List<MapElement> Previous { get; set; }
        public MapElement()
        {
            Next = new List<MapElement>();
            Previous = new List<MapElement>();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Box, Color);
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
                if (InputManager.Hover(Box))
                {
                    Color = Color.Blue;
                    if (InputManager.LeftClicked)
                    {
                        
                    }
                }
                else
                {
                    Color = Color.White;
                }
            
        }
    }
}
