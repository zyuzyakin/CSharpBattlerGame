using game1.Controller;
using game1.Model;
using game1.View;
using game1.View.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace game1.Model
{
    public enum ItemType
    {
        sword, shield, heal
    }
    public class Item : GameObject
    {

        public string TextureName { get; set; }

        public SpriteFont Font { get; set; }

        public string Text { get; set; }

        public int Charge { get; set; }

        public int MaxCharge { get; set; }
        public int ChargePerElapsed { get; set; }

        public ItemType ItemType { get; set; }
        public bool IsEnabled { get; set; }

        public bool IsItOwned { get; set; }

        public int Cost { get; set; }

        public int currentTime { get; set; } = 0;// сколько времени прошло
        public int period { get; set; } = 100; // частота обновления в миллисекундах
        public Item()
        {
            IsEnabled = true;
            Text = "";
            MaxCharge = 100;
            ChargePerElapsed = 10;

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Box, Color);
            spriteBatch.DrawString(Font, Text, 
                new Vector2(Box.X, Box.Y), Color.Purple);

            if (IsEnabled && !IsItOwned)
            {
                spriteBatch.DrawString(Font, Cost.ToString(),
                new Vector2(Box.X, Box.Y), Color.Red);
            }
        }

        public override void Update(GameTime gameTime, Game1 game)
        {   

            if (IsEnabled)
            {
                currentTime += gameTime.ElapsedGameTime.Milliseconds;
                if (currentTime > period)
                {
                    currentTime -= period;
                    Charge += ChargePerElapsed;
                    Text = Charge.ToString();
                    if (Charge >= MaxCharge)
                    {
                        Charge = 0;
                        Act(gameTime, game);
                    }
                }
                
            }
        }
        public void Act(GameTime gameTime, Game1 game)
        {
            game.gameState.CurrentEnemy.HealthPoints -= 1;
        }
        public void ShopUpdate(GameTime gameTime, Game1 game)
        {
            if (IsEnabled)
            {
                if (InputManager.Hover(Box))
                {
                    Color = Color.Yellow;
                    if (InputManager.LeftClicked)
                    {   if (game.shopState.Money.MoneyValue >= Cost)
                        {
                            game.shopState.Money.MoneyValue -= Cost;
                            IsEnabled = false;
                            game.gameState.Player.PlayerArsenal.Items.Add(new Item()
                            {
                                Texture = this.Texture,
                                ItemType = ItemType,
                                TextureName = TextureName,
                                IsEnabled = true,
                                IsItOwned = true,
                                Font = this.Font,
                                ChargePerElapsed = ChargePerElapsed
                            });
                            Color = Color.Red;
                        }
                    }
                }
                else
                {
                    Color = Color.White;
                }
            }
        }
    }
}