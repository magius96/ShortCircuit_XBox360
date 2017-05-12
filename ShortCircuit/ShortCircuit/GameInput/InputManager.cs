using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ShortCircuit.GameInput
{
    public static class InputManager
    {
        private static GamePadState _previousGamepadState = new GamePadState();
        private static GamePadState _currentGamepadState = new GamePadState();
        private static KeyboardState _previousKeyboardState = new KeyboardState();
        private static KeyboardState _currentKeyboardState = new KeyboardState();
        public static PlayerIndex LastPlayer = PlayerIndex.One;
        private static int waitValue = 0;

        public static void Initialize()
        {
            waitValue = 0;
        }

        public static void Update()
        {
            waitValue++;
                _previousGamepadState = _currentGamepadState;
                _currentGamepadState = GamePad.GetState(PlayerIndex.One);
                _previousKeyboardState = _currentKeyboardState;
                _currentKeyboardState = Keyboard.GetState(PlayerIndex.One);
        }

        public static bool GameButtonPressed(GameButtons button)
        {
            var keyboard = GetKeyboardButtons(button);
            var gamepad = GetGamePadButtons(button);
            foreach (Keys btn in keyboard)
            {
                if (KeyPressed(btn))
                {
                    waitValue = 0;
                    return true;
                }
            }
            foreach (Buttons btn in gamepad)
            {
                if (ButtonPressed(btn))
                {
                    waitValue = 0;
                    return true;
                }
            }
            return false;
        }
        public static bool GameButtonReleased(GameButtons button)
        {
            var keyboard = GetKeyboardButtons(button);
            var gamepad = GetGamePadButtons(button);
            foreach (Keys btn in keyboard)
            {
                if (KeyReleased(btn))
                {
                    waitValue = 0;
                    return true;
                }
            }
            foreach (Buttons btn in gamepad)
            {
                if (ButtonReleased(btn))
                {
                    waitValue = 0;
                    return true;
                }
            }
            return false;
        }
        public static bool GameButtonHeld(GameButtons button)
        {
            var keyboard = GetKeyboardButtons(button);
            var gamepad = GetGamePadButtons(button);
            foreach (Keys btn in keyboard)
            {
                if (KeyHeld(btn))
                {
                    waitValue = 0;
                    return true;
                }
            }
            foreach (Buttons btn in gamepad)
            {
                if (ButtonHeld(btn))
                {
                    waitValue = 0;
                    return true;
                }
            }
            return false;
        }
        public static bool GameButtonPressedOrHeld(GameButtons button)
        {
            if (waitValue > DataManager.AutoRepeatDelay)
            {
                if (GameButtonPressed(button) || GameButtonHeld(button)) return true;
            }
            return false;
        }

        public static bool AnyInput()
        {
            try
            {
                var lst = Utils.GetEnumValues<GameButtons>();
                if (lst.Any(GameButtonPressed))
                {
                    return true;
                }
                return false;
            }
            catch (Exception exception)
            {
                ErrorLog.Add(exception);
                return false;
            }
        }

        #region Keyboard
        public static bool KeyPressed(Keys key)
        {
            return _previousKeyboardState.IsKeyUp(key) && _currentKeyboardState.IsKeyDown(key);
        }
        private static bool KeyReleased(Keys key)
        {
            return _previousKeyboardState.IsKeyDown(key) && _currentKeyboardState.IsKeyUp(key);
        }
        private static bool KeyHeld(Keys key)
        {
            return _previousKeyboardState.IsKeyDown(key) && _currentKeyboardState.IsKeyDown(key);
        }
        private static List<Keys> GetKeyboardButtons(GameButtons button)
        {
            var toReturn = new List<Keys>();

            switch (button)
            {
                case GameButtons.Down:
                    toReturn.Add(Keys.Down);
                    break;
                case GameButtons.Accept:
                    toReturn.Add(Keys.Enter);
                    break;
                case GameButtons.Left:
                    toReturn.Add(Keys.Left);
                    break;
                case GameButtons.Right:
                    toReturn.Add(Keys.Right);
                    break;
                case GameButtons.Up:
                    toReturn.Add(Keys.Up);
                    break;
                case GameButtons.Menu:
                    toReturn.Add(Keys.F1);
                    break;
                case GameButtons.Decline:
                    toReturn.Add(Keys.Escape);
                    break;
                case GameButtons.Restart:
                    toReturn.Add(Keys.F1);
                    break;
            }
    
            return toReturn;
        }
        #endregion

        #region GamePad
        private static bool ButtonPressed(Buttons button)
        {
            return _previousGamepadState.IsButtonUp(button) && _currentGamepadState.IsButtonDown(button);
        }
        private static bool ButtonReleased(Buttons button)
        {
            return _previousGamepadState.IsButtonDown(button) && _currentGamepadState.IsButtonUp(button);
        }
        private static bool ButtonHeld(Buttons button)
        {
            return _previousGamepadState.IsButtonDown(button) && _currentGamepadState.IsButtonDown(button);
        }
        private static List<Buttons> GetGamePadButtons(GameButtons button)
        {
            var toReturn = new List<Buttons>();

            switch (button)
            {
                case GameButtons.Down:
                    toReturn.Add(Buttons.LeftThumbstickDown);
                    toReturn.Add(Buttons.DPadDown);
                    toReturn.Add(Buttons.RightThumbstickDown);
                    break;
                case GameButtons.Accept:
                    toReturn.Add(Buttons.A);
                    break;
                case GameButtons.Left:
                    toReturn.Add(Buttons.LeftThumbstickLeft);
                    toReturn.Add(Buttons.DPadLeft);
                    toReturn.Add(Buttons.RightThumbstickLeft);
                    break;
                case GameButtons.Right:
                    toReturn.Add(Buttons.LeftThumbstickRight);
                    toReturn.Add(Buttons.DPadRight);
                    toReturn.Add(Buttons.RightThumbstickRight);
                    break;
                case GameButtons.Up:
                    toReturn.Add(Buttons.LeftThumbstickUp);
                    toReturn.Add(Buttons.DPadUp);
                    toReturn.Add(Buttons.RightThumbstickUp);
                    break;
                case GameButtons.Menu:
                    toReturn.Add(Buttons.Start);
                    break;
                case GameButtons.Decline:
                    toReturn.Add(Buttons.B);
                    toReturn.Add(Buttons.Back);
                    break;
            }

            return toReturn;
        } 
        #endregion
    }
}
