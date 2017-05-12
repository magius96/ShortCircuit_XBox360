using System;
using Microsoft.Xna.Framework;
using ShortCircuit.GameInput;

namespace ShortCircuit.Screens
{
    public class JGamesSplash : GameScreen
    {
        private float fadeVal = 0;
        private float blendVal = 0;
        private int waitVal = 0;
        private float dissapearVal = 0;

        public JGamesSplash()
        {
            ScreenName = "JGamesSplash";
            BackgroundColor = Color.Black;
        }

        public override void Update(GameTime gameTime)
        {
            try
            {
                //if (InputManager.GameButtonPressedOrHeld(GameButtons.Accept)
                //    || InputManager.GameButtonPressedOrHeld(GameButtons.Menu))
                //{
                //    DataManager.LoadScores();
                //    ScreenManager.ChangeScreens(this, new MainMenu());
                //}

                if (fadeVal < 1)
                {
                    fadeVal += 0.005f;
                    BackgroundColor = new Color(fadeVal, fadeVal, fadeVal);
                }
                else
                {
                    if (blendVal < 1)
                    {
                        blendVal += 0.005f;
                        float bcBlend = 1 - blendVal;
                        BackgroundColor = new Color(bcBlend, bcBlend, bcBlend);
                    }
                    else
                    {
                        if (waitVal < 60)
                        {
                            waitVal++;
                        }
                        else
                        {
                            if (dissapearVal < 1)
                            {
                                dissapearVal += 0.01f;
                            }
                            else
                            {
                                ScreenManager.ChangeScreens(this, new PressStartScreen());
                            }
                        }
                    }
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
                ScreenManager.Sprites.Draw(ScreenManager.Textures2D[GameTextures2D.JGamesLogoLarge],
                                           new Rectangle(10, 10, 620, 460), Color.White*(blendVal - dissapearVal));
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }
    }
}
