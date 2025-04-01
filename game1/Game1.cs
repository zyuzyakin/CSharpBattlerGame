using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System.Collections.Generic;
//using System.Drawing;

namespace game1;

public class Item : GameObject
{
    public int HealthPoints { get; set; }

    public Item()
    {
        Position = new Vector2(600, 750);
    }
}

public class ItemGrid : GameObject
{
    public List<Item> Items { get; set; }
    public ItemGrid()
    {
        Box = new Rectangle(500, 800, 10000, 400);
        Items = new List<Item>() { new Item(), new Item(), new Item(), new Item() };
    }

    public void RecalculateItemBoxes()
    {
        
        int distance = 10;
        int itemWidth = 300;
        int itemHeight = 300;
        for (var i = 0; i < Items.Count; i++)
        {
            Items[i].Box = new Rectangle(Box.X + i * (itemWidth+distance), Box.Y, 
                itemWidth, itemHeight);
        }
    }

    public void Draw(SpriteBatch _spriteBatch)
    {
        foreach (var item in Items)
        {
            _spriteBatch.Draw(item.Texture, item.Box, item.Color);
        }
    }

}

public class Game1 : Game
{
    Player Player;
    
    ItemGrid ItemGrid;


    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Vector2 baseScreenSize = new Vector2(2000, 1500);
    private Matrix globalTransformation;
    int backbufferWidth, backbufferHeight;

    public Game1()
    {
        Player = new Player();
        
        ItemGrid = new ItemGrid();


        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        

        _graphics.PreferredBackBufferWidth = 2000;
        _graphics.PreferredBackBufferHeight = 1500;

        
        _graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;


    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        Player.Texture = Content.Load<Texture2D>("player");
        

        foreach(var item in ItemGrid.Items)
        {
            item.Texture = Content.Load<Texture2D>("items/sword");
        }
        

        ScalePresentationArea();
        // TODO: use this.Content to load your game content here
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
        System.Diagnostics.Debug.WriteLine("Screen Size - Width[" + GraphicsDevice.PresentationParameters.BackBufferWidth + "] Height [" + GraphicsDevice.PresentationParameters.BackBufferHeight + "]");
    }
    protected override void Update(GameTime gameTime)
    {
        if (backbufferHeight != GraphicsDevice.PresentationParameters.BackBufferHeight ||
                backbufferWidth != GraphicsDevice.PresentationParameters.BackBufferWidth)
        {
            ScalePresentationArea();
        }
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.CornflowerBlue);

        _spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, globalTransformation);

        _spriteBatch.Draw(Player.Texture, Player.Position, Microsoft.Xna.Framework.Color.White);

        ItemGrid.RecalculateItemBoxes();

        ItemGrid.Draw(_spriteBatch);

        _spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
