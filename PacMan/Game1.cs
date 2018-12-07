using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
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

        //Create Game Manager
        GameManager gameManager;

        //Keyboard States (new, old)
        KeyboardState keyState, lastKeyState;
        
        

        //Tile Manager
        MapLoader mapLoader;


        #region Testregion
        //Testing out some programming with simple shapes first
        Vector2 cubePos;
        int cubeSizeX, cubeSizeY;
        Texture2D cubeTex;
        Rectangle cubeRect;
        #endregion

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            //Initialise gamemanager
            gameManager = new GameManager(graphics, Content);
            mapLoader = new MapLoader();

            SetWindowSize();

            //Not yet done
            //DrawMap();
                       
            #region Testregion2
            cubePos = new Vector2(20, 20);
            cubeSizeX = 50;
            cubeSizeY = 50;

            //Making a rectangle with texture
            cubeTex = new Texture2D(graphics.GraphicsDevice, 80, 80);
            Color[] cubeTexData = new Color[80 * 80];
            for (int i = 0; i < cubeTexData.Length; i++) cubeTexData[i] = Color.Chocolate;
            cubeTex.SetData(cubeTexData);

            cubeRect = new Rectangle((int)cubePos.X,(int)cubePos.Y,cubeSizeX, cubeSizeY);
            #endregion

            base.Initialize();
        }


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

            //Set the current state of any key presses for the loop
            keyState = Keyboard.GetState();

            #region Testregion3
            //Single Step the cube once to the right if Key Right is pressed
            if (keyState.IsKeyDown(Keys.Right) && !lastKeyState.IsKeyDown(Keys.Right))
            {
                cubeRect.X = cubeRect.X + 5;
                Debug.WriteLine("Moving cube");
            }
            #endregion




            //Set the Last Key State to be able to press button "once"
            lastKeyState = keyState;

            mapLoader.Update(gameTime);
            gameManager.Update(gameTime);
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
            mapLoader.Draw(spriteBatch);
            #region Testregion4

            spriteBatch.Draw(cubeTex, cubeRect, Color.White);

            #endregion

            gameManager.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        

        /// <summary>
        /// Set the current size of the game window depending on the width and heigh wanted
        /// </summary>
        /// <param name="width">The width in pixels, will be multiplied by 50</param>
        /// <param name="height">The height in pixels, will be multiplied by 50</param>
        public void SetWindowSize()
        {
            Vector2 currentMapSize = mapLoader.currentMapSize;
            graphics.PreferredBackBufferWidth = (int)currentMapSize.X * 50;
            graphics.PreferredBackBufferHeight = (int)currentMapSize.Y * 50;
            graphics.ApplyChanges();
        }
    }
}
