using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShortCircuitLib;
using System;

namespace ShortCircuit
{
    public class GameScreen
    {
        public string ScreenName = "Unknown";
        public bool IsPopup = false;
        public Color BackgroundColor = Color.CornflowerBlue;
        private readonly List<GameObject> _objects = new List<GameObject>();
        public GraphicsDevice graphicsDevice = ScreenManager.GraphicsDeviceMgr.GraphicsDevice;

        public virtual void LoadAssets() { }

        public virtual void Update(GameTime gameTime)
        {
            try
            {
                foreach (var o in _objects)
                {
                    o.Update(gameTime);
                }
            }
            catch (Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        public virtual void Draw(GameTime gameTime)
        {
            try
            {
                foreach (var o in _objects)
                {
                    o.Draw(gameTime);
                }
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        public virtual void UnloadAssets()
        {
            try
            {
                foreach (var o in _objects)
                {
                    o.Unload();
                }
                _objects.Clear();
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        public void AddObject(GameObject obj)
        {
            try
            {
                obj.Load();
                _objects.Add(obj);
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        public void RemoveObject(GameObject obj)
        {
            try
            {
                obj.Unload();
                _objects.Remove(obj);
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }
    }
}

