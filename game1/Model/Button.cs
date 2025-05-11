using game1.Controller;
using game1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace game1.Model
{
    public class Button : GameObject
    {
        public delegate void ClickEvent(Game1 game); //делегат для событий от нажатия кнопки
        public ClickEvent OnClick { get; set; }
        public bool IsEnabled { get; set; } 
        public string Text { get; set; }
        public Button()
        {
            IsEnabled = true;
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            if (IsEnabled)
            {
                if (InputManager.Hover(Box))
                {
                    Color = Color.Green;
                    if (InputManager.LeftClicked)
                    {
                        OnClick(game);
                    }
                }
                else
                {
                    Color = Color.White;
                } 
            }
        }

        //Функционал кнопок
        public static void StartGame(Game1 game) 
        {
            game.NewGame();
            game.ChangeState(game.mapState); 
        }
        public static void CombineItems(Game1 game) 
            => game.gameState.Player.PlayerArsenal.CombineItems(game);
        public static void ExitGame(Game1 game) => game.Exit();
        public static void BackToMap(Game1 game)
        {
            game.ChangeState(game.mapState);
        }
        public static void EnterShop(Game1 game) => game.ChangeState(game.shopState);
        public static void PauseUnpauseGame(Game1 game) 
            => game.gameState.IsPaused = !game.gameState.IsPaused;

        public static void UpdateMap(Game1 game)
        {
            game.mapState.Map = new Map();
            game.mapState.Map.LoadContent(game.Content);
        }

    }
}
