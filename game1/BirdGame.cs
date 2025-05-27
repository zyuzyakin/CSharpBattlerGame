using game1.Controller;
using game1.Model;
using game1.States;
using game1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace game1;

public class BirdGame : Game
{
    private State currentState;
    private State nextState;

    public StartMenuState startMenuState { get; set; }

    public MapState mapState { get; set; }

    public GameState gameState { get; set; }

    public ShopState shopState { get; set; }
    public ChestState chestState { get; set; }

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public BirdGame()
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
    public void ChangeStateToChest()
    {
        chestState.ChestGrid = new ChestGridView();
        chestState.ChestGrid.LoadContent(Content);

        ChangeState(chestState);
    }
    public void ChangeStateToGame(EnemyType enemyType)
    {
        ChangeState(gameState);
        gameState.IsPaused = false;
        gameState.PauseButton.IsEnabled = true;
        gameState.BackToMapButton.IsEnabled = false;
        gameState.CurrentEnemy = new EnemyView(enemyType);
        gameState.Player.ShieldPoints = 0;
        gameState.CurrentEnemy.LoadContent(Content);
    }
    public void ChangeStateToShop()
    {
        ChangeState(shopState);
        shopState.ShopGrid = new ShopGridView();
        shopState.ShopGrid.LoadContent(Content);
    }
    public void NewGame()
    {
        startMenuState = new StartMenuState(this, Content, _graphics.GraphicsDevice);
        mapState = new MapState(this, Content, _graphics.GraphicsDevice);
        gameState = new GameState(this, Content, _graphics.GraphicsDevice);
        shopState = new ShopState(this, Content, _graphics.GraphicsDevice);
        chestState = new ChestState(this, Content, _graphics.GraphicsDevice);
    }
    protected override void LoadContent()
    {
        NewGame();

        currentState = startMenuState;

        _spriteBatch = new SpriteBatch(GraphicsDevice);
    }
    
    protected override void Update(GameTime gameTime)
    {
        MouseInputManager.Update();

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

    public void StartGame()
    {
        NewGame();
        ChangeState(mapState);
    }
    public void RestartGame()
    {
        NewGame();
        ChangeState(startMenuState);
    }
    public  void CombineItems()
        => gameState.PlayerArsenal.CombineItems(this);
    public void BackToMap() => ChangeState(mapState);
    public  void PauseUnpauseGame()
        => gameState.IsPaused = !gameState.IsPaused;

    public  void UpdateMap()
    {
        mapState.Map = new MapView();
        mapState.Map.LoadContent(Content);
    }
}
