using System;
using System.Globalization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Media;
using ShortCircuit.GameInput;
using ShortCircuit.Objects;
using ShortCircuitLib;

namespace ShortCircuit.Screens
{
    class GridScreen : GameScreen
    {
        private Button[,] _buttons;
        private GameLevel _initLevel;
        private GameLevel _level;
        private int _moves = 0;
        private Coordinates2D CursorLocation = new Coordinates2D(0, 0);

        public GridScreen(GameLevel level)
            : base()
        {
            try
            {
                ScreenName = "Game Screen";
                _level = level;
                _initLevel = level;
                BackgroundColor = Color.ForestGreen;
                InitBoard(level);
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        private void InitBoard(GameLevel lvl)
        {
            try
            {
                _moves = 0;
                _buttons = new Button[lvl.MapSize,lvl.MapSize];
                for (var x = 0; x < lvl.MapSize; x++)
                {
                    for (var y = 0; y < lvl.MapSize; y++)
                    {
                        var btn = new Button(lvl.GetType(x, y));
                        btn.ButtonState = lvl.GetState(x, y);
                        btn.Position.X = x*(470/lvl.MapSize) + 5;
                        btn.Position.Y = y*(470/lvl.MapSize) + 5;
                        btn.Size = new Coordinates2D((470/lvl.MapSize) - 5, (470/lvl.MapSize) - 5);
                        _buttons[x, y] = btn;
                    }
                }
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        public override void LoadAssets()
        {
            try
            {
                if (MediaPlayer.State == MediaState.Stopped)
                {
                    MediaPlayer.Play(ScreenManager.Songs[PickRandomSong()]);
                    MediaPlayer.IsRepeating = true;
                    MediaPlayer.Volume = DataManager.MusicVolume;
                }
                base.LoadAssets();
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }
        public override void Update(GameTime gameTime)
        {
            try
            {
                if (InputManager.GameButtonPressedOrHeld(GameButtons.Up))
                {
                    CursorLocation.Y -= 1;
                }
                if (InputManager.GameButtonPressedOrHeld(GameButtons.Down))
                {
                    CursorLocation.Y += 1;
                }
                if (InputManager.GameButtonPressedOrHeld(GameButtons.Left))
                {
                    CursorLocation.X -= 1;
                }
                if (InputManager.GameButtonPressedOrHeld(GameButtons.Right))
                {
                    CursorLocation.X += 1;
                }
                if (CursorLocation.X > _level.MapSize - 1) CursorLocation.X = 0;
                if (CursorLocation.X < 0) CursorLocation.X = _level.MapSize - 1;
                if (CursorLocation.Y > _level.MapSize - 1) CursorLocation.Y = 0;
                if (CursorLocation.Y < 0) CursorLocation.Y = _level.MapSize - 1;
                if (InputManager.GameButtonPressed(GameButtons.Accept))
                {
                    var x = CursorLocation.X;
                    var y = CursorLocation.Y;
                    _moves += 1;
                    _buttons[x, y].Toggle();
                    if (x > 0) _buttons[x - 1, y].Toggle();
                    if (y > 0) _buttons[x, y - 1].Toggle();
                    if (x < _level.MapSize - 1) _buttons[x + 1, y].Toggle();
                    if (y < _level.MapSize - 1) _buttons[x, y + 1].Toggle();
                }

                if (LevelCleared())
                {
                    var score = _moves - _level.Par;
                    DataManager.LogScore(_level.Id, score);
                    if (Guide.IsTrialMode)
                    {
                        var nLvl = NextDemoLevel();
                        ScreenManager.ChangeScreens(this,
                                                    nLvl == null
                                                        ? new LevelClearScreen(_level.Par, _moves, score, null)
                                                        : new LevelClearScreen(_level.Par, _moves, score, nLvl));
                    }
                    else
                    {
                        ScreenManager.ChangeScreens(this,
                                                    new LevelClearScreen(_level.Par, _moves, score, _level.NextLevel));
                    }
                }
                if (InputManager.GameButtonPressed(GameButtons.Decline))
                    ScreenManager.ChangeScreens(this, DataManager.LastSelectionScreen);
                if (InputManager.GameButtonPressed(GameButtons.Restart))
                {
                    _level = _initLevel;
                    InitBoard(_initLevel);
                }
                base.Update(gameTime);
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            try
            {
                ScreenManager.Sprites.Draw(ScreenManager.Textures2D[GameTextures2D.MainBack],
                                           new Rectangle(0, 0, 640, 480), Color.Gray);
                for (var x = 0; x < _level.MapSize; x++)
                {
                    for (var y = 0; y < _level.MapSize; y++)
                    {
                        _buttons[x, y].Draw(gameTime);
                    }
                }
                DrawCenterString("Par", 10);
                DrawCenterString(_level.Par.ToString(CultureInfo.InvariantCulture), 60);
                DrawCenterString("Moves", 110);
                DrawCenterString(_moves.ToString(CultureInfo.InvariantCulture), 160);
                var safeRight = ScreenManager.GraphicsDeviceMgr.GraphicsDevice.Viewport.TitleSafeArea.Right;
                var safeBottom = ScreenManager.GraphicsDeviceMgr.GraphicsDevice.Viewport.TitleSafeArea.Bottom;
                ScreenManager.Sprites.Draw(ScreenManager.Textures2D[GameTextures2D.GameButtons],
                                           new Rectangle(480, 368, safeRight - 480, safeBottom - 368), Color.White);
                ScreenManager.Sprites.Draw(ScreenManager.Textures2D[GameTextures2D.Cursor], GetCursorCoordinates(),
                                           Color.White);
                base.Draw(gameTime);
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        private void DrawCenterString(string text, int Y)
        {
            try
            {
                var len = ScreenManager.Fonts[GameFonts.GameStatusFont].MeasureString(text).X;
                var space = 630 - 480;
                var mid = space/2;
                var center = mid - (len/2);
                var x = 480 + center;
                ScreenManager.Sprites.DrawString(ScreenManager.Fonts[GameFonts.GameStatusFont], text, new Vector2(x, Y),
                                                 Color.White);
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        private Rectangle GetCursorCoordinates()
        {
            try
            {
                var btn = _buttons[CursorLocation.X, CursorLocation.Y];
                var x = btn.Position.X + (btn.Size.X/2);
                var y = btn.Position.Y + (btn.Size.Y/2);
                var size = btn.Size.X/3;
                return new Rectangle(x, y, size, size);
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
                return new Rectangle();
            }
        }

        private GameSongs PickRandomSong()
        {
            try
            {
                var rand = new Random();
                var vals = Utils.GetEnumValues<GameSongs>();
                var obj = vals[rand.Next(vals.Count)];
                return obj;
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
                return GameSongs.Morning;
            }
        }

        private bool LevelCleared()
        {
            try
            {
                var ct = _level.MapSize*_level.MapSize;
                for(int x=0;x<_level.MapSize;x++)
                {
                    for(int y=0;y<_level.MapSize;y++)
                    {
                        if (_buttons[x, y].ButtonState == ButtonStates.Off) ct--;
                    }
                }
                return ct == 0;
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
                return false;
            }
        }

        private int CountOn()
        {
            try
            {
                var ct = 0;
                for (int x = 0; x < _level.MapSize; x++)
                {
                    for (int y = 0; y < _level.MapSize; y++)
                    {
                        if (_buttons[x, y].ButtonState == ButtonStates.On) ct++;
                    }
                }
                return ct;
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
                return int.MinValue;
            }
        }
        private int CountDim()
        {
            try
            {
                var ct = 0;
                for (int x = 0; x < _level.MapSize; x++)
                {
                    for (int y = 0; y < _level.MapSize; y++)
                    {
                        if (_buttons[x, y].ButtonState == ButtonStates.Dim) ct++;
                    }
                }
                return ct;
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
                return int.MinValue;
            }
        }
        private int CountOff()
        {
            try
            {
                var ct = 0;
                for (int x = 0; x < _level.MapSize; x++)
                {
                    for (int y = 0; y < _level.MapSize; y++)
                    {
                        if (_buttons[x, y].ButtonState == ButtonStates.Off) ct++;
                    }
                }
                return ct;
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
                return int.MinValue;
            }
        }

        private GameLevel NextDemoLevel()
        {
            var lvl = _level.NextLevel;
            while (lvl != null && lvl.UseInDemo == false)
            {
                lvl = lvl.NextLevel;
            }
            return lvl;
        }
    }
}
