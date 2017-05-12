using System;
using Microsoft.Xna.Framework;

namespace ShortCircuit.Screens
{
    class PressStartScreen : GameScreen
    {
        public PressStartScreen()
        {
            try
            {
                ScreenName = "PressStartScreen";
                BackgroundColor = Color.Black;
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
                if(GameInput.InputManager.AnyInput())
                {
                    GameInput.InputManager.LockPlayer();
                    DataManager.LoadScores();
                    ScreenManager.ChangeScreens(this, new MainMenu());
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
                var ts = ScreenManager.GraphicsDeviceMgr.GraphicsDevice.Viewport.TitleSafeArea;
                var fs = ScreenManager.Fonts[GameFonts.MainMenuFont].MeasureString("Press Start");
                var center = new Vector2(320, 240);
                ScreenManager.Sprites.Draw(ScreenManager.Textures2D[GameTextures2D.MainBack],
                                           new Rectangle(0, 0, 640, 480), Color.Gray);
                ScreenManager.Sprites.DrawString(
                    ScreenManager.Fonts[GameFonts.MainMenuFont],
                    "Press Start",
                    new Vector2(
                        center.X - (fs.X/2),
                        center.Y - (fs.Y/2)),
                    Color.White);
                base.Draw(gameTime);
            }
            catch (Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }
    }
}
