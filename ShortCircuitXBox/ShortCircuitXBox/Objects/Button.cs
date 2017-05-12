using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShortCircuitLib;

namespace ShortCircuit.Objects
{
    class Button : GameObject
    {
        public ButtonTypes ButtonType { get; set; }
        public ButtonStates ButtonState { get; set; }

        public Button(ButtonTypes buttonType)
        {
            try
            {
                ButtonType = buttonType;
                ButtonState = ButtonStates.Off;
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        public void Toggle()
        {
            try
            {
                ScreenManager.Sounds[GameSounds.ButtonClick].Play();
                switch (ButtonState)
                {
                    case ButtonStates.On:
                        ButtonState = ButtonType == ButtonTypes.TwoState ? ButtonStates.Off : ButtonStates.Dim;
                        break;
                    case ButtonStates.Dim:
                        ButtonState = ButtonStates.Off;
                        break;
                    case ButtonStates.Off:
                        ButtonState = ButtonStates.On;
                        break;
                }
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        private Texture2D GetTexture()
        {
            try
            {
                if (ButtonState == ButtonStates.Off)
                    return ScreenManager.Textures2D[GameTextures2D.ButtonOff];
                else
                    return ScreenManager.Textures2D[GameTextures2D.ButtonOn];
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
                return new Texture2D(ScreenManager.GraphicsDeviceMgr.GraphicsDevice, 10, 10);
            }
        }

        private Color GetColor()
        {
            try
            {
                switch (ButtonState)
                {
                    case ButtonStates.On:
                        return ButtonType == ButtonTypes.TwoState ? Color.Blue : Color.Green;
                    case ButtonStates.Dim:
                        return Color.Yellow;
                    case ButtonStates.Off:
                        return ButtonType == ButtonTypes.TwoState ? Color.Blue : Color.Red;
                    default:
                        return Color.White;
                }
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
                return Color.White;
            }
        }

        public bool WasClicked()
        {
            return false;
            //return (InputManager.CurrentMouseState.X > Position.X &&
            //        InputManager.CurrentMouseState.Y > Position.Y &&
            //        InputManager.CurrentMouseState.X < (Position.X + Size.X) &&
            //        InputManager.CurrentMouseState.Y < (Position.Y + Size.Y));
        }

        public override void Draw(GameTime gameTime)
        {
            try
            {
                ScreenManager.Sprites.Draw(GetTexture(), new Rectangle(Position.X, Position.Y, Size.X, Size.Y),
                                           GetColor());
                base.Draw(gameTime);
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }
    }
}
