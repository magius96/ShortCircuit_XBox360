using Microsoft.Xna.Framework;


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
