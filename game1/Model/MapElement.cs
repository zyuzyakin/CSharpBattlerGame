using game1.Controller;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using static game1.Controller.MouseInputManager;


namespace game1.Model;

public enum PointType
{
    battle, hardbattle, chest, shop, boss
}
public class MapElement : GameObject
{
    public int LevelNumber { get; set; }
    public PointType PointType { get; set; }
    public bool IsAvailable { get; set; }
    public List<MapElement> Next { get; set; }
    public List<MapElement> Previous { get; set; }
    public MapElement()
    {
        Color = Color.Gray;
        Next = new List<MapElement>();
        Previous = new List<MapElement>();
    }

    public override void Update(GameTime gameTime, BirdGame game)
    {
        var curelem = game.mapState.Map.CurrentMapElem;

        IsAvailable = curelem == null && LevelNumber == 1
            || curelem != null && curelem.Next.Contains(this);

        if (!IsAvailable)
        {
            Color = Color.Gray;
            return;
        }

        if (OnLeftClick(this, Color.Green))
        {
            game.mapState.Map.CurrentMapElem = this;
            game.mapState.UpdateMapButton.IsEnabled = false;
            CreateLevel(game);
        }
    }
    public void CreateLevel(BirdGame game)
    {
        switch (PointType)
        {
            case PointType.chest:
                game.ChangeStateToChest();
                break;
            case PointType.battle:
                game.ChangeStateToGame(EnemyType.adware);
                break;
            case PointType.hardbattle:
                game.ChangeStateToGame(EnemyType.spyware);
                break;
            case PointType.boss:
                game.ChangeStateToGame(EnemyType.miner);
                break;
            case PointType.shop:
                game.ChangeStateToShop();
                break;
        }
    }

}
