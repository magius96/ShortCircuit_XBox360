using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using ShortCircuit.GameInput;
using ShortCircuit.InputControls;

namespace ShortCircuit.Screens
{
    class OptionsScreen : GameScreen
    {
        private List<InputControl> Options = new List<InputControl>();
        private int IndexLocation = 0;

        public OptionsScreen()
        {
            try
            {
                ScreenName = "Options";
                BackgroundColor = Color.Black;
                Options = new List<InputControl>();

                var musicVolume = new SliderControl()
                                      {
                                          BackgroundColor = Color.Black,
                                          ForegroundColor = Color.White,
                                          FontColor = Color.White,
                                          Height = 20,
                                          MaximumValue = 100,
                                          MinimumValue = 0,
                                          StepAmount = 5,
                                          Text = "Music Volume",
                                          Value = (int) (DataManager.MusicVolume*100),
                                          Width = 200
                                      };
                musicVolume.ValueChanged += musicVolumeValueChanged;
                Options.Add(musicVolume);

                var soundVolume = new SliderControl()
                                      {
                                          BackgroundColor = Color.DarkRed,
                                          ForegroundColor = Color.Red,
                                          FontColor = Color.White,
                                          Height = 20,
                                          MaximumValue = 100,
                                          MinimumValue = 0,
                                          StepAmount = 5,
                                          Text = "Sound Volume",
                                          Value = (int) (DataManager.SoundVolume*100),
                                          Width = 200
                                      };
                soundVolume.ValueChanged += soundVolumeValueChanged;
                Options.Add(soundVolume);

                var autoRepeatDelay = new SliderControl()
                                          {
                                              BackgroundColor = Color.DarkBlue,
                                              ForegroundColor = Color.Blue,
                                              FontColor = Color.White,
                                              Height = 20,
                                              MaximumValue = 15,
                                              MinimumValue = 5,
                                              StepAmount = 1,
                                              Text = "Controller Sensitivity",
                                              Value = DataManager.AutoRepeatDelay,
                                              Width = 200
                                          };
                autoRepeatDelay.ValueChanged += autoRepeatDelayValueChanged;
                Options.Add(autoRepeatDelay);
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        void musicVolumeValueChanged(InputControl sender)
        {
            try
            {
                var control = (SliderControl) sender;
                DataManager.MusicVolume = (float) control.Value/100f;
                MediaPlayer.Volume = DataManager.MusicVolume;
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        void soundVolumeValueChanged(InputControl sender)
        {
            try
            {
                var control = (SliderControl) sender;
                DataManager.SoundVolume = (float) control.Value/100f;
                SoundEffect.MasterVolume = DataManager.SoundVolume;
                ScreenManager.Sounds[GameSounds.ding].Play();
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        void autoRepeatDelayValueChanged(InputControl sender)
        {
            try
            {
                var control = (SliderControl) sender;
                DataManager.AutoRepeatDelay = control.Value;
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
                    IndexLocation -= 1;
                if (InputManager.GameButtonPressedOrHeld(GameButtons.Down))
                    IndexLocation += 1;
                if (IndexLocation > Options.Count - 1) IndexLocation = 0;
                if (IndexLocation < 0) IndexLocation = Options.Count - 1;
                Options[IndexLocation].Update(gameTime);

                if (InputManager.GameButtonPressed(GameButtons.Accept))
                {
                    DataManager.SaveScores();
                    ScreenManager.ChangeScreens(this, new MainMenu());
                }
                if (InputManager.GameButtonPressed(GameButtons.Decline))
                {
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
                var ss = ScreenManager.Fonts[GameFonts.GameFont].MeasureString("Exit");
                var ts = ScreenManager.GraphicsDeviceMgr.GraphicsDevice.Viewport.TitleSafeArea;

                ScreenManager.Sprites.Draw(ScreenManager.Textures2D[GameTextures2D.MainBack],
                                           new Rectangle(0, 0, 640, 480), Color.Gray);

                ScreenManager.Sprites.Draw(ScreenManager.Textures2D[GameTextures2D.XBoxA],
                                           new Rectangle(
                                               ts.Left + 10,
                                               ts.Bottom - (10 + (int) ss.Y),
                                               (int) ss.Y,
                                               (int) ss.Y),
                                           Color.White);

                ScreenManager.Sprites.Draw(ScreenManager.Textures2D[GameTextures2D.XBoxB],
                                           new Rectangle(
                                               ts.Right - (10 + (int) ss.Y),
                                               ts.Bottom - (10 + (int) ss.Y),
                                               (int) ss.Y,
                                               (int) ss.Y),
                                           Color.White);

                ScreenManager.Sprites.DrawString(ScreenManager.Fonts[GameFonts.GameFont], "Save and Exit",
                                                 new Vector2(ts.Left + (20 + (int) ss.Y), ts.Bottom - (10 + (int) ss.Y)), Color.White);

                ScreenManager.Sprites.DrawString(ScreenManager.Fonts[GameFonts.GameFont], "Exit", 
                    new Vector2(ts.Right - (20 + (int)ss.Y + (int)ss.X), ts.Bottom - (10 + (int)ss.Y)),
                                                 Color.White);

                for (int i = 0; i < Options.Count(); i++)
                {
                    if (i == IndexLocation)
                        Options[i].FontColor = Color.White;
                    else
                        Options[i].FontColor = Color.Gray;
                    Options[i].Draw(gameTime, 100, 100 + (i*30));
                }
                base.Draw(gameTime);
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        class OptionItem
        {
            public string Name { get; set; }
            public InputControl Control { get; set; }
        }
    }
}
