using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using ShortCircuit.GameInput;

namespace ShortCircuit.Screens
{
    class CreditsScreen : GameScreen
    {
        private List<Credit> _credits = new List<Credit>();

        private int _y = ScreenManager.ScreenHeight;
        private int OffY = int.MinValue;

        public CreditsScreen() : base()
        {
            try
            {
                ScreenName = "Credits";
                BackgroundColor = Color.Black;

                _credits = new List<Credit>();
                _credits.Add(new Credit("Created By", "", "Jason Yarber"));
                _credits.Add(new Credit());
                _credits.Add(new Credit());
                _credits.Add(new Credit("Development Adviser", "", "Jessica Yarber"));
                _credits.Add(new Credit());
                _credits.Add(new Credit());
                _credits.Add(new Credit("Game Music", "", ""));
                _credits.Add(new Credit("", "Matt McFarland", ""));
                _credits.Add(new Credit("", "www.mattmcfarland.com", ""));
                _credits.Add(new Credit("crushedout", "", "Conspiracy"));
                _credits.Add(new Credit("cyber", "", "Down"));
                _credits.Add(new Credit("enrolled", "", "eternal"));
                _credits.Add(new Credit("Fade", "", "findingHappiness"));
                _credits.Add(new Credit("Forget", "", "Kreepor"));
                _credits.Add(new Credit("lost", "", "Morning"));
                _credits.Add(new Credit("oncein", "", "Ooze"));
                _credits.Add(new Credit("potion_shop", "", "rock out"));
                _credits.Add(new Credit("Slipped", "", "stone"));
                _credits.Add(new Credit("Street Lights", "", "temperance"));
                _credits.Add(new Credit("thahall2", "", "timefliesby"));
                _credits.Add(new Credit("TradeOff", "", "Warfield"));
                _credits.Add(new Credit("", "witbe", ""));
                _credits.Add(new Credit());
                _credits.Add(new Credit());
                _credits.Add(new Credit("Special Thanks", "", ""));
                _credits.Add(new Credit("", "", "XNA Development Community"));
                _credits.Add(new Credit("", "", "Microsoft"));
                _credits.Add(new Credit());
                _credits.Add(new Credit());
                _credits.Add(new Credit("Game design based upon", "", ""));
                _credits.Add(new Credit("", "Lights Out Handheld", ""));
                _credits.Add(new Credit("", "", "By:  Tiger Electronics Ltd."));
                _credits.Add(new Credit());
                _credits.Add(new Credit());
                _credits.Add(new Credit("In Memory Of", "", ""));
                _credits.Add(new Credit("", "Betty Lou Yarber", ""));
                _credits.Add(new Credit("", "", "She always believed in me."));
                _credits.Add(new Credit());
                _credits.Add(new Credit());
                _credits.Add(new Credit("Send Questions", "", ""));
                _credits.Add(new Credit("", "And Comments to:", ""));
                _credits.Add(new Credit("", "", "JasonYarber@hotmail.com"));
                _credits.Add(new Credit());
                _credits.Add(new Credit("Read the development blog at:", "", ""));
                _credits.Add(new Credit("", "", "http://jasonyarber.webnode.com"));
                _credits.Add(new Credit());
                _credits.Add(new Credit());
                _credits.Add(new Credit());
                _credits.Add(new Credit());
                _credits.Add(new Credit());
                _credits.Add(new Credit());
                _credits.Add(new Credit());
                _credits.Add(new Credit());
                _credits.Add(new Credit());
                _credits.Add(new Credit());
                _credits.Add(new Credit());
                _credits.Add(new Credit());
                _credits.Add(new Credit());
                _credits.Add(new Credit());
                _credits.Add(new Credit());
                _credits.Add(new Credit());
                _credits.Add(new Credit());
                _credits.Add(new Credit());
                _credits.Add(new Credit());
                _credits.Add(new Credit());
                _credits.Add(new Credit());
                _credits.Add(new Credit());
                _credits.Add(new Credit());
                _credits.Add(new Credit());
                _credits.Add(new Credit("", "Thank you for playing.", ""));
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
                    MediaPlayer.Play(ScreenManager.Songs[GameSongs.eternal]);
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
                OffY = 0 - (_credits.Count*20);
                _y -= 1;
                if (_y < OffY) ScreenManager.RemoveScreen(this);
                if (InputManager.GameButtonPressed(GameButtons.Decline)) ScreenManager.RemoveScreen(this);
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
                for (var i = 0; i < _credits.Count; i++)
                {
                    _credits[i].Draw(_y + (i*20));
                }
                base.Draw(gameTime);
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        class Credit
        {
            public string LeftText { get; set; }
            public string CenterText { get; set; }
            public string RightText { get; set; }

            public Credit()
            {
                LeftText = string.Empty;
                CenterText = string.Empty;
                RightText = string.Empty;
            }

            public Credit(string leftText, string centerText, string rightText)
            {
                LeftText = leftText;
                CenterText = centerText;
                RightText = rightText;
            }

            public void Draw(int y)
            {
                try
                {
                    var ts = ScreenManager.GraphicsDeviceMgr.GraphicsDevice.Viewport.TitleSafeArea;
                    if (!string.IsNullOrEmpty(LeftText))
                        ScreenManager.Sprites.DrawString(ScreenManager.Fonts[GameFonts.CreditsFont], LeftText,
                                                         new Vector2(ts.Left + 10, y), Color.White);
                    if (!string.IsNullOrEmpty(CenterText))
                    {
                        var cx = (ts.Right - (ScreenManager.Fonts[GameFonts.CreditsFont].MeasureString(CenterText).X))/2;
                        ScreenManager.Sprites.DrawString(ScreenManager.Fonts[GameFonts.CreditsFont], CenterText,
                                                         new Vector2(cx, y), Color.White);
                    }
                    if (!string.IsNullOrEmpty(RightText))
                    {
                        var rx = (ts.Right - (ScreenManager.Fonts[GameFonts.CreditsFont].MeasureString(RightText).X)) - 10;
                        ScreenManager.Sprites.DrawString(ScreenManager.Fonts[GameFonts.CreditsFont], RightText,
                                                         new Vector2(rx, y), Color.White);
                    }
                }catch(Exception exception)
                {
                    ErrorLog.Add(exception);
                }
            }
        }
    }
}
