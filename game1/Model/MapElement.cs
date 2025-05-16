using game1.Controller;
using game1.View;
using game1.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace game1.Model
{   
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
            Next = new List<MapElement>();
            Previous = new List<MapElement>();
        }

        public override void Update(GameTime gameTime, BirdGame game)
        {
            var curelem = game.mapState.Map.CurrentMapElem;

            IsAvailable = curelem == null && LevelNumber == 1
                || curelem != null && curelem.Next.Contains(this);

            if (MouseInputManager.Hover(Box))
            {
                Color = Color.Green;
                if (MouseInputManager.LeftClicked && IsAvailable)
                {
                    game.mapState.Map.CurrentMapElem = this;
                    game.mapState.UpdateMapButton.IsEnabled = false;
                    CreateLevel(game);
                }
            }
            else
            {
                if (IsAvailable)
                    Color = Color.Yellow;
                else
                    Color = Color.White;
            }
            
        }
        public void CreateLevel(BirdGame game)
        {
            switch (PointType)
            {
                //TODO перенести в game переход к новому state
                case PointType.chest:
                    game.ChangeState(game.chestState);
                    game.chestState.ChestGrid = new ChestGridView();
                    game.chestState.ChestGrid.LoadContent(game.Content);
                    break;
                case PointType.battle:
                    game.ChangeState(game.gameState);
                    game.gameState.IsPaused = false;
                    game.gameState.PauseButton.IsEnabled = true;
                    game.gameState.BackToMapButton.IsEnabled = false;
                    game.gameState.CurrentEnemy = new EnemyView(EnemyType.adware);
                    game.gameState.CurrentEnemy.LoadContent(game.Content);
                    break;
                case PointType.hardbattle:

                    game.ChangeState(game.gameState);
                    game.gameState.IsPaused = false;
                    game.gameState.PauseButton.IsEnabled = true;
                    game.gameState.BackToMapButton.IsEnabled = false;
                    game.gameState.CurrentEnemy = new EnemyView(EnemyType.spyware);
                    game.gameState.CurrentEnemy.LoadContent(game.Content);
                    
                    break;
                case PointType.boss:
                    game.ChangeState(game.gameState);
                    game.gameState.IsPaused = false;
                    game.gameState.PauseButton.IsEnabled = true;
                    game.gameState.BackToMapButton.IsEnabled = false;
                    game.gameState.CurrentEnemy = new EnemyView(EnemyType.miner);
                    game.gameState.CurrentEnemy.LoadContent(game.Content);
                    break;
                case PointType.shop:
                    game.ChangeState(game.shopState);
                    game.shopState.ShopGrid = new ShopGridView();
                    game.shopState.ShopGrid.LoadContent(game.Content);
                    break;
                
            }
        }

    }
}
