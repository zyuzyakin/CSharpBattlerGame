using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//using SharpDX.Direct2D1;
using SharpDX.Direct3D9;
using System.Collections.Generic;

namespace game1.Controller
{
    public static class InputManager
    {
        public static bool LeftClicked = false;

        public static bool RightClicked = false;

        private static MouseState ms = new MouseState(), oms;

        public static void Update()
        {
            oms = ms;
            ms = Mouse.GetState();
            LeftClicked = ms.LeftButton != ButtonState.Pressed && oms.LeftButton == ButtonState.Pressed;
            RightClicked = ms.RightButton != ButtonState.Pressed && oms.RightButton == ButtonState.Pressed;
            // true On left release like Windows buttons
        }
        public static bool Hover(Rectangle r)
        {
            return r.Contains(new Vector2(ms.X, ms.Y));
        }
    }
}
