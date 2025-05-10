using game1.Controller;
using game1.Model;
using game1.View.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

//using System.Drawing;

namespace game1.View;

public class Game1 : Game
{

    public State currentState;
    public State nextState;

    public StartMenuState startMenuState { get; set; }

    public MapState mapState { get; set; }

    public GameState gameState { get; set; }

    public ShopState shopState { get; set; }
    public ChestState chestState { get; set; }




    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public SpriteFont BaseFont;


    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);

        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        

        _graphics.PreferredBackBufferWidth = 200 * GameObject.k;
        _graphics.PreferredBackBufferHeight = 150 * GameObject.k;

        
        _graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;

    }
    public void ChangeState(State state)
    {
        nextState = state;
    }
    public void NewGame()
    {
        mapState = new MapState(this, Content, _graphics.GraphicsDevice);
        gameState = new GameState(this, Content, _graphics.GraphicsDevice);
        shopState = new ShopState(this, Content, _graphics.GraphicsDevice);
        chestState = new ChestState(this, Content, _graphics.GraphicsDevice);
    }
    protected override void LoadContent()
    {
        startMenuState = new StartMenuState(this, Content, _graphics.GraphicsDevice);
        NewGame();


        currentState = startMenuState;

        _spriteBatch = new SpriteBatch(GraphicsDevice);
    }
    
    protected override void Update(GameTime gameTime)
    {
        InputManager.Update();

        if(nextState != null)
        {
            currentState = nextState;
            nextState = null;
        }

        currentState.Update(gameTime, this);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        currentState.Draw(gameTime, _spriteBatch);
        base.Draw(gameTime);
    }
}
