using game1.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace game1.Controller;

public static class MouseInputManager
{
    public static bool LeftClicked = false;

    public static bool RightClicked = false;

    private static MouseState ms = new MouseState(), oms;

    public delegate void OnClicked();

    public static void Update()
    {
        oms = ms;
        ms = Mouse.GetState();
        LeftClicked = ms.LeftButton != ButtonState.Pressed 
            && oms.LeftButton == ButtonState.Pressed;

        RightClicked = ms.RightButton != ButtonState.Pressed 
            && oms.RightButton == ButtonState.Pressed;
    }
    public static bool Hover(Rectangle r)
    {
        return r.Contains(new Vector2(ms.X, ms.Y));
    }

    public static void OnLeftClicked(GameObject obj)
    {
        
    }
}

