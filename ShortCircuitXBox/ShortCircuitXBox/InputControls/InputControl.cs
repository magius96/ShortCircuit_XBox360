using Microsoft.Xna.Framework;

namespace ShortCircuit.InputControls
{
    public class InputControl
    {
        public Color BackgroundColor { get; set; }
        public Color ForegroundColor { get; set; }
        public string Text { get; set; }
        public Color FontColor { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(GameTime gameTime, int x, int y){}
    }
}
