using game1.Model;
using game1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace game1.States;

public class GameState : State
{   
    public AnimatedTexture PlayerTexture { get; set; }
    public PlayerView Player { get; private set; }
    public PlayerArsenalView PlayerArsenal { get; private set; }
    public EnemyView CurrentEnemy { get; set; }
    public bool IsPaused {get;set;}
    public ButtonView BackToMapButton { get; private set; }
    public ButtonView PauseButton { get; set; }
    public ButtonView RestartGameButton { get; set; }

    public GameState(BirdGame game, ContentManager content, GraphicsDevice graphicsDevice) 
        : base(game, content, graphicsDevice)
    {
        Background = content.Load<Texture2D>("backgrounds/bgbattle");
        PlayerTexture = new AnimatedTexture(20, 24, "playerbattlesheet", 
            new Rectangle(10 * k, 80 * k, 40 * k, 40 * k));
        
        Player = new PlayerView();
        PlayerArsenal = new PlayerArsenalView();

        RestartGameButton = new ButtonView()
        {
            Box = new Rectangle(70 * k, 90 * k, 70 * k, 40 * k),
            Text = "ВЫ ПРОИГРАЛИ!\n\n\nНОВАЯ ИГРА!",
            IsEnabled = false,
            OnClick = Game.RestartGame
        };

        BackToMapButton = new ButtonView()
        {
            Box = new Rectangle(140 * k, 30 * k, 50 * k, 15 * k),
            Text = "НАЗАД!",
            IsEnabled = false,
            OnClick = Game.BackToMap

        };

        PauseButton = new ButtonView()
        {
            Box = new Rectangle(140 * k, 10 * k, 50 * k, 15 * k),
            Text = "ПАУЗА!",
            OnClick = Game.PauseUnpauseGame
        };

        

        Player.LoadContent(content);
        PlayerArsenal.LoadContent(content);
        BackToMapButton.LoadContent(content);
        PauseButton.LoadContent(content);
        RestartGameButton.LoadContent(content);
        PlayerTexture.LoadContent(content);
        
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();

        spriteBatch.Draw(Background, new Rectangle(0, 0, 200 * k, 150 * k), Color.White);

        Player.Draw(spriteBatch);
        PlayerArsenal.Draw(spriteBatch);
        BackToMapButton.Draw(spriteBatch);
        PauseButton.Draw(spriteBatch);
        PlayerTexture.Draw(spriteBatch);
        RestartGameButton.Draw(spriteBatch);
        CurrentEnemy.Draw(spriteBatch);

        spriteBatch.End();
    }

    public override void Update(GameTime gameTime, BirdGame game)
    {
        CurrentEnemy.Update(gameTime, game);

        Player.Update(gameTime, game);
        PlayerArsenal.Update(gameTime, game);
        BackToMapButton.Update(gameTime, game);
        PauseButton.Update(gameTime, game);
        PlayerTexture.Update(gameTime, game);
        RestartGameButton.Update(gameTime, game);
    }
}
