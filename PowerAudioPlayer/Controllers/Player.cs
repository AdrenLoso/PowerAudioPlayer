﻿using PowerAudioPlayer.Controllers.Helper;
using PowerAudioPlayer.Controllers.PlayerCore;
using PowerAudioPlayer.Controllers.Utils;
using System.IO;

namespace PowerAudioPlayer.Controllers
{
    public enum PlayMode
    {
        OrderPlay,
        PlaylistLoop,
        TrackLoop,
        ShufflePlay
    }

    public enum PlayerCores
    {
        BASS = 0,
        MCI = 1
    }

    public enum ABRepeatMode
    {
        None = 0,
        ASelected = 1,
        ABRepeat = 2
    };

    public enum DataFilePath
    {
        LocalAppData = 0,
        Program = 1
    }

    public class FileSearchArgs
    {
        public string Directory { get; set; } = string.Empty;

        public bool SearchSubDir { get; set; } = true;

        public FileSearchArgs(string dir, bool searchSubDir) { Directory = dir; SearchSubDir = searchSubDir; }
    }

    public class MediaLibraryDirectory
    {
        public string Directory { get; set; } = string.Empty;


        public MediaLibraryDirectory(string dir) { Directory = dir; }

        public MediaLibraryDirectory() { }
    }

    internal class Player
    {
        public const int WM_USER = 0x400;
        public const int WM_PLAY = WM_USER + 2;
        public const int WM_REFRESHPLAYLISTVIEW = WM_USER + 3;
        public const int WM_LOCATETO = WM_USER + 4;
        public const int WM_SETHOTKEY = WM_USER + 5;
        public const int WM_LOADLYRICS = WM_USER + 6;
        public const int WM_LRCROLL = WM_USER + 7;
        public const int WM_CLEARLRC = WM_USER + 8;
        public const int WM_UPDATEMEDIALIBRARY = WM_USER + 10;
        public const int WM_HANDLECOMMANDLINE = WM_USER + 11;
        public const int WM_REFRESHHISTORYVIEW = WM_USER + 12;
        public const int WM_SWITCHPLAYLISTEDITORFORMEMBEDDED = WM_USER + 13;
        public const int WM_SETALBUMPICTURE = WM_USER + 14;
        public const int WM_CLEARALBUMPICTURE = WM_USER + 15;

        public static ABRepeatMode abRepeatMode = ABRepeatMode.None;
        public static int playIndex = -1;
        private static int aRepeatPos = 0;
        private static int bRepeatPos = 0;

        public static DataFilePath DataFilePath = DataFilePath.LocalAppData;

        public static IPlayerCore Core = null!;
        public static void Init()
        {
            try
            {
                using FileStream fs = new FileStream(Path.Combine(MiscUtils.GetProgramExecuableFilePath(), "DataFileSavePath.dat"), FileMode.Open, FileAccess.Read);
                {
                    var b = fs.ReadByte();
                    if (b == 0x0)
                        DataFilePath = DataFilePath.LocalAppData;
                    else
                        DataFilePath = DataFilePath.Program;
                }
            }
            catch
            {
                DataFilePath = DataFilePath.LocalAppData;
                SetDataFilePath(DataFilePath);
            }
            GetExactDataFilePath();
            if(Settings.Default.Equalizer == null || Settings.Default.Equalizer.Length == 0) 
                Settings.Default.Equalizer = new int[10];
            if (Settings.Default.MediaLibraryDirectories == null)
                Settings.Default.MediaLibraryDirectories = new List<MediaLibraryDirectory>();
            try
            {
                if (Settings.Default.PlayerCore == PlayerCores.MCI)
                    Core = new MCICore();
                else
                    Core = new BASSCore();
            }
            catch 
            { 
                Core = new BASSCore(); 
            }
            Core.Init();
            Core.SetMIDISoundFont(Settings.Default.MIDISoundFont);
            Core.SetConfig(PlayerCoreConfig.PlayBuffer, Settings.Default.PlayBuffer);
            Core.SetConfig(PlayerCoreConfig.NetBuffer, Settings.Default.NetBuffer);
            Core.SetConfig(PlayerCoreConfig.NetTimeOut, Settings.Default.NetTimeOut);
            Core.SetConfig(PlayerCoreConfig.MIDIVoices, Settings.Default.MIDIVoices);
            MediaLibraryHelper.LoadMediaLibrary();
            PlaylistHelper.LoadPlaylists();
            PlayHistoryHelper.LoadHistory();
        }

