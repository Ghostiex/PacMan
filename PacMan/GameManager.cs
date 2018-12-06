using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace PacMan
{
    class GameManager
    {
        GraphicsDeviceManager graphics;
        private ContentManager contentManager;

        public GameManager(GraphicsDeviceManager gfx, ContentManager content)
        {
            this.graphics = gfx;
            this.contentManager = content;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch sb)
        {
            sb.Begin();


            sb.End();
        }










    }
}
