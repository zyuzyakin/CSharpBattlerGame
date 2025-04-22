using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace game1.View
{
    public class AnimatedTexture : GameObject
    {   
        public List<Texture2D> Textures { get; set; }

        // Number of frames in the animation.
        public int FrameCount { get; set; }

        // The number of frames to draw per second.
        public float TimePerFrame { get; set; }

        // The current Frame being drawn.
        public int Frame { get; set; }

        // Total amount of time the animation has been running.
        public float TotalElapsed { get; set; }

        public bool IsPaused { get; set; }
        public string AssetName;

        public AnimatedTexture(int frameCount, int framesPerSec, string assetName)
        {
            Box = new Rectangle(0, 0, 2000, 1500);
            Frame = 0;
            TotalElapsed = 0;
            IsPaused = false;
            Textures = new List<Texture2D>();
            TimePerFrame = (float)1 / framesPerSec * 1000;
            FrameCount = frameCount;
            AssetName = assetName;

        }

        public override void LoadContent(ContentManager content)
        {
            for (var i = 1;i <= FrameCount;i++)
            {
                Textures.Add(content.Load<Texture2D>($"backgrounds/{AssetName}/" + i.ToString("D4")));
            }
            Texture = Textures[0];
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            if (IsPaused) return;

            TotalElapsed += gameTime.ElapsedGameTime.Milliseconds;

            if (TotalElapsed >= TimePerFrame)
            {
                Texture = Textures[Frame];
                Frame++;
                
                Frame %= FrameCount;
                TotalElapsed -= TimePerFrame;
            }
        }
        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Texture, Box, Color.White);
        }

        public void Reset()
        {
            Frame = 0;
            TotalElapsed = 0f;
        }

        public void Stop()
        {
            Pause();
            Reset();
        }

        public void Play()
        {
            IsPaused = false;
        }

        public void Pause()
        {
            IsPaused = true;
        }
    }
}
