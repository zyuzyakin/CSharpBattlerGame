using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SharpDX.Direct3D9;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;


namespace game1.View
{
    public class AnimatedTexture : GameObject
    {
        // Number of frames in the animation.
        public int FrameCount { get; set; }

        // The number of frames to draw per second.
        public float TimePerFrame { get; set; }

        // The current Frame being drawn.
        public int Frame { get; set; }

        int FrameWidth;
        int FrameHeight;
        Rectangle SourceRect;
        // Total amount of time the animation has been running.
        public float TotalElapsed { get; set; }

        public bool IsPaused { get; set; }
        public string AssetName;

        public AnimatedTexture(int frameCount, int framesPerSec, string assetName, Rectangle box)
        {
            Box = box;
            Frame = 0;
            TotalElapsed = 0;
            IsPaused = false;
            TimePerFrame = (float)1 / framesPerSec * 1000;
            FrameCount = frameCount;
            AssetName = assetName;
        }

        public override void LoadContent(ContentManager content)
        {
            Texture = content.Load<Texture2D>($"{AssetName}");
            FrameWidth = Texture.Width / 10;
            FrameHeight = Texture.Height / 2;
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            if (IsPaused) return;

            TotalElapsed += gameTime.ElapsedGameTime.Milliseconds;
            if (TotalElapsed >= TimePerFrame)
            {

                SourceRect = new Rectangle(FrameWidth * (Frame % 10), 
                    FrameHeight * (Frame / 10),
                FrameWidth, FrameHeight);

                Frame++;

                Frame %= FrameCount;
                TotalElapsed -= TimePerFrame;
            }
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Texture, Box, SourceRect, Color);
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