using System;
using Microsoft.Xna.Framework;
using ShortCircuit.GameInput;

namespace ShortCircuit.InputControls
{
    class SliderControl : InputControl
    {
        public int Value { get; set; }
        public int MaximumValue { get; set; }
        public int MinimumValue { get; set; }
        public int StepAmount { get; set; }

        public event InputControlValueChanged ValueChanged;

        public SliderControl()
        {
            try
            {
                Value = 0;
                MaximumValue = 100;
                MinimumValue = 0;
                StepAmount = 1;
                Width = 200;
                Height = 20;
                BackgroundColor = Color.Black;
                ForegroundColor = Color.White;
                FontColor = Color.White;
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            try
            {
                var val = Value;
                if (InputManager.GameButtonPressedOrHeld(GameButtons.Right))
                {
                    Value += StepAmount;
                }
                if (InputManager.GameButtonPressedOrHeld(GameButtons.Left))
                {
                    Value -= StepAmount;
                }
                if (Value < MinimumValue) Value = MinimumValue;
                if (Value > MaximumValue) Value = MaximumValue;
                if (val != Value && ValueChanged != null) ValueChanged(this);
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        private int GetWidth()
        {
            try
            {
                float range = MaximumValue - MinimumValue;
                float real = Value - MinimumValue;
                float percent = (real/range);
                return (int) (Width*percent);
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
                return int.MinValue;
            }
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime, int x, int y)
        {
            try
            {
                // Draw the slider's background
                ScreenManager.Sprites.DrawString(ScreenManager.Fonts[GameFonts.GameFont], Text, new Vector2(x, y),
                                                 FontColor);

                ScreenManager.Sprites.Draw(ScreenManager.Textures2D[GameTextures2D.WhiteBox],
                                           new Rectangle(x + 220, y, Width, Height), BackgroundColor);

                ScreenManager.Sprites.Draw(ScreenManager.Textures2D[GameTextures2D.WhiteBox],
                                           new Rectangle(x + 221, y + 1, GetWidth() - 2, Height - 2), ForegroundColor);
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }
    }
}
