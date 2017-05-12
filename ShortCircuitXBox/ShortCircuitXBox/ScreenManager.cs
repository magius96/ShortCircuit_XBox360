using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ShortCircuit.GameInput;
using ShortCircuit.Screens;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Media;

namespace ShortCircuit
{
    public class ScreenManager : Game
    {
        public static GraphicsDeviceManager GraphicsDeviceMgr;
        public static SpriteBatch Sprites;
        public static Dictionary<GameTextures2D, Texture2D> Textures2D;
        public static Dictionary<GameFonts, SpriteFont> Fonts;
        public static Dictionary<GameSongs, Song> Songs;
        public static Dictionary<GameSounds, SoundEffect> Sounds; 
        public static List<GameScreen> ScreenList;
        public static ContentManager ContentMgr;
        private static bool _exiting = false;
        public static int ScreenWidth = 640;
        public static int ScreenHeight = 480;

        public static void Main()
        {
            using (var manager = new ScreenManager())
            {
                manager.Run();
            }
        }

        public ScreenManager()
        {
            try
            {
                GraphicsDeviceMgr = new GraphicsDeviceManager(this)
                                        {
                                            PreferredBackBufferWidth = ScreenWidth,
                                            PreferredBackBufferHeight = ScreenHeight,
                                            IsFullScreen = false
                                        };
                this.Components.Add(new GamerServicesComponent(this));

                Content.RootDirectory = "Content";
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        protected override void Initialize()
        {
            try
            {
                Textures2D = new Dictionary<GameTextures2D, Texture2D>();
                Fonts = new Dictionary<GameFonts, SpriteFont>();
                InputManager.Initialize();
                base.Initialize();
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        protected override void LoadContent()
        {
            try
            {
                ContentMgr = Content;
                Sprites = new SpriteBatch(GraphicsDevice);
                //DataManager.LoadScores();

                // Load any full game assets here
                AddFont(GameFonts.GameFont);
                AddFont(GameFonts.MainMenuFont);
                AddFont(GameFonts.CreditsFont);
                AddFont(GameFonts.ErrorFont);
                AddFont(GameFonts.TitleFont);
                AddFont(GameFonts.GameStatusFont);

                AddTexture2D(GameTextures2D.MainBack);
                AddTexture2D(GameTextures2D.Cursor);
                AddTexture2D(GameTextures2D.WhiteBox);
                AddTexture2D(GameTextures2D.ButtonOff);
                AddTexture2D(GameTextures2D.ButtonOn);
                AddTexture2D(GameTextures2D.XBoxX);
                AddTexture2D(GameTextures2D.XBoxA);
                AddTexture2D(GameTextures2D.XBoxB);
                AddTexture2D(GameTextures2D.GameButtons);
                AddTexture2D(GameTextures2D.JGamesLogoLarge);
                AddTexture2D(GameTextures2D.JGamesLogoSmall);
                AddTexture2D(GameTextures2D.Instructions);
                AddTexture2D(GameTextures2D.LevelLock);

                AddSong(GameSongs.Conspiracy);
                AddSong(GameSongs.Down);
                AddSong(GameSongs.Fade);
                AddSong(GameSongs.Forget);
                AddSong(GameSongs.Kreepor);
                AddSong(GameSongs.Morning);
                AddSong(GameSongs.Ooze);
                AddSong(GameSongs.Slipped);
                AddSong(GameSongs.StreetLights);
                AddSong(GameSongs.TradeOff);
                AddSong(GameSongs.Warfield);
                AddSong(GameSongs.chrushedout);
                AddSong(GameSongs.cyber);
                AddSong(GameSongs.enrolled);
                AddSong(GameSongs.eternal);
                AddSong(GameSongs.findingHappiness);
                AddSong(GameSongs.lost);
                AddSong(GameSongs.oncein);
                AddSong(GameSongs.potionshop);
                AddSong(GameSongs.rockout);
                AddSong(GameSongs.stone);
                AddSong(GameSongs.temperence);
                AddSong(GameSongs.thahall2);
                AddSong(GameSongs.timefliesby);
                AddSong(GameSongs.witbe);

                AddSound(GameSounds.ButtonClick);
                AddSound(GameSounds.ding);

                AddScreen(new JGamesSplash());
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        protected override void UnloadContent()
        {
            try
            {
                foreach (var screen in ScreenList)
                {
                    screen.UnloadAssets();
                }
                Textures2D.Clear();
                Fonts.Clear();
                ScreenList.Clear();
                Songs.Clear();
                Content.Unload();
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            try
            {
                if(_exiting)
                {
                    MediaPlayer.Stop();
                    Exit();
                }

                ErrorLog.Update();
                InputManager.Update();

                var startIndex = ScreenList.Count - 1;
                while (ScreenList[startIndex].IsPopup)
                {
                    startIndex--;
                }
                for (var i = startIndex; i < ScreenList.Count; i++)
                {
                    ScreenList[i].Update(gameTime);
                }
                base.Update(gameTime);
            }
            catch{}
        }

        protected override void Draw(GameTime gameTime)
        {
            try
            {
                var startIndex = ScreenList.Count - 1;
                while (ScreenList[startIndex].IsPopup)
                {
                    startIndex--;
                }

                GraphicsDevice.Clear(ScreenList[startIndex].BackgroundColor);
                GraphicsDeviceMgr.GraphicsDevice.Clear(ScreenList[startIndex].BackgroundColor);
                Sprites.Begin();
                for (var i = startIndex; i < ScreenList.Count; i++)
                {
                    ScreenList[i].Draw(gameTime);
                }

                ErrorLog.Draw();
                Sprites.End();
                base.Draw(gameTime);
            }
            catch{}
        }

        public static void AddSound(GameSounds obj)
        {
            try
            {
                if (Sounds == null)
                    Sounds = new Dictionary<GameSounds, SoundEffect>();
                if (!Sounds.ContainsKey(obj))
                    Sounds.Add(obj, ContentMgr.Load<SoundEffect>("Sounds/" + Enum.GetName(typeof(GameSounds), obj)));
            }
            catch (Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        public static void RemoveSound(GameSounds obj)
        {
            try
            {
                if (Sounds.ContainsKey(obj))
                    Sounds.Remove(obj);
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        public static void AddSong(GameSongs obj)
        {
            try
            {
                if (Songs == null)
                    Songs = new Dictionary<GameSongs, Song>();
                if (!Songs.ContainsKey(obj))
                    Songs.Add(obj, ContentMgr.Load<Song>("Songs/" + Enum.GetName(typeof(GameSongs), obj)));
            }
            catch (Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        public static void RemoveSong(GameSongs obj)
        {
            try
            {
                if (Songs.ContainsKey(obj))
                    Songs.Remove(obj);
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        public static void AddFont(GameFonts obj)
        {
            try
            {
                if (Fonts == null)
                    Fonts = new Dictionary<GameFonts, SpriteFont>();
                if (!Fonts.ContainsKey(obj))
                    Fonts.Add(obj, ContentMgr.Load<SpriteFont>("Fonts/" + Enum.GetName(typeof (GameFonts), obj)));
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        public static void RemoveFont(GameFonts obj)
        {
            try
            {
                if (Fonts.ContainsKey(obj))
                    Fonts.Remove(obj);
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        public static void AddTexture2D(GameTextures2D obj)
        {
            try
            {
                if (Textures2D == null)
                    Textures2D = new Dictionary<GameTextures2D, Texture2D>();
                if (!Textures2D.ContainsKey(obj))
                    Textures2D.Add(obj,
                                   ContentMgr.Load<Texture2D>("Textures2D/" + Enum.GetName(typeof (GameTextures2D), obj)));
            } catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        public static void RemoveTexture2D(GameTextures2D obj)
        {
            try
            {
                if (Textures2D.ContainsKey(obj))
                    Textures2D.Remove(obj);
            } catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        public static void AddScreen(GameScreen obj)
        {
            try
            {
                if (MediaPlayer.State != MediaState.Stopped) MediaPlayer.Stop();
                obj.LoadAssets();
                if (ScreenList == null)
                    ScreenList = new List<GameScreen>();
                ScreenList.Add(obj);
                obj.LoadAssets();
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        public static void RemoveScreen(string obj)
        {
            try
            {
                if (MediaPlayer.State != MediaState.Stopped) MediaPlayer.Stop();
                GameScreen screen = GetScreen(obj);
                RemoveScreen(screen);
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        public static void RemoveScreen(GameScreen obj)
        {
            try
            {
                if (MediaPlayer.State != MediaState.Stopped) MediaPlayer.Stop();
                obj.UnloadAssets();
                ScreenList.Remove(obj);
                if (ScreenList.Count < 1)
                    AddScreen(new MainMenu());
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        public static void ChangeScreens(GameScreen currentScreen, GameScreen targetScreen)
        {
            try
            {
                AddScreen(targetScreen);
                RemoveScreen(currentScreen);
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        public static bool HasScreen(string screenName)
        {
            return ScreenList.Any(screen => screen.ScreenName == screenName);
        }

        public static GameScreen GetScreen(string screenName)
        {
            return ScreenList.FirstOrDefault(screen => screen.ScreenName == screenName);
        }

        public static void ExitGame()
        {
            try
            {
                _exiting = true;
                MediaPlayer.Stop();
            }catch(Exception exception)
            {
                ErrorLog.Add(exception);
                _exiting = true;
            }
        }
    }
}

