using game1.Controller;
using game1.Model;
using game1.View.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//using SharpDX.Direct2D1;
using SharpDX.Direct3D9;
using System.Collections.Generic;

//using System.Drawing;

namespace game1.View;

public class Game1 : Game
{

    public State CurrentState { get; set; }
    public State NextState { get; set; }

    public StartMenuState StartMenuState { get; set; }

    public GameState GameState { get; set; }

    public ShopState ShopState { get; set; }



    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public SpriteFont BaseFont;


    public Game1()
    {

        _graphics = new GraphicsDeviceManager(this);

        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        

        _graphics.PreferredBackBufferWidth = 2000;
        _graphics.PreferredBackBufferHeight = 1500;

        
        _graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;

        
    }
    public void ChangeState(State state)
    {
        NextState = state;
    }
    protected override void Initialize()
    {
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        StartMenuState = new StartMenuState(this, Content, _graphics.GraphicsDevice);
        GameState = new GameState(this, Content, _graphics.GraphicsDevice);
        ShopState = new ShopState(this, Content, _graphics.GraphicsDevice);

        CurrentState = StartMenuState;

        _spriteBatch = new SpriteBatch(GraphicsDevice);
       
    }
    
    protected override void Update(GameTime gameTime)
    {
        InputManager.Update();

        if(NextState != null)
        {
            CurrentState = NextState;
            NextState = null;
        }

        CurrentState.Update(gameTime, this);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        CurrentState.Draw(gameTime, _spriteBatch);
        base.Draw(gameTime);
    }
}
