using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace ShortCircuitLib
{
    public class GameObject
    {
        public Coordinates2D Position = new Coordinates2D();
        public Coordinates2D Size = new Coordinates2D();

        public virtual void Load(){}

        public virtual void Update(GameTime gameTime){}

        public virtual void Draw(GameTime gameTime) { }

        public virtual void Unload()
        {
            Position = null;
            Size = null;
        }
    }
}
