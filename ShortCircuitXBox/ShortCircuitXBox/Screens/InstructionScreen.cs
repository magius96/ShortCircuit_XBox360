using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using ShortCircuit.GameInput;

namespace ShortCircuit.Screens
{
    class InstructionScreen : GameScreen
    {
        public InstructionScreen()
        {
            try
            {
                ScreenName = "Instructions";
                BackgroundColor = Color.Black;
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
                    MediaPlayer.Play(ScreenManager.Songs[GameSongs.Slipped]);
                    MediaPlayer.IsRepeating = true;
                    MediaPlayer.Volume = DataManager.MusicVolume;
                }
            }
            catch (Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        public override void Update(GameTime gameTime)
        {
            try
            {
                if(InputManager.GameButtonPressedOrHeld(GameButtons.Accept) || InputManager.GameButtonPressedOrHeld(GameButtons.Decline))
                    ScreenManager.ChangeScreens(this, new MainMenu());
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
                
                ScreenManager.Sprites.Draw(ScreenManager.Textures2D[GameTextures2D.MainBack],
                                           new Rectangle(0, 0, 640, 480), Color.Gray);
                ScreenManager.Sprites.Draw(ScreenManager.Textures2D[GameTextures2D.Instructions],
                                           new Rectangle(ts.Left, ts.Top, ts.Right - ts.Left, ts.Bottom - ts.Top), Color.Yellow);
                base.Draw(gameTime);
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }
    }
}
