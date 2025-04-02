using game1.Controller;
using game1.Model;
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
    public Player Player { get; private set; }
    public Enemy Enemy { get; private set; }
    public ItemGrid ItemGrid { get; private set; }

    public EndTurnButton EndTurnButton { get; private set; }


    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public SpriteFont BaseFont;

    Vector2 baseScreenSize = new Vector2(2000, 1500);
    private Matrix globalTransformation;
    int backbufferWidth, backbufferHeight;

    public Game1()
    {
        Player = new Player();
        ItemGrid = new ItemGrid();
        Enemy = new Enemy();
        EndTurnButton = new EndTurnButton();

        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        

        _graphics.PreferredBackBufferWidth = 2000;
        _graphics.PreferredBackBufferHeight = 1500;

        
        _graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;


    }

    protected override void Initialize()
    {
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        BaseFont = Content.Load<SpriteFont>("Fonts/Hud");

        EndTurnButton.Font = BaseFont;
        Player.Font = BaseFont;
        Enemy.Font = BaseFont;


        _spriteBatch = new SpriteBatch(GraphicsDevice);


        EndTurnButton.Texture = Content.Load<Texture2D>("Buttons/endturn");
        Player.Texture = Content.Load<Texture2D>("player");
        
        Enemy.Texture = Content.Load<Texture2D>("enemies/ptichka");
        

        foreach (var item in ItemGrid.Items)
        {
            item.Texture = Content.Load<Texture2D>("items/sword");
        }
        

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
        Player.Update(gameTime);
        if (backbufferHeight != GraphicsDevice.PresentationParameters.BackBufferHeight ||
                backbufferWidth != GraphicsDevice.PresentationParameters.BackBufferWidth)
        {
            ScalePresentationArea();
        }
        

       

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);


        _spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, globalTransformation);

        Enemy.Draw(_spriteBatch);
        Player.Draw(_spriteBatch);
        ItemGrid.Draw(_spriteBatch);
        EndTurnButton.Draw(_spriteBatch);
        _spriteBatch.End();

        

        base.Draw(gameTime);
    }
}
