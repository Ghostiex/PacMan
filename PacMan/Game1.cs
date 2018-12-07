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
        
        
        //Map Container
        string[,] tiles;


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

            
            //Working correctly
            LoadMap();
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


            gameManager.Update();
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

            #region Testregion4

            spriteBatch.Draw(cubeTex, cubeRect, Color.White);

            #endregion  

            spriteBatch.End();

            gameManager.Draw(spriteBatch);
            base.Draw(gameTime);
        }

        private void LoadMap()
        {
            string[] line = File.ReadAllLines("map1.txt");
            tiles = new string[line[0].Length, line.Length];
            for (int j = 0; j < line.Length; j++)
            {
                for (int i = 0; i < line[0].Length; i++)
                {
                    tiles[i, j] = line[j].Substring(i, 1);
                    //To debug map position
                    //Console.WriteLine(i + " " + j + "=" + tiles[i, j]);
                }
            }
        }

        private void SetWindowSize()
        {
            graphics.PreferredBackBufferWidth = tiles.GetLength(0) * 50;
            graphics.PreferredBackBufferHeight = tiles.GetLength(1) * 50;
            graphics.ApplyChanges();
        }
    }
}
