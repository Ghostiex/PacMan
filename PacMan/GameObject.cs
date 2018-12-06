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
    class GameObject
    {
        SpriteBatch sb;
        Vector2 pos;
        public GameObject(Vector2 position)
        {
            this.pos = position;
        }




        protected void Update()
        {
            
        }

        protected void Draw()
        {
            sb.Begin();
            
            sb.End();
        }
    }
}
