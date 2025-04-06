using game1.Model;
using game1.Model.Buttons;
using game1.Model.ItemTypes;
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
        public Enemy CurrentEnemy { get; private set; }
        public ItemGrid ItemGrid { get; private set; }
        public EndTurnButton EndTurnButton { get; private set; }

        public Money Money { get; private set; }

        public GameState(Game1 game, ContentManager content, GraphicsDevice graphicsDevice) : base(game, content, graphicsDevice)
        {
            Player = new Player();
            ItemGrid = new ItemGrid();
            CurrentEnemy = new Enemy();
            EndTurnButton = new EndTurnButton();
            Money = new Money();
            

            var BaseFont = Content.Load<SpriteFont>("fonts/Hud");

            EndTurnButton.Font = BaseFont;
            Player.Font = BaseFont;
            CurrentEnemy.Font = BaseFont;
            Money.Font = BaseFont;

            EndTurnButton.Texture = Content.Load<Texture2D>("controls/button");
            Money.Texture = Content.Load<Texture2D>("controls/button");
            Player.Texture = Content.Load<Texture2D>("player");
            CurrentEnemy.Texture = Content.Load<Texture2D>("enemies/ptichka");


            foreach (var item in ItemGrid.Items)
            {
                item.Texture = Content.Load<Texture2D>($"items/{item.TextureName}");
                item.Font = BaseFont;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, Matrix globalTransformation)
        {
            Game.GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, globalTransformation);

            CurrentEnemy.Draw(spriteBatch);
            Player.Draw(spriteBatch);
            ItemGrid.Draw(spriteBatch);
            EndTurnButton.Draw(spriteBatch);
            Money.Draw(spriteBatch);

            spriteBatch.End();
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            Player.Update(gameTime, game);
            EndTurnButton.Update(gameTime, game);
        }
    }
}
