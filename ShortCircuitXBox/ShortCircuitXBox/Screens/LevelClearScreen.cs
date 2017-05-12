using System;
using System.Globalization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using ShortCircuit.GameInput;
using ShortCircuitLib;

namespace ShortCircuit.Screens
{
    class LevelClearScreen : GameScreen
    {
        private DateTime Dissapear = DateTime.Now.AddSeconds(5);
        private int _par;
        private int _moves;
        private int _score;
        private GameLevel _next;

        public LevelClearScreen(int par, int moves, int score, GameLevel nextLevel) : base()
        {
            try
            {
                ScreenName = "Level Clear Screen";
                BackgroundColor = Color.Black;
                _par = par;
                _moves = moves;
                _score = score;
                _next = nextLevel;
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        public override void LoadAssets()
        {
            try
            {
                base.LoadAssets();
                if (MediaPlayer.State == MediaState.Stopped)
                {
                    MediaPlayer.Play(ScreenManager.Songs[GameSongs.cyber]);
                    MediaPlayer.IsRepeating = true;
                    MediaPlayer.Volume = DataManager.MusicVolume;
                }
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }
        public override void Update(GameTime gameTime)
        {
            try
            {
                if (DateTime.Now > Dissapear
                    || InputManager.GameButtonPressed(GameButtons.Accept)
                    || InputManager.GameButtonPressed(GameButtons.Decline))
                {
                    DataManager.SaveScores();
                    if (_next != null)
                        ScreenManager.ChangeScreens(this, new GridScreen(_next));
                    else
                        ScreenManager.ChangeScreens(this, new CreditsScreen());
                }
                base.Update(gameTime);
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            try
            {
                var sprites = ScreenManager.Sprites;

                ScreenManager.Sprites.Draw(ScreenManager.Textures2D[GameTextures2D.MainBack],
                                           new Rectangle(0, 0, 640, 480), Color.Gray);
                DrawCenterString("Level Cleared", 10, ScreenManager.Fonts[GameFonts.TitleFont]);
                var font = ScreenManager.Fonts[GameFonts.GameStatusFont];
                DrawCenterString("Par", 150, font);
                DrawCenterString(_par.ToString(CultureInfo.InvariantCulture), 200, font);
                DrawCenterString("Moves", 250, font);
                DrawCenterString(_moves.ToString(CultureInfo.InvariantCulture), 300, font);
                DrawCenterString("Score", 350, font);
                DrawCenterString(_score.ToString(CultureInfo.InvariantCulture), 400, font);
                base.Draw(gameTime);
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        private void DrawCenterString(string text, int Y, SpriteFont font)
        {
            try
            {
                var mid = 640/2;
                var len = font.MeasureString(text).X;
                var center = len/2;
                var x = mid - center;
                ScreenManager.Sprites.DrawString(font, text, new Vector2(x, Y), Color.White);
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }
    }
}
