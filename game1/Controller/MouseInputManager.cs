using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace game1.Controller;

public static class MouseInputManager
{
    private static MouseState _prevState;
    private static MouseState _currentState;

    // Список отслеживаемых объектов
    private static readonly List<IClickable> ClickableObjects = new();

    public static void Update()
    {
        _prevState = _currentState;
        _currentState = Mouse.GetState();

        foreach (var obj in ClickableObjects)
        {
            var isHovered = obj.Bounds.Contains(GetPosition());

            // Обработка ховера
            obj.OnHover(isHovered);

            // Обработка кликов
            if (isHovered)
            {
                if (IsLeftClicked()) obj.OnLeftClick();
                if (IsRightClicked()) obj.OnRightClick();
            }
        }
    }

    // Регистрация объектов
    public static void Register(IClickable obj) => ClickableObjects.Add(obj);
    public static void Unregister(IClickable obj) => ClickableObjects.Remove(obj);
    public static void UnregisterAll() => ClickableObjects.Clear();


    // Вспомогательные методы
    public static Point GetPosition() => _currentState.Position;
    public static bool IsLeftClicked() => _prevState.LeftButton == ButtonState.Pressed &&
                                        _currentState.LeftButton == ButtonState.Released;
    public static bool IsRightClicked() => _prevState.RightButton == ButtonState.Pressed &&
                                         _currentState.RightButton == ButtonState.Released;
}

// Интерфейс для кликабельных объектов
public interface IClickable
{
    Rectangle Bounds { get; }
    void OnLeftClick();
    void OnRightClick();
    void OnHover(bool isHovered);
}