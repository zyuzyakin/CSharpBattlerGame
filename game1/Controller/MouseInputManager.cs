using game1.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace game1.Controller;

public static class MouseInputManager
{
    private static bool leftClicked = false;

    private static bool rightClicked = false;

    private static MouseState ms = new MouseState(), oms;

    public delegate void OnClicked();

    public static void Update()
    {
        oms = ms;
        ms = Mouse.GetState();
        leftClicked = ms.LeftButton != ButtonState.Pressed 
            && oms.LeftButton == ButtonState.Pressed;

        rightClicked = ms.RightButton != ButtonState.Pressed 
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
        return OnHover(obj, highlightColor) && leftClicked;
    }

    public static bool OnRightClick(GameObject obj, Color highlightColor)
    {
        return OnHover(obj, highlightColor) && rightClicked;
    }
}

