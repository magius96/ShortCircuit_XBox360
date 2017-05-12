using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Media;
using ShortCircuit.GameInput;

namespace ShortCircuit.Screens
{
    internal class MainMenu : GameScreen
    {
        private delegate void myDelegate();

        private readonly List<MenuItem> menuItems = new List<MenuItem>();
        private int _menuLocation = 0;
        private int _x = 200;
        private int _y = 150;

        public MainMenu()
            : base()
        {
            try
            {
                ScreenName = "Main Menu";
                BackgroundColor = Color.Black;

                menuItems.Add(new MenuItem("Classic Levels", ClassicLevelsMenuItem));
                menuItems.Add(new MenuItem("Advanced Levels", AdvancedLevelsMenuItem));

                menuItems.Add(new MenuItem("Instructions", InstructionMenuItem));
                menuItems.Add(new MenuItem("Options", OptionsMenuItem));
                menuItems.Add(new MenuItem("Credits", CreditsMenuItem));
                if (Guide.IsTrialMode)
                {
                    menuItems.Add(new MenuItem("Purchase Full Game", PurchaseGameMenuItem));
                    menuItems.Add(new MenuItem("Exit Demo", ExitGameMenuItem));
                }
                else
                {
                    menuItems.Add(new MenuItem("Exit Game", ExitGameMenuItem));
                }
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        protected void ClassicLevelsMenuItem()
        {
            ScreenManager.ChangeScreens(this, new ClassicLevels());
        }

        protected void AdvancedLevelsMenuItem()
        {
            ScreenManager.ChangeScreens(this, new AdvancedLevels());
        }

        protected void CreditsMenuItem()
        {
            ScreenManager.ChangeScreens(this, new CreditsScreen());
        }

        protected void OptionsMenuItem()
        {
            ScreenManager.ChangeScreens(this, new OptionsScreen());
        }

        protected void ExitGameMenuItem()
        {
            ScreenManager.ExitGame();
        }

        protected void InstructionMenuItem()
        {
            ScreenManager.ChangeScreens(this, new InstructionScreen());
        }

        protected void PurchaseGameMenuItem()
        {
            try
            {
                var gp = Gamer.SignedInGamers[InputManager.LastPlayer].Privileges;
                if(gp.AllowPurchaseContent)
                    Guide.ShowMarketplace(InputManager.LastPlayer);
                else
                    ErrorLog.Add("You need to log in with an XBox Live Membership to purchase the game.");
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        protected void TestMenuItem()
        {
            ErrorLog.Add("Testing");
        }

        public override void LoadAssets()
        {
            try
            {
                ScreenName = "MainMenu";
                if (MediaPlayer.State == MediaState.Stopped)
                {
                    MediaPlayer.Play(ScreenManager.Songs[GameSongs.Morning]);
                    MediaPlayer.IsRepeating = true;
                    MediaPlayer.Volume = DataManager.MusicVolume;
                }
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
                                           new Rectangle(0, 0, 640, 480), new Color(100, 100, 100));
                var x = (640 - (ScreenManager.Fonts[GameFonts.TitleFont].MeasureString("Short Circuit").X))/2;
                ScreenManager.Sprites.DrawString(ScreenManager.Fonts[GameFonts.TitleFont], "Short Circuit",
                                                 new Vector2(x, 10), Color.LightBlue);
                for (var i = 0; i < menuItems.Count; i++)
                {
                    Color c;
                    if (i == _menuLocation)
                        c = new Color(150, 150, 255);
                    else
                        c = new Color(50, 50, 200);
                    ScreenManager.Sprites.DrawString(ScreenManager.Fonts[GameFonts.MainMenuFont], menuItems[i].Text,
                                                     new Vector2(_x, _y + (i*30)), c);
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
                if (InputManager.GameButtonPressed(GameButtons.Accept))
                {
                    menuItems[_menuLocation].CmdPointer();
                }
                if (InputManager.GameButtonPressedOrHeld(GameButtons.Up))
                {
                    _menuLocation -= 1;
                }
                if (InputManager.GameButtonPressedOrHeld(GameButtons.Down))
                {
                    _menuLocation += 1;
                }

                if (_menuLocation < 0) _menuLocation = menuItems.Count - 1;
                if (_menuLocation > menuItems.Count - 1) _menuLocation = 0;

                base.Update(gameTime);
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        public override void UnloadAssets()
        {
            try
            {
                menuItems.Clear();
                base.UnloadAssets();
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        private class MenuItem
        {
            public string Text = default(string);
            public myDelegate CmdPointer;

            public MenuItem(string text, myDelegate dPointer)
            {
                Text = text;
                CmdPointer = dPointer;
            }
        }
    }
}