using game1.Controller;
using game1.View;
using game1.View.States;
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
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Box, Color);
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            var curelem = game.mapState.Map.CurrentMapElem;

            IsAvailable = curelem == null && LevelNumber == 1
                || curelem != null && curelem.Next.Contains(this);

            if (InputManager.Hover(Box))
            {
                Color = Color.Green;
                if (InputManager.LeftClicked && IsAvailable)
                {
                    game.mapState.Map.CurrentMapElem = this;
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
        public void CreateLevel(Game1 game)
        {
            switch (PointType)
            {
                case PointType.chest:
                    game.ChangeState(game.gameState);
                    game.gameState.IsPaused = false;
                    game.gameState.CurrentEnemy = new Enemy(EnemyType.adware);
                    game.gameState.CurrentEnemy.LoadContent(game.Content);
                    break;
                case PointType.battle:
                    game.ChangeState(game.gameState);
                    game.gameState.IsPaused = false;
                    game.gameState.BackToMapButton.IsEnabled = false;
                    game.gameState.CurrentEnemy = new Enemy(EnemyType.adware);
                    game.gameState.CurrentEnemy.LoadContent(game.Content);
                    break;
                case PointType.hardbattle:

                    game.ChangeState(game.gameState);
                    game.gameState.IsPaused = false;
                    game.gameState.BackToMapButton.IsEnabled = false;
                    game.gameState.CurrentEnemy = new Enemy(EnemyType.spyware);
                    game.gameState.CurrentEnemy.LoadContent(game.Content);
                    
                    break;
                case PointType.boss:

                    game.ChangeState(game.gameState);
                    game.gameState.IsPaused = false;
                    game.gameState.BackToMapButton.IsEnabled = false;
                    game.gameState.CurrentEnemy = new Enemy(EnemyType.miner);
                    game.gameState.CurrentEnemy.LoadContent(game.Content);

                    break;
                case PointType.shop:
                    game.ChangeState(game.shopState);
                    game.shopState.ShopGrid = new ShopGrid();
                    game.shopState.ShopGrid.LoadContent(game.Content);
                    break;
                
            }
        }
        public override void LoadContent(ContentManager content)
        {
            Texture = content.Load<Texture2D>($"mapIcons/{PointType}");
        }
    }
}
