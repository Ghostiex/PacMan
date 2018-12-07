using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PacMan
{
    class Tile
    {
        public Vector2 position { get; private set; }
        private Texture2D texture;
        private string tileType;
        /// <summary>
        /// Create a tile (collision with ghosts and Pacman). These are the walls and also the berries & points.
        /// </summary>
        /// <param name="positionIn">The top left position of the tile</param>
        /// <param name="tileType">The char of the tile - will determine it's type</param>
        public Tile(Vector2 positionIn, string tileTypeIn)
        {
            position = positionIn;
            tileType = tileTypeIn;

            switch (tileType)
            {
                case "X":
                    //Standard tile
                    
                    //Set texture here?
                    break;
                case "O":
                    //Background tile

                    break;
                case "P":
                    //This is a player why is he here
                    break;

                default:
                    Console.WriteLine("Ceci n'est pas un tile");
                    break;
            }
        }
    }
}
