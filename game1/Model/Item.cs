using game1.Controller;
using game1.Model;
using game1.View;
using game1.View.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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

        public int Charge { get; set; } // процент заряда

        public Texture2D ChargeBarTexture { get; set; }
        public int ChargePerPeriod { get; set; } // заряд за 1 интервал

        public ItemType ItemType { get; set; }
        public bool IsEnabled { get; set; }

        public bool IsItOwned { get; set; }

        public int Cost { get; set; } 

        public int currentTime { get; set; } = 0;// сколько времени прошло
        public int period { get; set; } = 50; // частота обновления в миллисекундах
        public Item()
        {
            IsEnabled = true;;
            ChargePerPeriod = 5;

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            DrawFrame(spriteBatch, Charge / 5);

            DrawBarFrame(spriteBatch, Charge / 5);
            
            if (IsEnabled && !IsItOwned)
            {
                spriteBatch.DrawString(Font, Cost.ToString(),
                new Vector2(Box.X, Box.Y), Color.Yellow);
            }
        }
        public void DrawFrame(SpriteBatch spriteBatch, int frame)
        {
            int FrameWidth = Texture.Width / 20;


            Rectangle sourcerect = new Rectangle(FrameWidth * frame, 0,
                FrameWidth, Texture.Height);

            spriteBatch.Draw(Texture, Box, sourcerect, Color);
        }
        public void DrawBarFrame(SpriteBatch spriteBatch, int frame)
        {
            int FrameWidth = ChargeBarTexture.Width / 20;
            
            
            Rectangle sourcerect = new Rectangle(FrameWidth * frame, 0,
                FrameWidth, ChargeBarTexture.Height);

            spriteBatch.Draw(ChargeBarTexture, new Vector2(Box.X, Box.Y + 200), 
                sourcerect, Color.White, 0f, new Vector2(0, 0), new Vector2(1.5f, 1),
                SpriteEffects.None, 0f);
        }
        public override void Update(GameTime gameTime, Game1 game)
        {
            if (!game.gameState.IsPaused)
            {
                if (IsEnabled)
                {
                    currentTime += gameTime.ElapsedGameTime.Milliseconds;
                    if (currentTime > period)
                    {
                        currentTime -= period;
                        Charge += ChargePerPeriod;
                        
                        if (Charge >= 100)
                        {
                            Charge = 0;
                            Act(gameTime, game);
                        }
                    }

                }
            }
        }
        public void Act(GameTime gameTime, Game1 game)
        {
            switch (ItemType)
            {
                case ItemType.sword: 
                    game.gameState.CurrentEnemy.HealthPoints -= 1;
                    break;
                case ItemType.shield:
                    game.gameState.Player.ShieldPoints += 1;
                    break;
            }
            
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
                                Texture = Texture,
                                ChargeBarTexture = ChargeBarTexture,
                                ItemType = ItemType,
                                TextureName = TextureName,
                                IsEnabled = true,
                                IsItOwned = true,
                                Font = Font,
                                ChargePerPeriod = ChargePerPeriod
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