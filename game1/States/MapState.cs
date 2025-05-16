
using game1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace game1.States;

public class MapState : State
{
    public MapView Map { get; set; }
    public ButtonView UpdateMapButton { get; set; }
    private Texture2D description;

    public MapState(BirdGame game, ContentManager content, GraphicsDevice graphicsDevice) 
        : base(game, content, graphicsDevice)
    {
        Background = content.Load<Texture2D>("backgrounds/bgshop");
        description = content.Load<Texture2D>("mapIcons/legend");

        Map = new MapView();

        UpdateMapButton = new ButtonView()
        {
            Box = new Rectangle(140 * k, 60 * k, 50 * k, 15 * k),
            Text = "ОБНОВИТЬ!",
            OnClick = Game.UpdateMap
        };

        Map.LoadContent(content);
        UpdateMapButton.LoadContent(content);
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();

        spriteBatch.Draw(Background, new Rectangle(0, 0, 200 * k, 150 * k), Color.White);
        spriteBatch.Draw(description, new Rectangle(130 * k, 80 * k, 60 * k, 60 * k), Color.White);
        
        Map.Draw(spriteBatch);
        UpdateMapButton.Draw(spriteBatch);
        Game.shopState.Money.Draw(spriteBatch);

        spriteBatch.End();
    }
    
    public override void Update(GameTime gameTime, BirdGame game)
    {
        Map.Update(gameTime, game);
        UpdateMapButton.Update(gameTime, game);
        Game.shopState.Money.Update(gameTime, game);
    }
}
