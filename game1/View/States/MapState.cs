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
        public List<MapElement> MapElems { get; set; }

        public MapElement CurrentMapElem { get; set; }

        public Texture2D roadPoint { get; set; }
        public Random rnd { get; set; }

        public MapState(Game1 game, ContentManager content, GraphicsDevice graphicsDevice) : base(game, content, graphicsDevice)
        {
            MapElems = new List<MapElement>();
            rnd = new Random();
            roadPoint = content.Load<Texture2D>("controls/button");
            int startY = 1300;
            int startX = 800;
            int size = 100;
            MapElems.Add(new MapElement()
            {
                Box = new Rectangle(startX, startY, size, size),
                LevelNumber = 0,
                Previous = new List<MapElement>(),
                Next = new List<MapElement>(),
                Texture = content.Load<Texture2D>("mapIcons/вислоушик")

            });
            CurrentMapElem = MapElems[0];
            for(var levelNum = 1; levelNum < 5; levelNum++)
            {
                var dotNumber = rnd.Next(2, 5);
                for (int i = 0; i < dotNumber; i++) 
                {
                    MapElems.Add(new MapElement()
                    {
                        Box = new Rectangle(startX - 100 * (dotNumber-1) + i * 200, 
                            startY - levelNum * 200, size, size),
                        LevelNumber = levelNum,
                        Previous = new List<MapElement>(),
                        Next = new List<MapElement>(),
                        Texture = content.Load<Texture2D>("mapIcons/вислоушик")
                    });
                    
                }
            }

            MapElems.Add(new MapElement()
            {
                Box = new Rectangle(startX, startY - 200 * 5, size, size),
                LevelNumber = 5,
                Previous = new List<MapElement>(),
                Next = new List<MapElement>(),
                Texture = content.Load<Texture2D>("mapIcons/вислоушик")

            });
            MapElems.Add(new MapElement()
            {
                Box = new Rectangle(startX, startY - 200 * 6, size, size),
                LevelNumber = 6,
                Previous = new List<MapElement>(),
                Next = new List<MapElement>(),
                Texture = content.Load<Texture2D>("mapIcons/вислоушик")

            });


            foreach (var elem in MapElems)
            {
                if (elem.LevelNumber != 0)
                {
                    if (!elem.Previous.Any())
                    {
                        var prevLevelItems = MapElems.Where(x => x.LevelNumber == elem.LevelNumber - 1);
                        var r = rnd.Next(0, prevLevelItems.Count());
                        var prevelem = prevLevelItems.Skip(r).First();
                        elem.Previous.Add(prevelem);
                        prevelem.Next.Add(elem);
                    }
                }
                if (elem.LevelNumber != 6){ 
                    if (!elem.Next.Any())
                    {
                        var nextLevelItems = MapElems.Where(x => x.LevelNumber == elem.LevelNumber + 1);
                        var r = rnd.Next(0, nextLevelItems.Count());
                        var nextelem = nextLevelItems.Skip(r).First();
                        elem.Next.Add(nextelem);
                        nextelem.Previous.Add(elem);
                    }
                }
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Game.GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            foreach (var elem in MapElems)
            {
                foreach (var nelem in elem.Next)
                {
                    DrawRoad(elem, nelem, spriteBatch);
                }
                elem.Draw(spriteBatch);
            }

            Game.shopState.Money.Draw(spriteBatch);
            spriteBatch.End();
        }
        public void DrawRoad(MapElement e1, MapElement e2, SpriteBatch spriteBatch)
        {
            var step = 10;
            
            var minx = Math.Min(e2.Box.X, e1.Box.X);
            var maxx = Math.Max(e2.Box.X, e1.Box.X);
            var miny = Math.Min(e2.Box.Y, e1.Box.Y);
            var maxy = Math.Max(e2.Box.Y, e1.Box.Y);

            double deltax = e2.Box.X - e1.Box.X;
            double deltay = e2.Box.Y - e1.Box.Y;
            if (deltax == 0) 
            {
                for (var y = miny; y <= maxy; y += step)
                {
                    spriteBatch.Draw(roadPoint, 
                        new Rectangle(e1.Box.X, y, 
                        10, 10), Color.White);
                }
            }
            else
            {
                for (var x = minx; x <= maxx; x += step)
                {
                    spriteBatch.Draw(roadPoint, 
                        new Rectangle(x, (int)((x - e1.Box.X) * (deltay / deltax) + e1.Box.Y), 
                        10, 10), Color.White);
                }
            }
        }
        
        public override void Update(GameTime gameTime, Game1 game)
        {
  
        }
    }
}
