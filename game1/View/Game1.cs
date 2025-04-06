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

    private State _currentState;
    private State _nextState;


    public Player Player { get; private set; }
    public Money Money { get; private set; }
    public ItemGrid ItemGrid { get; private set; }
    public Enemy CurrentEnemy { get; private set; }


    public StartMenuState startMenuState { get; set; }

    public GameState gameState { get; set; }

    public ShopState shopState { get; set; }



    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public SpriteFont BaseFont;

    Vector2 baseScreenSize = new Vector2(2000, 1500);
    private Matrix globalTransformation;
    int backbufferWidth, backbufferHeight;

    public Game1()
    {

        _graphics = new GraphicsDeviceManager(this);

        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        

        _graphics.PreferredBackBufferWidth = 2000;
        _graphics.PreferredBackBufferHeight = 1500;

        
        _graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;

        Player = new Player();
        ItemGrid = new ItemGrid();
        CurrentEnemy = new Enemy();

    }
    public void ChangeState(State state)
    {
        _nextState = state;
    }
    protected override void Initialize()
    {
        
        base.Initialize();
    }

    protected override void LoadContent()
    {   
        startMenuState = new StartMenuState(this, Content, _graphics.GraphicsDevice);
        gameState = new GameState(this, Content, _graphics.GraphicsDevice);

        _currentState = startMenuState;

        _spriteBatch = new SpriteBatch(GraphicsDevice);


        ScalePresentationArea();
       
    }
    public void ScalePresentationArea()
    {
        //Work out how much we need to scale our graphics to fill the screen
        backbufferWidth = GraphicsDevice.PresentationParameters.BackBufferWidth;
        backbufferHeight = GraphicsDevice.PresentationParameters.BackBufferHeight;
        float horScaling = backbufferWidth / baseScreenSize.X;
        float verScaling = backbufferHeight / baseScreenSize.Y;
        Vector3 screenScalingFactor = new Vector3(horScaling, verScaling, 1);
        globalTransformation = Matrix.CreateScale(screenScalingFactor);
    }
    protected override void Update(GameTime gameTime)
    {
        InputManager.Update();

        if(_nextState != null)
        {
            _currentState = _nextState;
            _nextState = null;
        }

        _currentState.Update(gameTime, this);

        if (backbufferHeight != GraphicsDevice.PresentationParameters.BackBufferHeight ||
                backbufferWidth != GraphicsDevice.PresentationParameters.BackBufferWidth)
        {
            ScalePresentationArea();
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        _currentState.Draw(this, gameTime, _spriteBatch, globalTransformation);
        base.Draw(gameTime);
    }
}
