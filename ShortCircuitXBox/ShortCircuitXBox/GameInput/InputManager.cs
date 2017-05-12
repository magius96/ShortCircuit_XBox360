using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ShortCircuit.GameInput
{
    public static class InputManager
    {
        private static Dictionary<PlayerIndex, GamePadState> _previousGamepadState = new Dictionary<PlayerIndex, GamePadState>();
        private static Dictionary<PlayerIndex, GamePadState> _currentGamepadState = new Dictionary<PlayerIndex, GamePadState>();
        private static List<PlayerIndex> players = new List<PlayerIndex>();
        public static PlayerIndex LastPlayer = PlayerIndex.One;
        private static int _waitValue = 0;
        private static bool _playerLocked = false;

        public static void Initialize()
        {
            try
            {
                _waitValue = 0;
                players = Utils.GetEnumValues<PlayerIndex>();
                foreach (var index in players)
                {
                    _previousGamepadState.Add(index, new GamePadState());
                    _currentGamepadState.Add(index, new GamePadState());
                }
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }
        public static void LockPlayer()
        {
            _playerLocked = true;
        }
        public static void Update()
        {
            try
            {
                _waitValue++;

                foreach (var player in players)
                {
                    _previousGamepadState[player] = _currentGamepadState[player];
                    _currentGamepadState[player] = GamePad.GetState(player);
                }
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        public static bool GameButtonPressed(GameButtons button)
        {
            try
            {
                var gamepad = GetGamePadButtons(button);
                if (gamepad.Any(ButtonPressed))
                {
                    _waitValue = 0;
                    return true;
                }
                return false;
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
                return false;
            }
        }
        public static bool GameButtonReleased(GameButtons button)
        {
            try
            {
                var gamepad = GetGamePadButtons(button);
                if (gamepad.Any(ButtonReleased))
                {
                    _waitValue = 0;
                    return true;
                }
                return false;
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
                return false;
            }
        }
        public static bool GameButtonHeld(GameButtons button)
        {
            try
            {
                var gamepad = GetGamePadButtons(button);
                if (gamepad.Any(ButtonHeld))
                {
                    _waitValue = 0;
                    return true;
                }
                return false;
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
                return false;
            }
        }
        public static bool GameButtonPressedOrHeld(GameButtons button)
        {
            try
            {
                if (_waitValue > DataManager.AutoRepeatDelay)
                {
                    if (GameButtonPressed(button) || GameButtonHeld(button)) return true;
                }
                return false;
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
                return false;
            }
        }

        public static bool AnyInput()
        {
            try
            {
                var lst = Utils.GetEnumValues<GameButtons>();
                foreach (GameButtons buttons in lst.Where(GameButtonPressed))
                {
                    return true;
                }
                return false;
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
                return false;
            }
        }

        #region GamePad
        private static bool ButtonPressed(Buttons button)
        {
            try
            {
                foreach (var player in players)
                {
                    if (_playerLocked && player != LastPlayer) return false;
                    if (_previousGamepadState[player].IsConnected
                        && _previousGamepadState[player].IsButtonUp(button)
                        && _currentGamepadState[player].IsConnected
                        && _currentGamepadState[player].IsButtonDown(button))
                    {
                        LastPlayer = player;
                        return true;
                    }
                }
                return false;
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
                return false;
            }
        }
        private static bool ButtonReleased(Buttons button)
        {
            try
            {
                foreach (var player in players)
                {
                    if (_playerLocked && player != LastPlayer) return false;

                    if (_previousGamepadState[player].IsConnected
                        && _previousGamepadState[player].IsButtonDown(button)
                        && _currentGamepadState[player].IsConnected
                        && _currentGamepadState[player].IsButtonUp(button))
                    {
                        LastPlayer = player;
                        return true;
                    }
                }
                return false;
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
                return false;
            }
        }
        private static bool ButtonHeld(Buttons button)
        {
            try
            {
                foreach (var player in players)
                {
                    if (_playerLocked && player != LastPlayer) return false;

                    if (_previousGamepadState[player].IsConnected
                        && _previousGamepadState[player].IsButtonDown(button)
                        && _currentGamepadState[player].IsConnected
                        && _currentGamepadState[player].IsButtonDown(button))
                    {
                        LastPlayer = player;
                        return true;
                    }
                }
                return false;
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
                return false;
            }
        }
        private static IEnumerable<Buttons> GetGamePadButtons(GameButtons button)
        {
            try
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
                    case GameButtons.Restart:
                        toReturn.Add(Buttons.Start);
                        toReturn.Add(Buttons.X);
                        break;
                }

                return toReturn;
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
                return null;
            }
        } 
        #endregion
    }
}
