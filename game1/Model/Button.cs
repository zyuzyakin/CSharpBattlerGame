using Microsoft.Xna.Framework;
using static game1.Controller.MouseInputManager;

namespace game1.Model;

public class Button : GameObject
{
    public OnClicked OnClick { get; set; }
    public bool IsEnabled { get; set; } 
    public string Text { get; set; }
    public Button()
    {
        IsEnabled = true;
    }

    public override void Update(GameTime gameTime, BirdGame game)
    {
        if (!IsEnabled) return;

        if (OnLeftClick(this, Color.Green))
        {
            OnClick();
        }
    }
}
