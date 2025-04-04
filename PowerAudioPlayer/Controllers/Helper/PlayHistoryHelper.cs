﻿using MemoryPack;
using PowerAudioPlayer.Controllers.Utils;
using PowerAudioPlayer.Model;
using System.IO;

namespace PowerAudioPlayer.Controllers.Helper
{
    internal class PlayHistoryHelper
    {
        private static Dictionary<string, PlayHistoryItem> _history = new Dictionary<string, PlayHistoryItem>();
        public static string defaultFile = Path.Combine(Player.GetExactDataFilePath(), "History.dat");

        public static int Count
        {
            get => _history.Count;
        }

        public static Dictionary<string, PlayHistoryItem> History
        {
            get => _history;
            set => _history = value;
        }

        public static int TotalLength
        {
            get => _history.Values.Where(x => x.Length > 0).ToList().Sum(x => x.Length);
        }

        public static int TotalLengthWithTimesPlayed
        {
            get => _history.Values.Where(x => x.Length > 0).ToList().Sum(x => x.Length * x.PlayCount);
        }

        public static int TotalPlayTimesCount
        {
            get => _history.Values.Sum(x => x.PlayCount);
        }

        public static long Size
        {
            get => MiscUtils.GetFileSize(defaultFile);
        }

        public static void SaveHistory(string file = "")
        {
            if (string.IsNullOrEmpty(file))
                file = defaultFile;
            using FileStream fs = new FileStream(file, FileMode.Create);
            fs.Write(MemoryPackSerializer.Serialize(_history));
        }

        public static void LoadHistory(string file = "")
        {
            if (string.IsNullOrEmpty(file))
                file = defaultFile;
            using FileStream fs = new FileStream(file, FileMode.OpenOrCreate);
            int length = (int)fs.Length;
            byte[] buffer = new byte[length];
            fs.ReadExactly(buffer, 0, length);
            try
            {
                _history = MemoryPackSerializer.Deserialize<Dictionary<string, PlayHistoryItem>>(buffer) ?? [];
            }
            catch
            {
                _history = new Dictionary<string, PlayHistoryItem>();
            }
        }

        public static void ClearHistory()
        {
            _history.Clear();
            SaveHistory();
        }

        public static void Add(string file, DateTime lastPlaybackTime, string displayTitle = "", int length = 0, int playCount = 1)
        {
            if(_history.ContainsKey(file))
            {
                _history[file].PlayCount++;
                _history[file].LastPlaybackTime = lastPlaybackTime > _history[file].LastPlaybackTime ? lastPlaybackTime : _history[file].LastPlaybackTime;
            }
            else
            {
                _history.Add(file, new PlayHistoryItem(lastPlaybackTime, playCount, displayTitle, length, file));
            }
        }

        public static void Add(PlaylistItem item)
        {
            Add(item.File, DateTime.Now, item.DisplayTitle, item.Length);
        }

        public static void Remove(string file)
        {
            _history.Remove(file);
        }
    }
}
