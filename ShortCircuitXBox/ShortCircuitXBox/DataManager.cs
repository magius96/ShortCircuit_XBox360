using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Storage;
using ShortCircuit.Screens;

namespace ShortCircuit
{
    public static class DataManager
    {
        public static LevelSelectScreen LastSelectionScreen = new LevelSelectScreen();

        public static Dictionary<string, int> Scores = new Dictionary<string, int>();
        public static int AutoRepeatDelay = 10;
        public static float MusicVolume = 1;
        public static float SoundVolume = 1;

        private static StorageDevice device;
        private static string containerName = "ShortCircuit";
        private static string filename = "ShortCircuit.sav";

        public static void LogScore(string level, int value)
        {
            try
            {
                if (DataManager.Scores.ContainsKey(level))
                {
                    if (DataManager.Scores[level] > value)
                        DataManager.Scores[level] = value;
                }
                else
                {
                    DataManager.Scores.Add(level, value);
                }
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        public static void SaveScores()
        {
            try
            {
                if (device == null && !Guide.IsVisible)
                {
                    device = null;
                    StorageDevice.BeginShowSelector(GameInput.InputManager.LastPlayer, SaveDriveSelected, null);
                }
                else
                {
                    device.BeginOpenContainer(containerName, SaveContainerOpen, null);
                }
            }
            catch
            {
            }
            //catch(Exception exception)
            //{
            //    ErrorLog.Add(exception);
            //}
        }

        private static void SaveDriveSelected(IAsyncResult result)
        {
            try
            {
                device = StorageDevice.EndShowSelector(result);
                device.BeginOpenContainer(containerName, SaveContainerOpen, null);
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        private static void SaveContainerOpen(IAsyncResult result)
        {
            try
            {
                var dat = PrepDataForSaving();
                var container = device.EndOpenContainer(result);
                if (container.FileExists(filename))
                    container.DeleteFile(filename);
                using (var stream = container.CreateFile(filename))
                {
                    var serializer = new XmlSerializer(typeof(SaveData));
                    serializer.Serialize(stream, dat);
                }
                container.Dispose();
            } catch { }
            //catch (Exception exception)
            //{
            //    ErrorLog.Add(exception);
            //}
            finally
            {
                result.AsyncWaitHandle.Close();
            }
        }

        public static void LoadScores()
        {
            try
            {
                if(device == null)
                {
                    if(!Guide.IsVisible)
                    {
                        device = null;
                        StorageDevice.BeginShowSelector(GameInput.InputManager.LastPlayer, LoadDriveSelected, null);
                    }
                }
                else
                {
                    device.BeginOpenContainer(containerName, LoadContainerOpen, null);
                }
            }
            catch (Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        private static void LoadDriveSelected(IAsyncResult result)
        {
            try
            {
                device = StorageDevice.EndShowSelector(result);
                device.BeginOpenContainer(containerName, LoadContainerOpen, null);
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        private static void LoadContainerOpen(IAsyncResult result)
        {
            try
            {
                var container = device.EndOpenContainer(result);
                result.AsyncWaitHandle.Close();
                if (container.FileExists(filename))
                {
                    var stream = container.OpenFile(filename, FileMode.Open);
                    var serializer = new XmlSerializer(typeof(SaveData));
                    var saveData = (SaveData)serializer.Deserialize(stream);
                    stream.Close();
                    container.Dispose();
                    //Update the game based on the save game file
                    ParseSaveData(saveData);
                }
            }
            catch (Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }

        public static SaveData PrepDataForSaving()
        {
            try
            {
                SaveData dat = new SaveData();
                dat.autoRepeat = AutoRepeatDelay;
                dat.musicVolume = MusicVolume;
                dat.soundVolume = SoundVolume;
                dat.scores = new ScoreData[Scores.Count];
                for (var i = 0; i < Scores.Count; i++)
                {
                    dat.scores[i] = new ScoreData(Scores.ElementAt(i).Key, Scores.ElementAt(i).Value);
                }
                return dat;
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
                return new SaveData();
            }
        }

        public static void ParseSaveData(SaveData dat)
        {
            try
            {
                AutoRepeatDelay = dat.autoRepeat;
                MusicVolume = dat.musicVolume;
                SoundVolume = dat.soundVolume;
                Scores = new Dictionary<string, int>();
                for (var i = 0; i < dat.scores.Count(); i++)
                {
                    Scores.Add(dat.scores[i].Key, dat.scores[i].Value);
                }
            }
            catch(Exception exception)
            {
                ErrorLog.Add(exception);
            }
        }
    }

    public class SaveData
    {
        public int autoRepeat;
        public float musicVolume;
        public float soundVolume;
        public ScoreData[] scores;
        public SaveData()
        {
            autoRepeat = 10;
            musicVolume = 1;
            soundVolume = 1;
        }
    }

    public class ScoreData
    {
        public string Key;
        public int Value;
        public ScoreData(string key, int value)
        {
            Key = key;
            Value = value;
        }
        public ScoreData()
        {
            Key = string.Empty;
            Value = int.MinValue;
        }
    }
}
