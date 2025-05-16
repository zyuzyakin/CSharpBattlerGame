using game1.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace game1.States;

public class State : GameObject
{
    public List<GameObject> StateElements { get; set; }
    public Texture2D Background { get; set; }
    public BirdGame Game { get; set; }
    public ContentManager Content { get; set; }
    public GraphicsDevice GraphicDevice { get; set; }


    public State(BirdGame game, ContentManager content, GraphicsDevice graphicsDevice)
    {
        StateElements = new List<GameObject>();
        Game = game;
        Content = content;
        GraphicDevice = graphicsDevice;
    }

    public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    { 

    }
}
