using game1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace game1.View
{
    public class MapView : Map
    {
        private Texture2D roadPointTexture;
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
        /// <summary>
        /// Метод отрисовывает линию из точек между 2 элементами карты
        /// </summary>
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
