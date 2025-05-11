using game1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;


namespace game1.Model
{
    public class Map : GameObject
    {
        private readonly Random rnd;
        public List<MapElementView> mapElems { get; set; }
        public MapElement CurrentMapElem { get; set; }

        public Map()
        {
            mapElems = new List<MapElementView>();
            rnd = new Random();
            CurrentMapElem = null;

            int startY = 150 * k;
            int startX = 80 * k;
            int size = 15 * k;
            int totalLevels = 7;

            for (var levelNum = 1; levelNum <= totalLevels; levelNum++)
            {   
                //На этих уровнях генерируется только магазин
                if (levelNum == 1 || levelNum == (totalLevels + 1) / 2  || levelNum == totalLevels-1)
                {
                    mapElems.Add(new MapElementView()
                    {
                        Box = new Rectangle(startX,
                                startY - levelNum * 20 * k, size, size),
                        LevelNumber = levelNum,
                        PointType = PointType.shop

                    });
                }
                //На последнем битва с боссом
                else if(levelNum == totalLevels)
                {
                    mapElems.Add(new MapElementView()
                    {
                        Box = new Rectangle(startX - 5 * k, startY - 20 * k * totalLevels - 10 * k, 30 * k, 30 * k),
                        LevelNumber = levelNum,
                        PointType = PointType.boss
                    });
                }
                //Остальные заполняем случайно
                else
                {
                    var dotNumber = rnd.Next(2, 4);
                    for (int i = 0; i < dotNumber; i++)
                    {
                        mapElems.Add(new MapElementView()
                        {
                            Box = new Rectangle(startX - 15 * k * (dotNumber - 1) + i * 30 * k,
                                startY - levelNum * 20 * k, size, size),
                            LevelNumber = levelNum,
                            PointType = (PointType)Enum.GetValues(typeof(PointType))
                                .GetValue(rnd.Next(0, 3))
                        });
                    }
                }
            }
            //генерируем случайные связи между точками
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

        public override void Update(GameTime gameTime, BirdGame game)
        {
            foreach (var elem in mapElems)
            {
                elem.Update(gameTime, game);
            }
        }

        
    }

}

