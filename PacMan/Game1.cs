using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace PacMan
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;



        //Testing out some programming with simple shapes first
        Vector2 cubePos;
        int cubeSizeX, cubeSizeY;
        Texture2D cubeTex;
        Rectangle cubeRect;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            cubePos = new Vector2(20, 20);
            cubeSizeX = 50;
            cubeSizeY = 50;

            //Making a rectangle with texture
            cubeTex = new Texture2D(graphics.GraphicsDevice, 80, 80);
            Color[] cubeTexData = new Color[80 * 80];
            for (int i = 0; i < cubeTexData.Length; i++) cubeTexData[i] = Color.Chocolate;
            cubeTex.SetData(cubeTexData);

            cubeRect = new Rectangle((int)cubePos.X,(int)cubePos.Y,cubeSizeX, cubeSizeY);


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

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState keyState = Keyboard.GetState();
            KeyboardState lastKeyState = keyState;


            cubeRect.X = keyState.IsKeyDown(Keys.Right) ? cubeRect.X++ : cubeRect.X = cubeRect.X + 0;


            if (keyState.IsKeyDown(Keys.Right))
            {
                cubeRect.X = cubeRect.X + 5;
                Debug.WriteLine("Moving cube");
            }

            //if (keyState.IsKeyDown(Keys.Right) &&) { }

            
            
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
            spriteBatch.Draw(cubeTex, cubeRect, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
