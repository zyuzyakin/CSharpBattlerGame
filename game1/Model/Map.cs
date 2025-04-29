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
        private readonly Random rnd;
        private Texture2D roadPointTexture;
        private List<MapElement> mapElems;

        public MapElement CurrentMapElem { get; set; }

        public Map()
        {
            mapElems = new List<MapElement>();
            rnd = new Random();
            CurrentMapElem = null;

            int startY = 150 * k;
            int startX = 80 * k;
            int size = 15 * k;
            int totalLevels = 7;

            for (var levelNum = 1; levelNum <= totalLevels; levelNum++)
            {
                if (levelNum == 1 || levelNum == (totalLevels + 1) / 2  || levelNum == totalLevels-1)
                {
                    mapElems.Add(new MapElement()
                    {
                        Box = new Rectangle(startX,
                                startY - levelNum * 20 * k, size, size),
                        LevelNumber = levelNum,
                        PointType = PointType.shop

                    });
                }
                else if(levelNum == totalLevels)
                {
                    mapElems.Add(new MapElement()
                    {
                        Box = new Rectangle(startX - 5 * k, startY - 20 * k * totalLevels - 10 * k, 30 * k, 30 * k),
                        LevelNumber = levelNum,
                        PointType = PointType.boss
                    });
                }
                else
                {
                    var dotNumber = rnd.Next(2, 4);
                    for (int i = 0; i < dotNumber; i++)
                    {
                        mapElems.Add(new MapElement()
                        {
                            Box = new Rectangle(startX - 15 * k * (dotNumber - 1) + i * 30 * k,
                                startY - levelNum * 20 * k, size, size),
                            LevelNumber = levelNum,
                            PointType = (PointType)Enum.GetValues(typeof(PointType)).GetValue(rnd.Next(0, 3))
                        });
                    }
                }
            }

            foreach (var elem in mapElems)
            {
                if (elem.LevelNumber != 1)
                {
                    if (!elem.Previous.Any())
                    {
                        var prevLevelItems = mapElems.Where(x => x.LevelNumber == elem.LevelNumber - 1);
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
                        var nextLevelItems = mapElems.Where(x => x.LevelNumber == elem.LevelNumber + 1);
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
            foreach (var elem in mapElems)
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
            var step = 2 * k;
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
                        2 * k, 2 * k), Color.White);
                }
            }
            else if (maxx - minx > maxy - miny)
            {
                for (var x = minx; x <= maxx; x += step)
                {
                    spriteBatch.Draw(roadPointTexture,
                        new Rectangle(x, (int)((x - e1x) * (deltay / deltax) + e1y),
                        2 * k, 2 * k), Color.White);
                }
            }
            else
            {
                for (var y = miny; y <= maxy; y += step)
                {
                    spriteBatch.Draw(roadPointTexture,
                        new Rectangle((int)(deltax / deltay * (y - e1y) + e1x), y,
                        2 * k, 2 * k), Color.White);
                }
            }
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            foreach (var elem in mapElems)
            {
                elem.Update(gameTime, game);
            }
        }

        public override void LoadContent(ContentManager content)
        {
            roadPointTexture = content.Load<Texture2D>("mapIcons/roadPoint");

            foreach (var elem in mapElems)
            {
                elem.LoadContent(content);
            }
        }
    }

}

