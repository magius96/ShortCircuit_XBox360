using System;
using Microsoft.Xna.Framework;
using ShortCircuitLib;
using ShortCircuit.GameInput;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.GamerServices;

namespace ShortCircuit.Screens
{
    public class LevelSelectScreen : GameScreen
    {
        protected GameLevel[,] LevelGrid;
        protected string LevelTitle = "Unknown Level";
        private Coordinates2D CursorLocation;
        protected int GridWidth = 15;
        protected int GridHeight = 11;
        private int ButtonWidth { get { return 620/GridWidth; } }
        private int ButtonHeight { get { return 440/GridHeight; } }

        public LevelSelectScreen()
        {
            LevelGrid = new GameLevel[GridWidth, GridHeight];
            CursorLocation = new Coordinates2D(0, 0);
        }

        protected void AddLevel(GameLevel lvl)
        {
            try
            {
                for (var y = 0; y < GridHeight; y++)
                {
                    for (var x = 0; x < GridWidth; x++)
                    {
                        if (LevelGrid[x, y] == null)
                        {
                            LevelGrid[x, y] = lvl;
                            return;
                        }
                    }
                }
            }
            catch(Exception exception)
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
                    MediaPlayer.Play(ScreenManager.Songs[GameSongs.timefliesby]);
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
                DataManager.LastSelectionScreen = this;

                if (InputManager.GameButtonPressedOrHeld(GameButtons.Up))
                {
                    if (CursorLocation.Y > 0 && LevelGrid[CursorLocation.X, CursorLocation.Y - 1] != null)
                        CursorLocation.Y -= 1;
                }
                if (InputManager.GameButtonPressedOrHeld(GameButtons.Down))
                {
                    if (CursorLocation.Y < GridHeight - 1 && LevelGrid[CursorLocation.X, CursorLocation.Y + 1] != null)
                        CursorLocation.Y += 1;
                }
                if (InputManager.GameButtonPressedOrHeld(GameButtons.Left))
                {
                    if (CursorLocation.X > 0 && LevelGrid[CursorLocation.X - 1, CursorLocation.Y] != null)
                        CursorLocation.X -= 1;
                }
                if (InputManager.GameButtonPressedOrHeld(GameButtons.Right))
                {
                    if (CursorLocation.X < GridWidth - 1 && LevelGrid[CursorLocation.X + 1, CursorLocation.Y] != null)
                        CursorLocation.X += 1;
                }

                if (InputManager.GameButtonPressed(GameButtons.Accept))
                {
                    if(Guide.IsTrialMode)
                    {
                        var lvl = LevelGrid[CursorLocation.X, CursorLocation.Y];
                        if(lvl.UseInDemo)
                            ScreenManager.ChangeScreens(this, new GridScreen(LevelGrid[CursorLocation.X, CursorLocation.Y]));
                    }
                    else
                        ScreenManager.ChangeScreens(this, new GridScreen(LevelGrid[CursorLocation.X, CursorLocation.Y]));
                }
                if (InputManager.GameButtonPressed(GameButtons.Decline))
                    ScreenManager.ChangeScreens(this, new MainMenu());
                base.Update(gameTime);
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            try
            {
                ScreenManager.Sprites.Draw(ScreenManager.Textures2D[GameTextures2D.MainBack],
                                           new Rectangle(0, 0, 640, 480), new Color(100, 100, 100));
                var tx = (ScreenManager.ScreenWidth -
                          ScreenManager.Fonts[GameFonts.MainMenuFont].MeasureString(LevelTitle).X)/2;
                ScreenManager.Sprites.DrawString(ScreenManager.Fonts[GameFonts.MainMenuFont], LevelTitle,
                                                 new Vector2(tx, 5), Color.White);
                for (var x = 0; x < GridWidth; x++)
                {
                    for (var y = 0; y < GridHeight; y++)
                    {
                        GameTextures2D tex;
                        if (x == CursorLocation.X && y == CursorLocation.Y)
                            tex = GameTextures2D.ButtonOn;
                        else
                            tex = GameTextures2D.ButtonOff;
                        if (LevelGrid[x, y] != null)
                        {
                            if (DataManager.Scores.ContainsKey(LevelGrid[x, y].Id))
                            {
                                if (DataManager.Scores[LevelGrid[x, y].Id] <= LevelGrid[x, y].Par)
                                {
                                    ScreenManager.Sprites.Draw(ScreenManager.Textures2D[tex],
                                                               new Rectangle((x*ButtonWidth) + 10, (y*ButtonHeight) + 40,
                                                                             ButtonWidth - 1, ButtonHeight - 1),
                                                               Color.Green);
                                }
                                else
                                {
                                    ScreenManager.Sprites.Draw(ScreenManager.Textures2D[tex],
                                                               new Rectangle((x*ButtonWidth) + 10, (y*ButtonHeight) + 40,
                                                                             ButtonWidth - 1, ButtonHeight - 1),
                                                               Color.Yellow);
                                }
                            }
                            else
                            {
                                ScreenManager.Sprites.Draw(ScreenManager.Textures2D[tex],
                                                           new Rectangle((x*ButtonWidth) + 10, (y*ButtonHeight) + 40,
                                                                         ButtonWidth - 1, ButtonHeight - 1), Color.Red);
                            }
                            var txt = string.Format("{0}", (y*GridWidth) + x + 1);
                            var width = ScreenManager.Fonts[GameFonts.MainMenuFont].MeasureString(txt).X;
                            var height = ScreenManager.Fonts[GameFonts.MainMenuFont].MeasureString(txt).Y;
                            var xa = (ButtonWidth - width)/2;
                            var ya = (ButtonHeight - height)/2;
                            ScreenManager.Sprites.DrawString(ScreenManager.Fonts[GameFonts.MainMenuFont], txt,
                                                             new Vector2((x*ButtonWidth) + xa + 10,
                                                                         (y*ButtonHeight) + 40 + ya), Color.White);

                            if (Guide.IsTrialMode && !LevelGrid[x, y].UseInDemo)
                                ScreenManager.Sprites.Draw(ScreenManager.Textures2D[GameTextures2D.LevelLock],
                                                           new Rectangle((x*ButtonWidth) + 20, (y*ButtonHeight) + 50,
                                                                         ButtonWidth - 21, ButtonHeight - 21),
                                                           Color.White * .5f);
                        }
                    }

                }
                //ScreenManager.Sprites.Draw(ScreenManager.Textures2D[GameTextures2D.Cursor], new Rectangle((CursorLocation.X * ButtonWidth)+(ButtonWidth/2)+10,(CursorLocation.Y*ButtonHeight)+(ButtonHeight/2)+40,ButtonWidth/2,ButtonHeight/2), Color.White);
                base.Draw(gameTime);
            }
            catch (Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }
    }
}
