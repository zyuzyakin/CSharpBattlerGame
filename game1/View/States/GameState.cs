using game1.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1.View.States
{
    public class GameState : State
    {
        
        public EndTurnButton EndTurnButton { get; private set; }

        public GameState(Game1 game, ContentManager content, GraphicsDevice graphicsDevice) : base(game, content, graphicsDevice)
        {
            
            EndTurnButton = new EndTurnButton();


            var BaseFont = Content.Load<SpriteFont>("fonts/Hud");

            EndTurnButton.Font = BaseFont;
            game.Player.Font = BaseFont;
            game.CurrentEnemy.Font = BaseFont;
            game.Money.Font = BaseFont;

            EndTurnButton.Texture = Content.Load<Texture2D>("controls/button");
            game.Money.Texture = Content.Load<Texture2D>("controls/button");
            game.Player.Texture = Content.Load<Texture2D>("player");
            game.CurrentEnemy.Texture = Content.Load<Texture2D>("enemies/ptichka");


            foreach (var item in game.ItemGrid.Items)
            {
                item.Texture = Content.Load<Texture2D>("items/sword");
                item.Font = BaseFont;
            }
        }

        public override void Draw(Game1 game, GameTime gameTime, SpriteBatch spriteBatch, Matrix globalTransformation)
        {
            game.GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, globalTransformation);

            game.CurrentEnemy.Draw(game, spriteBatch);
            game.Player.Draw(game, spriteBatch);
            game.ItemGrid.Draw(game, spriteBatch);
            EndTurnButton.Draw(game, spriteBatch);
            game.Money.Draw(game, spriteBatch);

            spriteBatch.End();
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            game.Player.Update(gameTime, game);
            EndTurnButton.Update(gameTime, game);
        }
    }
}
