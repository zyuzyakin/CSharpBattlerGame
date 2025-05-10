using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
            LeftClicked = ms.LeftButton != ButtonState.Pressed 
                && oms.LeftButton == ButtonState.Pressed;
            RightClicked = ms.RightButton != ButtonState.Pressed 
                && oms.RightButton == ButtonState.Pressed;
        }

        public static bool Hover(Rectangle r) => r.Contains(new Vector2(ms.X, ms.Y));
    }
}
