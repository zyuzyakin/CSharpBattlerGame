﻿using game1.Model;
using game1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace game1.States;

public class ChestState : State
{
    public AnimatedTexture PlayerTexture { get; set; }
    public MoneyView Money { get; set; }
    public ButtonView BackToMapButton { get; set; }
    public ButtonView CombineItemsButton { get; set; }

    public ChestGridView ChestGrid { get; set; }

    public ChestState(BirdGame game, ContentManager content, GraphicsDevice graphicsDevice) 
        : base(game, content, graphicsDevice)
    {
        Background = content.Load<Texture2D>("backgrounds/bgshop");
        PlayerTexture = new AnimatedTexture(20, 24, "playershopsheet",
            new Rectangle(160 * k, 40 * k, 40 * k, 40 * k));


        ChestGrid = new ChestGridView();
        Money = new MoneyView();

        CombineItemsButton = new ButtonView()
        {
            Box = new Rectangle(140 * k, 90 * k, 50 * k, 15 * k),
            Text = "СОЕДИНИТЬ!",
            OnClick = Game.CombineItems
        };
        BackToMapButton = new ButtonView()
        {
            Box = new Rectangle(140 * k, 130 * k, 50 * k, 15 * k),
            Text = "НАЗАД!",
            OnClick = Game.BackToMap
        };

        BackToMapButton.LoadContent(content);
        PlayerTexture.LoadContent(content);
        CombineItemsButton.LoadContent(content);
        Money.LoadContent(content);
        ChestGrid.LoadContent(content);
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();

        spriteBatch.Draw(Background, new Rectangle(0, 0, 200 * k, 150 * k), 
            Color.White);
        
        Game.gameState.PlayerArsenal.Draw(spriteBatch);

        ChestGrid.Draw(spriteBatch);

        BackToMapButton.Draw(spriteBatch);
        PlayerTexture.Draw(spriteBatch);
        CombineItemsButton.Draw(spriteBatch);
        Money.Draw(spriteBatch);

        spriteBatch.End();
    }

    public override void Update(GameTime gameTime, BirdGame game)
    {
        ChestGrid.Update(gameTime, game);

        BackToMapButton.Update(gameTime, game);
        PlayerTexture.Update(gameTime, game);
        CombineItemsButton.Update(gameTime, game);
        Money.Update(gameTime, game);
    }

}
