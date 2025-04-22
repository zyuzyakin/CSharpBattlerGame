using game1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace game1.Model
{
    public class Map : GameObject
    {
        public List<MapElement> MapElems { get; set; }

        public MapElement CurrentMapElem { get; set; }



        public Texture2D roadPointTexture { get; set; }
        public Random rnd { get; set; }

        public Map()
        {
            MapElems = new List<MapElement>();
            rnd = new Random();
            CurrentMapElem = null;

            int startY = 1500;
            int startX = 800;
            int size = 150;
            int totalLevels = 7;

            for (var levelNum = 1; levelNum <= totalLevels; levelNum++)
            {
                if (levelNum == 1 || levelNum == (totalLevels + 1) / 2  || levelNum == totalLevels-1)
                {
                    MapElems.Add(new MapElement()
                    {
                        Box = new Rectangle(startX,
                                startY - levelNum * 200, size, size),
                        LevelNumber = levelNum,
                        PointType = PointType.shop

                    });
                }
                else if(levelNum == totalLevels)
                {
                    MapElems.Add(new MapElement()
                    {
                        Box = new Rectangle(startX - 50, startY - 200 * totalLevels - 100, 300, 300),
                        LevelNumber = levelNum,
                        PointType = PointType.boss
                    });
                }
                else
                {
                    var dotNumber = rnd.Next(2, 4);
                    for (int i = 0; i < dotNumber; i++)
                    {
                        MapElems.Add(new MapElement()
                        {
                            Box = new Rectangle(startX - 150 * (dotNumber - 1) + i * 300,
                                startY - levelNum * 200, size, size),
                            LevelNumber = levelNum,
                            PointType = (PointType)Enum.GetValues(typeof(PointType)).GetValue(rnd.Next(0, 3))
                        });
                    }
                }
            }

            foreach (var elem in MapElems)
            {
                if (elem.LevelNumber != 1)
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
                if (elem.LevelNumber != totalLevels)
                {
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
        
        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (var elem in MapElems)
            {
                foreach (var nelem in elem.Next)
                {
                    DrawRoad(elem, nelem, spriteBatch);
                }
                elem.Draw(spriteBatch);
            }
        }

        public void DrawRoad(MapElement e1, MapElement e2, SpriteBatch spriteBatch)
        {
            var step = 20;
            var e1x = e1.Box.X + e1.Box.Width / 2;
            var e1y = e1.Box.Y + e1.Box.Height / 2;

            var e2x = e2.Box.X + e2.Box.Width / 2;
            var e2y = e2.Box.Y + e2.Box.Height / 2;

            var minx = Math.Min(e2x, e1x);
            var maxx = Math.Max(e2x, e1x);
            var miny = Math.Min(e2y, e1y);
            var maxy = Math.Max(e2y, e1y);

            double deltax = e2x - e1x;
            double deltay = e2y - e1y;
            if (deltax == 0)
            {
                for (var y = miny; y <= maxy; y += step)
                {
                    spriteBatch.Draw(roadPointTexture,
                        new Rectangle(e1x, y,
                        20, 20), Color.White);
                }
            }
            else if (maxx - minx > maxy - miny)
            {
                for (var x = minx; x <= maxx; x += step)
                {
                    spriteBatch.Draw(roadPointTexture,
                        new Rectangle(x, (int)((x - e1x) * (deltay / deltax) + e1y),
                        20, 20), Color.White);
                }
            }
            else
            {
                for (var y = miny; y <= maxy; y += step)
                {
                    spriteBatch.Draw(roadPointTexture,
                        new Rectangle((int)(deltax / deltay * (y - e1y) + e1x), y,
                        20, 20), Color.White);
                }
            }
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            foreach (var elem in MapElems)
            {
                elem.Update(gameTime, game);
            }
        }

        public override void LoadContent(ContentManager content)
        {
            roadPointTexture = content.Load<Texture2D>("mapIcons/roadPoint");

            foreach (var elem in MapElems)
            {
                elem.LoadContent(content);
            }
        }
    }

}

