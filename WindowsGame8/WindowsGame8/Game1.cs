using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WarGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D territory;
        State GameState;
        MouseState oldState;
        KeyboardState oldKey;

        public enum State{
            Menu,
            Playing,
            Pause
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            GameState = State.Menu;
            this.IsMouseVisible = true;
            TerrainCreation.Initialize();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            territory = Content.Load<Texture2D>("Territory");
            if (GameState == State.Menu)
            {
                Menu.load(Content, graphics);
            }
            else if (GameState == State.Pause)
            {
                //load Pause Menu
            }
            else
            {
                TerrainCreation.loadContent(Content);
            }
        }

        protected override void UnloadContent()
        {
            GC.Collect();
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState key = Keyboard.GetState();
            if (GameState == State.Playing)
            {
                if (key.IsKeyDown(Keys.Escape) && oldKey.IsKeyDown(Keys.Escape) == false)
                {
                    GameState = State.Pause;
                    UnloadContent();
                    LoadContent();
                }
            }
            else if (GameState == State.Pause)
            {
                if (key.IsKeyDown(Keys.Escape) && oldKey.IsKeyDown(Keys.Escape) == false)
                {
                    GameState = State.Playing;
                    UnloadContent();
                    LoadContent();
                }
            }else if(GameState == State.Menu){
                if (key.IsKeyDown(Keys.Escape) && oldKey.IsKeyDown(Keys.Escape) == false)
                    Exit();
            }

            oldKey = key;
            // TODO: Add your update logic here
            MouseState mouse = Mouse.GetState();
            if (mouse.LeftButton == ButtonState.Pressed && oldState.LeftButton != ButtonState.Pressed)
            {
                if (Menu.isMouseOnButton(mouse))
                {
                    GameState = State.Playing;
                    UnloadContent();
                    LoadContent();
                }
            }

            oldState = mouse;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            if (GameState == State.Menu)
            {
                Menu.MenuDraw(spriteBatch);
            }
            else if (GameState == State.Playing)
            {
                TerrainCreation.drawBoard(spriteBatch);
            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
