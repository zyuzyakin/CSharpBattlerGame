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
        public Player Player { get; private set; }
        public Enemy Enemy { get; private set; }
        public ItemGrid ItemGrid { get; private set; }
        public EndTurnButton EndTurnButton { get; private set; }

        public GameState(Game1 game, ContentManager content, GraphicsDevice graphicsDevice) : base(game, content, graphicsDevice)
        {
            Player = new Player();
            ItemGrid = new ItemGrid();
            Enemy = new Enemy();
            EndTurnButton = new EndTurnButton();


            var BaseFont = Content.Load<SpriteFont>("fonts/Hud");

            EndTurnButton.Font = BaseFont;
            Player.Font = BaseFont;
            Enemy.Font = BaseFont;

            EndTurnButton.Texture = Content.Load<Texture2D>("controls/button");
            Player.Texture = Content.Load<Texture2D>("player");
            Enemy.Texture = Content.Load<Texture2D>("enemies/ptichka");


            foreach (var item in ItemGrid.Items)
            {
                item.Texture = Content.Load<Texture2D>("items/sword");
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, Matrix globalTransformation)
        {
            Game.GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, globalTransformation);

            Enemy.Draw(spriteBatch);
            Player.Draw(spriteBatch);
            ItemGrid.Draw(spriteBatch);
            EndTurnButton.Draw(spriteBatch);

            spriteBatch.End();
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            Player.Update(gameTime, game);
            EndTurnButton.Update(gameTime, game);
        }
    }
}
