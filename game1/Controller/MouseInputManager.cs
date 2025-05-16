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
    public static bool OnHover(GameObject obj, Color highlightColor)
    {
        var cond = obj.Box.Contains(new Vector2(ms.X, ms.Y));
        obj.Color = cond ? highlightColor : Color.White;
        return cond;
    }

    public static bool OnLeftClick(GameObject obj, Color highlightColor)
    {
        return OnHover(obj, highlightColor) && LeftClicked;
    }

    public static bool OnRightClick(GameObject obj, Color highlightColor)
    {
        return OnHover(obj, highlightColor) && RightClicked;
    }
}