        public static void SaveDataFile()
        {
            MediaLibraryHelper.SaveMediaLibrary();
            PlayHistoryHelper.SaveHistory();
            PlaylistHelper.SavePlaylists();
            Settings.Default.Save();
        }

        public static void UnInit()
        {
            Core.UnInit();
            SaveDataFile();
        }

        public static string GetString(string id, params object?[] args)
        {
            if (MiscUtils.IsDesignMode())
                return id;
            if (args.Length == 0)
            {
                try
                {
                    return Program.languageResourceManager.GetString(id) ?? $"[!{id}:{Thread.CurrentThread.CurrentUICulture.Name}!]";
                }
                catch
                {
#if DEBUG
                    return $"[!{id}:{Thread.CurrentThread.CurrentUICulture.Name}!]";
#else
                    return Program.languageResourceManager.GetString(id, Program.defaultCultureInfo) ?? $"[!{id}:{Program.defaultCultureInfo.Name}!]";
#endif
                }
            }
            else
            {
                try
                {
                    string str = Program.languageResourceManager.GetString(id) ?? $"[!{id}:{Thread.CurrentThread.CurrentUICulture.Name}!]";
                    return string.Format(str, args);
                }
                catch
                {
#if DEBUG
                    return $"[!{id}:{Thread.CurrentThread.CurrentUICulture.Name}!]";
#else
                    return Program.languageResourceManager.GetString(id, Program.defaultCultureInfo) ?? $"[!{id}:{Program.defaultCultureInfo.Name}!]";
#endif
                }
            }
        }

        public static bool SetARepeatPoint()
        {
            aRepeatPos = Core.GetPositionMillisecond();
            abRepeatMode = ABRepeatMode.ASelected;
            return true;
        }

        public static bool SetBRepeatPoint()
        {
            if (abRepeatMode != ABRepeatMode.None)
            {
                long timeSpan = Core.GetPositionMillisecond() - aRepeatPos;
                if (timeSpan > 200 && timeSpan < Core.GetLengthMillisecond())
                {
                    bRepeatPos = Core.GetPositionMillisecond();
                    abRepeatMode = ABRepeatMode.ABRepeat;
                    return true;
                }
            }
            return false;
        }

        public static bool ContinueABRepeat()
        {
            if(abRepeatMode == ABRepeatMode.ABRepeat)
            {
                if(Core.GetPositionMillisecond() > bRepeatPos || Core.GetPositionMillisecond() < aRepeatPos - 2000)
                    Core.SetPositionMillisecond(aRepeatPos);
                return true;
            }
            return false;
        }

        public static void DoABRepeat()
        {
            switch (abRepeatMode)
            {
                case ABRepeatMode.None:
                    SetARepeatPoint();
                    break;
                case ABRepeatMode.ASelected:
                    if (!SetBRepeatPoint())
                        ResetABRepeat();
                    break;
                case ABRepeatMode.ABRepeat:
                    ResetABRepeat();
                    break;
                default:
                    break;
            }
        }

        public static void ResetABRepeat()
        {
            abRepeatMode = ABRepeatMode.None;
        }

        public static Color GetThemeColor()
        {
            return Settings.Default.ThemeColorFollowingSystem ? MiscUtils.GetSystemThemeColor() : Settings.Default.ThemeColor;
        }

        public static void SetDataFilePath(DataFilePath dataFilePath)
        {
            using FileStream fs = new FileStream(Path.Combine(MiscUtils.GetProgramExecuableFilePath(), "DataFileSavePath.dat"), FileMode.Create, FileAccess.Write);
            if (dataFilePath == DataFilePath.LocalAppData)
                fs.WriteByte(0x0);
            else
                fs.WriteByte(0x1);
        }

        public static string GetExactDataFilePath()
        {
            try
            {
                if (DataFilePath == DataFilePath.LocalAppData)
                {
                    string path = MiscUtils.GetProgramLocalAppDataPath();
                    if (!Path.Exists(path))
                        Directory.CreateDirectory(path);
                    return MiscUtils.GetProgramLocalAppDataPath();
                }
                else
                {
                    string path = Path.Combine(MiscUtils.GetProgramExecuableFilePath(), "DataFile");
                    if (!Path.Exists(path))
                        Directory.CreateDirectory(path);
                    return path;
                }
            }
            catch
            {
                DataFilePath = DataFilePath.LocalAppData;
                return MiscUtils.GetProgramLocalAppDataPath();
            }
        }

        public static DataFilePath GetDataFilePath()
        {
            return DataFilePath;
        }
    }
}