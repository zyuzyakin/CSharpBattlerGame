using game1.Model;
using game1.Model.Buttons;
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
        
        


        public EnterShop EnterShop { get; private set; }



        public GameState(Game1 game, ContentManager content, GraphicsDevice graphicsDevice) : base(game, content, graphicsDevice)
        {
            Player = new Player();
            
            CurrentEnemy = new Enemy();
 
            EnterShop = new EnterShop();

            var BaseFont = Content.Load<SpriteFont>("fonts/Hud");

    
            EnterShop.Font = BaseFont;
            Player.Font = BaseFont;
            CurrentEnemy.Font = BaseFont;
            

            
            EnterShop.Texture = Content.Load<Texture2D>("controls/button");
            Player.Texture = Content.Load<Texture2D>("player");
            CurrentEnemy.Texture = Content.Load<Texture2D>("enemies/ptichka");


            foreach (var item in Player.PlayerArsenal.Items)
            {
                item.Texture = Content.Load<Texture2D>($"items/{item.TextureName}");
                item.Font = BaseFont;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Game.GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            CurrentEnemy.Draw(spriteBatch);
            Player.Draw(spriteBatch);
            Player.PlayerArsenal.Draw(spriteBatch);
            EnterShop.Draw(spriteBatch);
            
            Game.shopState.Money.Draw(spriteBatch);
            

            spriteBatch.End();
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            Player.Update(gameTime, game);
            
            EnterShop.Update(gameTime, game);
        }
    }
}
