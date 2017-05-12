using System;
using Microsoft.Xna.Framework;
using ShortCircuit.GameInput;

namespace ShortCircuit.InputControls
{
    class LabelControl : InputControl
    {
        public event InputControlActivated Activate;

        public override void Update(GameTime gameTime)
        {
            try
            {
                if (InputManager.GameButtonPressed(GameButtons.Accept))
                {
                    if (Activate != null) Activate(this);
                }
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        public override void Draw(GameTime gameTime, int x, int y)
        {
            try
            {
                ScreenManager.Sprites.DrawString(ScreenManager.Fonts[GameFonts.GameFont], Text, new Vector2(x, y),
                                                 FontColor);
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }
    }
}
