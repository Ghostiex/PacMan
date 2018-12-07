using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PacMan
{
    class MapLoader
    {
        //Initialise Variables in Map Loader
        public Vector2 currentMapSize { get; private set; }
        public string[,] tiles { get; private set; }
        private int tileNrX, tileNrY;
        public Tile[,] tileArray { get; private set; }

        public MapLoader()
        {
            LoadMap();


        }

        public void Update(GameTime gt)
        {

        }

        public void Draw(SpriteBatch sb)
        {
            DrawTiles();
        }

        private void LoadMap()
        {
            string[] line = File.ReadAllLines("map1.txt");

            //Map array
            tiles = new string[line[0].Length, line.Length];

            //Load each character in the file into the array as individual strings
            for (int j = 0; j < line.Length; j++)
            {
                for (int i = 0; i < line[0].Length; i++)
                {
                    tiles[i, j] = line[j].Substring(i, 1);
                    
                    if (tiles[i, j] != "X")
                    {
                        AddObject(tiles[i,j]);
                    }
                    else { tileArray[i, j] = new Tile(new Vector2(i * 50, j * 50), tiles[i, j]); }
                    
                    //To debug map position
                    //Console.WriteLine(i + " " + j + "=" + tiles[i, j]);
                }
            }
            tileNrX = tiles.GetLength(0);
            tileNrY = tiles.GetLength(1);
            //Set the size of the current map
            currentMapSize = new Vector2(tileNrX, tileNrY);
        }

        private void DrawTiles()
        {
            for (int j = 0; j < tileNrY; j++)
            {
                for (int i = 0; i < tileNrX; i++)
                {
                    //draw the tiles depending on how close they are to other tiles


                }
            }
        }

        private void AddObject(string type)
        {
            switch (type)
            {
                case "P":
                    //Add Pacman
                    break;
                case "C":
                    //add a Cherry
                    break;
                case "D":
                    //add a Dot
                    break;
                case "G":
                    //add Ghost Spawner
                    break;
                case "S":
                    //Add shortcut "teleport"
                    break;

                default:
                    //If it doesn't have a proper string
                    Console.Write("Something went wrong loading the map");
                    break;
            }
        }
        
    }
}
